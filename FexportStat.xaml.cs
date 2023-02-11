using Microsoft.Win32;
using OfficeOpenXml;

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

namespace AppShedule
{
    /// <summary>
    /// Interaction logic for FexportStat.xaml
    /// </summary>
    public partial class FexportStat : Window
    {
        List<ThongKe> List_ThongKe_Fillter;

        public FexportStat()
        {
            InitializeComponent();
            List_Data_ToaNha();
            FillterData();
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
            cbboxToaNha.DataContext = null;
            cbboxToaNha.DataContext = arr_toa_nha.ToList();
            cbboxToaNha.SelectedIndex = 0;
        }

        private void FillterData()
        {
            List_ThongKe_Fillter = new List<ThongKe>();

            DateTime dateStart = DateTime.Now;
            dateStart = dateStart.AddDays((-dateStart.Day) + 1); // lấy ngày đầu tiên của tháng           
            txtStartDate.Text = dateStart.ToShortDateString();

            DateTime dateEnd = DateTime.Now;
            dateEnd = dateEnd.AddMonths(1);
            dateEnd = dateEnd.AddDays(-(dateEnd.Day));
            txtEndDate.Text = dateEnd.ToShortDateString(); // lấy ngày cuối cùng của tháng hiện tại       


            Funcs_dbAppShedule f = new Funcs_dbAppShedule();

            List<SheduleRoom> List_All_SheduleRooms = new List<SheduleRoom>();

            List_All_SheduleRooms = f.SheduleRoom_GetAll().ToList();



            var data_item_phonghoc = List_All_SheduleRooms.OrderBy(x => x.TenPhong).Select(x => x.TenPhong).Distinct().ToList();

            foreach (var item in data_item_phonghoc)
            {
                ThongKe it_thongke = new ThongKe();
                it_thongke.TenPhong = item;
                it_thongke.SoBuoiTrongTuan = 0;
                it_thongke.SoBuoiCuoiTuan = 0;
                it_thongke.TongSoBuoi = it_thongke.SoBuoiTrongTuan + it_thongke.SoBuoiCuoiTuan;
                it_thongke.GhiChu = "";
                List_ThongKe_Fillter.Add(it_thongke);
            }

            var List_Fillter_SheduleRooms = from item in List_All_SheduleRooms.Where(x => x.NgayThang >= dateStart && x.NgayThang <= dateEnd)
                                            select item;
            foreach (var item_thongke in List_ThongKe_Fillter)
            {
                foreach (SheduleRoom item_sheduleroom in List_Fillter_SheduleRooms)
                {
                    if (item_sheduleroom.TenPhong == item_thongke.TenPhong)
                    {
                        item_thongke.TongSoBuoi += 1;
                        if (item_sheduleroom.Thu == "Chủ nhật" || item_sheduleroom.Thu == "Thứ Bảy")
                        {
                            item_thongke.SoBuoiCuoiTuan += 1;
                        }
                        else
                        {
                            item_thongke.SoBuoiTrongTuan += 1;
                        }
                    }
                }
            }
            List_Statistical_Fillter.DataContext = null;
            List_Statistical_Fillter.DataContext = List_ThongKe_Fillter;

        }


        private void chkSelectAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbSelectRow_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void cbSelectRow_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btStatistical_default_Click(object sender, RoutedEventArgs e)
        {
            FillterData();
        }

        private void btStatistical_custom_Click(object sender, RoutedEventArgs e)
        {
            List_ThongKe_Fillter = new List<ThongKe>();

            DateTime dateStart_fillter = Convert.ToDateTime(txtStartDate.Text);
            DateTime dateEnd_fillter = Convert.ToDateTime(txtEndDate.Text);

            Funcs_dbAppShedule f = new Funcs_dbAppShedule();

            List<SheduleRoom> List_All_SheduleRooms = new List<SheduleRoom>();

            List_All_SheduleRooms = f.SheduleRoom_GetAll().ToList();
            var data_item_phonghoc = List_All_SheduleRooms.OrderBy(x => x.TenPhong).Select(x => x.TenPhong).Distinct().ToList();

            foreach (var item in data_item_phonghoc)
            {
                ThongKe it_thongke = new ThongKe();
                it_thongke.TenPhong = item;
                it_thongke.SoBuoiTrongTuan = 0;
                it_thongke.SoBuoiCuoiTuan = 0;
                it_thongke.TongSoBuoi = it_thongke.SoBuoiTrongTuan + it_thongke.SoBuoiCuoiTuan;
                it_thongke.GhiChu = "";
                List_ThongKe_Fillter.Add(it_thongke);
            }

            var List_Fillter_SheduleRooms = from item in List_All_SheduleRooms.Where(x => x.NgayThang >= dateStart_fillter && x.NgayThang <= dateEnd_fillter)
                                            select item;
            foreach (var item_thongke in List_ThongKe_Fillter)
            {
                foreach (SheduleRoom item_sheduleroom in List_Fillter_SheduleRooms)
                {
                    if (item_sheduleroom.TenPhong == item_thongke.TenPhong)
                    {
                        item_thongke.TongSoBuoi += 1;
                        if (item_sheduleroom.Thu == "Chủ nhật" || item_sheduleroom.Thu == "Thứ Bảy")
                        {
                            item_thongke.SoBuoiCuoiTuan += 1;
                        }
                        else
                        {
                            item_thongke.SoBuoiTrongTuan += 1;
                        }
                    }
                }
            }

            List_Statistical_Fillter.DataContext = null;
            List_Statistical_Fillter.DataContext = List_ThongKe_Fillter;
        }

        private void cbboxToaNha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index_toanha = cbboxToaNha.SelectedIndex;
            if (index_toanha > 0)
            {
                string str_toanha_select = cbboxToaNha.Items.GetItemAt(index_toanha).ToString();
            }
        }

        private void btExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (ExcelPackage _excelpackage = new ExcelPackage())
                {
                    _excelpackage.Workbook.Properties.Author = "hduTeam";  // đặt tên người tạo file                       
                    _excelpackage.Workbook.Properties.Title = "ThongKeSD"; // đặt tiêu đề cho file


                    //Tạo sheet để làm việc 
                    _excelpackage.Workbook.Worksheets.Add("ThongKeSD");
                    string[] arr_col_number = { "TT", "Tên phòng", "Số buổi sử dụng trong tuần",
                            "Số buổi sử dụng cuối tuần", "Tổng số buổi", "Ghi chú" };

                    ExcelWorksheet ws = null; // khai báo để thao tác với ws

                    // lấy sheet vừa add ra để thao tác 

                    if (List_ThongKe_Fillter.Count > 0)
                    {
                        ws = _excelpackage.Workbook.Worksheets[1];

                        ws.Name = "ThongKeSD";  // đặt tên cho sheet                       
                        ws.Cells.Style.Font.Size = 12;  // fontsize mặc định cho cả sheet                       
                        ws.Cells.Style.Font.Name = "Times New Roman"; // font family mặc định cho cả sheet

                        ws.Cells[1, 1].Value = "Thống kê từ " + txtStartDate.Text + " đến " + txtEndDate.Text;
                        //ws.Cells["A1:F1"].Merge = true;
                        ws.Cells[1, 1, 1, 6].Merge = true;

                        // Tạo danh sách các tiêu đề cho cột (column header)                         
                        int colIndex = 1, rowIndex = 2;
                        //tạo các header từ column header đã tạo từ bên trên
                        foreach (var item in arr_col_number)
                        {
                            var cell = ws.Cells[rowIndex, colIndex];
                            cell.Value = item;
                            colIndex++;
                        }


                        rowIndex = 2;
                        // với mỗi item trong danh sách sẽ ghi trên 1 dòng
                        foreach (var item in List_ThongKe_Fillter)
                        {
                            colIndex = 1; // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                            rowIndex++;  // rowIndex tương ứng từng dòng dữ liệu
                            //gán giá trị cho từng cell                      
                            ws.Cells.Style.Font.Bold = false;
                            ws.Cells.Style.WrapText = true;
                            ws.Cells[rowIndex, colIndex++].Value = (rowIndex - 2);      //1
                            ws.Cells[rowIndex, colIndex++].Value = item.TenPhong;      //2
                            ws.Cells[rowIndex, colIndex++].Value = item.SoBuoiTrongTuan;       //3
                            ws.Cells[rowIndex, colIndex++].Value = item.SoBuoiCuoiTuan;            //4
                            ws.Cells[rowIndex, colIndex++].Value = item.TongSoBuoi; //5
                            ws.Cells[rowIndex, colIndex++].Value = item.GhiChu;           //6

                        }

                        for (int indexCol = 1; indexCol <= arr_col_number.Count(); indexCol++)
                        {
                            if (indexCol == 1) { ws.Column(indexCol).Width = 6; }       //1
                            if (indexCol == 2) { ws.Column(indexCol).Width = 17; }      //2
                            if (indexCol == 3) { ws.Column(indexCol).Width = 28; }      //3
                            if (indexCol == 4) { ws.Column(indexCol).Width = 28; }     //4
                            if (indexCol == 5) { ws.Column(indexCol).Width = 15; }      //5
                            if (indexCol == 6) { ws.Column(indexCol).Width = 20; }       //6  
                            ws.Cells[2, 1, 2, indexCol].Style.Font.Bold = true;         // đặt tiêu đề cho bảng có kiểu chữ đậm
                        }
                        //worksheet.Cells[FromRow, FromColumn, ToRow, ToColumn].Merge = true;
                        ws.Cells[1, 1].Style.Font.Bold = true;

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
                    this.Close();
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

        }
    }
    public class ThongKe
    {
        public string TenPhong { get; set; }
        public int SoBuoiTrongTuan { get; set; }
        public int SoBuoiCuoiTuan { get; set; }
        public int TongSoBuoi { get; set; }
        public string GhiChu { get; set; }

        public ThongKe() { }
        public ThongKe(string tenPhong, int soBuoiTrongTuan, int soBuoiCuoiTuan, int tongSoBuoi, string ghiChu)
        {
            TenPhong = tenPhong;
            SoBuoiTrongTuan = soBuoiTrongTuan;
            SoBuoiCuoiTuan = soBuoiCuoiTuan;
            TongSoBuoi = tongSoBuoi;
            GhiChu = ghiChu;
        }
    }
}
