using System;
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
using MiniProjectDatabase.asset.database;
using System.Data.OracleClient;

namespace MiniProjectDatabase.form
{
    public partial class AddMenu : Form
    {
        byte[] byteImg;
        string filename;
        database db = new database();
        public AddMenu()
        {
            InitializeComponent();
        }

        private void addmenu_btn_Click(object sender, EventArgs e)
        {
            
            db.openconnect();
            OracleCommand orcl1;
            string command1,command2;
            int rowaffeted;
            OracleDataAdapter da1, da2;
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();

            da1 = new OracleDataAdapter($"SELECT * FROM ENVY_MENU WHERE menu_id = '{menuID_Text.Text}'", db.OracleConnect);
            da2 = new OracleDataAdapter($"SELECT * FROM ENVY_MENU_SIZE WHERE menu_id = '{menuID_Text.Text}' AND size_id = '{menuSize_Box.SelectedValue}'",db.OracleConnect);
            

            if (radioButton1.Checked == true) {
                rowaffeted = da1.Fill(ds, "menu");
                if (menuID_Text.Text == "" || menuName_Text.Text == "" || menuPrice_Text.Text == "" || menuSize_Box.SelectedIndex < 0  ||menuType_Text.Text == "" ||pictureBox1.Image == null)
                {
                    MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if(MessageBox.Show("Want to insert?","warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        if (rowaffeted == 0)
                        {
                            command1 = "INSERT INTO ENVY_MENU (menu_id,menuname,detail,type,picture)";
                            command1 += $"VALUES('{menuID_Text.Text}','{menuName_Text.Text}','{menuDetail_Text.Text}','{menuType_Text.Text}','{filename}')";
                            command2 = "INSERT INTO ENVY_MENU_SIZE (menu_id,size_id,price)";
                            command2 += $"VALUES('{menuID_Text.Text}','{menuSize_Box.SelectedValue}','{menuPrice_Text.Text}')";

                            saveimage(filename);

                            orcl1 = new OracleCommand();
                            

                            try
                            {
                                orcl1.CommandType = CommandType.Text;
                                orcl1.CommandText = command1;
                                orcl1.Connection = db.OracleConnect;
                                rowaffeted = orcl1.ExecuteNonQuery();
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            try
                            {
                                orcl1.CommandType = CommandType.Text;
                                orcl1.CommandText = command2;
                                orcl1.Connection = db.OracleConnect;
                                rowaffeted = orcl1.ExecuteNonQuery();
                                MessageBox.Show("เพิ่มเมนูสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        }
                        else
                        {
                            MessageBox.Show("ไม่สามารถเพิ่มข้อมูลได้ หมายเลข ID ซ้ำ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else if(radioButton2.Checked == true)
            {
                rowaffeted = da2.Fill(ds2, "menu2");
                if (menuID_Text.Text == "" || menuPrice_Text.Text == "" || menuSize_Box.SelectedIndex < 0)
                {
                    MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (rowaffeted == 0)
                    {
                        command2 = "INSERT INTO ENVY_MENU_SIZE (menu_id,size_id,price)";
                        command2 += $"VALUES('{menuID_Text.Text}','{menuSize_Box.SelectedValue}','{menuPrice_Text.Text}')";

                        orcl1 = new OracleCommand();
                        try
                        {
                            orcl1.CommandType = CommandType.Text;
                            orcl1.CommandText = command2;
                            orcl1.Connection = db.OracleConnect;
                            rowaffeted = orcl1.ExecuteNonQuery();
                            MessageBox.Show("เพิ่มขนาดเมนูสำเร็จ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถเพิ่มข้อมูลได้เนื่องจากมี Size นี้อยู่แล้ว", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            refresh();
        }

        private void oracleConnection1_InfoMessage(object sender, System.Data.OracleClient.OracleInfoMessageEventArgs e)
        {

        }
        public void saveimage(string filename)
        {
             //Create a Folder in your Root directory on your solution.
            if(pictureBox1.Image == null)
            {
                MessageBox.Show("กรุณาใส่รูปภาพ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\";
                string folderPath = "asset\\img\\";
                string imagePath = projectPath + folderPath + filename;
                MessageBox.Show($"รูปภาพเก็บไว้ที่ :: {imagePath}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MemoryStream ms = new MemoryStream(byteImg);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            

        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
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
        private void chosefile_btn_Click(object sender, EventArgs e)
        {
            Bitmap img;
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            
            if (result == DialogResult.OK) // Test result.
            {
                filename = openFileDialog1.SafeFileName;
                string file = openFileDialog1.FileName;
                pictureBox1.BackgroundImage = null;
                try
                {
                    byteImg = System.IO.File.ReadAllBytes(file);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(byteImg);
                    img = new Bitmap(byteArrayToImage(byteImg));
                    Image IMG = resizeImage(img, new Size(269, 233));
                    pictureBox1.Image = IMG;
                    
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            /* OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            DialogResult result = OpenFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string directoryName = Path.GetDirectoryName(OpenFileDialog1.FileName);
                // directoryName now contains the path
                MessageBox.Show(directoryName);
            }
           */
        }

        public void refresh()
        {
            OracleDataAdapter da1,da2;
            DataSet ds1,ds2;
            ds1 = new DataSet();
            ds2 = new DataSet();

            string temp_sql1 = "SELECT envy_menu.menu_id,envy_menu.menuname,envy_menu.detail,envy_menu_size.price,envy_size.sizename,envy_menu.type ";
            temp_sql1 += "FROM envy_menu_size inner join envy_menu on envy_menu_size.menu_id = envy_menu.menu_id ";
            temp_sql1 += "inner join envy_size on envy_size.size_id = envy_menu_size.size_id ";
            temp_sql1 += "order by envy_menu.menu_id ASC";
            string temp_sql2 = $"SELECT * FROM ENVY_SIZE";
            da1 = new OracleDataAdapter(temp_sql1,db.OracleConnect);
            da2 = new OracleDataAdapter(temp_sql2,db.OracleConnect);
            da1.Fill(ds1,"menu");
            da2.Fill(ds2,"size");
            menu_datagrid.DataSource = ds1;
            menu_datagrid.DataMember = "menu";

            DataGridViewColumn c1, c2, c3;
            c1 = menu_datagrid.Columns[1];
            c2 = menu_datagrid.Columns[2];
            c3 = menu_datagrid.Columns[3];
            c1.Width = 175;
            c2.Width = 180;
            c3.Width = 120;
            menu_datagrid.Columns[0].HeaderText = "รหัสสินค้า";
            menu_datagrid.Columns[1].HeaderText = "ชื่อสินค้า";
            menu_datagrid.Columns[2].HeaderText = "รายละเอียด";
            menu_datagrid.Columns[3].HeaderText = "ราคา";
            menu_datagrid.Columns[4].HeaderText = "ขนาด";
            menu_datagrid.Columns[5].HeaderText = "ประเภท";
            menuSize_Box.DataSource = ds2.Tables["size"];
            menuSize_Box.DisplayMember = "SIZENAME";
            menuSize_Box.ValueMember = "SIZE_ID";
            menuSize_Box.SelectedItem = null;
            menuSize_Box.SelectedText = "กรุณาเลิอกขนาด";
        }
        private void AddMenu_Load(object sender, EventArgs e)
        {
            refresh();
            radioButton1.Checked = true;
            menuID_Text.Focus();
            menu_datagrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
            Main fs = new Main();
            fs.Visible = true;
        }

        private void menuPrice_Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void add_size_btn_Click(object sender, EventArgs e)
        {
            AddSizeDetail fs = new AddSizeDetail();
            fs.Visible = true;
        }

        private void editmenu_btn_Click(object sender, EventArgs e)
        {
            OracleDataAdapter da1;
            DataSet ds1 = new DataSet();
            int rowaffected;
            string getId = menuSize_Box.SelectedValue.ToString();
            string temp_sql1 = "SELECT envy_size.size_id,envy_menu.menu_id,envy_menu.menuname,envy_menu.detail,envy_menu_size.price,envy_size.sizename,envy_menu.type ";
            temp_sql1 += "FROM envy_menu_size inner join envy_menu on envy_menu_size.menu_id = envy_menu.menu_id ";
            temp_sql1 += "inner join envy_size on envy_size.size_id = envy_menu_size.size_id ";
            temp_sql1 += $"WHERE envy_menu.menu_id = '{menuID_Text.Text}' ";
            temp_sql1 += "order by envy_menu.menu_id ASC";
            
            da1 = new OracleDataAdapter(temp_sql1,db.OracleConnect);
            rowaffected = da1.Fill(ds1,"menusize");

            if (rowaffected > 0)
            {
                EditMenu editEMP = new EditMenu(menuID_Text.Text, getId);
                this.Hide();
                editEMP.Show();
                
            }
            else
            {
                MessageBox.Show("ไม่พบรหัสสินค้า");
            }
            
            /* if (menu_datagrid.SelectedCells.Count > 0)
             {
                 int rowIndex = menu_datagrid.SelectedCells[0].RowIndex;
                 if (menu_datagrid.SelectedRows.Count > 0 && menu_datagrid.SelectedCells.Count == menu_datagrid.Columns.Count)
                 {
                     string idt = menu_datagrid.Rows[rowIndex].Cells["MENU_ID"].Value.ToString();
                     EditMenu editEMP = new EditMenu(idt);
                     editEMP.Show();
                     this.Hide();
                 }
                 else
                 {
                     MessageBox.Show("กรุณาเลือกแถวข้อมูลทั้งหมดที่จะแก้ไข");
                 }
            */
        }
        

        private void radioButton1_Click(object sender, EventArgs e)
        {
            menuID_Text.Enabled = true;
            menuName_Text.Enabled = true;
            menuDetail_Text.Enabled = true;
            menuType_Text.Enabled = true;
            menuPrice_Text.Enabled = true;
            menuSize_Box.Enabled = true;
            chosefile_btn.Enabled = true;

        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            menuID_Text.Enabled = true;
            menuName_Text.Enabled = false;
            menuDetail_Text.Enabled = false;
            menuType_Text.Enabled = false;
            menuPrice_Text.Enabled = true;
            menuSize_Box.Enabled = true;
            chosefile_btn.Enabled = false;
        }

        private void menu_datagrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = menu_datagrid.Rows[e.RowIndex];
                menuID_Text.Text = row.Cells["MENU_ID"].Value.ToString();
                menuName_Text.Text = row.Cells["MENUNAME"].Value.ToString();
                menuDetail_Text.Text = row.Cells["DETAIL"].Value.ToString();
                menuPrice_Text.Text = row.Cells["PRICE"].Value.ToString();
                menuType_Text.Text = row.Cells["TYPE"].Value.ToString();
                string sizeName = row.Cells["SIZENAME"].Value.ToString();
                int SizeIndex = menuSize_Box.FindStringExact(sizeName);
                if (SizeIndex >= 0)
                {
                    menuSize_Box.SelectedIndex = SizeIndex;
                }
            }
            
        }
    }
}
