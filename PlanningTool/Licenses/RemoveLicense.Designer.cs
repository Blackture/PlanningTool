
namespace PlanningTool.Licenses
{
    partial class RemoveLicense
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
            this.tbKey = new System.Windows.Forms.TextBox();
            this.bnCancel = new System.Windows.Forms.Button();
            this.bnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remove License Key";
            // 
            // tbKey
            // 
            this.tbKey.Location = new System.Drawing.Point(12, 25);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(108, 20);
            this.tbKey.TabIndex = 1;
            // 
            // bnCancel
            // 
            this.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnCancel.Location = new System.Drawing.Point(12, 51);
            this.bnCancel.Name = "bnCancel";
            this.bnCancel.Size = new System.Drawing.Size(50, 23);
            this.bnCancel.TabIndex = 2;
            this.bnCancel.Text = "Cancel";
            this.bnCancel.UseVisualStyleBackColor = true;
            this.bnCancel.Click += new System.EventHandler(this.bnCancel_Click);
            // 
            // bnDelete
            // 
            this.bnDelete.Location = new System.Drawing.Point(68, 51);
            this.bnDelete.Name = "bnDelete";
            this.bnDelete.Size = new System.Drawing.Size(52, 23);
            this.bnDelete.TabIndex = 3;
            this.bnDelete.Text = "Delete";
            this.bnDelete.UseVisualStyleBackColor = true;
            this.bnDelete.Click += new System.EventHandler(this.bnDelete_Click);
            // 
            // RemoveLicense
            // 
            this.AcceptButton = this.bnDelete;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bnCancel;
            this.ClientSize = new System.Drawing.Size(136, 88);
            this.Controls.Add(this.bnDelete);
            this.Controls.Add(this.bnCancel);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RemoveLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RemoveLicense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Button bnCancel;
        private System.Windows.Forms.Button bnDelete;
    }
}