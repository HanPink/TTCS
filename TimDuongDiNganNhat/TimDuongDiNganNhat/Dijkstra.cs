using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Data;

namespace TimDuongDiNganNhat
{
    class Dijkstra
    {
        public int[,] duLieu { get; private set; } //Lưu ma trận trọng số được đưa vào.
        List<bool> daXet { get; set; } //Lưu danh sách các điểm đã xét.
        List<DuongDi> listDuongDi { get; set; } //Lưu danh sách các con đường đang tìm.
        int diemDau { get; set; } //Lưu điểm xuất phát.
        int diemCuoi { get; set; } //Lưu điểm cần tới.

        private PointF[] dsve;
        private int[] Truoc;

        public PointF[] ViTriVe
        {
            get { return dsve; }
        }

        public Dijkstra(int[,] duLieu) //Hàm khởi tạo với giá trị truyền vào là một ma trận trọng số.
        {
            this.duLieu = duLieu;
            dsve = new PointF[duLieu.GetLength(0)];
            Truoc = new int[duLieu.GetLength(0)];
            Init();
        }
        public Dijkstra(string urlFile) //Hàm khởi tạo với giá trị truyền vào là một file chứa dữ liệu là ma trận trọng số
        {
            StreamReader file = new StreamReader(urlFile);
            string dls = file.ReadToEnd(); //đọc hết các giá trị trong file
            file.Close();
            
            string[] tach = dls.Split('\n');
            int[,] duLieu = new int[tach.Length, tach.Length];
            
            for (int i = 0; i < tach.Length; i++)
            {
                tach[i] = XoaKiTuLa(tach[i]);
                string[] tach2 = tach[i].Split(' ');
                if (tach2.Length != tach.Length)
                    return;
                else
                {
                    for (int j = 0; j < tach2.Length; j++)
                    {
                        try
                        {
                            duLieu[i, j] = Convert.ToInt32(tach2[j]);
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
            }

            this.duLieu = duLieu;
            dsve = new PointF[duLieu.GetLength(0)];
            Truoc = new int[duLieu.GetLength(0)];
            Init();
        }      
        void Init() //Hàm khởi tạo giá trị ban đầu cho các thuộc tính.
        {
            listDuongDi = new List<DuongDi>();
            daXet = new List<bool>();
            for (int i = 0; i < duLieu.GetLength(0); i++) daXet.Add(false);
            DanhDauVoCung();
        }
        public List<int> TimDuong(int diemDau, int diemCuoi) //Tìm đường đi giữa đi hai điểm truyền vào.
        {
            Init(); //Hàm khởi tạo giá trị ban đầu cho các thuộc tính.

            diemDau--;
            diemCuoi--;
            this.diemDau = diemDau;
            this.diemCuoi = diemCuoi;
            if (diemDau < 0 || diemDau > duLieu.GetLength(0) || diemCuoi < 0 || diemCuoi > duLieu.GetLength(0)) return null;

            List<int> duong = new List<int>();


            DuongDi dd = new DuongDi();
            dd.diemDaDi.Add(diemDau);

            this.listDuongDi.Add(dd);

            int dangXet = diemDau;
            daXet[diemDau] = true;

            while (!KetThuc(diemCuoi))
            {
                DuongDi timDuong = this.listDuongDi[0];
                int diemMoi = -1;

                foreach (DuongDi item in this.listDuongDi)
                {
                    int s = TimDuong(item);
                    if (s != -1)
                    {
                        if (diemMoi == -1)
                        {
                            diemMoi = s;
                            timDuong = item;
                        }
                        else
                        {
                            if (s < diemMoi)
                            {
                                diemMoi = s;
                                timDuong = item;
                            }
                        }
                    }
                }

                int soLuongThem = TimDiemKe(timDuong.diemDaDi[timDuong.diemDaDi.Count - 1]).Count;
                for (int i = 0; i < soLuongThem - 1; i++)
                { 
                    DuongDi ddn = new DuongDi();
                    foreach (int item in timDuong.diemDaDi) ddn.diemDaDi.Add(item);

                    this.listDuongDi.Add(ddn);
                }

                if (diemMoi != -1)
                {
                    timDuong.diemDaDi.Add(diemMoi);
                    daXet[diemMoi] = true;
                }


                if (diemMoi == diemCuoi) duong = timDuong.diemDaDi;
            }

            return duong;
        }
        bool KetThuc(int diemCuoi) //Kiểm tra xem có phải tất cả các con đường đã đi tới đường cụt hay không (isDie=true). Nếu tất cả đã tới đường cụt thì không tồn tại đường đi giữa hai điểm truyền vào hoặc đã tìm được đường đi giữa hai điểm.
        {
            bool kt = true;

            foreach (DuongDi item in listDuongDi)
            {
                if (!item.isDie)
                {
                    kt = false;
                }
            }

            foreach (DuongDi item in listDuongDi)
            {
                if (!item.isDie)
                {
                    if (item.diemDaDi[item.diemDaDi.Count - 1] == diemCuoi) return true;
                }
            }

            return kt;
        }
        int TimDuong(DuongDi dd) //Tìm điểm đi kế tiếp từ đỉnh cuối cùng của đường đi.
        {
            int le = dd.diemDaDi.Count;
            int diem = dd.diemDaDi[le - 1];
            List<int> list = TimDiemKe(diem);

            if (list.Count == 0)
            {
                dd.isDie = true;
                return -1;
            }

            int min = duLieu[diem, list[0]];
            int diemToi = list[0];
            foreach (int item in list) if (min >= duLieu[diem, item] && duLieu[diem, item] > 0)
                {
                    if (diem == this.diemCuoi && min > duLieu[diem, item]) continue;
                    min = duLieu[diem, item];
                    diemToi = item;
                }

            return diemToi;
        }
        List<int> TimDiemKe(int diem) //Tìm danh sách điểm kề từ một điểm.
        {
            List<int> listkq = new List<int>();

            for (int i = 0; i < duLieu.GetLength(0); i++)
            {
                if (diem != i && duLieu[diem, i] > 0 && !daXet[i]) listkq.Add(i);
            }

            return listkq;
        }
        void DanhDauVoCung() //Xử lý ma trận trọng số truyền vào chương trình. Nếu giữa hai điểm không tồn tại đường đi thì đánh dấu trong ma trận trọng số là -1.
        {
            if (duLieu == null) return;

            for (int i = 0; i < duLieu.GetLength(0); i++)
            {
                for (int j = 0; j < duLieu.GetLength(1); j++)
                    if (i != j && duLieu[i, j] <= 0) duLieu[i, j] = -1;
            }
        }
        string XoaKiTuLa(string duLieu) //Xử lý dữ liệu vào từ file. Loại bỏ toàn bộ các ký tự lạ (không phải là số, không phải là dấu cách, không phải là dấu xuống hàng).
        {
            string kq = "";
            for (int i = 0; i < duLieu.Length; i++)
            {
                if (KiemTraKyTu(duLieu[i])) kq += duLieu[i];
            }
            return kq;
        }
        bool KiemTraKyTu(char kyTu) //Kiểm tra xem ký tự có phải là số hay không.
        {
            switch (kyTu)
            {
                case '0':
                    return true;
                case '1':
                    return true;
                case '2':
                    return true;
                case '3':
                    return true;
                case '4':
                    return true;
                case '5':
                    return true;
                case '6':
                    return true;
                case '7':
                    return true;
                case '8':
                    return true;
                case '9':
                    return true;
                case ' ':
                    return true;
                default:
                    return false;
            }
        }
        public int TinhDuong(List<int> duongDi) //Tính khoảng cách giữa hai điểm nhờ con đường được truyền vào.
        {
            if (duLieu != null)
            {
                if (duongDi.Count == 0)
                {
                    return 0;
                }
                else
                {
                    int quangDuong = 0;

                    for (int i = 0; i < duongDi.Count - 1; i++)
                    {
                        quangDuong += duLieu[duongDi[i], duongDi[i + 1]];
                    }

                    return quangDuong;
                }
            }
            return 0;
        }

        #region Display
        public Bitmap Paint()
        {
            Bitmap kq = new Bitmap(900, 450);
            int top = duLieu.GetLength(0) / 2;
            if (duLieu.GetLength(0) == 1)
            {
                top = duLieu.GetLength(0);
            }


            int vtbd = 900 / (top * 2);
            for (int i = 1; i <= top; i++)
            {
                if (i % 2 != 0)
                {
                    kq = DrawNode(i.ToString(), vtbd + (i - 1) * 900 / (top), 20, kq, Color.Red);
                    dsve[i - 1] = new PointF(vtbd + (i - 1) * 900 / (float)((top)), 20);
                }
                else
                {
                    kq = DrawNode(i.ToString(), vtbd + (i - 1) * 900 / (top), 100, kq, Color.Red);
                    dsve[i - 1] = new PointF(vtbd + (i - 1) * 900 / (float)((top)), 100);
                }

            }

            int khoangcach = duLieu.GetLength(0) - top;

            for (int i = 1; i <= duLieu.GetLength(0) - top; i++)
            {
                if (i % 2 != 0)
                {
                    kq = DrawNode((i + top).ToString(), (i - 1) * 900 / (khoangcach), 300, kq, Color.Red);
                    dsve[i - 1 + top] = new PointF((i - 1) * 900 / (float)((khoangcach)), 300);
                }
                else
                {
                    kq = DrawNode((i + top).ToString(), (i - 1) * 900 / (khoangcach), 380, kq, Color.Red);
                    dsve[i - 1 + top] = new PointF((i - 1) * 900 / (float)((khoangcach)), 380);
                }

            }

            kq = Line(kq);
            return kq;
        }


        public Bitmap DuongDiPic(int bd, int kt, Image anh, Dijkstra td)
        {
            Bitmap a = new Bitmap(anh);
            List<int> kqs = td.TimDuong(bd, kt);
            for (int j = 0; j < kqs.Count; j++)
            {
                a = LineTo(dsve[j+1], dsve[Truoc[j+1]], a, duLieu[j+1, Truoc[j+1]], Color.Red);
                int i = Truoc[j+1];
                while (i != j)
                {
                    a = LineTo(dsve[i], new PointF(dsve[Truoc[i]].X, dsve[Truoc[i]].Y), a, duLieu[i, Truoc[i]], Color.Red);
                    i = Truoc[i];
                }
            }
            
            return a;
        }
        public Bitmap Line(Bitmap a)
        {

            for (int i = 1; i <= duLieu.GetLength(0); i++)
            {
                for (int j = 1; j <= duLieu.GetLength(0); j++)
                {
                    if (duLieu[i - 1, j - 1] > 0)
                    {
                        a = LineTo(dsve[i - 1], dsve[j - 1], a, duLieu[i - 1, j - 1], Color.Green);

                    }
                }
            }


            return a;
        }

        public Bitmap LineTo(PointF p1, PointF p2, Image ima, int k, Color mau)
        {
            Bitmap kq;

            if (ima != null)
            {
                kq = new Bitmap(ima);
            }
            else
            {
                kq = new Bitmap(900, 400);
            }


            System.Drawing.Graphics graphicsObj;



            graphicsObj = Graphics.FromImage(kq);

            Pen myPen = new Pen(mau, 4);



            graphicsObj.DrawLine(myPen, p1, p2);

            Brush myBrush = new SolidBrush(Color.Black);
            Font myFont = new System.Drawing.Font("Verdana", 14, FontStyle.Regular);
            graphicsObj.DrawString(k.ToString(), myFont, myBrush, new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2 - 20));


            return kq;
        }

        public Bitmap DrawNode(string st, float x, float y, Image ima, Color cl)
        {


            Bitmap kq;

            if (ima != null)
            {
                kq = new Bitmap(ima);
            }
            else
            {
                kq = new Bitmap(992, 438);
            }


            System.Drawing.Graphics graphicsObj;



            graphicsObj = Graphics.FromImage(kq);

            Pen myPen = new Pen(Color.Green, 2);


            Font myFont = new System.Drawing.Font("Verdana", 17, FontStyle.Regular);

            Brush myBrush = new SolidBrush(cl);

            graphicsObj.DrawString(st, myFont, myBrush, x + 5, y - 6);


            return kq;

        }
        #endregion
    }


    public class DuongDi
    {
        public List<int> diemDaDi { get; private set; } //Lưu trữ các điểm đã đi qua.

        public bool isDie { get; set; } //Xem con đường này đã đi vào đường cụt hay chưa.

        public DuongDi() //Hàm khởi tạo của class.
        {
            diemDaDi = new List<int>();
            this.isDie = false;

        }

        public bool ThemDiem(int diem) //Thêm một điểm vào cuối con đường.
        {
            foreach (int item in this.diemDaDi) if (item == diem) return false;
            this.diemDaDi.Add(diem);
            return true;
        }
    }

}

