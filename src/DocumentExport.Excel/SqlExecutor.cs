using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace DocumentExport {

	/// <summary>
	/// SQLを実行する機能を提供します。
	/// </summary>
	internal class SqlExecutor : IDisposable {

		#region フィールド

		/// <summary>
		/// DB接続
		/// </summary>
		private OleDbConnection _connection;

		#endregion フィールド

		#region プロパティ

		/// <summary>
		/// 実行するSQLを格納する
		/// </summary>
		private OleDbCommand _command;

		public string Sql {
			get {
				return _command.CommandText;
			}
			set {
				_command.CommandText = value;
			}
		}
	
		public OleDbParameterCollection Parameters {
			get {
				return _command.Parameters;
			}
		}
	
		#endregion プロパティ

		#region コンストラクタ

		public SqlExecutor() {
			_command = new OleDbCommand();
		}

		#endregion コンストラクタ

		#region 接続

		/// <summary>
		/// DBに接続します。
		/// </summary>
		/// <param name="connectionString">接続文字列</param>
		public void Connect(string connectionString) {
			_connection = new OleDbConnection(connectionString);
			_connection.Open();

			_command.Connection = _connection;
		}

		#endregion 接続

		#region 出力

		/// <summary>
		/// SQLを実行します。
		/// </summary>
		/// <param name="sql">SQL</param>
		public void ExecuteNonQuery() {
			try {
				_command.ExecuteNonQuery();
			} catch (Exception ex) {
				throw new Exception("コマンドの実行でエラーが発生しました。CommandText:" + _command.CommandText, ex);
			}
		}

		#endregion 出力

		#region 終了処理

		/// <summary>
		/// リソースを解放します。
		/// </summary>
		void IDisposable.Dispose() {
			if (_command != null) {
				_command.Dispose();
			}

			if (_connection != null) {
				if (_connection.State == System.Data.ConnectionState.Open) {
					_connection.Close();
					_connection.Dispose();
				}
			}
		}

		#endregion 終了処理

	}
}
