using System;
using System.Collections.Generic;
using System.Text;

namespace Entity {

	/// <summary>
	/// データベースを示します。
	/// </summary>
	public class Database {

		#region プロパティ
		
		private Dictionary<string, Table> _tables;

		public Dictionary<string, Table> Tables {
			get {
				return _tables;
			}
			set {
				_tables = value;
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
		public Database() {
			_extendedProperties = new ExtendedProperties();
		}

		#endregion コンストラクタ

	}
}
