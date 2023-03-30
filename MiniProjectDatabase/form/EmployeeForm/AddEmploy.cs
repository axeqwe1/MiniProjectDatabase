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
    public partial class AddEmploy : Form
    {
        database db = new database();
        public DataGridView EMP_dataGrid
        {
            get { return EMP_datagridview; }
            set { EMP_datagridview = value; }
        }
        public AddEmploy()
        {
            InitializeComponent();
        }
        public void refresh_grid()
        {
            OracleDataAdapter da;
            DataSet ds1;
            ds1 = new DataSet();

            string temp_sql1 = $"SELECT EMP_ID, FNAME, LNAME, TEL, ADDRESS FROM ENVY_EMPLOYEE";

            da = new OracleDataAdapter(temp_sql1, db.OracleConnect);

            da.Fill(ds1, "ENVY_EMPLOYEE");

            EMP_datagridview.DataSource = ds1;
            EMP_datagridview.DataMember = "ENVY_EMPLOYEE";

            EMP_datagridview.Columns[0].HeaderText = "รหัสพนักงาน";
            EMP_datagridview.Columns[1].HeaderText = "ชื่อ";
            EMP_datagridview.Columns[2].HeaderText = "นามสกุล";
            EMP_datagridview.Columns[3].HeaderText = "เบอร์โทร";
            EMP_datagridview.Columns[4].HeaderText = "ที่อยู่";
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

            if (txtID_EMP.Text == "" || txtFNAME_EMP.Text == "" || txtLNAME_EMP.Text == "" || txtTEL_EMP.Text == "" || txtADDRESS_EMP.Text == "")
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

        private void AddEmploy_Load(object sender, EventArgs e)
        {
            refresh_grid();
            EMP_datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DELETE_EMP_Click(object sender, EventArgs e)
        {
            if (EMP_datagridview.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("คุณต้องการที่จะลบข้อมูลหรือไม่?", "ลบข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rowIndex = EMP_datagridview.SelectedRows[0].Index;
                    string id = EMP_datagridview.Rows[rowIndex].Cells["EMP_ID"].Value.ToString();
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
            if (EMP_datagridview.SelectedCells.Count > 0)
            {
                int rowIndex = EMP_datagridview.SelectedCells[0].RowIndex;
                if (EMP_datagridview.SelectedRows.Count > 0 && EMP_datagridview.SelectedCells.Count == EMP_datagridview.Columns.Count)
                {
                    string id = EMP_datagridview.Rows[rowIndex].Cells["EMP_ID"].Value.ToString();
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

        private void EDIT_EMP_MouseEnter(object sender, EventArgs e)
        {
            EDIT_EMP.BackColor = Color.Green;
        }

        private void EDIT_EMP_MouseLeave(object sender, EventArgs e)
        {
            EDIT_EMP.BackColor = Color.White;
        }

        private void DELETE_EMP_MouseEnter(object sender, EventArgs e)
        {
            DELETE_EMP.BackColor = Color.Red;

        }

        private void DELETE_EMP_MouseLeave_1(object sender, EventArgs e)
        {
            DELETE_EMP.BackColor = Color.White;
        }

        private void CLEAR_EMP_MouseEnter(object sender, EventArgs e)
        {
            CLEAR_EMP.BackColor = Color.Red;
        }

        private void CLEAR_EMP_MouseLeave(object sender, EventArgs e)
        {
            CLEAR_EMP.BackColor = Color.White;
        }

        private void ADD_EMP_MouseEnter(object sender, EventArgs e)
        {
            ADD_EMP.BackColor = Color.Green;
        }

        private void ADD_EMP_MouseLeave(object sender, EventArgs e)
        {
            ADD_EMP.BackColor = Color.White;
        }

        private void CANCEL_EMP_MouseEnter(object sender, EventArgs e)
        {
            CANCEL_EMP.BackColor = Color.Red;
        }

        private void CANCEL_EMP_MouseLeave(object sender, EventArgs e)
        {
            CANCEL_EMP.BackColor = Color.White;
        }
    }
}
