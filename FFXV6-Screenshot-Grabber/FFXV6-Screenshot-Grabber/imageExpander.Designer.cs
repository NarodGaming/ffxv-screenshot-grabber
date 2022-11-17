namespace FFXV6_Screenshot_Grabber
{
    partial class imageExpander
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
            this.previewBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // previewBox
            // 
            this.previewBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.previewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewBox.Location = new System.Drawing.Point(0, 0);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(1264, 681);
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            // 
            // imageExpander
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.previewBox);
            this.MinimumSize = new System.Drawing.Size(640, 360);
            this.Name = "imageExpander";
            this.Text = "Narod\'s FFXV Screenshot Grabber - Preview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.imageExpander_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox previewBox;
    }
}