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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(imageExpander));
            previewBox=new PictureBox();
            ((System.ComponentModel.ISupportInitialize)previewBox).BeginInit();
            SuspendLayout();
            // 
            // previewBox
            // 
            previewBox.BackgroundImageLayout=ImageLayout.Zoom;
            previewBox.Dock=DockStyle.Fill;
            previewBox.Location=new Point(0, 0);
            previewBox.Name="previewBox";
            previewBox.Size=new Size(1280, 720);
            previewBox.TabIndex=0;
            previewBox.TabStop=false;
            // 
            // imageExpander
            // 
            AutoScaleDimensions=new SizeF(7F, 16F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1280, 720);
            Controls.Add(previewBox);
            Font=new Font("Segoe UI Variable Text", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon=(Icon)resources.GetObject("$this.Icon");
            MinimumSize=new Size(640, 381);
            Name="imageExpander";
            Text="Narod's FFXV Screenshot Grabber - Preview";
            FormClosing+=imageExpander_FormClosing;
            ((System.ComponentModel.ISupportInitialize)previewBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox previewBox;
    }
}