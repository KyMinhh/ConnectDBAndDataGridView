using DataGridViewAndConnectDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewAndConnectDB
{
    public partial class frmStudentMannagement : Form
    {
        public frmStudentMannagement()
        {
            InitializeComponent();
        }

        private void frmStudentMannagement_Load(object sender, EventArgs e)
        {
            try
            {
                StudentDBContext context = new StudentDBContext();
                List<Faculty> faculties = context.Faculties.ToList();
                List<Student> students = context.Students.ToList();
                FillFacultyCombobox(faculties);
                BindGrid(students); 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }

        }

        private void FillFacultyCombobox(List<Faculty> faculties)
        {
            this.cmbFaculty.DataSource = faculties;
            this.cmbFaculty.DisplayMember ="FaculltyName";
            this.cmbFaculty.ValueMember = "FacultyId";
        }

        private void BindGrid(List<Student> students)
        {
            dgvSinhVienn.Rows.Clear();
            foreach (var item in students)
            {
                int index = dgvSinhVienn.Rows.Add();
                dgvSinhVienn.Rows[index].Cells[0].Value = item.StudentID;
                dgvSinhVienn.Rows[index].Cells[1].Value = item.FullName;
                dgvSinhVienn.Rows[index].Cells[2].Value = item.Faculty.FaculltyName;
                dgvSinhVienn.Rows[index].Cells[3].Value = item.AverageScore;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string studentID = txtMSSV.Text;

            if (string.IsNullOrEmpty(studentID))
            {
                MessageBox.Show("Vui lòng nhập mã số sinh viên!");
                return;
            }

            using (StudentDBContext context = new StudentDBContext())
            {
                var student = context.Students.FirstOrDefault(s => s.StudentID == studentID);

                if (student == null)
                {
                    MessageBox.Show("Không tìm thấy MSSV cần xóa!");
                    return;
                }

                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                    MessageBox.Show("Xóa sinh viên thành công!");
                }
            }

            // Reset dữ liệu form và load lại DataGridView
            ResetForm();
            LoadData();
        }
        private void LoadData()
        {
            using (StudentDBContext context = new StudentDBContext())
            {
                // Load students with their faculties
                List<Student> students = context.Students.Include("Faculty").ToList();
                BindGrid(students);
            }
        }

        private void ResetForm()
        {
            txtMSSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();
            cmbFaculty.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Lấy thông tin sinh viên từ form
            string studentID = txtMSSV.Text;
            string fullName = txtHoTen.Text;
            string facultyID = cmbFaculty.SelectedValue.ToString();
            double averageScore;

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(fullName) || !double.TryParse(txtDiemTB.Text, out averageScore))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Kiểm tra độ dài của mã số sinh viên
            if (studentID.Length != 10)
            {
                MessageBox.Show("Mã số sinh viên phải có 10 kí tự!");
                return;
            }

            using (StudentDBContext context = new StudentDBContext())
            {
                // Kiểm tra nếu MSSV đã tồn tại
                var existingStudent = context.Students.FirstOrDefault(s => s.StudentID == studentID);
                if (existingStudent != null)
                {
                    MessageBox.Show("Mã số sinh viên đã tồn tại. Không thể thêm mới!");
                    return;
                }

                // Thêm mới sinh viên
                var newStudent = new Student
                {
                    StudentID = studentID,
                    FullName = fullName,
                    FacultyID = int.Parse(facultyID),
                    AverageScore = averageScore
                };
                context.Students.Add(newStudent);
                context.SaveChanges();
                MessageBox.Show("Thêm mới dữ liệu thành công!");
            }

            // Reset dữ liệu form và load lại DataGridView
            ResetForm();
            LoadData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy thông tin sinh viên từ form
            string studentID = txtMSSV.Text;
            string fullName = txtHoTen.Text;
            string facultyID = cmbFaculty.SelectedValue.ToString();
            double averageScore;

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(studentID) || string.IsNullOrEmpty(fullName) || !double.TryParse(txtDiemTB.Text, out averageScore))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Kiểm tra độ dài của mã số sinh viên
            if (studentID.Length != 10)
            {
                MessageBox.Show("Mã số sinh viên phải có 10 kí tự!");
                return;
            }

            using (StudentDBContext context = new StudentDBContext())
            {
                // Tìm sinh viên với MSSV
                var existingStudent = context.Students.FirstOrDefault(s => s.StudentID == studentID);

                if (existingStudent == null)
                {
                    MessageBox.Show("Không tìm thấy MSSV cần sửa!");
                    return;
                }

                // Cập nhật thông tin sinh viên
                existingStudent.FullName = fullName;
                existingStudent.FacultyID = int.Parse(facultyID);
                existingStudent.AverageScore = averageScore;
                context.SaveChanges();
                MessageBox.Show("Cập nhật dữ liệu thành công!");
            }

            // Reset dữ liệu form và load lại DataGridView
            ResetForm();
            LoadData();
        }

        private void dgvSinhVienn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu một dòng hợp lệ được chọn
            {
                DataGridViewRow row = dgvSinhVienn.Rows[e.RowIndex];

                // Kiểm tra và gán giá trị của các ô với xử lý null
                txtMSSV.Text = row.Cells[0].Value != null ? row.Cells[0].Value.ToString() : string.Empty;
                txtHoTen.Text = row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : string.Empty;
                cmbFaculty.Text = row.Cells[2].Value != null ? row.Cells[2].Value.ToString() : string.Empty;
                txtDiemTB.Text = row.Cells[3].Value != null ? row.Cells[3].Value.ToString() : string.Empty;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắ muốn thoát", "Thông báo",  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
