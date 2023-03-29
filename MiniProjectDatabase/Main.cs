using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OracleClient;
using MiniProjectDatabase.form;
using MiniProjectDatabase.form.etc;
using MiniProjectDatabase.asset.database;
namespace MiniProjectDatabase
{
    public partial class Main : Form
    {
        database db = new database();
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMenu fs = new AddMenu();
            fs.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddEmploy AddEMPForm = new AddEmploy();
            AddEMPForm.Show();
            this.Hide();
        }
        public void refresh()
        {
            OracleDataAdapter da1;
            DataSet ds1, ds2;
            ds1 = new DataSet();


            string temp_sql1 = $"SELECT menu_id,menuname,detail,type FROM ENVY_MENU ORDER BY menu_id ASC";

            da1 = new OracleDataAdapter(temp_sql1, db.OracleConnect);


            DataGridViewColumn c1, c2, c3;

        }
        private void GenerateControl()
        {
            flowLayoutPanel1.Controls.Clear();

            MainControl[] list = new MainControl[5];

            string[] menuname = new string[5] {"test1","test2","test3","test4","test5"};
            string[] description = new string[5] {"desc1", "desc2", "desc3", "desc4", "desc5"};

            for (int i = 0; i< list.Length; i++)
            {
                list[i] = new MainControl();

                list[i]._Menuname = menuname[i];
                list[i]._Description = description[i];

                flowLayoutPanel1.Controls.Add(list[i]);

                list[i].Click += new System.EventHandler(this.UserControl_Click);
            }
            
        }

        void UserControl_Click(object sender,EventArgs e)
        {
            MainControl obj = (MainControl)sender;
            ChoseSize sz = new ChoseSize();

            sz.ShowDialog();
            if(sz.DialogResult == DialogResult.OK)
            {
                MessageBox.Show(sz.GetSize);
            }
            
            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            GenerateControl();
        }
    }
}
