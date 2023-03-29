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
                        MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
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

        private void size_edit_btn_Click(object sender, EventArgs e)
        {
            if (sizeID_text.Text == "" || sizeName_text.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลที่จะแก้ไขให้ครบถ้วน");
                sizeID_text.Focus();
            }
            else if (MessageBox.Show("คุณต้องการที่จะแก้ไขข้อมูลใช่หรือไม่?", "แก้ไขข้อมูลพนักงาน", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OracleCommand orclcmd = new OracleCommand();
                string temp_sql = $"UPDATE ENVY_SIZE SET SIZENAME = '{sizeName_text.Text}' WHERE SIZE_ID = '{sizeID_text.Text}'";

                try
                {
                    db.openconnect();
                    orclcmd.CommandType = CommandType.Text;
                    orclcmd.CommandText = temp_sql;
                    orclcmd.Connection = db.OracleConnect;
                    int rowaffected = orclcmd.ExecuteNonQuery();
                    MessageBox.Show("แก้ไขข้อมูลขนาดสำเร็จ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    sizeName_text.Focus();
                }
                refresh();

            }
        }

        private void sizedatagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = sizedatagrid.Rows[e.RowIndex];
                sizeID_text.Text = row.Cells["SIZE_ID"].Value.ToString();
                sizeName_text.Text = row.Cells["SIZENAME"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sizedatagrid.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("คุณต้องการที่จะลบข้อมูลหรือไม่?", "ลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rowIndex = sizedatagrid.SelectedRows[0].Index;
                    string id = sizedatagrid.Rows[rowIndex].Cells["SIZE_ID"].Value.ToString();
                    string temp_sql = "DELETE FROM ENVY_SIZE WHERE SIZE_ID = '" + id + "'";
                    try
                    {
                        db.openconnect();
                        OracleCommand orclcmd = new OracleCommand();
                        orclcmd.CommandType = CommandType.Text;
                        orclcmd.CommandText = temp_sql;
                        orclcmd.Connection = db.OracleConnect;
                        int rowaffected = orclcmd.ExecuteNonQuery();
                        MessageBox.Show("ลบข้อมูลสำเร็จ");
                        refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        sizeID_text.Focus();
                    }
                }
            }
        }

        private void sizeID_text_KeyPress(object sender, KeyPressEventArgs e)
        {
            int num = Convert.ToInt32(e.KeyChar);
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 || num == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
