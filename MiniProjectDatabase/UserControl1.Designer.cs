
namespace MiniProjectDatabase
{
    partial class UserControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuLab = new System.Windows.Forms.Label();
            this.descLab = new System.Windows.Forms.Label();
            this.priceLab = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuLab
            // 
            this.menuLab.AutoSize = true;
            this.menuLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuLab.Location = new System.Drawing.Point(185, 13);
            this.menuLab.Name = "menuLab";
            this.menuLab.Size = new System.Drawing.Size(141, 26);
            this.menuLab.TabIndex = 2;
            this.menuLab.Text = "MENUNAME";
            // 
            // descLab
            // 
            this.descLab.AutoSize = true;
            this.descLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descLab.Location = new System.Drawing.Point(187, 52);
            this.descLab.Name = "descLab";
            this.descLab.Size = new System.Drawing.Size(77, 17);
            this.descLab.TabIndex = 3;
            this.descLab.Text = "description";
            // 
            // priceLab
            // 
            this.priceLab.AutoSize = true;
            this.priceLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLab.Location = new System.Drawing.Point(397, 111);
            this.priceLab.Name = "priceLab";
            this.priceLab.Size = new System.Drawing.Size(53, 24);
            this.priceLab.TabIndex = 4;
            this.priceLab.Text = "Price";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 144);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 122);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.priceLab);
            this.Controls.Add(this.descLab);
            this.Controls.Add(this.menuLab);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(455, 150);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label menuLab;
        private System.Windows.Forms.Label descLab;
        private System.Windows.Forms.Label priceLab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
