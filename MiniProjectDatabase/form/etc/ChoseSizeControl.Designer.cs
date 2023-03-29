
namespace MiniProjectDatabase.form.etc
{
    partial class ChoseSizeControl
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
            this.sizeLab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sizeLab
            // 
            this.sizeLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeLab.Location = new System.Drawing.Point(25, 0);
            this.sizeLab.Name = "sizeLab";
            this.sizeLab.Size = new System.Drawing.Size(155, 28);
            this.sizeLab.TabIndex = 0;
            this.sizeLab.Text = "Size";
            this.sizeLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChoseSizeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.sizeLab);
            this.Name = "ChoseSizeControl";
            this.Size = new System.Drawing.Size(206, 102);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label sizeLab;
    }
}
