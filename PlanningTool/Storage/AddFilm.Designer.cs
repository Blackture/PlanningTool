
namespace PlanningTool.Storage
{
    partial class AddFilm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblReleaseDate = new System.Windows.Forms.Label();
            this.txTitle = new System.Windows.Forms.TextBox();
            this.lblGenre = new System.Windows.Forms.Label();
            this.txGenre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txDuration = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txLocation = new System.Windows.Forms.TextBox();
            this.bnAddGenre = new System.Windows.Forms.Button();
            this.bnRemoveGenre = new System.Windows.Forms.Button();
            this.dtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(217, 142);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.Add);
            // 
            // bnCancel
            // 
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(136, 142);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 1;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(27, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title";
            // 
            // lblReleaseDate
            // 
            this.lblReleaseDate.AutoSize = true;
            this.lblReleaseDate.Location = new System.Drawing.Point(12, 94);
            this.lblReleaseDate.Name = "lblReleaseDate";
            this.lblReleaseDate.Size = new System.Drawing.Size(72, 13);
            this.lblReleaseDate.TabIndex = 4;
            this.lblReleaseDate.Text = "Release Date";
            // 
            // txTitle
            // 
            this.txTitle.Location = new System.Drawing.Point(109, 10);
            this.txTitle.Name = "txTitle";
            this.txTitle.Size = new System.Drawing.Size(183, 20);
            this.txTitle.TabIndex = 5;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(13, 40);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(36, 13);
            this.lblGenre.TabIndex = 6;
            this.lblGenre.Text = "Genre";
            // 
            // txGenre
            // 
            this.txGenre.Location = new System.Drawing.Point(109, 37);
            this.txGenre.Name = "txGenre";
            this.txGenre.ReadOnly = true;
            this.txGenre.Size = new System.Drawing.Size(129, 20);
            this.txGenre.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Duration";
            // 
            // txDuration
            // 
            this.txDuration.Location = new System.Drawing.Point(109, 64);
            this.txDuration.Name = "txDuration";
            this.txDuration.Size = new System.Drawing.Size(183, 20);
            this.txDuration.TabIndex = 9;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(12, 119);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 10;
            this.lblLocation.Text = "Location";
            // 
            // txLocation
            // 
            this.txLocation.Location = new System.Drawing.Point(109, 116);
            this.txLocation.Name = "txLocation";
            this.txLocation.Size = new System.Drawing.Size(183, 20);
            this.txLocation.TabIndex = 11;
            // 
            // bnAddGenre
            // 
            this.bnAddGenre.Location = new System.Drawing.Point(271, 36);
            this.bnAddGenre.Name = "bnAddGenre";
            this.bnAddGenre.Size = new System.Drawing.Size(21, 21);
            this.bnAddGenre.TabIndex = 12;
            this.bnAddGenre.Text = "+";
            this.bnAddGenre.UseVisualStyleBackColor = true;
            this.bnAddGenre.Click += new System.EventHandler(this.bnAddGenre_Click);
            // 
            // bnRemoveGenre
            // 
            this.bnRemoveGenre.Location = new System.Drawing.Point(244, 36);
            this.bnRemoveGenre.Name = "bnRemoveGenre";
            this.bnRemoveGenre.Size = new System.Drawing.Size(21, 21);
            this.bnRemoveGenre.TabIndex = 13;
            this.bnRemoveGenre.Text = "-";
            this.bnRemoveGenre.UseVisualStyleBackColor = true;
            this.bnRemoveGenre.Click += new System.EventHandler(this.bnRemove_Click);
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Location = new System.Drawing.Point(92, 90);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(200, 20);
            this.dtpReleaseDate.TabIndex = 14;
            // 
            // AddFilm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(304, 176);
            this.Controls.Add(this.dtpReleaseDate);
            this.Controls.Add(this.bnRemoveGenre);
            this.Controls.Add(this.bnAddGenre);
            this.Controls.Add(this.txLocation);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.txDuration);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txGenre);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.txTitle);
            this.Controls.Add(this.lblReleaseDate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddFilm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Film";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblReleaseDate;
        private System.Windows.Forms.TextBox txTitle;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txDuration;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txLocation;
        private System.Windows.Forms.Button bnAddGenre;
        public System.Windows.Forms.TextBox txGenre;
        private System.Windows.Forms.Button bnRemoveGenre;
        private System.Windows.Forms.DateTimePicker dtpReleaseDate;
    }
}