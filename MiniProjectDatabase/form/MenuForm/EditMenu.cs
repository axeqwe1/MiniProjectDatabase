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

namespace MiniProjectDatabase
{
    public partial class EditMenu : Form
    {
        byte[] byteImg;
        string filename;
        database db = new database();

        public EditMenu(string id)
        {
            InitializeComponent();

            db.openconnect();

            // Populate the form with the data of the selected employee
            string query = "SELECT * FROM ENVY_MENU WHERE MENU_ID = '" + id + "'";
            OracleCommand cmd = new OracleCommand(query, db.OracleConnect);
            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txtMenu_ID.Text = reader["MENU_ID"].ToString();
                txtMenu_Name.Text = reader["MENUNAME"].ToString();
                txtMenu_Detail.Text = reader["DETAIL"].ToString();
                //txtMenu_Price.Text = reader["PRICE"].ToString();
                txtMenu_Type.Text = reader["TYPE"].ToString();
                //comboMenu_SIze.SelectedItem = reader["SIZENAME"].ToString();  
            }
            reader.Close();
        }

        public void saveimage(string filename)
        {
            //Create a Folder in your Root directory on your solution.
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("กรุณาใส่รูปภาพ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void chosefile_btn_Click_1(object sender, EventArgs e)
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
                OracleCommand orclcmd = new OracleCommand();
                string temp_sql1 =  $"UPDATE ENVY_MENU SET MENUNAME = '{txtMenu_Name.Text}', DETAIL = '{txtMenu_Detail.Text}'," +
                    $"TYPE = '{txtMenu_Type.Text}', PICTURE = '{filename}' WHERE MENU_ID = '{txtMenu_ID.Text}'";

                string temp_sql2 = $"UPDATE ENVY_MENU_SIZE SET PRICE = '{txtMenu_Price.Text}', WHERE MENU_ID,SIZE_ID = '{txtMenu_ID.Text}', '{comboMenu_SIze.SelectedValue}' ";
                saveimage(filename);
                try
                {
                    db.openconnect();
                    orclcmd.CommandType = CommandType.Text;
                    orclcmd.CommandText = temp_sql1;
                    orclcmd.CommandText = temp_sql2;
                    orclcmd.Connection = db.OracleConnect;
                    int rowaffected = orclcmd.ExecuteNonQuery();
                    MessageBox.Show("แก้ไขข้อมูลสำเร็จ");
                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtMenu_ID.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
