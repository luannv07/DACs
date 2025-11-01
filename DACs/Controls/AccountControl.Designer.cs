namespace DACs.Controls
{
    partial class ucAccountControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAccountControl));
            this.imageAccountSubOptions = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageAccountSubOptions
            // 
            this.imageAccountSubOptions.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageAccountSubOptions.ImageStream")));
            this.imageAccountSubOptions.TransparentColor = System.Drawing.Color.Transparent;
            this.imageAccountSubOptions.Images.SetKeyName(0, "Contacts_1.png");
            this.imageAccountSubOptions.Images.SetKeyName(1, "MySpace.png");
            // 
            // ucAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucAccountControl";
            this.Size = new System.Drawing.Size(960, 681);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageAccountSubOptions;
    }
}
