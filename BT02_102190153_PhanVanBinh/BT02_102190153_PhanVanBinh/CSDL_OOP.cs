using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BT02_102190153_PhanVanBinh
{
    class CSDL_OOP
    {
        private static CSDL_OOP _Instance;
        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CSDL_OOP();
                return _Instance;
            }
            private set
            {
                _Instance = value;
            }

        }
       // private CSDL_OOP() { }
        public List<SV> GetAllSV()
        {
            List<SV> data = new List<SV>();
            foreach(DataRow i in CSDL.Instance.DTSV.Rows)
            {
                data.Add(GetSV(i));
            }    
            return data;
        }
        public SV GetSV(DataRow i)
        {
            return new SV
            {
                MSSV = ( i["MSSV"].ToString()),
                Name = i["Name"].ToString(),
                Gender = Convert.ToBoolean(i["Gender"].ToString()),
                NS = Convert.ToDateTime(i["NS"].ToString()),
                ID_Lop = Convert.ToInt32(i["ID_Lop"].ToString()),
            };    
        }
        public List<LSH> GetAllLSH()
        {
            List<LSH> data = new List<LSH>();
            foreach (DataRow i in CSDL.Instance.DTLSH.Rows)
            {
                data.Add(GetLSH(i));
            }
            return data;
        }
        public LSH GetLSH(DataRow i)
        {
            return new LSH
            {
                ID_Lop =Convert.ToInt32(i["ID_Lop"]),
                Name_Lop = i["Name_Lop"].ToString()
            };
        }
        public List<SV> Select_Class(int id)
        {
            List<SV> list = new List<SV>();
            foreach (DataRow sv in CSDL.Instance.DTSV.Rows)
            {
                if (id == 0)
                {
                    list.Add(GetSV(sv));
                }
                else
                {
                    int id1 = Convert.ToInt32(sv["ID_Lop"]);
                    if(id1==id)
                    {
                        list.Add(GetSV(sv));
                    }    
                }    
            }
            return list;
        }
        public List<SV> Select_btn_Search(int id, string name)
        {
            List<SV> list = new List<SV>();
            foreach (DataRow sv in CSDL.Instance.DTSV.Rows)
            {
                if (name == "" && id==0)
                {
                    list.Add(GetSV(sv));
                }
                else
                {
                    if(name !="" && id == 0)
                    {
                        string _name = sv["Name"].ToString();
                        if (_name.Contains(name))
                        {
                            list.Add(GetSV(sv));
                        }
                    }
                    else
                    {
                        string _name = sv["Name"].ToString();
                        int Id = Convert.ToInt32(sv["ID_Lop"].ToString());
                        if (_name.Contains(name) && id == Id )
                        {
                            list.Add(GetSV(sv));
                        }

                    }    
                }
            }
            return list;
        }
       public void DeleteSV(string mssv)
        {
            CSDL.Instance.Delete_rows(mssv);
        }
        public SV GetSVbyMSSV(string MSSV)
        {
            SV sv = new SV();
            foreach (DataRow r in CSDL.Instance.DTSV.Rows)
            {
                if (r["MSSV"].ToString() == MSSV)
                {
                    sv = GetSV(r);
                }
            }
            return sv;
        }
        public List<SV> GetListSV(int ID_Lop, string Name)
        {
            List<SV> data = new List<SV>();
            foreach(SV i in GetAllSV())
            {
                if (i.ID_Lop == ID_Lop && i.Name.Contains(Name))
                {
                    data.Add(new SV
                    { Name = i.Name,
                        MSSV = i.MSSV,
                        Gender = i.Gender,
                        NS = i.NS,
                        ID_Lop = i.ID_Lop
                    });
                }
            }
            return data;
        }
        public bool Check_MSSV(string mssv)
        {
            foreach(DataRow i in CSDL.Instance.DTSV.Rows)
            {
                if (mssv == i["MSSV"].ToString())
                    return true;     
            }
            return false;
        }
        public void Sort(int check)
        {
            List<SV> sv = new List<SV>(CSDL.Instance.DTSV.Rows.Count);
            int count = 0;
            foreach (DataRow dr in CSDL.Instance.DTSV.Rows)
            {
                count++;
                sv.Add(GetSV(dr));            
            }
            switch (check)
            {
                case 1:
                    {
                        for (int i = 0; i < count; i++)
                        {
                            for (int j = 0; j < count - 1; j++)
                            {
                                if (Convert.ToInt32(sv[j].MSSV) > Convert.ToInt32(sv[j + 1].MSSV))

                                {
                                    SV temp = sv[j];
                                    sv[j] = sv[j + 1];
                                    sv[j + 1] = temp;
                                }
                            }
                        }
                        break;
                    }

                case 2:
                    {
                        for (int i = 0; i < count; i++)
                        {
                            for (int j = 0; j < count - 1; j++)
                            {
                                if (sv[j].Name.CompareTo(sv[j + 1].Name) > 0)

                                {
                                    SV temp = sv[j];
                                    sv[j] = sv[j + 1];
                                    sv[j + 1] = temp;
                                }
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        for (int i = 0; i < count; i++)
                        {
                            for (int j = 0; j < count - 1; j++)
                            {
                                if (sv[j].Gender.ToString().CompareTo(sv[j + 1].Gender.ToString()) > 0)

                                {
                                    SV temp = sv[j];
                                    sv[j] = sv[j + 1];
                                    sv[j + 1] = temp;
                                }
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        for (int i = 0; i < count; i++)
                        {
                            for (int j = 0; j < count - 1; j++)
                            {
                                if (sv[j].NS.ToString().CompareTo(sv[j + 1].NS.ToString()) > 0)

                                {
                                    SV temp = sv[j];
                                    sv[j] = sv[j + 1];
                                    sv[j + 1] = temp;
                                }
                            }
                        }
                        break;
                    }
                default:
                    {
                        for (int i = 0; i < count; i++)
                        {
                            for (int j = 0; j < count - 1; j++)
                            {
                                if (sv[j].ID_Lop > sv[j + 1].ID_Lop)

                                {
                                    SV temp = sv[j];
                                    sv[j] = sv[j + 1];
                                    sv[j + 1] = temp;
                                }
                            }
                        }
                        break;
                    }

            }
            CSDL.Instance.CapNhatDSSV(sv);
      
        }


    }
}
