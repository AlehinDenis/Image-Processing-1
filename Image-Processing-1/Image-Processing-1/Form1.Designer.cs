namespace Image_Processing_1
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filtresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.symilarityOfTwoImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shapesOfGrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.convertationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filtresToolStripMenuItem
            // 
            this.filtresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.symilarityOfTwoImagesToolStripMenuItem,
            this.shapesOfGrayToolStripMenuItem,
            this.convertationToolStripMenuItem});
            this.filtresToolStripMenuItem.Name = "filtresToolStripMenuItem";
            this.filtresToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtresToolStripMenuItem.Text = "Filters";
            // 
            // symilarityOfTwoImagesToolStripMenuItem
            // 
            this.symilarityOfTwoImagesToolStripMenuItem.Name = "symilarityOfTwoImagesToolStripMenuItem";
            this.symilarityOfTwoImagesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.symilarityOfTwoImagesToolStripMenuItem.Text = "Similarity of two images";
            this.symilarityOfTwoImagesToolStripMenuItem.Click += new System.EventHandler(this.symilarityOfTwoImagesToolStripMenuItem_Click);
            // 
            // shapesOfGrayToolStripMenuItem
            // 
            this.shapesOfGrayToolStripMenuItem.Name = "shapesOfGrayToolStripMenuItem";
            this.shapesOfGrayToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.shapesOfGrayToolStripMenuItem.Text = "Shapes of gray";
            this.shapesOfGrayToolStripMenuItem.Click += new System.EventHandler(this.shapesOfGrayToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(370, 422);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(402, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(370, 422);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // convertationToolStripMenuItem
            // 
            this.convertationToolStripMenuItem.Name = "convertationToolStripMenuItem";
            this.convertationToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.convertationToolStripMenuItem.Text = "Convertation";
            this.convertationToolStripMenuItem.Click += new System.EventHandler(this.convertationToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image processing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filtresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem symilarityOfTwoImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shapesOfGrayToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem convertationToolStripMenuItem;
    }
}

