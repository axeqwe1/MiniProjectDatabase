using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniProjectDatabase.asset.database;
using System.Data.OracleClient;

namespace MiniProjectDatabase
{
    public partial class EditMenu : Form
    {
        database db = new database();

        public EditMenu(string idt)
        {
            InitializeComponent();

            db.openconnect();

            // Populate the form with the data of the selected employee
            string query = "SELECT * FROM ENVY_MENU WHERE MENU_ID = '" + idt + "'";
            OracleCommand cmd = new OracleCommand(query, db.OracleConnect);
            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Emp_id.Text = reader["MENU_ID"].ToString();
                Fname.Text = reader["MENUNAME"].ToString();
                Lname.Text = reader["DETAIL"].ToString();
                Address.Text = reader["TYPE"].ToString();
            }

            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Emp_id.Text == "" || Fname.Text == "" || Lname.Text == "" ||
                 Address.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลที่จะแก้ไขให้ครบถ้วน");
                Emp_id.Focus();
            }
            else if (MessageBox.Show("คุณต้องการที่จะแก้ไขข้อมูลใช่หรือไม่?", "แก้ไขข้อมูลพนักงาน", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OracleCommand orclcmd = new OracleCommand();
                string temp_sql =  $"UPDATE ENVY_MENU SET MENUNAME = '{Fname.Text}', DETAIL = '{Lname.Text}'," +
                    $"TYPE = '{Address.Text}' WHERE MENU_ID = '{Emp_id.Text}'";
                try
                {
                    db.openconnect();
                    orclcmd.CommandType = CommandType.Text;
                    orclcmd.CommandText = temp_sql;
                    orclcmd.Connection = db.OracleConnect;
                    int rowaffected = orclcmd.ExecuteNonQuery();
                    MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Emp_id.Focus();
                }
            }
        }
    }
}
