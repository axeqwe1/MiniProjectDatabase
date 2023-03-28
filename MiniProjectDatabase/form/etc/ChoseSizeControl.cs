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
    public partial class ChoseSizeControl : UserControl
    {
        string _size;
        public ChoseSizeControl()
        {
            InitializeComponent();
        }

        [Category("Size")]
        public string Sizes
        {
            get { return _size; }
            set { _size = value;sizeLab.Text = value; }
        }
    }
}
