using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProjectDatabase.asset.database;
using System.Data.OracleClient;
using System.Windows.Forms;

namespace MiniProjectDatabase.form
{
    public partial class SaleDetail : Form
    {
        database db = new database();
        public SaleDetail()
        {
            InitializeComponent();
        }

        private void refresh()
        {
            db.openconnect();
            string sql = "SELECT envy_sale_detail.sale_id ,envy_sale_detail.menu_id ,envy_sale_detail.size_id ,envy_sale_detail.saleamount,envy_sale.sale_date " +
                   "FROM envy_sale_detail inner join envy_sale ON " +
                   "envy_sale.sale_id = envy_sale_detail.sale_id " +
                   "ORDER by envy_sale_detail.menu_id ASC ";

            OracleCommand orcl = new OracleCommand(sql, db.OracleConnect);
            OracleDataReader reader = orcl.ExecuteReader();

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "รหัสการขาย";
            dataGridView1.Columns[1].Name = "รหัสเมนู";
            dataGridView1.Columns[2].Name = "รหัสไซส์";
            dataGridView1.Columns[3].Name = "จำนวนที่ขาย";
            dataGridView1.Columns[4].Name = "วันที่ขาย";
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));

            }
        }

        private void SaleDetail_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main mn = new Main();
            mn.Visible = true;
            this.Close();
        }
    }
}
