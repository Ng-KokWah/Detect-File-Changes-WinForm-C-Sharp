namespace FileChangeDetection
{
    partial class CompareFile
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
            this.minimise = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.tbFilename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbModifiedStats = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNavConstantCheck = new System.Windows.Forms.Button();
            this.btnNavCompareFile = new System.Windows.Forms.Button();
            this.btnNavAddFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnFind = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // minimise
            // 
            this.minimise.AutoSize = true;
            this.minimise.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimise.Location = new System.Drawing.Point(777, 9);
            this.minimise.Name = "minimise";
            this.minimise.Size = new System.Drawing.Size(29, 29);
            this.minimise.TabIndex = 0;
            this.minimise.Text = "--";
            this.minimise.Click += new System.EventHandler(this.minimise_Click);
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(812, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(30, 29);
            this.close.TabIndex = 1;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(705, 52);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(108, 23);
            this.btnSelectFile.TabIndex = 3;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // tbFilename
            // 
            this.tbFilename.Location = new System.Drawing.Point(372, 53);
            this.tbFilename.Name = "tbFilename";
            this.tbFilename.ReadOnly = true;
            this.tbFilename.Size = new System.Drawing.Size(327, 22);
            this.tbFilename.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(249, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filepath:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Modifications:";
            // 
            // tbModifiedStats
            // 
            this.tbModifiedStats.Location = new System.Drawing.Point(372, 134);
            this.tbModifiedStats.Name = "tbModifiedStats";
            this.tbModifiedStats.ReadOnly = true;
            this.tbModifiedStats.Size = new System.Drawing.Size(327, 22);
            this.tbModifiedStats.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hashes:";
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
            this.panel1.TabIndex = 13;
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
            this.btnNavCompareFile.BackColor = System.Drawing.Color.Gray;
            this.btnNavCompareFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavCompareFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavCompareFile.ForeColor = System.Drawing.Color.White;
            this.btnNavCompareFile.Location = new System.Drawing.Point(0, 52);
            this.btnNavCompareFile.Name = "btnNavCompareFile";
            this.btnNavCompareFile.Size = new System.Drawing.Size(233, 52);
            this.btnNavCompareFile.TabIndex = 7;
            this.btnNavCompareFile.Text = "Compare File";
            this.btnNavCompareFile.UseVisualStyleBackColor = false;
            // 
            // btnNavAddFile
            // 
            this.btnNavAddFile.BackColor = System.Drawing.Color.White;
            this.btnNavAddFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavAddFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavAddFile.Location = new System.Drawing.Point(0, 0);
            this.btnNavAddFile.Name = "btnNavAddFile";
            this.btnNavAddFile.Size = new System.Drawing.Size(233, 52);
            this.btnNavAddFile.TabIndex = 6;
            this.btnNavAddFile.Text = "Add File";
            this.btnNavAddFile.UseVisualStyleBackColor = false;
            this.btnNavAddFile.Click += new System.EventHandler(this.btnNavAddFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(423, 162);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(207, 30);
            this.btnFind.TabIndex = 14;
            this.btnFind.Text = "Find Record and Compare";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(239, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(606, 34);
            this.label4.TabIndex = 15;
            this.label4.Text = "*NOTE: Please make sure that you do not change the file contents and/or the filen" +
    "ame as \r\nthese would affect the computed hash results and we would not be able t" +
    "o find your file records";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(252, 214);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(585, 217);
            this.dataGridView1.TabIndex = 24;
            // 
            // CompareFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 443);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbModifiedStats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFilename);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.close);
            this.Controls.Add(this.minimise);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CompareFile";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label minimise;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox tbFilename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbModifiedStats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNavConstantCheck;
        private System.Windows.Forms.Button btnNavCompareFile;
        private System.Windows.Forms.Button btnNavAddFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

