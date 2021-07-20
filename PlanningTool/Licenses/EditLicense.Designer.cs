
namespace PlanningTool.Licenses
{
    partial class EditLicense
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
            this.cbUser = new System.Windows.Forms.ComboBox();
            this.cbProject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bnCreate = new System.Windows.Forms.Button();
            this.bnCancel = new System.Windows.Forms.Button();
            this.cbKey = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbUser
            // 
            this.cbUser.FormattingEnabled = true;
            this.cbUser.Location = new System.Drawing.Point(122, 39);
            this.cbUser.Name = "cbUser";
            this.cbUser.Size = new System.Drawing.Size(166, 21);
            this.cbUser.TabIndex = 0;
            // 
            // cbProject
            // 
            this.cbProject.Location = new System.Drawing.Point(122, 66);
            this.cbProject.Name = "cbProject";
            this.cbProject.Size = new System.Drawing.Size(166, 21);
            this.cbProject.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Associated Project";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Associated User";
            // 
            // bnCreate
            // 
            this.bnCreate.Location = new System.Drawing.Point(213, 93);
            this.bnCreate.Name = "bnCreate";
            this.bnCreate.Size = new System.Drawing.Size(75, 23);
            this.bnCreate.TabIndex = 5;
            this.bnCreate.Text = "Edit";
            this.bnCreate.UseVisualStyleBackColor = true;
            this.bnCreate.Click += new System.EventHandler(this.bnCreate_Click);
            // 
            // bnCancel
            // 
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(15, 93);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(75, 23);
            this.bnCancel.TabIndex = 6;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // cbKey
            // 
            this.cbKey.FormattingEnabled = true;
            this.cbKey.Location = new System.Drawing.Point(122, 12);
            this.cbKey.Name = "cbKey";
            this.cbKey.Size = new System.Drawing.Size(166, 21);
            this.cbKey.TabIndex = 7;
            this.cbKey.SelectedValueChanged += new System.EventHandler(this.OnLicenseChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "License Key";
            // 
            // EditLicense
            // 
            this.AcceptButton = this.bnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(300, 130);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbKey);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.bnCreate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbProject);
            this.Controls.Add(this.cbUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditLicense";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit License";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUser;
        private System.Windows.Forms.ComboBox cbProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bnCreate;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.ComboBox cbKey;
        private System.Windows.Forms.Label label2;
    }
}