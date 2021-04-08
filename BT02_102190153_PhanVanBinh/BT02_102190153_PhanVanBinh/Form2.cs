using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT02_102190153_PhanVanBinh
{
    public partial class Form2 : Form
    {
        public delegate void Mydel(string s);

        public Mydel mydel { get; set; }
        string MSSV = "";
        private void GetMSSV(string s)
        {
            MSSV = s;
        }
        public Form2()
        {
            mydel = new Mydel(GetMSSV);
            InitializeComponent();
            SetCBBShow();
        }


        public void SetCBBShow()
        {

            foreach (DataRow i in CSDL.Instance.DTLSH.Rows)
            {
                comboBox_LSH.Items.Add(new CCBform
                {
                    Value = Convert.ToInt32(i["ID_Lop"].ToString()),
                    Text = i["Name_Lop"].ToString()
                });

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
           
        private void btn_OK_Click(object sender, EventArgs e)
        {
            SV sv = new SV();
            sv.MSSV = text_MSSV.Text.ToString();
            sv.Name = text_NameSV.Text.ToString();
            sv.ID_Lop = ((CCBform)comboBox_LSH.SelectedItem).Value;
            if (radioB_Male.Checked == true)
            {
                sv.Gender = true;
            }
            else
            {
                sv.Gender = false;
            }
            sv.NS = dateTimePicker1.Value;
            if (CSDL_OOP.Instance.Check_MSSV(text_MSSV.Text))
            {
                CSDL.Instance.EditDataRowSV(sv);
            }
            else
                CSDL.Instance.AddDataRowSV(sv);
            this.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (MSSV != "")
            {
                text_MSSV.Enabled = false;
                this.Text = "Edit";
                SV sv = new SV();
                sv = CSDL_OOP.Instance.GetSVbyMSSV(MSSV);

                text_MSSV.Text = sv.MSSV.ToString();
                text_NameSV.Text = sv.Name.ToString();
                if (sv.Gender == true) radioB_Male.Checked = true;
                else
                {
                    radioB_Female.Checked = true;
                }
                dateTimePicker1.Value = sv.NS;
                for (int i = 0; i < comboBox_LSH.Items.Count; i++)
                {
                    if (sv.ID_Lop == ((CCBform)comboBox_LSH.Items[i]).Value)
                    {
                        comboBox_LSH.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

    }
}
