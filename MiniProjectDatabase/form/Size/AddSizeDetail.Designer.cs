﻿
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
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sizedatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ขนาดภาชนะ";
            // 
            // sizeName_text
            // 
            this.sizeName_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeName_text.Location = new System.Drawing.Point(87, 90);
            this.sizeName_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sizeName_text.Name = "sizeName_text";
            this.sizeName_text.Size = new System.Drawing.Size(98, 26);
            this.sizeName_text.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "รหัสภาชนะ";
            // 
            // sizeID_text
            // 
            this.sizeID_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sizeID_text.Location = new System.Drawing.Point(87, 61);
            this.sizeID_text.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sizeID_text.Name = "sizeID_text";
            this.sizeID_text.Size = new System.Drawing.Size(98, 26);
            this.sizeID_text.TabIndex = 3;
            this.sizeID_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sizeID_text_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 152);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "เพิ่มข้อมูล";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(437, 7);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "CANCEL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(82, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Add Size";
            // 
            // sizedatagrid
            // 
            this.sizedatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sizedatagrid.Location = new System.Drawing.Point(230, 61);
            this.sizedatagrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sizedatagrid.Name = "sizedatagrid";
            this.sizedatagrid.RowHeadersWidth = 51;
            this.sizedatagrid.RowTemplate.Height = 24;
            this.sizedatagrid.Size = new System.Drawing.Size(259, 180);
            this.sizedatagrid.TabIndex = 7;
            this.sizedatagrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sizedatagrid_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(343, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "List";
            // 
            // size_edit_btn
            // 
            this.size_edit_btn.Location = new System.Drawing.Point(33, 189);
            this.size_edit_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.size_edit_btn.Name = "size_edit_btn";
            this.size_edit_btn.Size = new System.Drawing.Size(74, 35);
            this.size_edit_btn.TabIndex = 9;
            this.size_edit_btn.Text = "แก้ไขข้อมูล";
            this.size_edit_btn.UseVisualStyleBackColor = true;
            this.size_edit_btn.Click += new System.EventHandler(this.size_edit_btn_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.ForeColor = System.Drawing.Color.Blue;
            this.button3.Location = new System.Drawing.Point(110, 189);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 35);
            this.button3.TabIndex = 10;
            this.button3.Text = "ลบข้อมูล";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AddSizeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 282);
            this.Controls.Add(this.button3);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button button3;
    }
}