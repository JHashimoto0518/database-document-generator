using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI {

	/// <summary>
	/// メインフォームです。
	/// </summary>
	public partial class MainForm : Form {

		#region Enum

		/// <summary>
		/// ユースケース
		/// </summary>
		private enum Usecase {
			ConnectDatabase = 1,
			GetDatabaseInfo = 2,
			Convert = 3,
			Export = 4,
			Format = 5,
		}

		#endregion Enum
		
		#region フィールド

		private const string Caption = "DBドキュメント出力 [{0}]";

		private DatabaseProvider.SqlProvider _provider;

		private DatabaseConvert.DatabaseConverter _converter;
		
		private DocumentExport.Excel.ExcelExporter _exporter;

		private BackgroundWorker _backgroundWorker;

		private Dictionary<Usecase, Execution> _executionList;

		#endregion フィールド

		#region 初期化
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainForm() {
			InitializeComponent();
		}

		/// <summary>
		/// 初期化します。
		/// </summary>
		public void Initialize() {

			Logger.LogFilePath = UI.Properties.Settings.Default.LogFilePath;

			this.Text = string.Format(Caption, "接続なし");
			this.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);

			_initializeButton.Click += new EventHandler(_initializeButton_Click);

			_customizeButton.Enabled = false;
			_customizeButton.Click += new EventHandler(_customizeButton_Click);

			_exportButton.Enabled = false;
			_exportButton.Click += new EventHandler(_exportButton_Click);
			
			_closeButton.Click += new EventHandler(_closeButton_Click);

			_toolStripStatusLabel.Text = "DBに接続されていません。";
			_toolStripProgressBar.Step = 20;

			_backgroundWorker = new BackgroundWorker();
			_backgroundWorker.DoWork += new DoWorkEventHandler(_backgroundWorker_DoWork);
			_backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_backgroundWorker_RunWorkerCompleted);

			this.SetExecutionList();
		}

		/// <summary>
		/// 
		/// </summary>
		private void SetExecutionList() {
			_executionList = new Dictionary<Usecase, Execution>();

			{
				Execution e = new Execution();
				_executionList.Add(Usecase.ConnectDatabase, e);
			
				e.Work = delegate() {
					_provider = new DatabaseProvider.SqlProvider();
					_provider.ConnectDatabase(UI.Properties.Settings.Default.ConnectionString);
				};

				e.Complete = delegate() {
					this.Text = string.Format(Caption, _provider.CurrentDatabaseName);
					_toolStripProgressBar.PerformStep();
					_toolStripStatusLabel.Text = "データベース情報を取得しています...";
					_backgroundWorker.RunWorkerAsync(Usecase.GetDatabaseInfo);
				};
			}

			{
				Execution e = new Execution();
				_executionList.Add(Usecase.GetDatabaseInfo, e);

				e.Work = delegate() {
					_provider.SetDatabaseInfo();
				};

				e.Complete = delegate() {
					_toolStripProgressBar.PerformStep();
					_toolStripStatusLabel.Text = "データベース情報を変換しています...";
					_backgroundWorker.RunWorkerAsync(Usecase.Convert);
				};
			}

			{
				Execution e = new Execution();
				_executionList.Add(Usecase.Convert, e);

				e.Work = delegate() {
					_converter = new DatabaseConvert.DatabaseConverter(_provider.Servers);
					_converter.Convert();
				};

				e.Complete = delegate() {
					_customizeButton.Enabled = true;
					_exportButton.Enabled = true;
					_customizeButton.Focus();
					_toolStripProgressBar.PerformStep();
					_toolStripStatusLabel.Text = "出力の準備が完了しました。";
				};
			}

			{
				Execution e = new Execution();
				_executionList.Add(Usecase.Export, e);

				e.Work = delegate() {
					_exporter = new DocumentExport.Excel.ExcelExporter();
					_exporter.TemplateFilePath = UI.Properties.Settings.Default.TemplateFilePath;
					_exporter.OutputFilePath = UI.Properties.Settings.Default.OutputFilePath;
					_exporter.Database = _converter.Database[0];
					_exporter.Export();
				};

				e.Complete = delegate() {
					_toolStripProgressBar.PerformStep();
					_toolStripStatusLabel.Text = "出力を整形しています...";
					_backgroundWorker.RunWorkerAsync(Usecase.Format);
				};
			}

			{
				Execution e = new Execution();
				_executionList.Add(Usecase.Format, e);

				e.Work = delegate() {
					_exporter.Format(UI.Properties.Settings.Default.ExcelMacroName);
				};

				e.Complete = delegate() {
					_initializeButton.Enabled = true;
					_customizeButton.Enabled = true;
					_exportButton.Enabled = true;
					_toolStripProgressBar.PerformStep();
					_toolStripStatusLabel.Text = "出力が完了しました。";

					MessageBox.Show(
						this,
						_toolStripStatusLabel.Text,
						this.Text,
						MessageBoxButtons.OK,
						MessageBoxIcon.Information
					);
				};
			}
		}

		private void _initializeButton_Click(object sender, EventArgs e) {
			_initializeButton.Enabled = false;
			_toolStripProgressBar.Value = 0;
			_toolStripStatusLabel.Text = "データベースに接続しています...";

			_backgroundWorker.RunWorkerAsync(Usecase.ConnectDatabase);
		}

		private void _customizeButton_Click(object sender, EventArgs e) {
			using (CustomizeForm f = new CustomizeForm()) {
				f.Initialize(_converter.Database[0].Tables);
				f.ShowDialog(this);
			}
		}

		#endregion 初期化

		#region 終了処理

		private void _closeButton_Click(object sender, EventArgs e) {
			this.Close();
		}

		/// <summary>
		/// 終了処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
			if (_provider != null) {
				(_provider as IDisposable).Dispose();
			}

			if (_backgroundWorker != null) {
				_backgroundWorker.Dispose();
			}
		}

		#endregion 終了処理

		#region 出力

		/// <summary>
		/// データベースの内容をファイルに出力します。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _exportButton_Click(object sender, EventArgs e) {
			//_toolStripProgressBar.Value = 0;
			//_toolStripStatusLabel.Text = "データベースに接続しています...";

			//_backgroundWorker.RunWorkerAsync(Usecase.ConnectDatabase);

			_customizeButton.Enabled = false;
			_exportButton.Enabled = false;
			_toolStripStatusLabel.Text = "ファイルに出力しています...";

			_backgroundWorker.RunWorkerAsync(Usecase.Export);
		}

		private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
			_executionList[(Usecase) e.Argument].Work();

			e.Result = e.Argument;
		}

		private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			_executionList[(Usecase) e.Result].Complete();
		}

		#endregion 出力

		#region インナークラス
		
		/// <summary>
		/// 
		/// </summary>
		private class Execution {

			public delegate void Action();

			/// <summary>
			/// 実行したい処理
			/// </summary>
			public Action Work = null;
			
			/// <summary>
			/// 処理完了時にCallされる処理
			/// </summary>
			public Action Complete = null;
		}

		#endregion インナークラス
	}

}