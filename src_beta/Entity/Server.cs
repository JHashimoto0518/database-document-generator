using System;
using System.Collections.Generic;
using System.Text;

namespace Entity {

	/// <summary>
	/// ＤＢサーバーを示します。
	/// </summary>
	public class Server {

		#region プロパティ

		/// <summary>
		/// データベースリスト
		/// </summary>
		private Dictionary<string, Database> _databases;

		public Dictionary<string, Database> Databases {
			get {
				return _databases;
			}
			set {
				_databases = value;
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
		public Server() {
			_extendedProperties = new ExtendedProperties();
		}

		#endregion コンストラクタ

	}
}
