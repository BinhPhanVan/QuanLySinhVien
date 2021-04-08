using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BT02_102190153_PhanVanBinh
{
    class CSDL
    {
        public DataTable DTSV { get; set; }
        public DataTable DTLSH { get; set; }
       
        public static CSDL Instance
        {
          get
            {
                if(_Instance == null)
                    _Instance = new CSDL();
                    return _Instance;
            }
          private set
            {
                _Instance = value;
            }
         
        }
        private static CSDL _Instance;
        private CSDL()
        {
            DTSV = new DataTable();
            DTSV.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV", typeof(String)),
                new DataColumn("Name", typeof(String)),
                new DataColumn("Gender", typeof(bool)),
                new DataColumn("NS", typeof(DateTime)),
                new DataColumn("ID_Lop", typeof(int))
            }) ;
            DataRow dr = DTSV.NewRow();
            dr["MSSV"] = "101"; dr["Name"] = "Phan Văn Bình";
            dr["Gender"] = true; dr["NS"] = DateTime.Now;
            dr["ID_Lop"] = 10;
            DTSV.Rows.Add(dr);
            DataRow dr1 = DTSV.NewRow();
            dr1["MSSV"] = "102"; dr1["Name"] = "NVA";
            dr1["Gender"] = true; dr1["NS"] = DateTime.Now;
            dr1["ID_Lop"] = 11;
            DTSV.Rows.Add(dr1);
            DataRow dr2 = DTSV.NewRow();
            dr2["MSSV"] = "103"; dr2["Name"] = "NTB";
            dr2["Gender"] = false; dr2["NS"] = DateTime.Now;
            dr2["ID_Lop"] = 10;
            DTSV.Rows.Add(dr2);

            DTLSH = new DataTable();
            DTLSH.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID_Lop", typeof(int)),
                new DataColumn("Name_Lop", typeof(String))
            });
            DataRow dr11 = DTLSH.NewRow();
            dr11["ID_Lop"] = 11; dr11["Name_Lop"] = "19T4";
            DTLSH.Rows.Add(dr11);
            DataRow dr12 = DTLSH.NewRow();
            dr12["ID_Lop"] = 10; dr12["Name_Lop"] = "20T4";
            DTLSH.Rows.Add(dr12);
        }
        public void Delete_rows(string mssv)
        {
            foreach (DataRow i in CSDL.Instance.DTSV.Rows)
            {
                if(CSDL_OOP.Instance.GetSV(i).MSSV==mssv)
                {
                    CSDL.Instance.DTSV.Rows.Remove(i);
                    break;
                }    
            }    
        }
        public void AddDataRowSV(SV s)
        {
            DataRow dr1 = DTSV.NewRow();
            dr1["MSSV"] = s.MSSV; dr1["Name"] = s.Name;
            dr1["Gender"] = s.Gender; dr1["NS"] = s.NS;
            dr1["ID_Lop"] = s.ID_Lop;
            DTSV.Rows.Add(dr1);
        }
        public void EditDataRowSV(SV sv)
        {
            foreach (DataRow i in CSDL.Instance.DTSV.Rows)
            {
                if (i["MSSV"].ToString() == sv.MSSV)
                {
                    i["Name"] = sv.Name;
                    i["Gender"] = sv.Gender; i["NS"] = sv.NS;
                    i["ID_Lop"] = sv.ID_Lop;
                    break;
                }
            }
        }
        public void CapNhatDSSV(List<SV> sv)
        {
            DTSV.Rows.Clear();
            foreach (SV i in sv)
            {
                DataRow dataRow = DTSV.NewRow();
                dataRow["MSSV"] = i.MSSV;
                dataRow["Name"] = i.Name;
                dataRow["Gender"] = i.Gender;
                dataRow["NS"] = i.NS;
                dataRow["ID_Lop"] = i.ID_Lop;
                DTSV.Rows.Add(dataRow);
            }
        }
    }
}
