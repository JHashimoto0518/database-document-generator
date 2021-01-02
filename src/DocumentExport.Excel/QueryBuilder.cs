using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DocumentExport.Excel {

	/// <summary>
	/// クエリを生成する機能を提供します。
	/// </summary>
	internal class QueryBuilder {

		#region フィールド

		/// <summary>
		/// クエリのテンプレート
		/// </summary>
		private const string WithCreateQueryTemplate = @"
			SELECT
				*
			INTO
				[{0}]
			FROM (
				{1}
			)";

		private const string OnlyInsertQueryTemplate = @"
			INSERT INTO [{0}$]
				SELECT
					*
				FROM (
					{1}
				)";

		/// <summary>
		/// クエリ
		/// </summary>
		private StringBuilder _query;

		/// <summary>
		/// 同時にエクスポートできる行数の上限
		/// </summary>
		private const int ExportableRowCountLimit = 49;		// 50以上は「クエリが複雑すぎます」のエラー。Jet OleDB プロバイダの制限

		/// <summary>
		/// 追加された行数
		/// </summary>
		private int _rowCount;

		/// <summary>
		/// 
		/// </summary>
		private bool _isAddingValue;

		#endregion フィールド

		#region プロパティ

		/// <summary>
		/// 生成されたクエリのリスト
		/// </summary>
		private List<string> _queryList;
	
		private string _tableName;

		/// <summary>
		/// エクスポート先のテーブル名
		/// </summary>		
		public string TableName {
			get {
				return _tableName;
			}
		}

		#endregion プロパティ

		#region 初期化

		/// <summary>
		/// 初期化します。
		/// </summary>
		/// <param name="tableName">エクスポート先のテーブル名</param>
		public void Initialize(string tableName) {
			_rowCount = 0;
			_tableName = tableName;
			_isAddingValue = false;
			_query = new StringBuilder();
			_queryList = new List<string>();
		}

		#endregion 初期化

		#region クエリ取得

		/// <summary>
		/// 生成されたクエリのリストを取得します。
		/// </summary>
		/// <returns></returns>
		public List<string> GetQueryList() {
			if (_query.Length != 0) {
				_queryList.Add(this.CreateQuery());
				_query.Length = 0;
			}

			return _queryList;
		}

		#endregion クエリ取得

		#region クエリ生成


		public void AddValue(string name, object value) {

			if (!_isAddingValue) {
				_rowCount++;
				_query.Append(" SELECT ").Append(_rowCount).Append(" AS [ID]");
				_isAddingValue = true;
			}

			this.AddValueToQuery(name, value);
		}

		/// <summary>
		/// サブクエリを生成します。
		/// </summary>
		/// <param name="row">エクスポートする行</param>
		/// <param name="id">レコードのキーとなる連番</param>
		/// <returns></returns>
		private void AddValueToQuery(string name, object value) {
			_query.Append(", ");

			if (value.GetType() == typeof(String)) {
				string s = value.ToString().Replace("'", "''");
				s = "'" + s + "'";
				_query.Append(s);
			} else {
				_query.Append(value);
			}

			_query.Append(" AS [").Append(name).Append("]");
		}

		public void EndAddition() {
			_query.Append(" FROM [Dummy$]");
			_query.Append("UNION");

			_isAddingValue = false;

			if (_rowCount == ExportableRowCountLimit) {
				_queryList.Add(this.CreateQuery());
				_query.Length = 0;
			}
		}

		#endregion クエリ生成

		#region クエリ生成(old)

		/// <summary>
		/// エクスポートする行を追加します。
		/// </summary>
		/// <param name="row"></param>
		public void AddRow(DataRow row) {
			_rowCount++;

			_query.Append(this.CreateSubQuery(row, _rowCount));
			_query.Append("UNION");

			if (_rowCount == ExportableRowCountLimit) {
				_queryList.Add(this.CreateQuery());
				_query.Length = 0;
			}
		}

		/// <summary>
		/// クエリを生成します。
		/// </summary>
		/// <returns></returns>
		private string CreateQuery() {
			_query.Length = _query.Length - "UNION".Length;

			if (_rowCount > 1) {	// 1件のときOrderByを指定するとエラー
				_query.AppendLine("ORDER BY [ID]");
			}

			return string.Format(
				_queryList.Count == 0 ? WithCreateQueryTemplate : OnlyInsertQueryTemplate,	// 2回目以降はINSERTのみでないとエラー
				_tableName,
				_query.ToString()
			);
		}

		/// <summary>
		/// サブクエリを生成します。
		/// </summary>
		/// <param name="row">エクスポートする行</param>
		/// <param name="id">レコードのキーとなる連番</param>
		/// <returns></returns>
		private string CreateSubQuery(DataRow row, int id) {
			StringBuilder sb = new StringBuilder();
			sb.Append(" SELECT ").Append(id).Append(" AS [ID]");
			foreach (DataColumn col in row.Table.Columns) {
				// TODO:
				if (col.ColumnName == "Enabled") continue;

				sb.Append(", ");

				if (col.DataType == typeof(String)) {
					string value = row.ItemArray[col.Ordinal].ToString();
					value = value.Replace("'", "''");
					value = "'" + value + "'";
					sb.Append(value);
				} else {
					sb.Append(row.ItemArray[col.Ordinal]);
				}

				sb.Append(" AS [").Append(col.ColumnName).Append("]");
			}

			sb.Append(" FROM [Dummy$]");
			return sb.ToString();
		}
 
		#endregion クエリ生成

	}

}
