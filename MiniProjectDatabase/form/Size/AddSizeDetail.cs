using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;
using MiniProjectDatabase.asset.database;

namespace MiniProjectDatabase.form
{
    public partial class AddSizeDetail : Form
    {
        database db = new database();
        public AddSizeDetail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.openconnect();
            OracleCommand orcl;
            string command;
            int rowaffeted;
            OracleDataAdapter da;
            DataSet ds = new DataSet();


            da = new OracleDataAdapter($"SELECT * FROM ENVY_SIZE WHERE SIZE_ID = '{sizeID_text.Text}'",db.OracleConnect);
            rowaffeted = da.Fill(ds,"size");
            if (sizeID_text.Text == "" || sizeName_text.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ","WARNING",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                if (rowaffeted == 0)
                {
                    command = "INSERT INTO ENVY_SIZE (SIZE_ID,SIZENAME)";
                    command += $"VALUES('{sizeID_text.Text}','{sizeName_text.Text}')";

                    orcl = new OracleCommand();
                    try
                    {
                        orcl.CommandType = CommandType.Text;
                        orcl.CommandText = command;
                        orcl.Connection = db.OracleConnect;
                        rowaffeted = orcl.ExecuteNonQuery();
                        db.OracleConnect.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("SIZE_ID ซ้ำกัน กรูณาใช้ ID อื่น","WARNING",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }


            refresh();


        }
        private void refresh()
        {
            OracleDataAdapter da;
            DataSet ds1;
            ds1 = new DataSet();


            string temp_sql = $"SELECT * FROM ENVY_SIZE ORDER BY SIZE_ID ASC";

            da = new OracleDataAdapter(temp_sql, db.OracleConnect);

            da.Fill(ds1, "size");

            sizedatagrid.DataSource = ds1;
            sizedatagrid.DataMember = "size";

            DataGridViewColumn c1, c2;
            c1 = sizedatagrid.Columns[0];
            c2 = sizedatagrid.Columns[1];

            c1.Width = 80;
            c2.Width = 125;
        }
        private void AddSizeDetail_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            AddMenu fs = new AddMenu();
            fs.refresh();
        }
    }
}
