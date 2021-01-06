using System;
using System.Collections.Generic;
using System.Text;

namespace Entity {

	/// <summary>
	/// 拡張プロパティを示します
	/// </summary>
	public class ExtendedProperties {

		#region プロパティ

		/// <summary>
		/// 拡張プロパティリスト
		/// </summary>
		private Dictionary<string, string> _properties;

		/// <summary>
		/// プロパティが存在しない場合に返却する文字列
		/// </summary>
		private string _replaceStringIfNotContains;

		public string ReplaceStringIfNotContains {
			get {
				return _replaceStringIfNotContains;
			}
			set {
				_replaceStringIfNotContains = value;
			}
		}

		#endregion プロパティ

		#region コンストラクタ

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ExtendedProperties() {

			_replaceStringIfNotContains = null;

			_properties = new Dictionary<string, string>();
		}

		#endregion コンストラクタ

		#region GetValue

		/// <summary>
		/// プロパティの値を取得します。
		/// </summary>
		/// <param name="name">プロパティ名</param>
		/// <returns>値</returns>
		public string GetValue(string name) {
			if (!_properties.ContainsKey(name)) {
				if (_replaceStringIfNotContains != null) {
					return _replaceStringIfNotContains;
				}

				throw new ArgumentException(string.Format("{0}は存在しない拡張プロパティです。", name));
			}

			return _properties[name];
		}

		#endregion GetValue

		#region Add
		
		/// <summary>
		/// プロパティを追加します。
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public void Add(string name, string value){
			_properties.Add(name, value);
		}

		#endregion Add
	
	}
}
