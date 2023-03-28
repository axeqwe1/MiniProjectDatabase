
namespace MiniProjectDatabase.form
{
    partial class AddEmployee
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFNAME_EMP = new System.Windows.Forms.TextBox();
            this.txtLNAME_EMP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTEL_EMP = new System.Windows.Forms.TextBox();
            this.txtADDRESS_EMP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ADD_EMP = new System.Windows.Forms.Button();
            this.CLEAR_EMP = new System.Windows.Forms.Button();
            this.txtID_EMP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.EDIT_EMP = new System.Windows.Forms.Button();
            this.DELETE_EMP = new System.Windows.Forms.Button();
            this.CANCEL_EMP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 352);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(609, 200);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "FirstName";
            // 
            // txtFNAME_EMP
            // 
            this.txtFNAME_EMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFNAME_EMP.Location = new System.Drawing.Point(128, 79);
            this.txtFNAME_EMP.Margin = new System.Windows.Forms.Padding(2);
            this.txtFNAME_EMP.Name = "txtFNAME_EMP";
            this.txtFNAME_EMP.Size = new System.Drawing.Size(143, 26);
            this.txtFNAME_EMP.TabIndex = 2;
            // 
            // txtLNAME_EMP
            // 
            this.txtLNAME_EMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLNAME_EMP.Location = new System.Drawing.Point(128, 109);
            this.txtLNAME_EMP.Margin = new System.Windows.Forms.Padding(2);
            this.txtLNAME_EMP.Name = "txtLNAME_EMP";
            this.txtLNAME_EMP.Size = new System.Drawing.Size(143, 26);
            this.txtLNAME_EMP.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "LastName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tel";
            // 
            // txtTEL_EMP
            // 
            this.txtTEL_EMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTEL_EMP.Location = new System.Drawing.Point(128, 138);
            this.txtTEL_EMP.Margin = new System.Windows.Forms.Padding(2);
            this.txtTEL_EMP.Name = "txtTEL_EMP";
            this.txtTEL_EMP.Size = new System.Drawing.Size(143, 26);
            this.txtTEL_EMP.TabIndex = 6;
            // 
            // txtADDRESS_EMP
            // 
            this.txtADDRESS_EMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtADDRESS_EMP.Location = new System.Drawing.Point(128, 167);
            this.txtADDRESS_EMP.Margin = new System.Windows.Forms.Padding(2);
            this.txtADDRESS_EMP.Multiline = true;
            this.txtADDRESS_EMP.Name = "txtADDRESS_EMP";
            this.txtADDRESS_EMP.Size = new System.Drawing.Size(290, 98);
            this.txtADDRESS_EMP.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(147, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Employee";
            // 
            // ADD_EMP
            // 
            this.ADD_EMP.Location = new System.Drawing.Point(127, 269);
            this.ADD_EMP.Margin = new System.Windows.Forms.Padding(2);
            this.ADD_EMP.Name = "ADD_EMP";
            this.ADD_EMP.Size = new System.Drawing.Size(116, 36);
            this.ADD_EMP.TabIndex = 10;
            this.ADD_EMP.Text = "เพิ่มข้อมูล";
            this.ADD_EMP.UseVisualStyleBackColor = true;
            this.ADD_EMP.Click += new System.EventHandler(this.ADD_EMP_Click);
            // 
            // CLEAR_EMP
            // 
            this.CLEAR_EMP.Location = new System.Drawing.Point(247, 269);
            this.CLEAR_EMP.Margin = new System.Windows.Forms.Padding(2);
            this.CLEAR_EMP.Name = "CLEAR_EMP";
            this.CLEAR_EMP.Size = new System.Drawing.Size(120, 36);
            this.CLEAR_EMP.TabIndex = 11;
            this.CLEAR_EMP.Text = "ล้างข้อมูล";
            this.CLEAR_EMP.UseVisualStyleBackColor = true;
            this.CLEAR_EMP.Click += new System.EventHandler(this.CLEAR_EMP_Click);
            // 
            // txtID_EMP
            // 
            this.txtID_EMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID_EMP.Location = new System.Drawing.Point(128, 50);
            this.txtID_EMP.Margin = new System.Windows.Forms.Padding(2);
            this.txtID_EMP.Name = "txtID_EMP";
            this.txtID_EMP.Size = new System.Drawing.Size(84, 26);
            this.txtID_EMP.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "EmployeeID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(43, 320);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "รายการพนักงาน";
            // 
            // EDIT_EMP
            // 
            this.EDIT_EMP.Location = new System.Drawing.Point(463, 570);
            this.EDIT_EMP.Margin = new System.Windows.Forms.Padding(2);
            this.EDIT_EMP.Name = "EDIT_EMP";
            this.EDIT_EMP.Size = new System.Drawing.Size(86, 36);
            this.EDIT_EMP.TabIndex = 15;
            this.EDIT_EMP.Text = "แก้ไขข้อมูล";
            this.EDIT_EMP.UseVisualStyleBackColor = true;
            this.EDIT_EMP.Click += new System.EventHandler(this.EDIT_EMP_Click);
            // 
            // DELETE_EMP
            // 
            this.DELETE_EMP.BackColor = System.Drawing.Color.Red;
            this.DELETE_EMP.ForeColor = System.Drawing.Color.Yellow;
            this.DELETE_EMP.Location = new System.Drawing.Point(553, 570);
            this.DELETE_EMP.Margin = new System.Windows.Forms.Padding(2);
            this.DELETE_EMP.Name = "DELETE_EMP";
            this.DELETE_EMP.Size = new System.Drawing.Size(90, 36);
            this.DELETE_EMP.TabIndex = 16;
            this.DELETE_EMP.Text = "ลบข้อมูล";
            this.DELETE_EMP.UseVisualStyleBackColor = false;
            this.DELETE_EMP.Click += new System.EventHandler(this.DELETE_EMP_Click);
            // 
            // CANCEL_EMP
            // 
            this.CANCEL_EMP.Location = new System.Drawing.Point(577, 8);
            this.CANCEL_EMP.Name = "CANCEL_EMP";
            this.CANCEL_EMP.Size = new System.Drawing.Size(75, 36);
            this.CANCEL_EMP.TabIndex = 17;
            this.CANCEL_EMP.Text = "Cancel";
            this.CANCEL_EMP.UseVisualStyleBackColor = true;
            this.CANCEL_EMP.Click += new System.EventHandler(this.CANCEL_EMP_Click);
            // 
            // AddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 626);
            this.Controls.Add(this.CANCEL_EMP);
            this.Controls.Add(this.DELETE_EMP);
            this.Controls.Add(this.EDIT_EMP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtID_EMP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CLEAR_EMP);
            this.Controls.Add(this.ADD_EMP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtADDRESS_EMP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTEL_EMP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLNAME_EMP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFNAME_EMP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddEmployee";
            this.Text = "เพิ่มพนักงาน";
            this.Load += new System.EventHandler(this.AddEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFNAME_EMP;
        private System.Windows.Forms.TextBox txtLNAME_EMP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTEL_EMP;
        private System.Windows.Forms.TextBox txtADDRESS_EMP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ADD_EMP;
        private System.Windows.Forms.Button CLEAR_EMP;
        private System.Windows.Forms.TextBox txtID_EMP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button EDIT_EMP;
        private System.Windows.Forms.Button DELETE_EMP;
        private System.Windows.Forms.Button CANCEL_EMP;
    }
}