using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static AppShedule.SheduleRoom;

namespace AppShedule
{
    /// <summary>
    /// Interaction logic for Fimport.xaml
    /// </summary>
    public partial class Fimport : Window
    {
        public Fimport()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(f_Closing);
            txtPartShow.Text = "";
        }
        void f_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.DialogResult = true;
            e.Cancel = false;
        }
        List<SheduleRoom> List_SheduleRoom;
        int importTrue = 0, importFalse = 0;
        string str_load_file = "";
        private void btLoadFile_Click(object sender, RoutedEventArgs e)
        {
            importTrue = importFalse = 0;
            List_SheduleRoom = new List<SheduleRoom>();

            OpenFileDialog openfile = new OpenFileDialog(); // tạo dialog
            openfile.Filter = "Excel | *.xlsx| Excel 2003 | *.xls"; // lọc file
            openfile.InitialDirectory = @"E:\DuLieuChung\Desktop\aa"; // đến thư mục nào đó
            if (openfile.ShowDialog() == true)
            {
                string path = openfile.FileName; //MessageBox.Show(path); return;
                txtPartShow.Text = path;

                try
                {
                    var package = new ExcelPackage(new FileInfo(path));  // mở file excel
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[1];  // lấy ra sheet đầu tiên để thao tác
                    #region tòa nhà, phòng học
                    string str = workSheet.Cells[4, 1].Value.ToString();
                    string[] str_arr_input = str.Split(' ');
                    string[] str_arr_out = str_arr_input[5].Split('.');

                    string _tenToaNha = "", _tenPhongHoc = "";

                    if (str_arr_out.Length == 3)
                    {
                        _tenToaNha = "Toà nhà " + str_arr_out[0];
                        _tenPhongHoc = "Phòng " + str_arr_out[1] + "." + str_arr_out[2];
                    }
                    if (str_arr_out.Length == 4)
                    {
                        _tenToaNha = "Toà nhà " + str_arr_out[0];
                        _tenPhongHoc = "Phòng " + str_arr_out[1] + "." + str_arr_out[2] + "." + str_arr_out[3];
                    }
                    #endregion

                    string temp_thu_ngay_null = "";
                    for (int i = 9; i <= workSheet.Dimension.End.Row; i++)
                    {

                        // tạo RoomInfo mới           
                        SheduleRoom sheduleRoom_infor = new SheduleRoom();
                        sheduleRoom_infor.TenToaNha = _tenToaNha;
                        sheduleRoom_infor.TenPhong = _tenPhongHoc;

                        int j = 1; // biến j biểu thị cho một column trong file

                        // lấy dữ liệu bắt đầu từ hàng số 08
                        var ten_thu_input_excel = workSheet.Cells[i, j++].Value;
                        var _Buoi = workSheet.Cells[i, j++].Value;
                        var _LoaiDung = workSheet.Cells[i, j++].Value;
                        var _LopHocKhoa = workSheet.Cells[i, j++].Value;
                        var _MonHoc = workSheet.Cells[i, j++].Value;
                        var _GiangVien = workSheet.Cells[i, j++].Value;
                        var _Tiet = workSheet.Cells[i, j++].Value;
                        var _LoaiLich = workSheet.Cells[i, j++].Value;

                        string ten_thu_input = "";
                        if (ten_thu_input_excel != null)
                        {
                            temp_thu_ngay_null = ten_thu_input = ten_thu_input_excel.ToString();
                        }
                        else if (ten_thu_input_excel == null) { ten_thu_input = temp_thu_ngay_null; }

                        // tách ngày thứ 
                        string[] str_arr_split = ten_thu_input.Split(new char[] { '\r', '\n' });
                        if (str_arr_split[0].ToString() != "Chủ nhật")
                        {
                            sheduleRoom_infor.Thu = "Thứ " + str_arr_split[0].ToString();
                        }
                        else
                        {
                            sheduleRoom_infor.Thu = str_arr_split[0].ToString();
                        }

                        sheduleRoom_infor.NgayThang = Convert.ToDateTime(str_arr_split[1].ToString());
                        sheduleRoom_infor.NgayThang_Show = str_arr_split[1].ToString();

                        sheduleRoom_infor.Buoi = "";
                        if (_Buoi != null)
                        {
                            sheduleRoom_infor.Buoi = _Buoi.ToString();
                        }

                        sheduleRoom_infor.LoaiDung = "Không có lịch";
                        if (_LoaiDung != null)
                        {
                            string[] _arr_loaidung = _LoaiDung.ToString().Trim().Split(new char[] { '\r', '\n' });
                            sheduleRoom_infor.LoaiDung = _arr_loaidung[0].Trim().ToString();
                        }

                        sheduleRoom_infor.LopHocKhoa = "Không có lịch";
                        if (_LopHocKhoa != null)
                        {
                            string[] _arr_lophoc_khoa = _LopHocKhoa.ToString().Trim().Split(new char[] { '\r', '\n' });
                            sheduleRoom_infor.LopHocKhoa = _arr_lophoc_khoa[0];
                        }

                        sheduleRoom_infor.MonHoc = "Không có lịch";
                        if (_MonHoc != null)
                        {
                            string[] _arr_mon_hoc = _MonHoc.ToString().Trim().Split(new char[] { '\r', '\n' });
                            sheduleRoom_infor.MonHoc = _arr_mon_hoc[0];
                        }

                        sheduleRoom_infor.GiangVien = "Chưa có tên CBGD";
                        if (sheduleRoom_infor.LoaiDung.ToString() == "Lịch thi")
                        {
                            sheduleRoom_infor.GiangVien = sheduleRoom_infor.LoaiDung.ToString();
                        }
                        else
                        {
                            if (_GiangVien != null)
                            {
                                string[] _arr_giangvien = _GiangVien.ToString().Trim().Split(new char[] { '\r', '\n' });
                                sheduleRoom_infor.GiangVien = _arr_giangvien[0];
                            }
                        }

                        sheduleRoom_infor.Tiet = "Trống tiết";
                        if (sheduleRoom_infor.LoaiDung.ToString() == "Không có lịch")
                        {
                            sheduleRoom_infor.Tiet = "0 - 0";
                        }
                        else
                        {
                            if (_Tiet != null)
                            {
                                string[] _arr_tiet = _Tiet.ToString().Trim().Split(new char[] { '\r', '\n' });
                                sheduleRoom_infor.Tiet = _arr_tiet[0];
                            }
                        }

                        sheduleRoom_infor.LoaiLich = "Trống lịch";
                        if (_LoaiLich != null)
                        {
                            string[] _arr_loai_lich = _LoaiLich.ToString().Trim().Split(new char[] { '\r', '\n' });
                            sheduleRoom_infor.LoaiLich = _arr_loai_lich[0];
                        }

                        List_SheduleRoom.Add(sheduleRoom_infor);
                    }

                }
                catch (Exception exe) { MessageBox.Show(exe.ToString()); }

                ListTestRealExcel.ItemsSource = List_SheduleRoom.ToList();
                MessageBox.Show("Có tất cả: " + List_SheduleRoom.Count.ToString() + " bản ghi.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                str_load_file = path;
            }
        }

        private void btImportDataAll_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn chắc chắn muốn thêm dữ liệu này?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Funcs_dbAppShedule f = new Funcs_dbAppShedule();
                foreach (SheduleRoom room in List_SheduleRoom)
                {
                    f.SheduleRoom_Insert(room);
                    importTrue++;
                }
            }
            MessageBox.Show("Thêm thành công.\nCó tổng số: " + importTrue.ToString() + " thêm vào CSDL", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        private void btImportCustom_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn chắc chắn muốn thêm dữ liệu này?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Funcs_dbAppShedule f = new Funcs_dbAppShedule();

                foreach (SheduleRoom room in List_SheduleRoom)
                {
                    if (room.LoaiDung != "Không có lịch" && room.LopHocKhoa != "Không có lịch" && room.MonHoc != "Không có lịch")
                    {
                        importTrue++;
                        if (f.SheduleRoom_Insert(room) == false)
                        {
                            MessageBox.Show("thông báo các lỗi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                    }
                }
                MessageBox.Show("Thêm thành công.\nCó tổng số: " + importTrue.ToString() + " thêm vào CSDL", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                //ListTestRealExcel.ItemsSource = f.SheduleRoom_GetAll().ToList();
            }
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
