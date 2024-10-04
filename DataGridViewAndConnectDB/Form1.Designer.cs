namespace DataGridViewAndConnectDB
{
    partial class frmStudentMannagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblQLTTSVV = new System.Windows.Forms.Label();
            this.grbThongTinSinhVien = new System.Windows.Forms.GroupBox();
            this.cmbFaculty = new System.Windows.Forms.ComboBox();
            this.dgvSinhVienn = new System.Windows.Forms.DataGridView();
            this.colMSSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiemTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMSSV = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblMSSV = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.lblDiemTB = new System.Windows.Forms.Label();
            this.txtDiemTB = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.grbThongTinSinhVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienn)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQLTTSVV
            // 
            this.lblQLTTSVV.AutoSize = true;
            this.lblQLTTSVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQLTTSVV.ForeColor = System.Drawing.Color.Red;
            this.lblQLTTSVV.Location = new System.Drawing.Point(206, 33);
            this.lblQLTTSVV.Name = "lblQLTTSVV";
            this.lblQLTTSVV.Size = new System.Drawing.Size(413, 32);
            this.lblQLTTSVV.TabIndex = 0;
            this.lblQLTTSVV.Text = "Quản Lý Thông Tin Sinh Viên";
            // 
            // grbThongTinSinhVien
            // 
            this.grbThongTinSinhVien.Controls.Add(this.txtDiemTB);
            this.grbThongTinSinhVien.Controls.Add(this.lblDiemTB);
            this.grbThongTinSinhVien.Controls.Add(this.lblKhoa);
            this.grbThongTinSinhVien.Controls.Add(this.lblHoTen);
            this.grbThongTinSinhVien.Controls.Add(this.txtHoTen);
            this.grbThongTinSinhVien.Controls.Add(this.txtMSSV);
            this.grbThongTinSinhVien.Controls.Add(this.lblMSSV);
            this.grbThongTinSinhVien.Controls.Add(this.cmbFaculty);
            this.grbThongTinSinhVien.Location = new System.Drawing.Point(38, 101);
            this.grbThongTinSinhVien.Name = "grbThongTinSinhVien";
            this.grbThongTinSinhVien.Size = new System.Drawing.Size(349, 280);
            this.grbThongTinSinhVien.TabIndex = 1;
            this.grbThongTinSinhVien.TabStop = false;
            this.grbThongTinSinhVien.Text = "Thông tin sinh viên";
            // 
            // cmbFaculty
            // 
            this.cmbFaculty.FormattingEnabled = true;
            this.cmbFaculty.Location = new System.Drawing.Point(132, 154);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(186, 28);
            this.cmbFaculty.TabIndex = 0;
            // 
            // dgvSinhVienn
            // 
            this.dgvSinhVienn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSinhVienn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVienn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMSSV,
            this.colHoTen,
            this.colTenKhoa,
            this.colDiemTB});
            this.dgvSinhVienn.Location = new System.Drawing.Point(418, 101);
            this.dgvSinhVienn.Name = "dgvSinhVienn";
            this.dgvSinhVienn.RowHeadersWidth = 62;
            this.dgvSinhVienn.RowTemplate.Height = 28;
            this.dgvSinhVienn.Size = new System.Drawing.Size(752, 453);
            this.dgvSinhVienn.TabIndex = 2;
            this.dgvSinhVienn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSinhVienn_CellClick);
            // 
            // colMSSV
            // 
            this.colMSSV.HeaderText = "Mã Số SV";
            this.colMSSV.MinimumWidth = 8;
            this.colMSSV.Name = "colMSSV";
            // 
            // colHoTen
            // 
            this.colHoTen.HeaderText = "Họ Tên";
            this.colHoTen.MinimumWidth = 8;
            this.colHoTen.Name = "colHoTen";
            // 
            // colTenKhoa
            // 
            this.colTenKhoa.HeaderText = "Tên Khoa";
            this.colTenKhoa.MinimumWidth = 8;
            this.colTenKhoa.Name = "colTenKhoa";
            // 
            // colDiemTB
            // 
            this.colDiemTB.HeaderText = "Điểm TB";
            this.colDiemTB.MinimumWidth = 8;
            this.colDiemTB.Name = "colDiemTB";
            // 
            // txtMSSV
            // 
            this.txtMSSV.Location = new System.Drawing.Point(132, 36);
            this.txtMSSV.Name = "txtMSSV";
            this.txtMSSV.Size = new System.Drawing.Size(186, 26);
            this.txtMSSV.TabIndex = 2;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(132, 99);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(186, 26);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblMSSV
            // 
            this.lblMSSV.Location = new System.Drawing.Point(21, 36);
            this.lblMSSV.Name = "lblMSSV";
            this.lblMSSV.Size = new System.Drawing.Size(90, 23);
            this.lblMSSV.TabIndex = 1;
            this.lblMSSV.Text = "Mã Số SV";
            // 
            // lblHoTen
            // 
            this.lblHoTen.Location = new System.Drawing.Point(21, 99);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(90, 23);
            this.lblHoTen.TabIndex = 4;
            this.lblHoTen.Text = "Họ Tên";
            // 
            // lblKhoa
            // 
            this.lblKhoa.Location = new System.Drawing.Point(21, 154);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(90, 23);
            this.lblKhoa.TabIndex = 6;
            this.lblKhoa.Text = "Họ Tên";
            // 
            // lblDiemTB
            // 
            this.lblDiemTB.AutoSize = true;
            this.lblDiemTB.Location = new System.Drawing.Point(21, 224);
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(70, 20);
            this.lblDiemTB.TabIndex = 7;
            this.lblDiemTB.Text = "Điểm TB";
            // 
            // txtDiemTB
            // 
            this.txtDiemTB.Location = new System.Drawing.Point(132, 224);
            this.txtDiemTB.Name = "txtDiemTB";
            this.txtDiemTB.Size = new System.Drawing.Size(186, 26);
            this.txtDiemTB.TabIndex = 8;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(74, 387);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 37);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(312, 387);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 37);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(195, 387);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 37);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(1075, 570);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 37);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmStudentMannagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 631);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvSinhVienn);
            this.Controls.Add(this.grbThongTinSinhVien);
            this.Controls.Add(this.lblQLTTSVV);
            this.Name = "frmStudentMannagement";
            this.Text = "Quản lý thông tin sinh viên";
            this.Load += new System.EventHandler(this.frmStudentMannagement_Load);
            this.grbThongTinSinhVien.ResumeLayout(false);
            this.grbThongTinSinhVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVienn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQLTTSVV;
        private System.Windows.Forms.GroupBox grbThongTinSinhVien;
        private System.Windows.Forms.DataGridView dgvSinhVienn;
        private System.Windows.Forms.ComboBox cmbFaculty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiemTB;
        private System.Windows.Forms.TextBox txtDiemTB;
        private System.Windows.Forms.Label lblDiemTB;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMSSV;
        private System.Windows.Forms.Label lblMSSV;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThoat;
    }
}

