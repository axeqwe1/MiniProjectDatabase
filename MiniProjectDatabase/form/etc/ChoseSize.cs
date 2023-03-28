using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProjectDatabase.form.etc
{
    public partial class ChoseSize : Form
    {

        string getsize;
        public string GetSize
        {
            get { return getsize; }
            set { getsize = value; }
        }
        public ChoseSize()
        {
            InitializeComponent();
        }
        private void GenerateControl()
        {
            flowLayoutPanel1.Controls.Clear();

            ChoseSizeControl[] list = new ChoseSizeControl[5];

            string[] menuname = new string[5] { "test1", "test2", "test3", "test4", "test5" };
            string[] description = new string[5] { "desc1", "desc2", "desc3", "desc4", "desc5" };

            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new ChoseSizeControl();

                list[i].Sizes = menuname[i];

                flowLayoutPanel1.Controls.Add(list[i]);

                list[i].Click += new System.EventHandler(this.UserControl_Click);
            }

        }

        void UserControl_Click(object sender, EventArgs e)
        {
            ChoseSizeControl obj = (ChoseSizeControl)sender;
            GetSize = obj.Sizes;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ChoseSize_Load(object sender, EventArgs e)
        {
            GenerateControl();
        }
    }


}
