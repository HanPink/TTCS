using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TimDuongDiNganNhat
{
    public partial class Form1 : Form
    {
        public Form1() //Khởi tạo các đối tượng trong form.
        {
            InitializeComponent();
        }

        private void thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Dijkstra td; //Khai báo biến tìm đường đi.

        private void thucong_Click(object sender, EventArgs e)
        {
            Nhapmatran td = new Nhapmatran();
            button4.Enabled = true;
            td.ShowDialog();
        }
        

        string ChuyenDoi(int so) //Nếu số đưa vào là -1 thì chuyển thành hiển thị là "∞".
        {
            if (so == -1) return "∞";
            return so.ToString();
        }

        void LoadDuLieuLenListView() //Load ma trận trọng số lên listview.
        {
            lvDanhSachDiem.Clear();
            for (int i = 0; i < td.duLieu.GetLength(0); i++) this.lvDanhSachDiem.Columns.Add((i + 1).ToString());
            for (int i = 0; i < td.duLieu.GetLength(0); i++)
            {
                ListViewItem lvit = new ListViewItem(ChuyenDoi(td.duLieu[i, 0]));
                for (int j = 1; j < td.duLieu.GetLength(1); j++) lvit.SubItems.Add(new ListViewItem.ListViewSubItem().Text = ChuyenDoi(td.duLieu[i, j]));
                lvDanhSachDiem.Items.Add(lvit);
            }

            //440
            int witdh = (440 / this.lvDanhSachDiem.Columns.Count) - 1;
            for (int i = 0; i < this.lvDanhSachDiem.Columns.Count; i++) this.lvDanhSachDiem.Columns[i].Width = witdh;
        }

        void LoadDuLieuLenComboBox() //Load danh sách đỉnh vào combobox.
        {
            if (this.td != null)
            {
                this.cbbDiemCuoi.Items.Clear();
                this.cbbDiemCuoi.Items.Add("Cuối");
                this.cbbDiemDau.Items.Clear();
                this.cbbDiemDau.Items.Add("Đầu");

                this.cbbDiemCuoi.SelectedItem = "Cuối";
                this.cbbDiemDau.SelectedItem = "Đầu";

                for (int i = 0; i < td.duLieu.GetLength(0); i++)
                {
                    this.cbbDiemDau.Items.Add((i + 1).ToString());
                    this.cbbDiemCuoi.Items.Add((i + 1).ToString());
                }
            }
        }

        private void readfile_Click(object sender, EventArgs e) //Bắt sự kiện người dùng ấn vào nút mở file, và cho người dùng chọn file dữ liệu muốn mở.
        {
            rtbLog.Text = "";
            try
            {
                openFileDialog1.Filter = "Tập tin đồ thị | *.txt";
                openFileDialog1.ShowDialog();
                td = new Dijkstra(openFileDialog1.FileName);
                LoadDuLieuLenListView();
                LoadDuLieuLenComboBox();
            }
            catch
            {
                MessageBox.Show("Lỗi Dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lvDanhSachDiem.Clear();

                cbbDiemCuoi.Items.Clear();

                cbbDiemDau.Items.Clear();

                rtbLog.Text = "";
                td = null;
                return;
            }
        }

        private void btTinhDuongDi_Click(object sender, EventArgs e) //Bắt sự kiên người dùng ấn vào nút Tính đường đi và tính toán đường đi dựa vào hai điểm người dùng muốn tính.
        {
            if (td == null) return;

            int dau;
            int cuoi;

            try
            {
                dau = Convert.ToInt32(cbbDiemDau.SelectedItem);
                cuoi = Convert.ToInt32(cbbDiemCuoi.SelectedItem);
            }
            catch
            {
                MessageBox.Show("Mời chọn điểm đầu và điểm cuối", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<int> kqs = td.TimDuong(dau, cuoi);
            string kq = "";
            if (kqs.Count == 0 && dau != cuoi)
            {
                kq = "Không tồn tại đường đi từ " + dau.ToString() + " tới " + cuoi.ToString();
            }
            else
            {
                int quangDuong = td.TinhDuong(kqs);

                kq = "Quãng đường đi từ " + dau.ToString() + " tới " + cuoi.ToString() + " là: " + quangDuong.ToString();
                kq += "\nĐường đi:";
                for (int i = 0; i < kqs.Count; i++)
                {
                    kq += (kqs[i] + 1).ToString();
                    if (i != kqs.Count - 1) kq += " ----> ";
                }
            }

            rtbLog.Text = kq;
            //pb.Image = td.Paint();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Kết quả |*.txt";
                saveFileDialog1.ShowDialog();
                StreamWriter ghi = new StreamWriter(saveFileDialog1.FileName);
                ghi.WriteLine(rtbLog.Text);
                ghi.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
