namespace UI {
	partial class CustomizeForm {
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
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this._dataGridView = new System.Windows.Forms.DataGridView();
			this._closeButton = new System.Windows.Forms.Button();
			this._OKButton = new System.Windows.Forms.Button();
			this._moveUpButton = new System.Windows.Forms.Button();
			this._moveDownButton = new System.Windows.Forms.Button();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) (this._dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer.IsSplitterFixed = true;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.AutoScroll = true;
			this.splitContainer.Panel1.Controls.Add(this._dataGridView);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this._moveDownButton);
			this.splitContainer.Panel2.Controls.Add(this._moveUpButton);
			this.splitContainer.Panel2.Controls.Add(this._closeButton);
			this.splitContainer.Panel2.Controls.Add(this._OKButton);
			this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(3);
			this.splitContainer.Size = new System.Drawing.Size(402, 266);
			this.splitContainer.SplitterDistance = 219;
			this.splitContainer.TabIndex = 0;
			// 
			// _dataGridView
			// 
			this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this._dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this._dataGridView.Location = new System.Drawing.Point(0, 0);
			this._dataGridView.Name = "_dataGridView";
			this._dataGridView.RowTemplate.Height = 21;
			this._dataGridView.Size = new System.Drawing.Size(402, 219);
			this._dataGridView.TabIndex = 0;
			// 
			// _closeButton
			// 
			this._closeButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._closeButton.Location = new System.Drawing.Point(315, 8);
			this._closeButton.Name = "_closeButton";
			this._closeButton.Size = new System.Drawing.Size(75, 23);
			this._closeButton.TabIndex = 1;
			this._closeButton.Text = "閉じる(&C)";
			this._closeButton.UseVisualStyleBackColor = true;
			// 
			// _OKButton
			// 
			this._OKButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._OKButton.Location = new System.Drawing.Point(234, 8);
			this._OKButton.Name = "_OKButton";
			this._OKButton.Size = new System.Drawing.Size(75, 23);
			this._OKButton.TabIndex = 0;
			this._OKButton.Text = "OK(&O)";
			this._OKButton.UseVisualStyleBackColor = true;
			// 
			// _moveUpButton
			// 
			this._moveUpButton.Location = new System.Drawing.Point(6, 8);
			this._moveUpButton.Name = "_moveUpButton";
			this._moveUpButton.Size = new System.Drawing.Size(59, 23);
			this._moveUpButton.TabIndex = 2;
			this._moveUpButton.Text = "Up(&U)";
			this._moveUpButton.UseVisualStyleBackColor = true;
			// 
			// _moveDownButton
			// 
			this._moveDownButton.Location = new System.Drawing.Point(71, 8);
			this._moveDownButton.Name = "_moveDownButton";
			this._moveDownButton.Size = new System.Drawing.Size(59, 23);
			this._moveDownButton.TabIndex = 3;
			this._moveDownButton.Text = "Down(&D)";
			this._moveDownButton.UseVisualStyleBackColor = true;
			// 
			// CustomizeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(402, 266);
			this.Controls.Add(this.splitContainer);
			this.Name = "CustomizeForm";
			this.Text = "CustomizeForm";
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) (this._dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.Button _closeButton;
		private System.Windows.Forms.Button _OKButton;
		private System.Windows.Forms.DataGridView _dataGridView;
		private System.Windows.Forms.Button _moveDownButton;
		private System.Windows.Forms.Button _moveUpButton;
	}
}