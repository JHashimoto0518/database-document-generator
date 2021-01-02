using System;
using Microsoft.SqlServer.Management.Smo;

namespace DatabaseProvider {

	/// <summary>
	/// 拡張プロパティのヘルパー
	/// </summary>
	public static class ExtendedPropertyHelper {

		/// <summary>
		/// 拡張プロパティの値を取得します。
		/// </summary>
		/// <param name="properties">拡張プロパティコレクション</param>
		/// <param name="name">プロパティ名</param>
		/// <param name="textIfNotContains">プロパティが存在しない時に返却されます。</param>
		/// <returns>プロパティの値</returns>
		public static string GetValue(
			ExtendedPropertyCollection properties,
			string name,
			string textIfNotContains) {

			if (!properties.Contains(name)) {
				return textIfNotContains;
			}

			return properties[name].Value.ToString();
		}

		/// <summary>
		/// 拡張プロパティの値を取得します。
		/// </summary>
		/// <param name="properties">拡張プロパティコレクション</param>
		/// <param name="name">プロパティ名</param>
		/// <returns>プロパティの値</returns>
		/// <remarks>プロパティが存在しない時は空文字列を返却します。</remarks>
		public static string GetValue(
			ExtendedPropertyCollection properties,
			string name) {

			return ExtendedPropertyHelper.GetValue(properties, name, string.Empty);
		}
	}
}
