using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniProjectDatabase;
using MiniProjectDatabase.asset.lib;
using MiniProjectDatabase.asset.database;

namespace MiniProjectDatabase.form.SaleForm
{
    public partial class SaleForm : Form
    {
        SaleList[] allrecord;
        
        public SaleForm(List<SaleList> list)
        {
            InitializeComponent();
            allrecord = list.ToArray();
            foreach (SaleList s in allrecord)
            {
                MessageBox.Show(s.NAME + " " + s.DETAIL + " " + s.SIZE + " " + s.PRICE.ToString() + " " + s.QTY.ToString());
            }
        }
    }
}
