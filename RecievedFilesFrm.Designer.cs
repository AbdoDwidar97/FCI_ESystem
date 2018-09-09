namespace FCI_Com
{
    partial class RecievedFilesFrm
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
            this.DGV_Files = new System.Windows.Forms.DataGridView();
            this.FDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.File_Link = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Files)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Files
            // 
            this.DGV_Files.AllowUserToAddRows = false;
            this.DGV_Files.AllowUserToDeleteRows = false;
            this.DGV_Files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Files.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FDate,
            this.Sender,
            this.To_Level,
            this.Description,
            this.File_Link});
            this.DGV_Files.Location = new System.Drawing.Point(12, 12);
            this.DGV_Files.Name = "DGV_Files";
            this.DGV_Files.ReadOnly = true;
            this.DGV_Files.Size = new System.Drawing.Size(774, 447);
            this.DGV_Files.TabIndex = 0;
            // 
            // FDate
            // 
            this.FDate.HeaderText = "FDate";
            this.FDate.Name = "FDate";
            this.FDate.ReadOnly = true;
            // 
            // Sender
            // 
            this.Sender.HeaderText = "From";
            this.Sender.Name = "Sender";
            this.Sender.ReadOnly = true;
            // 
            // To_Level
            // 
            this.To_Level.HeaderText = "Level";
            this.To_Level.Name = "To_Level";
            this.To_Level.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // File_Link
            // 
            this.File_Link.HeaderText = "Link";
            this.File_Link.Name = "File_Link";
            this.File_Link.ReadOnly = true;
            this.File_Link.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.File_Link.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // RecievedFilesFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(798, 485);
            this.Controls.Add(this.DGV_Files);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecievedFilesFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FCI Com (Recieved Files)";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Files)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Files;
        private System.Windows.Forms.DataGridViewTextBoxColumn FDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sender;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_Level;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewLinkColumn File_Link;
    }
}