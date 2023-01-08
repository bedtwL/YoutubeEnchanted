namespace YoutubeEnchanted.UI
{
    partial class VideoPlayerPage
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.colorSlider2 = new ColorSlider.ColorSlider();
            this.colorSlider1 = new ColorSlider.ColorSlider();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.colorSlider2);
            this.panel1.Controls.Add(this.colorSlider1);
            this.panel1.Location = new System.Drawing.Point(4, 347);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 79);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            this.panel1.VisibleChanged += new System.EventHandler(this.panel1_VisibleChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "00:00/00:00";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::YoutubeEnchanted.Properties.Resources.PauseIcon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 32);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Location = new System.Drawing.Point(4, 424);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(823, 10);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(0, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(834, 434);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // colorSlider2
            // 
            this.colorSlider2.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider2.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.colorSlider2.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.colorSlider2.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider2.ElapsedInnerColor = System.Drawing.Color.Red;
            this.colorSlider2.ElapsedPenColorBottom = System.Drawing.Color.Red;
            this.colorSlider2.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.colorSlider2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.colorSlider2.ForeColor = System.Drawing.Color.Transparent;
            this.colorSlider2.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.colorSlider2.Location = new System.Drawing.Point(221, 39);
            this.colorSlider2.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.colorSlider2.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.colorSlider2.Name = "colorSlider2";
            this.colorSlider2.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.colorSlider2.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.colorSlider2.ShowDivisionsText = true;
            this.colorSlider2.ShowSmallScale = false;
            this.colorSlider2.Size = new System.Drawing.Size(102, 36);
            this.colorSlider2.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.colorSlider2.TabIndex = 2;
            this.colorSlider2.Text = "colorSlider2";
            this.colorSlider2.ThumbInnerColor = System.Drawing.Color.Red;
            this.colorSlider2.ThumbOuterColor = System.Drawing.Color.IndianRed;
            this.colorSlider2.ThumbPenColor = System.Drawing.Color.Red;
            this.colorSlider2.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.colorSlider2.ThumbSize = new System.Drawing.Size(16, 16);
            this.colorSlider2.TickAdd = 0F;
            this.colorSlider2.TickColor = System.Drawing.Color.Transparent;
            this.colorSlider2.TickDivide = 0F;
            this.colorSlider2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.colorSlider2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.colorSlider2_Scroll);
            // 
            // colorSlider1
            // 
            this.colorSlider1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorSlider1.BackColor = System.Drawing.Color.Transparent;
            this.colorSlider1.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.colorSlider1.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.colorSlider1.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider1.ElapsedInnerColor = System.Drawing.Color.Red;
            this.colorSlider1.ElapsedPenColorBottom = System.Drawing.Color.Red;
            this.colorSlider1.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.colorSlider1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.colorSlider1.ForeColor = System.Drawing.Color.Transparent;
            this.colorSlider1.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.colorSlider1.Location = new System.Drawing.Point(3, 9);
            this.colorSlider1.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.colorSlider1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.colorSlider1.Name = "colorSlider1";
            this.colorSlider1.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.colorSlider1.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.colorSlider1.ShowDivisionsText = true;
            this.colorSlider1.ShowSmallScale = false;
            this.colorSlider1.Size = new System.Drawing.Size(816, 36);
            this.colorSlider1.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.colorSlider1.TabIndex = 1;
            this.colorSlider1.Text = "colorSlider1";
            this.colorSlider1.ThumbInnerColor = System.Drawing.Color.Red;
            this.colorSlider1.ThumbOuterColor = System.Drawing.Color.IndianRed;
            this.colorSlider1.ThumbPenColor = System.Drawing.Color.Red;
            this.colorSlider1.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.colorSlider1.ThumbSize = new System.Drawing.Size(16, 16);
            this.colorSlider1.TickAdd = 0F;
            this.colorSlider1.TickColor = System.Drawing.Color.Transparent;
            this.colorSlider1.TickDivide = 0F;
            this.colorSlider1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.colorSlider1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.colorSlider1_Scroll);
            // 
            // VideoPlayerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "VideoPlayerPage";
            this.Size = new System.Drawing.Size(1102, 647);
            this.Load += new System.EventHandler(this.VideoPlayerPage_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ColorSlider.ColorSlider colorSlider2;
        private ColorSlider.ColorSlider colorSlider1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
    }
}
