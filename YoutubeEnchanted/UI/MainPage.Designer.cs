namespace YoutubeEnchanted.UI
{
    partial class MainPage
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
            this.TopicShower = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // TopicShower
            // 
            this.TopicShower.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopicShower.AutoScroll = true;
            this.TopicShower.BackColor = System.Drawing.SystemColors.Control;
            this.TopicShower.Location = new System.Drawing.Point(265, 52);
            this.TopicShower.Margin = new System.Windows.Forms.Padding(4);
            this.TopicShower.Name = "TopicShower";
            this.TopicShower.Size = new System.Drawing.Size(1325, 811);
            this.TopicShower.TabIndex = 0;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TopicShower);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainPage";
            this.Size = new System.Drawing.Size(1611, 876);
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.EnabledChanged += new System.EventHandler(this.MainPage_EnabledChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopicShower;
    }
}
