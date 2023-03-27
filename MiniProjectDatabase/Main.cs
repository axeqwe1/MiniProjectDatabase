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
    }
}
