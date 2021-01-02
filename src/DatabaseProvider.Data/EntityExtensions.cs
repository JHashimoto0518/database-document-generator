using System;

namespace DatabaseProvider.Data {

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
		}

	}

}
