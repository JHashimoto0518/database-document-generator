using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConvert.Data {

	/// <summary>
	/// データベースのインスタンスを示します。
	/// </summary>
	public class Database {

		#region プロパティ

		/// <summary>
		/// テーブルリスト
		/// </summary>
		private List<Table> _tables;

		public List<Table> Tables {
			get {
				return _tables;
			}
		}

		#endregion プロパティ

		#region コンストラクタ
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Database() {
			_tables = new List<Table>();
		}

		#endregion コンストラクタ

	}
}
