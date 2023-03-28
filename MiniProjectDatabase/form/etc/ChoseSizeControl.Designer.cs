
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
            this.sizeLab.AutoSize = true;
            this.sizeLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeLab.Location = new System.Drawing.Point(66, 37);
            this.sizeLab.Name = "sizeLab";
            this.sizeLab.Size = new System.Drawing.Size(67, 31);
            this.sizeLab.TabIndex = 0;
            this.sizeLab.Text = "Size";
            // 
            // ChoseSizeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.Controls.Add(this.sizeLab);
            this.Name = "ChoseSizeControl";
            this.Size = new System.Drawing.Size(210, 106);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sizeLab;
    }
}
