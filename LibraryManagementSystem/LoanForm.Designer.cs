﻿namespace LibraryManagementSystem
{
    partial class LoanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoanForm));
            this.txtUserNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBookID = new System.Windows.Forms.TextBox();
            this.btnLoan = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUserNumber
            // 
            this.txtUserNumber.Location = new System.Drawing.Point(371, 187);
            this.txtUserNumber.Name = "txtUserNumber";
            this.txtUserNumber.Size = new System.Drawing.Size(125, 20);
            this.txtUserNumber.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Book ID";
            // 
            // txtBookID
            // 
            this.txtBookID.Location = new System.Drawing.Point(371, 224);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.Size = new System.Drawing.Size(125, 20);
            this.txtBookID.TabIndex = 2;
            // 
            // btnLoan
            // 
            this.btnLoan.Location = new System.Drawing.Point(371, 269);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Size = new System.Drawing.Size(125, 30);
            this.btnLoan.TabIndex = 4;
            this.btnLoan.Text = "Loan the Book";
            this.btnLoan.UseVisualStyleBackColor = true;
            this.btnLoan.Click += new System.EventHandler(this.btnLoan_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Location = new System.Drawing.Point(56, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(692, 84);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sarasawi Library Management System\r\nBook Loan Form";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBookID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserNumber);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoanForm";
            this.Text = "Loan Form - Library Management System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBookID;
        private System.Windows.Forms.Button btnLoan;
        private System.Windows.Forms.Label label3;
    }
}