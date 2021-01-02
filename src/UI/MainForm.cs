using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI {

	/// <summary>
	/// ���C���t�H�[���ł��B
	/// </summary>
	public partial class MainForm : Form {

		#region Enum

		/// <summary>
		/// ���[�X�P�[�X
		/// </summary>
		private enum Usecase {
			ConnectDatabase = 1,
			GetDatabaseInfo = 2,
			Convert = 3,
			Export = 4,
			Format = 5,
		}

		#endregion Enum
		
		#region �t�B�[���h

		private const string Caption = "DB�h�L�������g�o�� [{0}]";

		private DatabaseProvider.SqlProvider _provider;

		private DatabaseConvert.DatabaseConverter _converter;
		
		private DocumentExport.Excel.ExcelExporter _exporter;

		private BackgroundWorker _backgroundWorker;

		private Dictionary<Usecase, Execution> _executionList;

		#endregion �t�B�[���h

		#region ������
		
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public MainForm() {
			InitializeComponent();
		}

		/// <summary>
		/// ���������܂��B
		/// </summary>
		public void Initialize() {

			Logger.LogFilePath = UI.Properties.Settings.Default.LogFilePath;

			this.Text = string.Format(Caption, "�ڑ��Ȃ�");
			this.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);

			_initializeButton.Click += new EventHandler(_initializeButton_Click);

			_customizeButton.Enabled = false;
			_customizeButton.Click += new EventHandler(_customizeButton_Click);

			_exportButton.Enabled = false;
			_exportButton.Click += new EventHandler(_exportButton_Click);
			
			_closeButton.Click += new EventHandler(_closeButton_Click);

			_toolStripStatusLabel.Text = "DB�ɐڑ�����Ă��܂���B";
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
					_toolStripStatusLabel.Text = "�f�[�^�x�[�X�����擾���Ă��܂�...";
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
					_toolStripStatusLabel.Text = "�f�[�^�x�[�X����ϊ����Ă��܂�...";
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
					_toolStripStatusLabel.Text = "�o�͂̏������������܂����B";
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
					_toolStripStatusLabel.Text = "�o�͂𐮌`���Ă��܂�...";
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
					_toolStripStatusLabel.Text = "�o�͂��������܂����B";

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
			_toolStripStatusLabel.Text = "�f�[�^�x�[�X�ɐڑ����Ă��܂�...";

			_backgroundWorker.RunWorkerAsync(Usecase.ConnectDatabase);
		}

		private void _customizeButton_Click(object sender, EventArgs e) {
			using (CustomizeForm f = new CustomizeForm()) {
				f.Initialize(_converter.Database[0].Tables);
				f.ShowDialog(this);
			}
		}

		#endregion ������

		#region �I������

		private void _closeButton_Click(object sender, EventArgs e) {
			this.Close();
		}

		/// <summary>
		/// �I������
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

		#endregion �I������

		#region �o��

		/// <summary>
		/// �f�[�^�x�[�X�̓��e���t�@�C���ɏo�͂��܂��B
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _exportButton_Click(object sender, EventArgs e) {
			//_toolStripProgressBar.Value = 0;
			//_toolStripStatusLabel.Text = "�f�[�^�x�[�X�ɐڑ����Ă��܂�...";

			//_backgroundWorker.RunWorkerAsync(Usecase.ConnectDatabase);

			_customizeButton.Enabled = false;
			_exportButton.Enabled = false;
			_toolStripStatusLabel.Text = "�t�@�C���ɏo�͂��Ă��܂�...";

			_backgroundWorker.RunWorkerAsync(Usecase.Export);
		}

		private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
			_executionList[(Usecase) e.Argument].Work();

			e.Result = e.Argument;
		}

		private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			_executionList[(Usecase) e.Result].Complete();
		}

		#endregion �o��

		#region �C���i�[�N���X
		
		/// <summary>
		/// 
		/// </summary>
		private class Execution {

			public delegate void Action();

			/// <summary>
			/// ���s����������
			/// </summary>
			public Action Work = null;
			
			/// <summary>
			/// ������������Call����鏈��
			/// </summary>
			public Action Complete = null;
		}

		#endregion �C���i�[�N���X
	}

}