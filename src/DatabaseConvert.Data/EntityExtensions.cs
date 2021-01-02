using System;
using System.Text;
using System.Data;

namespace DatabaseConvert.Data {

	/// <summary>
	/// 
	/// </summary>
	public partial class Entity {

		/// <summary>
		/// 
		/// </summary>
		public partial class ServerRow {

			private DatabaseDataTable _databases;

			public DatabaseDataTable Databases {
				get {
					return _databases;
				}
				set {
					_databases = value;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public partial class DatabaseRow {

			private TableDataTable _tables;

			public TableDataTable Tables {
				get {
					return _tables;
				}
				set {
					_tables = value;
				}
			}
		}

		public partial class TableDataTable {

			private string _propertyNamesString = string.Empty;

			public string PropertyNamesString {
				get {
					if (_propertyNamesString == string.Empty) {
						_propertyNamesString = DataTableUtil.ColumnNamesString(this.Columns);
					}

					return _propertyNamesString;
				}
			}

			public int PropertyCount {
				get {
					return this.Columns.Count;
				}
			}

		}

		/// <summary>
		/// 
		/// </summary>
		public partial class TableRow {

			private ColumnDataTable _columns;

			public ColumnDataTable Columns {
				get {
					return _columns;
				}
				set {
					_columns = value;
				}
			}

			//// TODO:プロパティ名を変更したい
			//public Entity.TableDataTable TableDataTable {
			//    get {
			//        return this.tableTable;
			//    }
			//}
	
		}

		public partial class ColumnDataTable {

			private string _propertyNamesString = string.Empty;

			public string PropertyNamesString {
				get {
					if (_propertyNamesString == string.Empty) {
						_propertyNamesString = DataTableUtil.ColumnNamesString(this.Columns);
					}

					return _propertyNamesString;
				}
			}

			public int PropertyCount {
				get {
					return this.Columns.Count;
				}
			}
		}

		internal static class DataTableUtil {

			public static string ColumnNamesString(DataColumnCollection dataColumns) {
				return DataTableUtil.ColumnNamesString(dataColumns, ",");
			}

			public static string ColumnNamesString(DataColumnCollection dataColumns, string delimiter) {

				StringBuilder sb = new StringBuilder();

				foreach (System.Data.DataColumn column in dataColumns) {
					sb.Append(column.ColumnName);
					sb.Append(",");
				}

				sb.Length--;

				return sb.ToString();
			}

		}
	}

}
