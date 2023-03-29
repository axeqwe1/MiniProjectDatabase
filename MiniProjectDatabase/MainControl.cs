using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProjectDatabase
{
    public partial class MainControl : UserControl
    {
        public MainControl()
        {
            InitializeComponent();
        }

        private string _menu_id;
        private Image _image;
        private string _menuname;
        private string _description;
        private double _price;
        [Category("Menu")]
        public string MenuID
        {
            get { return _menu_id; }
            set { _menu_id = value; }
        }
        [Category("Menu")]
        public Image _Image
        {
            get { return _image; }
            set { _image = value; pictureBox1.Image = value; }
        }
        [Category("Menu")]
        public string _Menuname
        {
            get { return _menuname; }
            set { _menuname = value; menuLab.Text = value; }
        }
        [Category("Menu")]
        public string _Description
        {
            get { return _description; }
            set { _description = value; descLab.Text = value; }
        }
        [Category("Menu")]
        public double _Price
        {
            get { return _price; }
            set { _price = value;}
        }

        private void picMenu_Click(object sender, EventArgs e)
        {

        }
    }
}
