using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.FormulaParsing.ExpressionGraph;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppShedule
{
    public class SheduleRoom
    {
        public int ID { get; set; }
        public string TenToaNha { get; set; }
        public string TenPhong { get; set; }
        public string Thu { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayThang { get; set; }
        public string Buoi { get; set; }
        public string LoaiDung { get; set; }
        public string LopHocKhoa { get; set; }
        public string MonHoc { get; set; }
        public string GiangVien { get; set; }
        public string Tiet { get; set; }
        public string LoaiLich { get; set; }
        public string NgayThang_Show { get; set; }
        public SheduleRoom() { }
        public SheduleRoom(int iD, string tenToaNha, string tenPhong, string thu, DateTime ngayThang, string buoi, string loaiDung, string lopHocKhoa, string monHoc, string giangVien, string tiet, string loaiLich, string ngaythang_Show)
        {
            ID = iD;
            TenToaNha = tenToaNha;
            TenPhong = tenPhong;
            Thu = thu;
            NgayThang = ngayThang;
            Buoi = buoi;
            LoaiDung = loaiDung;
            LopHocKhoa = lopHocKhoa;
            MonHoc = monHoc;
            GiangVien = giangVien;
            Tiet = tiet;
            LoaiLich = loaiLich;
            NgayThang_Show = ngaythang_Show;
        }
        public class Funcs_dbAppShedule
        {
            private string path = ConfigurationManager.ConnectionStrings["dbAppShedule"].ConnectionString;

            private DataSet m_dataSet;
            private DataTable m_table;
            public Funcs_dbAppShedule()
            {
                m_dataSet = new DataSet();
                m_table = new DataTable();


            }
            public IList<SheduleRoom> SheduleRoom_GetAll()
            {
                IList<SheduleRoom> List_SheduleRoom = new List<SheduleRoom>();
                try
                {
                    m_dataSet.ReadXml(path);
                    m_table = m_dataSet.Tables["SheduleRoom"];
                    for (int i = 1; i < m_table.Rows.Count; i++)
                    { 
                        SheduleRoom sheduleRoom = new SheduleRoom();
                        sheduleRoom.ID = Convert.ToInt32(m_table.Rows[i]["ID"].ToString());
                        sheduleRoom.TenToaNha = m_table.Rows[i]["TenToaNha"].ToString();
                        sheduleRoom.TenPhong = m_table.Rows[i]["TenPhong"].ToString();
                        sheduleRoom.Thu = m_table.Rows[i]["Thu"].ToString();
                        sheduleRoom.NgayThang = Convert.ToDateTime(m_table.Rows[i]["NgayThang"].ToString());                      
                        sheduleRoom.Buoi = m_table.Rows[i]["Buoi"].ToString();
                        sheduleRoom.LoaiDung = m_table.Rows[i]["LoaiDung"].ToString();
                        sheduleRoom.LopHocKhoa = m_table.Rows[i]["LopHocKhoa"].ToString();
                        sheduleRoom.MonHoc = m_table.Rows[i]["MonHoc"].ToString();
                        sheduleRoom.GiangVien = m_table.Rows[i]["GiangVien"].ToString();
                        sheduleRoom.Tiet = m_table.Rows[i]["Tiet"].ToString();
                        sheduleRoom.LoaiLich = m_table.Rows[i]["LoaiLich"].ToString();
                        sheduleRoom.NgayThang_Show = m_table.Rows[i]["NgayThang_Show"].ToString();
                        List_SheduleRoom.Add(sheduleRoom);
                    }
                }
                catch { }
                return List_SheduleRoom;
            }
            public SheduleRoom SheduleRoom_GetBy_ID(int _id_get)
            {
                SheduleRoom sheduleRoom = new SheduleRoom();
                try
                {
                    XDocument _db = XDocument.Load(path);
                    XElement _xe = _db.Descendants("SheduleRoom").Where(sr => sr.Attribute("ID").Value.Equals(_id_get.ToString())).FirstOrDefault();

                    sheduleRoom.ID = _id_get;
                    sheduleRoom.TenToaNha = (_xe.Element("TenToaNha").Value).ToString();
                    sheduleRoom.TenPhong = (_xe.Element("TenPhong").Value).ToString();
                    sheduleRoom.Thu = (_xe.Element("Thu").Value).ToString();
                    sheduleRoom.NgayThang = (Convert.ToDateTime((_xe.Element("NgayThang").Value).ToString())); 
                    sheduleRoom.Buoi = (_xe.Element("Buoi").Value).ToString();
                    sheduleRoom.LoaiDung = (_xe.Element("LoaiDung").Value).ToString();
                    sheduleRoom.LopHocKhoa = (_xe.Element("LopHocKhoa").Value).ToString();
                    sheduleRoom.MonHoc = (_xe.Element("MonHoc").Value).ToString();
                    sheduleRoom.GiangVien = (_xe.Element("GiangVien").Value).ToString();
                    sheduleRoom.Tiet = (_xe.Element("Tiet").Value).ToString();
                    sheduleRoom.LoaiLich = (_xe.Element("LoaiLich").Value).ToString();
                    sheduleRoom.NgayThang_Show = (_xe.Element("NgayThang_Show").Value).ToString();
                }
                catch { }
                return sheduleRoom;
            }
            public bool SheduleRoom_Insert(SheduleRoom shedule_room)
            {
                try
                {
                    XDocument _db = XDocument.Load(path);
                    var _last_appoint = _db.Descendants("SheduleRoom").Last();
                    int id_new = Convert.ToInt32(_last_appoint.Attribute("ID").Value) + 1;

                    XElement _new_Appoint = new XElement("SheduleRoom",
                                            new XElement("TenToaNha", shedule_room.TenToaNha),
                                            new XElement("TenPhong", shedule_room.TenPhong),
                                            new XElement("Thu", shedule_room.Thu),
                                            new XElement("NgayThang", shedule_room.NgayThang),
                                            new XElement("Buoi", shedule_room.Buoi),
                                            new XElement("LoaiDung", shedule_room.LoaiDung),
                                            new XElement("LopHocKhoa", shedule_room.LopHocKhoa),
                                            new XElement("MonHoc", shedule_room.MonHoc),
                                            new XElement("GiangVien", shedule_room.GiangVien),
                                            new XElement("Tiet", shedule_room.Tiet),
                                            new XElement("LoaiLich", shedule_room.LoaiLich),
                                            new XElement("NgayThang_Show", shedule_room.NgayThang_Show));
                    _new_Appoint.SetAttributeValue("ID", id_new.ToString());

                    _db.Element("SheduleRoomAll").Add(_new_Appoint);
                    _db.Save(path);
                    return true;
                }
                catch { return false; }
            }
            public bool SheduleRoom_Update(SheduleRoom shedule_room)
            {
                try
                {
                    XDocument _db = XDocument.Load(path);
                    XElement _xe = _db.Descendants("SheduleRoom").Where(a => a.Attribute("ID").Value.Equals((shedule_room.ID).ToString())).FirstOrDefault();
                    _xe.Element("TenToaNha").Value = shedule_room.TenToaNha;
                    _xe.Element("TenPhong").Value = shedule_room.TenPhong;
                    _xe.Element("Thu").Value = shedule_room.Thu;
                    _xe.Element("NgayThang").Value = shedule_room.NgayThang.ToString();
                    _xe.Element("Buoi").Value = shedule_room.Buoi;
                    _xe.Element("LoaiDung").Value = shedule_room.LoaiDung;
                    _xe.Element("LopHocKhoa").Value = shedule_room.LopHocKhoa;
                    _xe.Element("MonHoc").Value = shedule_room.MonHoc;
                    _xe.Element("GiangVien").Value = shedule_room.GiangVien;
                    _xe.Element("Tiet").Value = shedule_room.Tiet;
                    _xe.Element("LoaiLich").Value = shedule_room.LoaiLich;
                    _xe.Element("NgayThang_Show").Value = shedule_room.NgayThang_Show;
                    _db.Save(path);
                    return true;
                }
                catch { return false; }
            }
            public bool Appoint_Delete(int _id_del)
            {
                try
                {
                    XDocument _db = XDocument.Load(path);
                    XElement _xe = _db.Descendants("SheduleRoom").Where(z => z.Attribute("ID").Value.Equals(_id_del.ToString())).FirstOrDefault();
                    _xe.Remove();
                    _db.Save(path);
                    return true;
                }
                catch { return false; }
            }
        }
    }
}
