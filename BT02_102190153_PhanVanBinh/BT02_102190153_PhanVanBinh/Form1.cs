using System;
using System.Data;
using System.Windows.Forms;

namespace BT02_102190153_PhanVanBinh
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCCB();
            SetCBBSort();
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            int id_class = ((CCBform)comboBox1.SelectedItem).Value;
            dataGridView1.DataSource = CSDL_OOP.Instance.Select_Class(id_class);
        }
        public void Show(int ID_Lop, string name)
        {
            dataGridView1.DataSource = CSDL_OOP.Instance.GetListSV(ID_Lop, name);
        }


        public void SetCCB()
        {
            comboBox1.Items.Add(new CCBform
            {
                Text = "All",
                Value = 0
            });
            foreach (DataRow i in CSDL.Instance.DTLSH.Rows)
            {
                comboBox1.Items.Add(new CCBform
                {
                    Text = i["Name_Lop"].ToString(),
                    Value = Convert.ToInt32(i["ID_Lop"])
                });
            }
            comboBox1.SelectedIndex = 0;
        }
        public void SetCBBSort()
        {
            int count = 0;
            foreach (DataColumn i in CSDL.Instance.DTSV.Columns)
            {
                comboBox2.Items.Add(new CCBform
                {
                    Text = i.ColumnName,
                    Value = count++
                });
            }
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = ((CCBform)comboBox1.SelectedItem).Value;
            dataGridView1.DataSource = CSDL_OOP.Instance.Select_btn_Search(ID, textBox1.Text);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string Id = (dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString());
            CSDL_OOP.Instance.DeleteSV(Id);
            int ID_Lop = ((CCBform)comboBox1.SelectedItem).Value;
            dataGridView1.DataSource = CSDL_OOP.Instance.Select_btn_Search(ID_Lop, textBox1.Text);
        }



        private void btn_Sort_Click_1(object sender, EventArgs e)
        {
            string s = comboBox2.SelectedItem.ToString();
            if (s == "MSSV")
            {
                CSDL_OOP.Instance.Sort(1);
            }
            if (s == "NameSv")
            {
                CSDL_OOP.Instance.Sort(2);
            }
            if (s == "Gender")
            {
                CSDL_OOP.Instance.Sort(3);
            }
            if (s == "NS")
            {
                CSDL_OOP.Instance.Sort(4);
            }
            if (s == "ID_Lop")
            {
                CSDL_OOP.Instance.Sort(5);
            }
            CCBform index = (CCBform)comboBox1.SelectedItem;
            if (index.Value == 0)
            {
                dataGridView1.DataSource = CSDL_OOP.Instance.GetAllSV();
            }
            else
            {
                Show(index.Value, "");
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string MSSV = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
                Form2 f = new Form2();
                f.mydel(MSSV);
                f.ShowDialog();
                dataGridView1.DataSource = CSDL_OOP.Instance.GetAllSV();
            }
            else
            {
                Form2 f = new Form2();
                f.ShowDialog();
            }
        }

    }
}
