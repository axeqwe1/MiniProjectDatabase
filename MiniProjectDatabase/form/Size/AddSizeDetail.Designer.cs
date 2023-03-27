
namespace MiniProjectDatabase.form
{
    partial class AddSizeDetail
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.sizeName_text = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sizeID_text = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.sizedatagrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.size_edit_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sizedatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SizeName";
            // 
            // sizeName_text
            // 
            this.sizeName_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeName_text.Location = new System.Drawing.Point(130, 104);
            this.sizeName_text.Name = "sizeName_text";
            this.sizeName_text.Size = new System.Drawing.Size(129, 30);
            this.sizeName_text.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "SizeID";
            // 
            // sizeID_text
            // 
            this.sizeID_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeID_text.Location = new System.Drawing.Point(130, 68);
            this.sizeID_text.Name = "sizeID_text";
            this.sizeID_text.Size = new System.Drawing.Size(129, 30);
            this.sizeID_text.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(585, 292);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 43);
            this.button2.TabIndex = 5;
            this.button2.Text = "CANCEL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(124, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 33);
            this.label3.TabIndex = 6;
            this.label3.Text = "Add Size";
            // 
            // sizedatagrid
            // 
            this.sizedatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sizedatagrid.Location = new System.Drawing.Point(339, 51);
            this.sizedatagrid.Name = "sizedatagrid";
            this.sizedatagrid.RowHeadersWidth = 51;
            this.sizedatagrid.RowTemplate.Height = 24;
            this.sizedatagrid.Size = new System.Drawing.Size(345, 222);
            this.sizedatagrid.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(489, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 33);
            this.label4.TabIndex = 8;
            this.label4.Text = "List";
            // 
            // size_edit_btn
            // 
            this.size_edit_btn.Location = new System.Drawing.Point(192, 181);
            this.size_edit_btn.Name = "size_edit_btn";
            this.size_edit_btn.Size = new System.Drawing.Size(99, 43);
            this.size_edit_btn.TabIndex = 9;
            this.size_edit_btn.Text = "EDIT";
            this.size_edit_btn.UseVisualStyleBackColor = true;
            // 
            // AddSizeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 347);
            this.Controls.Add(this.size_edit_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sizedatagrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sizeID_text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sizeName_text);
            this.Controls.Add(this.label1);
            this.Name = "AddSizeDetail";
            this.Text = "AddSizeDetail";
            this.Load += new System.EventHandler(this.AddSizeDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sizedatagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sizeName_text;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sizeID_text;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView sizedatagrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button size_edit_btn;
    }
}