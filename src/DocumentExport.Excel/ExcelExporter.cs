using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;

using DatabaseConvert.Data;

namespace DocumentExport.Excel {

	/// <summary>
	/// Excel�t�@�C�����o�͂���@�\��񋟂��܂��B
	/// </summary>
	public class ExcelExporter {

		#region �v���p�e�B

		/// <summary>
		/// �e���v���[�g�t�@�C��
		/// </summary>
		private string _templateFilePath;

		public string TemplateFilePath {
			get {
				return _templateFilePath;
			}
			set {
				_templateFilePath = value;
			}
		}

		/// <summary>
		/// �o�̓t�@�C��
		/// </summary>
		private string _outputFilePath;

		public string OutputFilePath {
			get {
				return _outputFilePath;
			}
			set {
				_outputFilePath = value;
			}
		}

		/// <summary>
		/// �o�͂���f�[�^�x�[�X
		/// </summary>
		private Entity.DatabaseRow _database;

		public Entity.DatabaseRow Database {
			get {
				return _database;
			}
			set {
				_database = value;
			}
		}

		#endregion �v���p�e�B

		#region �o��

		/// <summary>
		/// �h�L�������g���o�͂��܂��B
		/// </summary>
		public void Export() {
			System.IO.File.Copy(_templateFilePath, _outputFilePath, true);

			this.ExportDataSheet();
		}

		/// <summary>
		///	�f�[�^�x�[�X�����V�[�g�ɏo�͂��܂��B
		/// </summary>
		private void ExportDataSheet() {

			const string ConnectionString
				= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES\";";

			using (OleDbConnection connection = new OleDbConnection(string.Format(ConnectionString, _outputFilePath)))
			using (OleDbCommand exportLayout = new OleDbCommand()) {
				exportLayout.Connection = connection;
				connection.Open();

				QueryBuilder layoutQuery = new QueryBuilder();
				QueryBuilder listQuery = new QueryBuilder();
				listQuery.Initialize("_TableList");

				// TODO:���ёւ�
				foreach (Entity.TableRow table in _database.Tables.Select("Enabled = True")) {
					layoutQuery.Initialize("_" + table.Name);

					foreach (Entity.ColumnRow column in table.Columns) {
						layoutQuery.AddValue(table.Columns.NameColumn.ColumnName, column.Name);
						layoutQuery.AddValue(table.Columns.DataTypeColumn.ColumnName, column.DataType);
						layoutQuery.AddValue(table.Columns.MaximumLengthColumn.ColumnName, column.MaximumLength);
						layoutQuery.AddValue(table.Columns.NumericPrecisionColumn.ColumnName, column.NumericPrecision);
						layoutQuery.AddValue(table.Columns.NotNullColumn.ColumnName, column.NotNull);
						layoutQuery.AddValue(table.Columns.DefaultColumn.ColumnName, column.Default);
						layoutQuery.AddValue(table.Columns.PrimaryKeyColumn.ColumnName, column.PrimaryKey);
						layoutQuery.AddValue(table.Columns.IdentityColumn.ColumnName, column.Identity);
						layoutQuery.AddValue(table.Columns.SummaryColumn.ColumnName, column.Summary);
						layoutQuery.AddValue(table.Columns.RemarksColumn.ColumnName, column.Remarks);
						layoutQuery.EndAddition();
					}

					this.ExecuteQuery(exportLayout, layoutQuery.GetQueryList());

					listQuery.AddValue(_database.Tables.NameColumn.ColumnName, table.Name);
					listQuery.AddValue(_database.Tables.LogicalNameColumn.ColumnName, table.LogicalName);
					listQuery.AddValue(_database.Tables.RemarksColumn.ColumnName, table.Remarks);
					listQuery.EndAddition();
				}

				using (OleDbCommand exportList = new OleDbCommand()) {
					exportList.Connection = connection;
					this.ExecuteQuery(exportList, listQuery.GetQueryList());
				}
			}
		}

		/// <summary>
		/// �N�G�������s���܂��B
		/// </summary>
		/// <param name="command"></param>
		/// <param name="queryList"></param>
		private void ExecuteQuery(OleDbCommand command, List<string> queryList) {
			try {
				foreach (string query in queryList) {
					command.CommandText = query;
					command.ExecuteNonQuery();
				}
			} catch (Exception e) {
				// TODO:��O��⑫�ł��Ȃ����Ƃ�����B
				throw new Exception("SQL���s�G���[ SQL:" + command.CommandText, e);
			}
		}

		#endregion �o��

		#region ���`

		/// <summary>
		/// �h�L�������g�𐮌`���܂��B
		/// </summary>
		public void Format(string macroName) {
			MacroExecutor executor = new MacroExecutor();
			executor.Execute(_outputFilePath, macroName);
		}

		#endregion ���`
	}
}
