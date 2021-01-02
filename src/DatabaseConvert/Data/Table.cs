using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConvert.Data {

	/// <summary>
	/// テーブルのインスタンスを示します。
	/// </summary>
	public class Table {

		#region プロパティ

		/// <summary>
		/// 物理テーブル名
		/// </summary>
		private string _physicalName;

		public string PhysicalName {
			get {
				return _physicalName;
			}
			set {
				_physicalName = value;
			}
		}

		/// <summary>
		/// 論理テーブル名
		/// </summary>
		private string _logicalName;

		public string LogicalName {
			get {
				return _logicalName;
			}
			set {
				_logicalName = value;
			}
		}

		/// <summary>
		/// 備考
		/// </summary>
		private string _remarks;

		public string Remarks {
			get {
				return _remarks;
			}
			set {
				_remarks = value;
			}
		}

		private List<Column> _columns;

		public List<Column> Columns {
			get {
				return _columns;
			}
			set {
				_columns = value;
			}
		}
	
		/// <summary>
		/// プロパティ名リスト
		/// </summary>
		public List<string> PropertyNames {
			get {
				// TODO:プロパティ名を動的に取得したい
				List<string> list = new List<string>();
				list.Add("PhysicalName");
				list.Add("LogicalName");
				list.Add("Remarks");
				return list;
			}
		}

		/// <summary>
		/// プロパティ値リスト
		/// </summary>
		public List<string> PropertyValues {
			get {
				List<string> list = new List<string>();
				list.Add(_physicalName);
				list.Add(_logicalName);
				list.Add(_remarks);
				return list;
			}
		}

		///// <summary>
		///// カラムリスト
		///// </summary>
		//private Dictionary<string, Column> _columns;

		//public Dictionary<string, Column> Columns {
		//    get {
		//        return _columns;
		//    }
		//    set {
		//        _columns = value;
		//    }
		//}

		///// <summary>
		///// 拡張プロパティ
		///// </summary>
		//private ExtendedProperties _extendedProperties;

		//public ExtendedProperties ExtendeProperties {
		//    get {
		//        return _extendedProperties;
		//    }
		//}

		#endregion プロパティ

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Table() {
			//_columns = new Dictionary<string, Column>();
			//_extendedProperties = new ExtendedProperties();
			_columns = new List<Column>();
		}

		#endregion コンストラクタ

	}
}
