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
        string _sizeId;
        public ChoseSizeControl()
        {
            InitializeComponent();
            sizeLab.Left = (this.ClientSize.Width - sizeLab.Width) / 2;
            sizeLab.Top = (this.ClientSize.Height - sizeLab.Height) / 2;

        }

        [Category("Size")]
        public string Sizes
        {
            get { return _size; }
            set { _size = value; sizeLab.Text = value; }
        }

        public string SizeIDs
        {
            get { return _sizeId; }
            set { _sizeId = value;  }
        }
    }
}
