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
using MiniProjectDatabase;
using MiniProjectDatabase.asset.lib;
using MiniProjectDatabase.asset.database;

namespace MiniProjectDatabase.form.SaleForm
{
    public partial class SaleForm : Form
    {
        SaleList[] allrecord;
        database db;
        string emp_id;
        double total;
        public SaleForm(List<SaleList> list,string employee)
        {
            InitializeComponent();
            allrecord = list.ToArray();
            db = new database();
            emp_id = employee;
        }
        public void refresh()
        {
            db.openconnect();
            string sql = $"SELECT fname from envy_employee WHERE emp_id = {emp_id}";
            OracleCommand orcl = new OracleCommand(sql,db.OracleConnect);
            OracleDataReader reader = orcl.ExecuteReader();
            
            
            if (reader.Read())
            {
                EMP_Label.Text = reader.GetString(0);
            }
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "ชื่อสินค้า";
            dataGridView1.Columns[1].Name = "รายระเอียดสินค้า";
            dataGridView1.Columns[2].Name = "ขนาดสินค้า";
            dataGridView1.Columns[3].Name = "ราคา/ชิ้น";
            dataGridView1.Columns[4].Name = "จำนวน";
            dataGridView1.Columns[5].Name = "รวม";
            
            foreach (SaleList s in allrecord)
            {
                dataGridView1.Rows.Add(s.NAME,s.DETAIL,s.SIZE,s.PRICE,s.QTY,s.PRICE * s.QTY);
                total += s.PRICE * s.QTY;
            }
            TotalLabel.Text = $"{total:#,###.00} Bath";
            db.closeconnect();
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            refresh();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatainSale();
            Main openMn = new Main();
            openMn.Visible = true;
            this.Close();

        }

        private void DatainSale()
        {
            db.openconnect();
            OracleCommand orcl;
            OracleDataAdapter da;
            DataSet ds;

            ds = new DataSet();
            int rowaffected;
            string cmd1, cmd2;
            Random rnd = new Random();
            long number = rnd.Next(000000000, 99999999);

            da = new OracleDataAdapter($"SELECT * FROM envy_sale WHERE sale_id = {number}",db.OracleConnect);
            rowaffected = da.Fill(ds, "envy_sale");
            
            DateTime now = DateTime.Now;
            string date = now.ToString("MM/dd/yyyy");
            if (MessageBox.Show("คุณต้องการที่จะทำรายการหรือไม่?", "เพิ่มข้อมูลพนักงาน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                    if (rowaffected == 0)
                    {
                        cmd1 = "INSERT INTO envy_sale (sale_id,sale_date,saletotalprice,emp_id) " +
                           $"VALUES('{number}','{date}','{total}','{emp_id}') ";
                        orcl = new OracleCommand();

                    try
                    {
                        orcl.CommandType = CommandType.Text;
                        orcl.CommandText = cmd1;
                        orcl.Connection = db.OracleConnect;
                        orcl.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
                    foreach (SaleList s in allrecord)
                    {
                        string sql2;
                        sql2 = "SELECT envy_menu.menu_id,envy_size.size_id ";
                        sql2 += "FROM envy_menu_size inner join envy_menu on envy_menu_size.menu_id = envy_menu.menu_id ";
                        sql2 += "inner join envy_size on envy_size.size_id = envy_menu_size.size_id ";
                        sql2 += $"WHERE envy_menu.menuname = '{s.NAME}' AND envy_size.sizename = '{s.SIZE}' ";
                        sql2 += "order by envy_menu.menu_id ASC";
                        OracleCommand text = new OracleCommand(sql2,db.OracleConnect);
                        OracleDataReader reader = text.ExecuteReader();
                        if (reader.Read())
                        {
                            try
                            {
                                cmd2 = "INSERT INTO envy_sale_detail (sale_id,menu_id,size_id,saleamount) " +
                                $"VALUES('{number}','{reader.GetString(0)}','{reader.GetString(1)}','{s.QTY}')";
                                orcl.CommandType = CommandType.Text;
                                orcl.CommandText = cmd2;
                                orcl.Connection = db.OracleConnect;
                                rowaffected = orcl.ExecuteNonQuery();
                            
                            }catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    if(rowaffected > 0)
                    {
                        MessageBox.Show("ทำรายการเสร็จสิ้น","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("รหัสสินค้าซ้ำกรุณากดทำรายการให้มอีกรอบ");
                }
            }
            db.closeconnect();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Red;

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
        }
    }
}
