namespace FileChangeDetection
{
    partial class AddFile
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
            this.close = new System.Windows.Forms.Label();
            this.minimise = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNavConstantCheck = new System.Windows.Forms.Button();
            this.btnNavCompareFile = new System.Windows.Forms.Button();
            this.btnNavAddFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.tbMD5Hash = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnComputeHash = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSHA256Hash = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSHA512Hash = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(812, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(30, 29);
            this.close.TabIndex = 5;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // minimise
            // 
            this.minimise.AutoSize = true;
            this.minimise.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimise.Location = new System.Drawing.Point(777, 9);
            this.minimise.Name = "minimise";
            this.minimise.Size = new System.Drawing.Size(29, 29);
            this.minimise.TabIndex = 4;
            this.minimise.Text = "--";
            this.minimise.Click += new System.EventHandler(this.minimise_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnNavConstantCheck);
            this.panel1.Controls.Add(this.btnNavCompareFile);
            this.panel1.Controls.Add(this.btnNavAddFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 443);
            this.panel1.TabIndex = 14;
            // 
            // btnNavConstantCheck
            // 
            this.btnNavConstantCheck.BackColor = System.Drawing.Color.White;
            this.btnNavConstantCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavConstantCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavConstantCheck.Location = new System.Drawing.Point(0, 104);
            this.btnNavConstantCheck.Name = "btnNavConstantCheck";
            this.btnNavConstantCheck.Size = new System.Drawing.Size(233, 52);
            this.btnNavConstantCheck.TabIndex = 8;
            this.btnNavConstantCheck.Text = "Constant Check";
            this.btnNavConstantCheck.UseVisualStyleBackColor = false;
            this.btnNavConstantCheck.Click += new System.EventHandler(this.btnNavConstantCheck_Click);
            // 
            // btnNavCompareFile
            // 
            this.btnNavCompareFile.BackColor = System.Drawing.Color.White;
            this.btnNavCompareFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavCompareFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavCompareFile.Location = new System.Drawing.Point(0, 52);
            this.btnNavCompareFile.Name = "btnNavCompareFile";
            this.btnNavCompareFile.Size = new System.Drawing.Size(233, 52);
            this.btnNavCompareFile.TabIndex = 7;
            this.btnNavCompareFile.Text = "Compare File";
            this.btnNavCompareFile.UseVisualStyleBackColor = false;
            this.btnNavCompareFile.Click += new System.EventHandler(this.btnNavCompareFile_Click);
            // 
            // btnNavAddFile
            // 
            this.btnNavAddFile.BackColor = System.Drawing.Color.Gray;
            this.btnNavAddFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavAddFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavAddFile.ForeColor = System.Drawing.Color.White;
            this.btnNavAddFile.Location = new System.Drawing.Point(0, 0);
            this.btnNavAddFile.Name = "btnNavAddFile";
            this.btnNavAddFile.Size = new System.Drawing.Size(233, 52);
            this.btnNavAddFile.TabIndex = 6;
            this.btnNavAddFile.Text = "Add File";
            this.btnNavAddFile.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Filepath:";
            // 
            // tbFilename
            // 
            this.tbFilename.Location = new System.Drawing.Point(368, 52);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.ReadOnly = true;
            this.tbFilename.Size = new System.Drawing.Size(327, 22);
            this.tbFilename.TabIndex = 16;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(701, 51);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(108, 23);
            this.btnSelectFile.TabIndex = 15;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // tbMD5Hash
            // 
            this.tbMD5Hash.Location = new System.Drawing.Point(368, 154);
            this.tbMD5Hash.Multiline = true;
            this.tbMD5Hash.Name = "tbMD5Hash";
            this.tbMD5Hash.ReadOnly = true;
            this.tbMD5Hash.Size = new System.Drawing.Size(450, 54);
            this.tbMD5Hash.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "MD5 Hash:";
            // 
            // btnComputeHash
            // 
            this.btnComputeHash.Location = new System.Drawing.Point(458, 80);
            this.btnComputeHash.Name = "btnComputeHash";
            this.btnComputeHash.Size = new System.Drawing.Size(159, 53);
            this.btnComputeHash.TabIndex = 20;
            this.btnComputeHash.Text = "Compute Hash";
            this.btnComputeHash.UseVisualStyleBackColor = true;
            this.btnComputeHash.Click += new System.EventHandler(this.btnComputeHash_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "SHA256 Hash:";
            // 
            // tbSHA256Hash
            // 
            this.tbSHA256Hash.Location = new System.Drawing.Point(368, 220);
            this.tbSHA256Hash.Multiline = true;
            this.tbSHA256Hash.Name = "tbSHA256Hash";
            this.tbSHA256Hash.ReadOnly = true;
            this.tbSHA256Hash.Size = new System.Drawing.Size(450, 77);
            this.tbSHA256Hash.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "SHA512 Hash:";
            // 
            // tbSHA512Hash
            // 
            this.tbSHA512Hash.Location = new System.Drawing.Point(368, 303);
            this.tbSHA512Hash.Multiline = true;
            this.tbSHA512Hash.Name = "tbSHA512Hash";
            this.tbSHA512Hash.ReadOnly = true;
            this.tbSHA512Hash.Size = new System.Drawing.Size(450, 128);
            this.tbSHA512Hash.TabIndex = 23;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 443);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSHA512Hash);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSHA256Hash);
            this.Controls.Add(this.btnComputeHash);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMD5Hash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFilename);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.minimise);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddFile";
            this.Text = "AddFile";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label minimise;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNavConstantCheck;
        private System.Windows.Forms.Button btnNavCompareFile;
        private System.Windows.Forms.Button btnNavAddFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox tbMD5Hash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnComputeHash;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSHA256Hash;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSHA512Hash;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}