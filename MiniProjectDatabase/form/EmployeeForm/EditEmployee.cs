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
    public partial class EditEmployee : Form
    {
        database db = new database();
        public string Id { get; set; }     

        public EditEmployee(string id)
        {
            InitializeComponent();

            db.openconnect();

            // Populate the form with the data of the selected employee
            string query = "SELECT * FROM ENVY_EMPLOYEE WHERE EMP_ID = '" + id + "'";
            OracleCommand cmd = new OracleCommand(query, db.OracleConnect);
            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txtID_EMP_EDIT.Text = reader["EMP_ID"].ToString();
                txtFNAME_EMP_EDIT.Text = reader["FNAME"].ToString();
                txtLNAME_EMP_EDIT.Text = reader["LNAME"].ToString();
                txtTEL_EMP_EDIT.Text = reader["TEL"].ToString();
                txtADDRESS_EMP_EDIT.Text = reader["ADDRESS"].ToString();
            }

            reader.Close();
        }

        public EditEmployee()
        {
            InitializeComponent();

        }

        private void EditEmployee_Load(object sender, EventArgs e)
        {

        }

        private void CANCEL_EDIT_EMP_Click(object sender, EventArgs e)
        {
            
        }

        private void SAVE_EDIT_EMP_Click(object sender, EventArgs e)
        {
            if (txtID_EMP_EDIT.Text == "" || txtFNAME_EMP_EDIT.Text == "" || txtLNAME_EMP_EDIT.Text == "" ||
                 txtTEL_EMP_EDIT.Text == "" || txtADDRESS_EMP_EDIT.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลที่จะแก้ไขให้ครบถ้วน");
                txtID_EMP_EDIT.Focus();
            }
            else if (MessageBox.Show("คุณต้องการที่จะแก้ไขข้อมูลใช่หรือไม่?", "แก้ไขข้อมูลพนักงาน", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OracleCommand orclcmd = new OracleCommand();
                string temp_sql = $"UPDATE ENVY_EMPLOYEE SET FNAME = '{txtFNAME_EMP_EDIT.Text}', LNAME = '{txtLNAME_EMP_EDIT.Text}'," +
                    $"TEL = '{txtTEL_EMP_EDIT.Text}', ADDRESS = '{txtADDRESS_EMP_EDIT.Text}' WHERE EMP_ID = '{txtID_EMP_EDIT.Text}'";
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
                    txtID_EMP_EDIT.Focus();
                }
            }
        }
    }
}
