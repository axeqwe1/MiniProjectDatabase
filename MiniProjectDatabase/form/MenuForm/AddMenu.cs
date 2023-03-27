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
            OracleCommand orcl1,orcl2;
            string command;
            int rowaffeted;
            OracleDataAdapter da1,da2;
            DataSet ds = new DataSet();

            da1 = new OracleDataAdapter($"SELECT * FROM ENVY_MENU WHERE menu_id = '{menuID_Text.Text}'",db.OracleConnect);

            rowaffeted = da1.Fill(ds,"menu");

            if (menuID_Text.Text == "" || menuName_Text.Text == "" || menuPrice_Text.Text == "" || menuSize_Box.SelectedIndex < 0  ||menuType_Text.Text == "" ||pictureBox1.Image == null)
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครับ", "warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (menuPrice_Text.Text is int)
            {
                MessageBox.Show("ราคาใส่ได้แค่ตัวเลขเท่านั้น");
                menuPrice_Text.Focus();
            }
            if(rowaffeted == 0)
            {
                command = "INSERT INTO ENVY_MENU (menu_id,menuname,detail,type,picture)";
                command += $"VALUES('{menuID_Text.Text}','{menuName_Text.Text}','{menuDetail_Text.Text}','{menuType_Text.Text}','{filename}')";
            }



            saveimage(filename);

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

            string temp_sql1 = $"SELECT menu_id,menuname,detail,type FROM ENVY_MENU ORDER BY menu_id ASC";
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
            c2.Width = 300;
            c3.Width = 120;
            
            menuSize_Box.DataSource = ds2.Tables["size"];
            menuSize_Box.DisplayMember = "SIZENAME";
            menuSize_Box.ValueMember = "SIZE_ID";
            menuSize_Box.SelectedItem = null;
            menuSize_Box.SelectedText = "กรุณาเลิอกขนาด";
        }
        private void AddMenu_Load(object sender, EventArgs e)
        {
            refresh();
            menuID_Text.Focus();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
