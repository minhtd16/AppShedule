using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Fmain.xaml
    /// </summary>
    public partial class Fmain : Window
    {

        public Fmain()
        {
            InitializeComponent();
            SetDate_DateStart_DateEnd();
            ListShow_Data_Fillter();
            //ListShow_Data_all();
            List_Data_ToaNha();
            List_Data_PhongHoc();
            List_Data_BuoiHoc();
            List_Data_LoaiDung();
            List_Data_MonHoc();
            List_Data_CBGiangDay();
        }
        private void List_Data_ToaNha()
        {
            List<string> arr_toa_nha = new List<string>();
            arr_toa_nha.Add("Chọn tòa nhà");

            Funcs_dbAppShedule f1 = new Funcs_dbAppShedule();
            List<SheduleRoom> List_SR_ToaNha = new List<SheduleRoom>();
            List_SR_ToaNha = f1.SheduleRoom_GetAll().ToList();

            var data_item_ten_toanha = List_SR_ToaNha.OrderBy(x => x.TenToaNha).Select(x => x.TenToaNha).Distinct().ToList();

            foreach (string item in data_item_ten_toanha)
            {
                arr_toa_nha.Add(item);
            }
            comboboxToaNha.DataContext = null;
            comboboxToaNha.DataContext = arr_toa_nha.ToList();
            comboboxToaNha.SelectedIndex = 0;
        }
        private void List_Data_PhongHoc()
        {
            List<string> _list_phonghoc = new List<string>();
            _list_phonghoc.Add("Chọn phòng");

            Funcs_dbAppShedule f2 = new Funcs_dbAppShedule();
            List<SheduleRoom> List_SR_PhongHoc = new List<SheduleRoom>();
            List_SR_PhongHoc = f2.SheduleRoom_GetAll().ToList();

            var data_item_ten_phonghoc = List_SR_PhongHoc.OrderBy(x => x.TenPhong).Select(x => x.TenPhong).Distinct().ToList();

            foreach (string item in data_item_ten_phonghoc)
            {
                _list_phonghoc.Add(item);
            }

            comboboxPhongHoc.DataContext = null;
            comboboxPhongHoc.DataContext = _list_phonghoc.ToList();
            comboboxPhongHoc.SelectedIndex = 0;
        }
        private void List_Data_BuoiHoc()
        {
            List<string> _list_buoihoc = new List<string>();
            _list_buoihoc.Add("Chọn buổi");

            Funcs_dbAppShedule f3 = new Funcs_dbAppShedule();
            List<SheduleRoom> List_SR_BuoiHoc = new List<SheduleRoom>();
            List_SR_BuoiHoc = f3.SheduleRoom_GetAll().ToList();

            var list_data_item_buoihoc = List_SR_BuoiHoc.OrderBy(x => x.Buoi).Select(x => x.Buoi).Distinct().ToList();
            foreach (string item in list_data_item_buoihoc)
            {
                _list_buoihoc.Add(item);
            }

            comboboxBuoiHoc.DataContext = null;
            comboboxBuoiHoc.DataContext = _list_buoihoc.ToList();
            comboboxBuoiHoc.SelectedIndex = 0;
        }
        private void List_Data_CBGiangDay()
        {
            List<string> _list_cbgd = new List<string>();
            _list_cbgd.Add("Chọn CBGD");

            Funcs_dbAppShedule f4 = new Funcs_dbAppShedule();
            List<SheduleRoom> List_SR_CBGiangDay = new List<SheduleRoom>();
            List_SR_CBGiangDay = f4.SheduleRoom_GetAll().ToList();

            var list_data_item_cbgd = List_SR_CBGiangDay.OrderBy(x => x.GiangVien).Select(x => x.GiangVien).Distinct().ToList();
            foreach (string item in list_data_item_cbgd)
            {
                _list_cbgd.Add(item);
            }
            comboboxCBGiangDay.DataContext = null;
            comboboxCBGiangDay.DataContext = _list_cbgd.ToList();
            comboboxCBGiangDay.SelectedIndex = 0;
        }
        private void List_Data_MonHoc()
        {
            List<string> _list_monhoc = new List<string>();
            _list_monhoc.Add("Chọn môn");

            Funcs_dbAppShedule f5 = new Funcs_dbAppShedule();
            List<SheduleRoom> List_SR_MonHoc = new List<SheduleRoom>();
            List_SR_MonHoc = f5.SheduleRoom_GetAll().ToList();

            var list_data_item_monhoc = List_SR_MonHoc.OrderBy(x => x.MonHoc).Select(x => x.MonHoc).Distinct().ToList();
            foreach (string item in list_data_item_monhoc)
            {
                _list_monhoc.Add(item);
            }

            comboboxMonHoc.DataContext = null;
            comboboxMonHoc.DataContext = _list_monhoc.ToList();
            comboboxMonHoc.SelectedIndex = 0;
        }
        private void List_Data_LoaiDung()
        {
            List<string> _list_loaidung = new List<string>();
            _list_loaidung.Add("Chọn loại");

            Funcs_dbAppShedule f6 = new Funcs_dbAppShedule();
            List<SheduleRoom> List_SR_LoaiDung = new List<SheduleRoom>();
            List_SR_LoaiDung = f6.SheduleRoom_GetAll().ToList();

            var list_data_item_loaidung = List_SR_LoaiDung.OrderBy(x => x.LoaiDung).Select(x => x.LoaiDung).Distinct().ToList();

            foreach (string item in list_data_item_loaidung)
            {
                _list_loaidung.Add(item);
            }

            comboboxLoaiDung.DataContext = null;
            comboboxLoaiDung.DataContext = _list_loaidung.ToList();
            comboboxLoaiDung.SelectedIndex = 0;
        }
        private void SetDate_DateStart_DateEnd()
        {
            Funcs_dbAppShedule fillter_Date = new Funcs_dbAppShedule();
            List<SheduleRoom> List_SR_PhongHoc = new List<SheduleRoom>();
            List_SR_PhongHoc = fillter_Date.SheduleRoom_GetAll().ToList();
            if (List_SR_PhongHoc.Count > 0)
            {
                var date_start = List_SR_PhongHoc.OrderBy(x => x.NgayThang).ToList().FirstOrDefault();

                if (date_start.NgayThang_Show.ToString().Trim() != string.Empty)
                {
                    txtDateStart.Text = date_start.NgayThang_Show.ToString();
                }

                var date_end = List_SR_PhongHoc.OrderByDescending(x => x.NgayThang).ToList().FirstOrDefault();
                if (date_end.NgayThang_Show.ToString().Trim() != string.Empty)
                {
                    txtDateEnd.Text = date_end.NgayThang_Show.ToString();
                }
            }
            else
            {
                txtDateStart.Text = txtDateEnd.Text = DateTime.Now.ToShortDateString();
            }
        }

        int index_toanha = -1, index_phonghoc = -1, index_buoi = -1, index_mon = -1, index_ldung = -1, index_gvien = -1;
        string str_tentoanha_select = "", str_tenphong_select = "", str_tenbuoihoc_select = "", str_tenmon_select = "",
                        str_ldung_select = "", str_tenCBGD_select = "";
        private void ListShow_Data_Fillter()
        {
            IList<SheduleRoom> List_SheduleRoom_Fillter = new List<SheduleRoom>();
            Funcs_dbAppShedule fillter = new Funcs_dbAppShedule();
            List_SheduleRoom_Fillter = fillter.SheduleRoom_GetAll();

            DateTime date_start = Convert.ToDateTime(txtDateStart.Text.ToString());
            DateTime date_End = Convert.ToDateTime(txtDateEnd.Text.ToString());

            List_SheduleRoom_Fillter = List_SheduleRoom_Fillter.Where(x => x.NgayThang >= date_start && x.NgayThang <= date_End)
                                                                .OrderBy(x => x.NgayThang).ThenByDescending(x => x.Buoi).ThenBy(x => x.TenPhong).ToList();

            index_toanha = comboboxToaNha.SelectedIndex;
            if (index_toanha > 0)
            {
                str_tentoanha_select = comboboxToaNha.Items.GetItemAt(index_toanha).ToString();
                List_SheduleRoom_Fillter = List_SheduleRoom_Fillter.Where(x => x.TenToaNha.ToUpper().Contains(str_tentoanha_select.ToUpper())).ToList();
            }
            index_phonghoc = comboboxPhongHoc.SelectedIndex;
            if (index_phonghoc > 0)
            {
                str_tenphong_select = comboboxPhongHoc.Items.GetItemAt(index_phonghoc).ToString();
                List_SheduleRoom_Fillter = List_SheduleRoom_Fillter.Where(x => x.TenPhong.ToUpper().Contains(str_tenphong_select.ToUpper())).ToList();
            }
            index_buoi = comboboxBuoiHoc.SelectedIndex;
            if (index_buoi > 0)
            {
                str_tenbuoihoc_select = comboboxBuoiHoc.Items.GetItemAt(index_buoi).ToString();
                List_SheduleRoom_Fillter = List_SheduleRoom_Fillter.Where(x => x.Buoi.ToUpper().Contains(str_tenbuoihoc_select.ToUpper())).ToList();
            }

            index_mon = comboboxMonHoc.SelectedIndex;
            if (index_mon > 0)
            {
                str_tenbuoihoc_select = comboboxMonHoc.Items.GetItemAt(index_mon).ToString();
                List_SheduleRoom_Fillter = List_SheduleRoom_Fillter.Where(x => x.MonHoc.ToUpper().Contains(str_tenbuoihoc_select.ToUpper())).ToList();
            }

            index_ldung = comboboxLoaiDung.SelectedIndex;
            if (index_ldung > 0)
            {
                str_ldung_select = comboboxLoaiDung.Items.GetItemAt(index_ldung).ToString();
                List_SheduleRoom_Fillter = List_SheduleRoom_Fillter.Where(x => x.LoaiDung.ToUpper().Contains(str_ldung_select.ToUpper())).ToList();
            }

            index_gvien = comboboxCBGiangDay.SelectedIndex;
            if (index_gvien > 0)
            {
                str_tenCBGD_select = comboboxCBGiangDay.Items.GetItemAt(index_gvien).ToString();
                List_SheduleRoom_Fillter = List_SheduleRoom_Fillter.Where(x => x.GiangVien.ToUpper().Contains(str_tenCBGD_select.ToUpper())).ToList();
            }

            List_SheduleRoom_Fillter = List_SheduleRoom_Fillter.OrderBy(x => x.NgayThang).ToList();

            checkboxToday.Content = "Today, " + List_SheduleRoom_Fillter.Count.ToString();

            ListShowInfor.DataContext = null;
            ListShowInfor.DataContext = List_SheduleRoom_Fillter.ToList();
        }
        private void btFilter_Click(object sender, RoutedEventArgs e)
        {
            ListShow_Data_Fillter();

        }
        private void btReload_Click(object sender, RoutedEventArgs e)
        {
            SetDate_DateStart_DateEnd();
            ListShow_Data_Fillter();
            List_Data_ToaNha();
            List_Data_PhongHoc();
            List_Data_BuoiHoc();
            List_Data_LoaiDung();
            List_Data_MonHoc();
            List_Data_CBGiangDay();
            checkboxToday.IsChecked = false;
        }
        private void checkboxToday_Click(object sender, RoutedEventArgs e)
        {
            if (checkboxToday.IsChecked == true)
            {
                string date_today = DateTime.Now.ToShortDateString();
                txtDateStart.Text = date_today;
                txtDateEnd.Text = date_today;
                ListShow_Data_Fillter();
                List_Data_ToaNha();
                List_Data_PhongHoc();
                List_Data_BuoiHoc();
                List_Data_LoaiDung();
                List_Data_MonHoc();
                List_Data_CBGiangDay();
            }
            else if (checkboxToday.IsChecked == false)
            {
                SetDate_DateStart_DateEnd();
                ListShow_Data_Fillter();
                List_Data_ToaNha();
                List_Data_PhongHoc();
                List_Data_BuoiHoc();
                List_Data_LoaiDung();
                List_Data_MonHoc();
                List_Data_CBGiangDay();
            }
        }
        private void comboboxToaNha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListShow_Data_Fillter();
        }

        private void comboboxPhongHoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListShow_Data_Fillter();
        }

        private void comboboxMonHoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListShow_Data_Fillter();
        }

        private void btDelAll_Click(object sender, RoutedEventArgs e)
        {
            Funcs_dbAppShedule f = new Funcs_dbAppShedule();

            MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn xóa toàn bộ dữ liệu không? ", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            int i = 0;
            if (rs == MessageBoxResult.OK)
            {
                var selectedItems = ListShowInfor.SelectedItems;

                foreach (SheduleRoom item in selectedItems)
                {
                    if (f.Appoint_Delete(item.ID) == true) { i++; }
                }
                MessageBox.Show("Đã xóa thành công " + i.ToString() + " bản ghi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                SetDate_DateStart_DateEnd();
                ListShow_Data_Fillter();
                List_Data_ToaNha();
                List_Data_PhongHoc();
                List_Data_BuoiHoc();
                List_Data_LoaiDung();
                List_Data_MonHoc();
                List_Data_CBGiangDay();

            }
        }

        private void comboboxLoaiDung_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListShow_Data_Fillter();
        }

        private void comboboxBuoiHoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListShow_Data_Fillter();
        }

        private void comboboxCBGiangDay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListShow_Data_Fillter();
        }

        private void btImport_Click(object sender, RoutedEventArgs e)
        {
            Fimport f = new Fimport();
            if (f.ShowDialog() == true)
            {
                SetDate_DateStart_DateEnd();
                ListShow_Data_Fillter();
                List_Data_ToaNha();
                List_Data_PhongHoc();
                List_Data_BuoiHoc();
                List_Data_CBGiangDay();
            }
        }


        #region Các sự kiện xuất dữ liệu
        private void btEXport_Click(object sender, RoutedEventArgs e)
        {
            string str_ex_tentoanha = comboboxToaNha.Items.GetItemAt(comboboxToaNha.SelectedIndex).ToString();
            string str_ex_phonghoc = comboboxPhongHoc.Items.GetItemAt(comboboxPhongHoc.SelectedIndex).ToString();
            string str_ex_buoihoc = comboboxBuoiHoc.Items.GetItemAt(comboboxBuoiHoc.SelectedIndex).ToString();
            string str_ex_tenmon = comboboxMonHoc.Items.GetItemAt(comboboxMonHoc.SelectedIndex).ToString();
            string str_ex_loaidung = comboboxLoaiDung.Items.GetItemAt(comboboxLoaiDung.SelectedIndex).ToString();
            string str_ex_tengv = comboboxCBGiangDay.Items.GetItemAt(comboboxCBGiangDay.SelectedIndex).ToString();

            DateTime str_ex_d_s;
            DateTime str_ex_s_e;
            try
            {
                str_ex_d_s = Convert.ToDateTime(txtDateStart.Text.ToString());
                str_ex_s_e = Convert.ToDateTime(txtDateEnd.Text.ToString());
            }
            catch
            {
                // thông báo lỗi, dừng chương trình
                return;
            }

            IList<SheduleRoom> List_SheduleRoom_Fillter_Export = new List<SheduleRoom>();
            Funcs_dbAppShedule f_ex = new Funcs_dbAppShedule();
            List_SheduleRoom_Fillter_Export = f_ex.SheduleRoom_GetAll();

            List_SheduleRoom_Fillter_Export = List_SheduleRoom_Fillter_Export.Where(x => x.NgayThang >= str_ex_d_s && x.NgayThang <= str_ex_s_e).OrderBy(x => x.NgayThang).ToList();

            if (str_ex_tentoanha != "Chọn tòa nhà")
            {
                List_SheduleRoom_Fillter_Export = List_SheduleRoom_Fillter_Export.Where(x => x.TenToaNha.ToUpper().Contains(str_tentoanha_select.ToUpper())).ToList();
            }

            if (str_ex_phonghoc != "Chọn phòng")
            {
                List_SheduleRoom_Fillter_Export = List_SheduleRoom_Fillter_Export.Where(x => x.TenPhong.ToUpper().Contains(str_ex_phonghoc.ToUpper())).ToList();
            }
            if (str_ex_buoihoc != "Chọn buổi")
            {
                List_SheduleRoom_Fillter_Export = List_SheduleRoom_Fillter_Export.Where(x => x.Buoi.ToUpper().Contains(str_ex_buoihoc.ToUpper())).ToList();
            }
            if (str_ex_tenmon != "Chọn môn")
            {
                List_SheduleRoom_Fillter_Export = List_SheduleRoom_Fillter_Export.Where(x => x.MonHoc.ToUpper().Contains(str_ex_tenmon.ToUpper())).ToList();
            }
            if (str_ex_loaidung != "Chọn loại")
            {
                List_SheduleRoom_Fillter_Export = List_SheduleRoom_Fillter_Export.Where(x => x.LoaiDung.ToUpper().Contains(str_ex_loaidung.ToUpper())).ToList();
            }

            if (str_ex_tengv != "Chọn CBGD")
            {
                List_SheduleRoom_Fillter_Export = List_SheduleRoom_Fillter_Export.Where(x => x.GiangVien.ToUpper().Contains(str_ex_tengv.ToUpper())).ToList();
            }

            try
            {
                using (ExcelPackage _excelpackage = new ExcelPackage())
                {
                    _excelpackage.Workbook.Properties.Author = "hduTeam";  // đặt tên người tạo file                       
                    _excelpackage.Workbook.Properties.Title = "BaoCao"; // đặt tiêu đề cho file

                    int colIndex = 1, rowIndex = 1;
                    //Tạo sheet để làm việc 
                    _excelpackage.Workbook.Worksheets.Add("LichPH");
                    string[] arr_col_room = { "TT", "Tòa nhà", "Phòng học", "Thứ", "Ngày tháng", "Buổi", "Loại dùng", "Lớp", "Môn", "Giáo viên", "Tiết", "Loại lịch" };

                    ExcelWorksheet ws = null; // khai báo để thao tác với ws

                    // lấy sheet vừa add ra để thao tác 
                    if (List_SheduleRoom_Fillter_Export.Count > 0)
                    {
                        excelFcHeaderName(ws, _excelpackage, 1, colIndex, rowIndex, "LichPH", arr_col_room);
                        ws = _excelpackage.Workbook.Worksheets[1];
                        rowIndex = 1;
                        // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                        foreach (var item in List_SheduleRoom_Fillter_Export)
                        {
                            colIndex = 1; // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                            rowIndex++;  // rowIndex tương ứng từng dòng dữ liệu
                                         //gán giá trị cho từng cell                      
                            ws.Cells.Style.Font.Bold = false;
                            ws.Cells.Style.WrapText = true;
                            ws.Cells[rowIndex, colIndex++].Value = (rowIndex - 1);      //1
                            ws.Cells[rowIndex, colIndex++].Value = item.TenToaNha;      //2
                            ws.Cells[rowIndex, colIndex++].Value = item.TenPhong;       //3
                            ws.Cells[rowIndex, colIndex++].Value = item.Thu;            //4
                            ws.Cells[rowIndex, colIndex++].Value = item.NgayThang_Show; //5
                            ws.Cells[rowIndex, colIndex++].Value = item.Buoi;           //6
                            ws.Cells[rowIndex, colIndex++].Value = item.LoaiDung;       //7
                            ws.Cells[rowIndex, colIndex++].Value = item.LopHocKhoa;     //8
                            ws.Cells[rowIndex, colIndex++].Value = item.MonHoc;         //9
                            ws.Cells[rowIndex, colIndex++].Value = item.GiangVien;      //10
                            ws.Cells[rowIndex, colIndex++].Value = item.Tiet;           //11
                            ws.Cells[rowIndex, colIndex++].Value = item.LoaiLich;       //12
                        }

                        for (int indexCol = 1; indexCol <= arr_col_room.Count(); indexCol++)
                        {
                            if (indexCol == 1) { ws.Column(indexCol).Width = 6; }       //1
                            if (indexCol == 2) { ws.Column(indexCol).Width = 12; }      //2
                            if (indexCol == 3) { ws.Column(indexCol).Width = 15; }      //3
                            if (indexCol == 4) { ws.Column(indexCol).Width = 9.5; }     //4
                            if (indexCol == 5) { ws.Column(indexCol).Width = 12; }      //5
                            if (indexCol == 6) { ws.Column(indexCol).Width = 8; }       //6
                            if (indexCol == 7) { ws.Column(indexCol).Width = 11; }      //7
                            if (indexCol == 8) { ws.Column(indexCol).Width = 40; }      //8
                            if (indexCol == 9) { ws.Column(indexCol).Width = 22.5; }    //9
                            if (indexCol == 10) { ws.Column(indexCol).Width = 21; }     //10
                            if (indexCol == 11) { ws.Column(indexCol).Width = 8; }      //11
                            if (indexCol == 12) { ws.Column(indexCol).Width = 13; }     //12
                            // đặt tiêu đề cho bảng có kiểu chữ đậm
                            ws.Cells[1, 1, 1, indexCol].Style.Font.Bold = true;
                        }

                    }


                    //Lưu file lại

                    string filePath = "";

                    SaveFileDialog dialog = new SaveFileDialog();  // tạo SaveFileDialog để lưu file excel              

                    dialog.Title = "Xuất dữ liệu cán bộ";

                    dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";  // chỉ lọc ra các file có định dạng Excel              
                    if (dialog.ShowDialog() == true)   // Nếu mở chọn nơi lưu file và đặt tên file thành công sẽ lưu đường dẫn lại dùng
                    {
                        filePath = dialog.FileName;
                    }
                    if (string.IsNullOrEmpty(filePath)) // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
                    {
                        // MessageBox.Show("Bạn chưa đặt tên têp dữ liệu hoặc tên têp không hợp lệ !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    Byte[] bin = _excelpackage.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                    MessageBox.Show("Xuất excel thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Có lỗi khi lưu file!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

        }
        private static void excelFcHeaderName(ExcelWorksheet _ws, ExcelPackage _excelpackage, int i, int colindex, int rowindex, string ws_name, string[] arrColhd)
        {
            _ws = _excelpackage.Workbook.Worksheets[i];
            _ws.Name = ws_name;  // đặt tên cho sheet                       
            _ws.Cells.Style.Font.Size = 12;  // fontsize mặc định cho cả sheet                       
            _ws.Cells.Style.Font.Name = "Times New Roman"; // font family mặc định cho cả sheet

            // Tạo danh sách các tiêu đề cho cột (column header) 
            colindex = 1; rowindex = 1;
            //tạo các header từ column header đã tạo từ bên trên
            foreach (var item in arrColhd)
            {
                var cell = _ws.Cells[rowindex, colindex];
                cell.Value = item;
                colindex++;
            }
        }
        #endregion
        #region các sự kiện cho checkbox select all
        private void chkSelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (chkSelectAll.IsChecked.Value == true)
            {
                ListShowInfor.SelectAll();
            }
            else
            {
                ListShowInfor.UnselectAll();
            }
        }

        private void chkWspSelect_Checked(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = ItemsControl.ContainerFromElement(ListShowInfor, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                item.IsSelected = true;
            }
        }

        private static bool individualChkBxUnCheckedFlag { get; set; }
        private void chkWspSelect_Unchecked(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = ItemsControl.ContainerFromElement(ListShowInfor, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
                item.IsSelected = false;

            individualChkBxUnCheckedFlag = true;
            CheckBox headerChk = (CheckBox)((GridView)ListShowInfor.View).Columns[0].Header;
            headerChk.IsChecked = false;
        }
        #endregion
    }
}
