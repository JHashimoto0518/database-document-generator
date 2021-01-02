using System;
using System.Collections.Generic;
using System.Text;

namespace UI {

	/// <summary>
	/// ���O�o�͋@�\��񋟂��܂��B
	/// </summary>
	internal static class Logger {

		/// <summary>
		/// ���O�t�@�C����
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
		/// ���O���o�͂��܂��B
		/// </summary>
		/// <param name="message">���b�Z�[�W</param>
		/// <param name="o">�o�͓��e</param>
		public static void Write(string message, object o) {
			System.IO.File.AppendAllText(
				_logPathName,
				DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "\t" + message + Environment.NewLine +
				o == null ? string.Empty : (o.ToString() + Environment.NewLine));
		}
	}
}
