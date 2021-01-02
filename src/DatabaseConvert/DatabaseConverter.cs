using System;
using System.Collections.Generic;
using System.Text;

using Convert = DatabaseConvert.Data;
using Provider = DatabaseProvider.Data;

namespace DatabaseConvert {

	/// <summary>
	/// �f�[�^�x�[�X�̑����𕶎���ɕϊ�����@�\��񋟂��܂��B
	/// </summary>
	public class DatabaseConverter {

		#region �t�B�[���h

		/// <summary>
		/// 
		/// </summary>
		private Provider.Entity.DatabaseDataTable _databases;

		#endregion �t�B�[���h

		#region �v���p�e�B
		
		/// <summary>
		/// �ϊ����ꂽ�f�[�^�x�[�X�C���X�^���X
		/// </summary>
		private Convert.Entity.DatabaseDataTable _convertedDatabases;

		public Convert.Entity.DatabaseDataTable Database {
			get {
				return _convertedDatabases;
			}
		}

		#endregion �v���p�e�B

		#region �R���X�g���N�^

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="database">�f�[�^�x�[�X�C���X�^���X</param>
		public DatabaseConverter(Provider.Entity.ServerDataTable servers) {
			_databases = servers[0].Databases;
		}

		#endregion �R���X�g���N�^

		#region �ϊ�

		/// <summary>
		/// �ϊ����܂��B
		/// </summary>
		public void Convert() {
			_convertedDatabases = new Convert.Entity.DatabaseDataTable();
			Convert.Entity.DatabaseRow database = _convertedDatabases.NewDatabaseRow();
			database.Name = _databases[0].Name;
			database.Tables = this.ConvertTables(_databases[0].Tables);
			_convertedDatabases.AddDatabaseRow(database);
		}

		private Convert.Entity.TableDataTable ConvertTables(Provider.Entity.TableDataTable tables) {
			Convert.Entity.TableDataTable convertedTables = new Convert.Entity.TableDataTable();

			foreach (Provider.Entity.TableRow table in tables) {
				Convert.Entity.TableRow convertedTable = convertedTables.NewTableRow();
				convertedTable.Name = table.Name;
				convertedTable.LogicalName = table.LogicalName;
				convertedTable.Remarks = table.Remarks;
				convertedTable.Columns = this.ConvertColumns(table.Columns);

				convertedTables.AddTableRow(convertedTable);
			}

			return convertedTables;
		}

		private Convert.Entity.ColumnDataTable ConvertColumns(Provider.Entity.ColumnDataTable columns) {
			Convert.Entity.ColumnDataTable convertedColumns = new Convert.Entity.ColumnDataTable();

			foreach (Provider.Entity.ColumnRow column in columns) {
				Convert.Entity.ColumnRow convertedColumn = convertedColumns.NewColumnRow();
				convertedColumn.Name = column.Name;
				convertedColumn.DataType = column.DataType;
				convertedColumn.MaximumLength = column.MaximumLength.ToString();
				convertedColumn.NumericPrecision = this.GetNumericPrecisionText(column);
				convertedColumn.NotNull = column.Nullable ? string.Empty : "��";
				convertedColumn.Default = this.GetDefaultText(column.Default);
				convertedColumn.PrimaryKey = column.InPrimaryKey ? "PK" : string.Empty;
				convertedColumn.Identity = this.GetIdentityText(column);
				convertedColumn.Summary = column.Summary;
				convertedColumn.Remarks = column.Remarks;

				convertedColumns.AddColumnRow(convertedColumn);
			}

			return convertedColumns;
		}

		private string GetNumericPrecisionText(Provider.Entity.ColumnRow column) {
			if ((column.NumericPrecision == 0) || (column.Name.Equals("datetime"))) {
				return string.Empty;
			} else {
				return string.Format("{0}({1})", column.NumericPrecision, column.NumericScale);
			}
		}

		private string GetDefaultText(string def) {
			if (def.Equals(string.Empty)) {
				return string.Empty;
			}
			
			// ���[��()���폜
			return def.Substring(1, def.Length - 2);
		}

		private string GetIdentityText(Provider.Entity.ColumnRow col) {
			if (!col.Identity) {
				return string.Empty;
			}

			return string.Format("{0}({1})", col.IdentitySeed, col.IdentityIncrement);
		}

		#endregion �ϊ�

	}
}
