using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SqlServer.Management.Common;
using Smo = Microsoft.SqlServer.Management.Smo;

namespace DatabaseProvider {

	/// <summary>
	/// SqlServerの情報を提供します。
	/// </summary>
	public class SqlProvider : IProvider {

		#region フィールド

		/// <summary>
		/// サーバー
		/// </summary>
		private Smo.Server _server;

		/// <summary>
		/// テーブル情報
		/// </summary>
		private Dictionary<string, Entity.Table> _tables;

		public Dictionary<string, Entity.Table> Tables {
			get {
				return _tables;
			}
		}

		#endregion フィールド

		#region 初期化

		/// <summary>
		/// 初期化します。
		/// </summary>
		public void Initialize(string connectionString) {

			this.Connect(connectionString);

			Smo.Database database = this.GetCurrentDatabase();

			this.SetTables(database);
			foreach (Smo.Table table in database.Tables) {
				this.SetColumns(table);
			}

			this.Disconnect();
		}

		/// <summary>
		/// 接続中のデータベースを取得します。
		/// </summary>
		/// <returns>データベース</returns>
		private Smo.Database GetCurrentDatabase(){
			return _server.Databases[_server.ConnectionContext.SqlConnectionObject.Database];
		}

		/// <summary>
		/// データベースに接続します。
		/// </summary>
		private void Connect(string connectionString) {
			ServerConnection connection = new ServerConnection();
			connection.ConnectionString = connectionString;
			connection.Connect();
			_server = new Smo.Server(connection);
		}

		/// <summary>
		/// データベースとの接続を切断します。
		/// </summary>
		private void Disconnect() {
			_server.ConnectionContext.Disconnect();
		}

		/// <summary>
		/// テーブル情報を設定します。
		/// </summary>
		/// <param name="database">データベース</param>
		private void SetTables(Smo.Database database) {
			_tables = new Dictionary<string, Entity.Table>();

			foreach (Smo.Table source in database.Tables) {
				Entity.Table destination = new Entity.Table();
				destination.Name = source.Name;
				destination.ExtendeProperties.ReplaceStringIfNotContains = string.Empty;
				this.SetExtendedProperties(source.ExtendedProperties, destination.ExtendeProperties);
				
				_tables.Add(destination.Name, destination);
			}
		}

		private void SetColumns(Smo.Table table) {

			Entity.Table destination = _tables[table.Name];

			foreach (Smo.Column item in table.Columns) {
				Entity.Column col = new Entity.Column();
				destination.Columns.Add(item.Name, col);
				col.Name = item.Name;
				col.IsPrimaryKey = item.InPrimaryKey;
				col.Nullable = item.Nullable;

				col.DataType.Name = item.DataType.Name;
				col.DataType.MaximumLength = item.DataType.MaximumLength;
				col.DataType.NumericPrecision = item.DataType.NumericPrecision;
				col.DataType.NumericScale = item.DataType.NumericScale;
				col.DataType.IsIdentity = item.Identity;
				col.DataType.IdentitySeed = item.IdentitySeed;
				col.DataType.IdentityIncrement = item.IdentityIncrement;

				col.ExtendeProperties.ReplaceStringIfNotContains = string.Empty;
				this.SetExtendedProperties(item.ExtendedProperties, col.ExtendeProperties);
			}

		}

		/// <summary>
		/// 拡張プロパティを設定します。
		/// </summary>
		/// <param name="source">取得元</param>
		/// <param name="destination">設定先</param>
		private void SetExtendedProperties(
			Smo.ExtendedPropertyCollection source,
			Entity.ExtendedProperties destination) {

			foreach (Smo.ExtendedProperty property in source) {
				destination.Add(property.Name, property.Value.ToString());
			}
		}

		#endregion 初期化

	}
}
