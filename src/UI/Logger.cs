using System;
using System.Collections.Generic;
using System.Text;

namespace UI {

	/// <summary>
	/// ログ出力機能を提供します。
	/// </summary>
	internal static class Logger {

		/// <summary>
		/// ログファイル名
		/// </summary>
		private static string _logPathName;

		public static string LogFilePath {
			get {
				return _logPathName;
			}
			set {
				_logPathName = value;
			}
		}

		/// <summary>
		/// ログを出力します。
		/// </summary>
		/// <param name="message">メッセージ</param>
		/// <param name="o">出力内容</param>
		public static void Write(string message, object o) {
			System.IO.File.AppendAllText(
				_logPathName,
				DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\t" + message + Environment.NewLine +
				o == null ? string.Empty : (o.ToString() + Environment.NewLine));
		}
	}
}
