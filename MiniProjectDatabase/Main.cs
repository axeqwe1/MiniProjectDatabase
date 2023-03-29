using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OracleClient;
using MiniProjectDatabase.form;
using MiniProjectDatabase.form.etc;
using MiniProjectDatabase.asset.lib;
using MiniProjectDatabase.asset.database;
namespace MiniProjectDatabase
{
    public partial class Main : Form
    {
        database db = new database();
        private int currentDatainDataGridView; // use for check repeat data in datagridview
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMenu fs = new AddMenu();
            this.Hide();
            fs.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddEmploy AddEMPForm = new AddEmploy();
            AddEMPForm.Show();
            this.Hide();
        }
       /* public void refresh()
        {
            OracleDataAdapter da1;
            DataSet ds1, ds2;
            ds1 = new DataSet();


            string temp_sql1 = $"SELECT menu_id,menuname,detail,type FROM ENVY_MENU ORDER BY menu_id ASC";

            da1 = new OracleDataAdapter(temp_sql1, db.OracleConnect);


            DataGridViewColumn c1, c2, c3;

        } */
        public void GenerateControl()
        {
            flowLayoutPanel1.Controls.Clear();
            db.openconnect();
            string sql = "SELECT envy_menu.menu_id ,envy_menu.menuname ,envy_menu.detail  ,envy_menu.type ,envy_menu.PICTURE ";
            sql += "FROM envy_menu_size inner join envy_menu on envy_menu_size.menu_id = envy_menu.menu_id ";
            sql += "inner join envy_size on envy_size.size_id = envy_menu_size.size_id ";
            sql += "Group by envy_menu.menu_id,envy_menu.menuname,envy_menu.detail,envy_menu.type ,envy_menu.PICTURE order by envy_menu.menu_id ASC ";
            
            OracleCommand orcl = new OracleCommand(sql,db.OracleConnect);
            OracleDataReader reader = orcl.ExecuteReader();
            MenuList[] allrecord;
            List<MenuList> mlist = new List<MenuList>();
            while (reader.Read())
            {
                mlist.Add(new MenuList {MenuId = reader.GetString(0), NAME = reader.GetString(1),Detail = reader.GetString(2),Type = reader.GetString(3), Picture = reader.GetString(4) });
            }
            allrecord = mlist.ToArray();
            int x = 0;
            string[] menuid = new string[allrecord.Length];
            string[] menuname = new string[allrecord.Length];
            string[] description = new string[allrecord.Length];
            string[] picture = new string[allrecord.Length];
            double[] price = new double[allrecord.Length];
            foreach (MenuList s in mlist)
            {
                menuid[x] = s.MenuId;
                menuname[x] = s.NAME;
                description[x] = s.Detail;
                picture[x] = s.Picture;
                price[x] = s.Price;
                x++;
            }
            //_____
            MainControl[] list = new MainControl[allrecord.Length];

            for (int i = 0; i< list.Length; i++)
            {
                string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\";
                string folderPath = "asset\\img\\";
                string filename = picture[i];
                string mix = projectPath + folderPath + filename;
                list[i] = new MainControl();
                Image IMG = resizeImage(Image.FromFile(mix) , new Size(135, 135));
                list[i].MenuID = menuid[i];
                list[i]._Menuname = menuname[i];
                list[i]._Description = description[i];
                list[i]._Image = IMG;
                list[i]._Price = price[i];
                flowLayoutPanel1.Controls.Add(list[i]);

                list[i].Click += new System.EventHandler(this.UserControl_Click);
            }
            
        }

        void UserControl_Click(object sender,EventArgs e)
        {
            MainControl obj = (MainControl)sender;
            ChoseSize sz = new ChoseSize(obj.MenuID);
            sz.ShowDialog();
            if(sz.DialogResult == DialogResult.OK)
            {
                string sql2 = "SELECT envy_menu_size.price ";
                sql2 += "FROM envy_menu_size inner join envy_menu on envy_menu_size.menu_id = envy_menu.menu_id ";
                sql2 += "inner join envy_size on envy_size.size_id = envy_menu_size.size_id ";
                sql2 += $"WHERE envy_menu.menu_id = {obj.MenuID} AND envy_size.size_id = {sz.GetSizeID}";
                int count = 0;
                OracleCommand orcl = new OracleCommand(sql2, db.OracleConnect);
                OracleDataReader reader = orcl.ExecuteReader();
                string abc = "";
                if (reader.Read())
                {
                    abc = obj._Menuname + obj._Description + sz.GetSize + reader.GetDouble(0).ToString();
                    if (DataInGrid(abc))
                    {
                        int number = int.Parse(dataGridView1.Rows[currentDatainDataGridView].Cells[4].Value.ToString());
                        dataGridView1.Rows[currentDatainDataGridView].Cells[4].Value = (number + 1).ToString();
                        //dataGridView1.Rows[currentData].Cells[4].Value = ;
                    }
                    else
                    {
                        dataGridView1.Rows.Add(obj._Menuname, obj._Description, sz.GetSize, reader.GetDouble(0).ToString(),Convert.ToString(++count));
                    }
                }
                
            }
            
            
        }

        private void Main_Load(object sender, EventArgs e)
        {

            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[0].Name = "ชื่อสินค้า";
            dataGridView1.Columns[1].Name = "รายระเอียด";
            dataGridView1.Columns[2].Name = "ขนาด";
            dataGridView1.Columns[3].Name = "ราคา";
            dataGridView1.Columns[4].Name = "จำนวน";
            GenerateControl();
        }

        private System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        private bool DataInGrid(string text)
        {
            string[] strC = new string[dataGridView1.RowCount];
            string temp_text = "";
            for (int i = 0; i < dataGridView1.RowCount - 1; i++) //compare data
            {
                var Row = dataGridView1.Rows[i];
                strC[i] = Row.Cells[0].Value.ToString() +Row.Cells[1].Value.ToString() + Row.Cells[2].Value.ToString() + Row.Cells[3].Value.ToString();
                if(strC[i] == text)
                {
                    temp_text = strC[i];
                    currentDatainDataGridView = i;
                }
            }
            if (temp_text == text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
