namespace WinFormDDD
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRequiredCheck = new System.Windows.Forms.Button();
            this.dataGridView = new WinFormDDD.control.BookMasterGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(290, 361);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(86, 32);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // btnRequiredCheck
            // 
            this.btnRequiredCheck.Location = new System.Drawing.Point(438, 361);
            this.btnRequiredCheck.Name = "btnRequiredCheck";
            this.btnRequiredCheck.Size = new System.Drawing.Size(144, 32);
            this.btnRequiredCheck.TabIndex = 4;
            this.btnRequiredCheck.Text = "書籍名必須チェック";
            this.btnRequiredCheck.UseVisualStyleBackColor = true;
            this.btnRequiredCheck.Click += new System.EventHandler(this.BtnRequired_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.Location = new System.Drawing.Point(51, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1193, 333);
            this.dataGridView.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(646, 361);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 32);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRequiredCheck);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnSearch);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private control.BookMasterGridView dataGridView;
        private System.Windows.Forms.Button btnRequiredCheck;
        private System.Windows.Forms.Button btnClear;
    }
}

