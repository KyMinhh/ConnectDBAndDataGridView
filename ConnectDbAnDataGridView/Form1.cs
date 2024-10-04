using ConnectDbAnDataGridView.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace ConnectDbAnDataGridView
{
    public partial class frmQuanLySinhVien : Form
    {
        private StudentContextDB _context;
        private Student _selectedStudent; // To keep track of the selected student

        public frmQuanLySinhVien()
        {
            InitializeComponent();
            _context = new StudentContextDB(); // Initialize the DbContext here
        }

        private void frmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var context = new StudentContextDB())
                {
                    // Include Faculty so that FacultyName can be displayed in the DataGridView
                    var students = context.Students
                                          .Include(s => s.Faculty) // Eagerly load the related Faculty
                                          .ToList();

                    if (students != null && students.Any())
                    {
                        BindGrid(students); // Bind students to the grid
                    }
                    else
                    {
                        MessageBox.Show("Không có sinh viên nào được tìm thấy.");
                    }

                    var faculties = context.Faculties.ToList(); // Load faculties
                    if (faculties != null && faculties.Any())
                    {
                        FillFacultyComboBox(faculties); // Fill ComboBox with faculties
                    }
                    else
                    {
                        MessageBox.Show("Không có khoa nào được tìm thấy.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }


        private void FillFacultyComboBox(List<Faculty> listFaculties)
        {
            if (listFaculties == null || !listFaculties.Any())
            {
                MessageBox.Show("Không có khoa nào được tìm thấy.");
                return;
            }

            cmbFaculty.DataSource = listFaculties;
            cmbFaculty.DisplayMember = "FacultyName";
            cmbFaculty.ValueMember = "FacultyId";
        }


        private void BindGrid(List<Student> listStudent)
        {
            if (listStudent == null || listStudent.Count == 0)
            {
                MessageBox.Show("Không có sinh viên nào được tìm thấy.");
                return;
            }

            dgvStudent.AutoGenerateColumns = false;  // Disable auto-generation of columns
            dgvStudent.Columns.Clear(); // Clear any existing columns

            // Add StudentId column
            dgvStudent.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "StudentId",
                HeaderText = "Mã Sinh Viên",
                ReadOnly = true
            });

            // Add FullName column
            dgvStudent.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FullName",
                HeaderText = "Tên Sinh Viên"
            });

            // Add AverageScore column
            dgvStudent.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "AverageScore",
                HeaderText = "Điểm Trung Bình"
            });

            // Add FacultyName column
            dgvStudent.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Faculty.FacultyName",  // Display Faculty Name
                HeaderText = "Tên Khoa",
                ReadOnly = true
            });

            // Bind the list of students to the DataGridView
            dgvStudent.DataSource = listStudent;
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedStudent == null)
            {
                MessageBox.Show("Không tìm thấy MSSV cần xóa!");
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var context = new StudentContextDB()) // Make sure you use the correct context
                    {
                        // Reload the student entity from the context to make sure it's tracked
                        var studentToDelete = context.Students
                            .FirstOrDefault(s => s.StudentId == _selectedStudent.StudentId);

                        if (studentToDelete != null)
                        {
                            context.Students.Remove(studentToDelete); // Remove the entity
                            context.SaveChanges(); // Commit the changes to the database

                            MessageBox.Show("Xóa sinh viên thành công!");
                            LoadData(); // Reload the data
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên cần xóa!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi xóa sinh viên: {ex.Message}");
                }
            }
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            // Ensure _context is initialized
            if (_context == null)
            {
                _context = new StudentContextDB();
            }

            // Validate input fields and create newStudent object
            if (!ValidateStudentInput(out Student newStudent))
            {
                return; // If validation fails, stop the process
            }

            try
            {
                // Check if StudentId already exists in the database
                var existingStudent = _context.Students.FirstOrDefault(s => s.StudentId == newStudent.StudentId);
                if (existingStudent != null)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại!"); // StudentId already exists
                    return;
                }

                // Add new student to the context
                _context.Students.Add(newStudent);

                // Save changes to the database
                _context.SaveChanges();

                // Display success message
                MessageBox.Show("Thêm mới dữ liệu thành công!");

                // Reload data in the UI
                LoadData();

                // Reset input fields after successful addition
                ResetInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi thêm sinh viên: {ex.Message}");
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedStudent == null)
            {
                MessageBox.Show("Không tìm thấy MSSV cần sửa!");
                return;
            }

            if (!ValidateStudentInput(out Student updatedStudent))
                return;

            // Update the existing student's details
            _selectedStudent.FullName = updatedStudent.FullName;
            _selectedStudent.AverageScore = updatedStudent.AverageScore;
            _selectedStudent.FacultyId = updatedStudent.FacultyId;

            _context.SaveChanges();
            MessageBox.Show("Cập nhật dữ liệu thành công!");
            LoadData(); // Reload the data
            ResetInputFields();
        }

        private bool ValidateStudentInput(out Student student)
        {
            student = null;
            var studentId = txtMSSV.Text.Trim();
            var fullName = txtTen.Text.Trim();
            if (string.IsNullOrWhiteSpace(studentId) || string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(txtDiemTB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }

            if (studentId.Length != 10)
            {
                MessageBox.Show("Mã số sinh viên phải có 10 kí tự!");
                return false;
            }

            if (!double.TryParse(txtDiemTB.Text.Trim(), out double averageScore))
            {
                MessageBox.Show("Điểm Trung Bình không hợp lệ!");
                return false;
            }

            student = new Student
            {
                StudentId = studentId,
                FullName = fullName,
                AverageScore = averageScore,
                FacultyId = (int)cmbFaculty.SelectedValue // Cast the value to int
            };
            return true;
        }

        private void ResetInputFields()
        {
            txtMSSV.Clear();
            txtTen.Clear();
            txtDiemTB.Clear();
            cmbFaculty.SelectedIndex = -1;
            _selectedStudent = null;
        }

        private void dgvStudent_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count > 0)
            {
                var selectedRow = dgvStudent.SelectedRows[0];
                _selectedStudent = (Student)selectedRow.DataBoundItem;

                // Populate input fields with selected student details
                txtMSSV.Text = _selectedStudent.StudentId;
                txtTen.Text = _selectedStudent.FullName;
                txtDiemTB.Text = _selectedStudent.AverageScore.ToString();
                cmbFaculty.SelectedValue = _selectedStudent.FacultyId;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
