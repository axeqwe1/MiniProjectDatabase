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

namespace MiniProjectDatabase.form
{
    public partial class AddMenu : Form
    {
        byte[] byteimg;
        string filename;
        Image IMG;
        public AddMenu()
        {
            InitializeComponent();
        }

        private void addmenu_btn_Click(object sender, EventArgs e)
        {
            database test = new database();
            test.openconnect();

            saveimage(filename);



        }

        private void oracleConnection1_InfoMessage(object sender, System.Data.OracleClient.OracleInfoMessageEventArgs e)
        {

        }
        public void saveimage(string filename)
        {
             //Create a Folder in your Root directory on your solution.
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\";
            string folderPath = "asset\\img\\";
            string imagePath = projectPath + folderPath + filename;
            MessageBox.Show(imagePath);
            MemoryStream ms = new MemoryStream(byteimg);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

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
                try
                {
                    byteimg = System.IO.File.ReadAllBytes(file);
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(byteimg);
                    img = new Bitmap(byteArrayToImage(byteimg));
                    Image IMG = resizeImage(img, new Size(150, 150));
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
    }
}
