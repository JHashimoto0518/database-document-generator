using System;
using System.Collections.Generic;
using System.Text;

namespace Entity {

	/// <summary>
	/// テーブルを示します。
	/// </summary>
	public class Table {

		#region プロパティ

		/// <summary>
		/// テーブル名
		/// </summary>
		private string _name;

		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}

		/// <summary>
		/// カラムリスト
		/// </summary>
		private Dictionary<string, Column> _columns;

		public Dictionary<string, Column> Columns {
			get {
				return _columns;
			}
			set {
				_columns = value;
			}
		}

		/// <summary>
		/// 拡張プロパティ
		/// </summary>
		private ExtendedProperties _extendedProperties;

		public ExtendedProperties ExtendeProperties {
		    get {
		        return _extendedProperties;
		    }
		}

		#endregion プロパティ

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Table() {
			_columns = new Dictionary<string, Column>();
			_extendedProperties = new ExtendedProperties();
		}

		#endregion コンストラクタ

	}
}
