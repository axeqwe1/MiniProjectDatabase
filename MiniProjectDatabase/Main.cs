using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniProjectDatabase.form;
namespace MiniProjectDatabase
{
    public partial class Main : Form
    {
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
            AddEmployee AddEMPForm = new AddEmployee();
            AddEMPForm.Show();
            this.Hide();
        }

        private void GenerateUserControl()
        {
            flowLayoutPanel1.Controls.Clear();

            UserControl1[] list = new UserControl1[5];

            string[] menuname = new string[5] {"test1","test2","test3","test4","test5"};
            string[] description = new string[5] {"desc1", "desc2", "desc3", "desc4", "desc5"};

            for (int i = 0; i< list.Length; i++)
            {
                list[i] = new UserControl1();

                list[i]._Menuname = menuname[i];
                list[i]._Description = description[i];

                flowLayoutPanel1.Controls.Add(list[i]);

                list[i].Click += new System.EventHandler(this.UserControl_Click);
            }
            
        }

        void UserControl_Click(object sender,EventArgs e)
        {
            UserControl1 obj = (UserControl1)sender;

            MessageBox.Show($"{obj._Menuname}");
            
        }

        private void Main_Load(object sender, EventArgs e)
        {
            GenerateUserControl();
        }
    }
}
