
namespace TimDuongDiNganNhat
{
    partial class Form1
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
            this.readfile = new System.Windows.Forms.Button();
            this.thucong = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvDanhSachDiem = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btTinhDuongDi = new System.Windows.Forms.Button();
            this.cbbDiemCuoi = new System.Windows.Forms.ComboBox();
            this.cbbDiemDau = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.pb = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // readfile
            // 
            this.readfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readfile.Location = new System.Drawing.Point(20, 10);
            this.readfile.Name = "readfile";
            this.readfile.Size = new System.Drawing.Size(200, 50);
            this.readfile.TabIndex = 0;
            this.readfile.Text = "Lấy DL từ file";
            this.readfile.UseVisualStyleBackColor = true;
            this.readfile.Click += new System.EventHandler(this.readfile_Click);
            // 
            // thucong
            // 
            this.thucong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thucong.Location = new System.Drawing.Point(230, 10);
            this.thucong.Name = "thucong";
            this.thucong.Size = new System.Drawing.Size(250, 50);
            this.thucong.TabIndex = 1;
            this.thucong.Text = "Nhập DL thủ công";
            this.thucong.UseVisualStyleBackColor = true;
            this.thucong.Click += new System.EventHandler(this.thucong_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(490, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 50);
            this.button4.TabIndex = 2;
            this.button4.Text = "Cập nhật";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(650, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 50);
            this.button5.TabIndex = 3;
            this.button5.Text = "Thoát";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.thoat_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvDanhSachDiem);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 80);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(730, 400);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ma Trận Trọng Số";
            // 
            // lvDanhSachDiem
            // 
            this.lvDanhSachDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDanhSachDiem.GridLines = true;
            this.lvDanhSachDiem.HideSelection = false;
            this.lvDanhSachDiem.Location = new System.Drawing.Point(15, 35);
            this.lvDanhSachDiem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvDanhSachDiem.Name = "lvDanhSachDiem";
            this.lvDanhSachDiem.Size = new System.Drawing.Size(700, 350);
            this.lvDanhSachDiem.TabIndex = 6;
            this.lvDanhSachDiem.UseCompatibleStateImageBehavior = false;
            this.lvDanhSachDiem.View = System.Windows.Forms.View.Details;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btTinhDuongDi);
            this.groupBox2.Controls.Add(this.cbbDiemCuoi);
            this.groupBox2.Controls.Add(this.cbbDiemDau);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(900, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(560, 90);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tính Đường Đi";
            // 
            // btTinhDuongDi
            // 
            this.btTinhDuongDi.Location = new System.Drawing.Point(435, 35);
            this.btTinhDuongDi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btTinhDuongDi.Name = "btTinhDuongDi";
            this.btTinhDuongDi.Size = new System.Drawing.Size(112, 35);
            this.btTinhDuongDi.TabIndex = 12;
            this.btTinhDuongDi.Text = "Tính";
            this.btTinhDuongDi.UseVisualStyleBackColor = true;
            this.btTinhDuongDi.Click += new System.EventHandler(this.btTinhDuongDi_Click);
            // 
            // cbbDiemCuoi
            // 
            this.cbbDiemCuoi.FormattingEnabled = true;
            this.cbbDiemCuoi.Location = new System.Drawing.Point(210, 35);
            this.cbbDiemCuoi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbDiemCuoi.Name = "cbbDiemCuoi";
            this.cbbDiemCuoi.Size = new System.Drawing.Size(180, 37);
            this.cbbDiemCuoi.TabIndex = 6;
            // 
            // cbbDiemDau
            // 
            this.cbbDiemDau.FormattingEnabled = true;
            this.cbbDiemDau.Location = new System.Drawing.Point(10, 35);
            this.cbbDiemDau.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbDiemDau.Name = "cbbDiemDau";
            this.cbbDiemDau.Size = new System.Drawing.Size(180, 37);
            this.cbbDiemDau.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtbLog);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(900, 120);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(560, 360);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log";
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(10, 35);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(540, 310);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // pb
            // 
            this.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb.Location = new System.Drawing.Point(20, 524);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(950, 450);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb.TabIndex = 15;
            this.pb.TabStop = false;
            //this.pb.Click += new System.EventHandler(this.pb_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1350, 490);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 40);
            this.button2.TabIndex = 45;
            this.button2.Text = "Xuất";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.thucong);
            this.Controls.Add(this.readfile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button readfile;
        private System.Windows.Forms.Button thucong;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        //private System.Windows.Forms.RichTextBox rtbLog;
        //private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvDanhSachDiem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btTinhDuongDi;
        private System.Windows.Forms.ComboBox cbbDiemCuoi;
        private System.Windows.Forms.ComboBox cbbDiemDau;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Button button2;
    }
}