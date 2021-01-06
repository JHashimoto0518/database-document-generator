using System;
using System.Collections.Generic;
using System.Text;

namespace Entity {

	/// <summary>
	/// 
	/// </summary>
	public class Column {

		#region プロパティ

		/// <summary>
		/// 名前
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
		/// true:Null許可, false:不許可
		/// </summary>
		private bool _isNullable;

		public bool Nullable {
			get {
				return _isNullable;
			}
			set {
				_isNullable = value;
			}
		}

		/// <summary>
		/// true:プライマリキー
		/// </summary>
		private bool isPrimaryKey;

		public bool IsPrimaryKey {
			get {
				return isPrimaryKey;
			}
			set {
				isPrimaryKey = value;
			}
		}

		/// <summary>
		/// データ型
		/// </summary>
		private DataType _dataType;

		public DataType DataType {
			get {
				return _dataType;
			}
			set {
				_dataType = value;
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
		public Column() {
			_dataType = new DataType();
			_extendedProperties = new ExtendedProperties();
		}

		#endregion コンストラクタ
	
	}

}
