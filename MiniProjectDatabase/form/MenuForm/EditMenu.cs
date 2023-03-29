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
using MiniProjectDatabase.form;
using System.Data.OracleClient;

namespace MiniProjectDatabase
{
    public partial class EditMenu : Form
    {
        byte[] byteImg;
        string filename;
        string checkfilename;
        string id, size_id;
        database db = new database();

        public EditMenu(string id,string size_id)
        {
            InitializeComponent();
            this.id = id;
            this.size_id = size_id;

        }

        public void saveimage(string filename)
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\";
            string folderPath = "asset\\img\\";
            string imagePath = projectPath + folderPath + filename;
            //Create a Folder in your Root directory on your solution.
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("กรุณาใส่รูปภาพ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (File.Exists(imagePath)) 
            {
                
            }
            else
            {
                
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
        private void chosefile_btn_Click_1(object sender, EventArgs e)
        {
            Bitmap img;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMenu_ID.Text == "" || txtMenu_Name.Text == "" || txtMenu_Detail.Text == "" ||
                 txtMenu_Type.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูลที่จะแก้ไขให้ครบถ้วน");
                txtMenu_ID.Focus();
            }
            else if (MessageBox.Show("คุณต้องการที่จะแก้ไขข้อมูลใช่หรือไม่?", "แก้ไขข้อมูลพนักงาน", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                db.openconnect();
                OracleCommand orclcmd;
                string temp_sql1 =  $"UPDATE ENVY_MENU SET MENUNAME = '{txtMenu_Name.Text}', DETAIL = '{txtMenu_Detail.Text}'," +
                    $"TYPE = '{txtMenu_Type.Text}', PICTURE = '{filename}' WHERE MENU_ID = '{id}' ";

                string temp_sql2 = $"UPDATE ENVY_MENU_SIZE SET PRICE = '{txtMenu_Price.Text}' WHERE MENU_ID = '{id}' AND SIZE_ID = '{size_id}' ";

                saveimage(filename);

                orclcmd =  new OracleCommand();
                try
                {
                    
                    orclcmd.CommandType = CommandType.Text;
                    orclcmd.CommandText = temp_sql1;
                    orclcmd.Connection = db.OracleConnect;
                    orclcmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtMenu_ID.Focus();
                }
                try
                {
                    
                    orclcmd.CommandType = CommandType.Text;
                    orclcmd.CommandText = temp_sql2;
                    orclcmd.Connection = db.OracleConnect;
                    orclcmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtMenu_ID.Focus();
                }
                AddMenu fs = new AddMenu();
                Main f1 = new Main();
                f1.GenerateControl();
                db.OracleConnect.Close();
                this.Close();
                fs.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            AddMenu Menu = new AddMenu();
            Menu.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        public void refresh()
        {
            OracleDataAdapter  da2;
            DataSet  ds2;
            ds2 = new DataSet();

            string temp_sql2 = $"SELECT * FROM ENVY_SIZE";
            da2 = new OracleDataAdapter(temp_sql2, db.OracleConnect);
            da2.Fill(ds2, "size");


            comboMenu_SIze.DataSource = ds2.Tables["size"];
            comboMenu_SIze.DisplayMember = "SIZENAME";
            comboMenu_SIze.ValueMember = "SIZE_ID";

        }
        private void read()
        {
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\";
            string folderPath = "asset\\img\\";
            string imagePath = projectPath + folderPath;
            db.openconnect();
            // Populate the form with the data of the selected employee
            string temp_sql1 = "SELECT envy_menu.menu_id,envy_size.size_id ,envy_menu.menuname ,envy_menu.detail ,envy_menu_size.price ,envy_size.sizename ,envy_menu.type ,envy_menu.picture ";
            temp_sql1 += "FROM envy_menu_size inner join envy_menu on envy_menu_size.menu_id = envy_menu.menu_id ";
            temp_sql1 += "inner join envy_size on envy_size.size_id = envy_menu_size.size_id ";
            temp_sql1 += $"WHERE envy_menu.menu_id = '{id}' AND envy_size.size_id = '{size_id}' ";
            temp_sql1 += "order by envy_menu.menu_id ASC";
            OracleCommand cmd = new OracleCommand(temp_sql1, db.OracleConnect);
            OracleDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                txtMenu_ID.Text = reader["MENU_ID"].ToString();
                txtMenu_Name.Text = reader["MENUNAME"].ToString();
                txtMenu_Detail.Text = reader["DETAIL"].ToString();
                txtMenu_Price.Text = reader["PRICE"].ToString();
                txtMenu_Type.Text = reader["TYPE"].ToString();
                comboMenu_SIze.SelectedValue = reader["size_id"].ToString();
                pictureBox1.BackgroundImage = null;
                filename = reader["picture"].ToString();
                Image IMG = resizeImage(Image.FromFile(imagePath + reader["picture"].ToString()), new Size(269, 233));
                pictureBox1.Image = IMG;
            }
            reader.Close();
            
        }
        private void EditMenu_Load(object sender, EventArgs e)
        {
            
            refresh();
            read();
            txtMenu_ID.Enabled = false;
            comboMenu_SIze.Enabled = false;
        }
    }
}
