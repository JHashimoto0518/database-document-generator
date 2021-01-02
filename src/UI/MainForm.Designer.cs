namespace UI {
	partial class MainForm {
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
			this._exportButton = new System.Windows.Forms.Button();
			this._statusStrip = new System.Windows.Forms.StatusStrip();
			this._toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this._toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this._closeButton = new System.Windows.Forms.Button();
			this._initializeButton = new System.Windows.Forms.Button();
			this._customizeButton = new System.Windows.Forms.Button();
			this._statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// _exportButton
			// 
			this._exportButton.Location = new System.Drawing.Point(12, 71);
			this._exportButton.Name = "_exportButton";
			this._exportButton.Size = new System.Drawing.Size(75, 23);
			this._exportButton.TabIndex = 2;
			this._exportButton.Text = "出力(&E)";
			this._exportButton.UseVisualStyleBackColor = true;
			// 
			// _statusStrip
			// 
			this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripStatusLabel,
            this._toolStripProgressBar});
			this._statusStrip.Location = new System.Drawing.Point(0, 244);
			this._statusStrip.Name = "_statusStrip";
			this._statusStrip.Size = new System.Drawing.Size(292, 22);
			this._statusStrip.TabIndex = 2;
			this._statusStrip.Text = "statusStrip1";
			// 
			// _toolStripStatusLabel
			// 
			this._toolStripStatusLabel.Name = "_toolStripStatusLabel";
			this._toolStripStatusLabel.Size = new System.Drawing.Size(175, 17);
			this._toolStripStatusLabel.Spring = true;
			this._toolStripStatusLabel.Text = "toolStripStatusLabel1";
			this._toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _toolStripProgressBar
			// 
			this._toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this._toolStripProgressBar.Name = "_toolStripProgressBar";
			this._toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
			// 
			// _closeButton
			// 
			this._closeButton.Location = new System.Drawing.Point(12, 205);
			this._closeButton.Name = "_closeButton";
			this._closeButton.Size = new System.Drawing.Size(75, 23);
			this._closeButton.TabIndex = 3;
			this._closeButton.Text = "閉じる(&C)";
			this._closeButton.UseVisualStyleBackColor = true;
			// 
			// _initializeButton
			// 
			this._initializeButton.Location = new System.Drawing.Point(12, 12);
			this._initializeButton.Name = "_initializeButton";
			this._initializeButton.Size = new System.Drawing.Size(75, 23);
			this._initializeButton.TabIndex = 0;
			this._initializeButton.Text = "初期化(&I)";
			this._initializeButton.UseVisualStyleBackColor = true;
			// 
			// _customizeButton
			// 
			this._customizeButton.Location = new System.Drawing.Point(12, 42);
			this._customizeButton.Name = "_customizeButton";
			this._customizeButton.Size = new System.Drawing.Size(75, 23);
			this._customizeButton.TabIndex = 1;
			this._customizeButton.Text = "設定(&U)";
			this._customizeButton.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.Add(this._customizeButton);
			this.Controls.Add(this._initializeButton);
			this.Controls.Add(this._closeButton);
			this.Controls.Add(this._statusStrip);
			this.Controls.Add(this._exportButton);
			this.Name = "MainForm";
			this.Text = "Form1";
			this._statusStrip.ResumeLayout(false);
			this._statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _exportButton;
		private System.Windows.Forms.StatusStrip _statusStrip;
		private System.Windows.Forms.ToolStripProgressBar _toolStripProgressBar;
		private System.Windows.Forms.ToolStripStatusLabel _toolStripStatusLabel;
		private System.Windows.Forms.Button _closeButton;
		private System.Windows.Forms.Button _initializeButton;
		private System.Windows.Forms.Button _customizeButton;
	}
}

