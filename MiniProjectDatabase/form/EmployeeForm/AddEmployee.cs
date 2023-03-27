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

namespace MiniProjectDatabase.form
{
    public partial class AddEmployee : Form
    {
        database db = new database();
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void refresh_grid()
        {
            OracleDataAdapter da;
            DataSet ds1;
            ds1 = new DataSet();

            string temp_sql1 = $"SELECT EMP_ID, FNAME, LNAME, TEL, ADDRESS FROM ENVY_EMPLOYEE";

            da = new OracleDataAdapter(temp_sql1, db.OracleConnect);

            da.Fill(ds1, "ENVY_EMPLOYEE");

            dataGridView1.DataSource = ds1;
            dataGridView1.DataMember = "ENVY_EMPLOYEE";

            dataGridView1.Columns[0].HeaderText = "รหัสพนักงาน";
            dataGridView1.Columns[1].HeaderText = "ชื่อ";
            dataGridView1.Columns[2].HeaderText = "นามสกุล";
            dataGridView1.Columns[3].HeaderText = "เบอร์โทร";
            dataGridView1.Columns[4].HeaderText = "ที่อยู่";
        }

        private void ADD_EMP_Click(object sender, EventArgs e)
        {
            OracleDataAdapter da;
            DataSet ds;
            OracleCommand orclcmd;
            orclcmd = new OracleCommand();
            int rowaffected;
            ds = new DataSet();
            string orclcommand;

            da = new OracleDataAdapter("SELECT * FROM ENVY_EMPLOYEE where EMP_ID = '" + txtID_EMP.Text + "'", db.OracleConnect);

            string temp_sql1 = $"INSERT INTO ENVY_EMPLOYEE (EMP_ID, FNAME, LNAME, TEL, ADDRESS) VALUES ('{txtID_EMP.Text}', " +
                $"'{txtFNAME_EMP.Text}', '{txtLNAME_EMP.Text}', '{txtTEL_EMP.Text}', '{txtADDRESS_EMP.Text}')";

            rowaffected = da.Fill(ds, "EMPLOYEE");

            if(txtID_EMP.Text == "" || txtFNAME_EMP.Text == "" || txtLNAME_EMP.Text == "" || txtTEL_EMP.Text == "" || txtADDRESS_EMP.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลพนักงานให้ครบถ้วน");
                txtID_EMP.Focus();
                return;
            }

            if (rowaffected == 0)
            {
                orclcommand = "INSERT INTO ENVY_EMPLOYEE (EMP_ID, FNAME, LNAME, TEL, ADDRESS)";
                orclcommand += " VALUES('" + txtID_EMP.Text + "','";
                orclcommand += txtFNAME_EMP.Text + "','";
                orclcommand += txtLNAME_EMP.Text + "','";
                orclcommand += txtTEL_EMP.Text + "','";
                orclcommand += txtADDRESS_EMP.Text + "','";
            }
            else
            {
                orclcommand = "UPDATE ENVY_EMPLOYEE";
                orclcommand += " SET FNAME = '" + txtFNAME_EMP.Text + "',";
                orclcommand += " LNAME = '" + txtLNAME_EMP.Text + "',";
                orclcommand += " TEL = '" + txtTEL_EMP.Text + "','";
                orclcommand += " ADDRESS = '" + txtADDRESS_EMP.Text + "','";
            }

            if (MessageBox.Show("คุณต้องการที่จะเพิ่มข้อมูลหรือไม่?", "เพิ่มข้อมูลพนักงาน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.openconnect();
                try
                {
                    orclcmd.CommandType = CommandType.Text;
                    orclcmd.CommandText = temp_sql1;
                    orclcmd.Connection = db.OracleConnect;
                    rowaffected = orclcmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtID_EMP.Focus();
                }
                MessageBox.Show("เพิ่มข้อมูลสำเร็จ");
                refresh_grid();
            }

        }

        private void CLEAR_EMP_Click(object sender, EventArgs e)
        {
            txtID_EMP.Clear();
            txtFNAME_EMP.Clear();
            txtLNAME_EMP.Clear();
            txtADDRESS_EMP.Clear();
            txtTEL_EMP.Clear();
            txtID_EMP.Focus();
        }

        private void CANCEL_EMP_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            refresh_grid();
        }

        private void DELETE_EMP_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("คุณต้องการที่จะลบข้อมูลหรือไม่?", "ลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rowIndex = dataGridView1.SelectedRows[0].Index;
                    string id = dataGridView1.Rows[rowIndex].Cells["EMP_ID"].Value.ToString();
                    string temp_sql = "DELETE FROM ENVY_EMPLOYEE WHERE EMP_ID = '" + id + "'";
                    try
                    {
                        db.openconnect();
                        OracleCommand orclcmd = new OracleCommand();
                        orclcmd.CommandType = CommandType.Text;
                        orclcmd.CommandText = temp_sql;
                        orclcmd.Connection = db.OracleConnect;
                        int rowaffected = orclcmd.ExecuteNonQuery();
                        refresh_grid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        txtID_EMP.Focus();
                    }
                }
            }
        }

        private void EDIT_EMP_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                if (dataGridView1.SelectedRows.Count > 0 && dataGridView1.SelectedCells.Count == dataGridView1.Columns.Count)
                {
                    string id = dataGridView1.Rows[rowIndex].Cells["EMP_ID"].Value.ToString();
                    EditEmployee editEMP = new EditEmployee(id);
                    editEMP.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกแถวข้อมูลทั้งหมดที่จะแก้ไข");
                }
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

    }
}
