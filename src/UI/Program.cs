using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;

namespace UI {
	static class Program {
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() {
			Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
			Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(Program_UnhandledException);
			// TODO:調査
			//Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			MainForm f = new MainForm();
			f.Initialize();
			Application.Run(f);
		}

		/// <summary>
		/// メインスレッドで発生した例外をハンドリングします。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
			Program.HandleException(MethodBase.GetCurrentMethod().Name + " で例外を補足しました。", e.Exception);
		}

		/// <summary>
		/// メインスレッド以外で発生した例外をハンドリングします。
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void Program_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
			Exception ex = e.ExceptionObject as Exception;
			if (ex != null) {
				Program.HandleException(MethodBase.GetCurrentMethod().Name + " で例外を補足しました。", ex);
			}
		}

		/// <summary>
		/// 例外をハンドリングします。
		/// </summary>
		/// <param name="message">メッセージ</param>
		/// <param name="e">例外</param>
		private static void HandleException(string message, Exception e) {
			Logger.LogFilePath = UI.Properties.Settings.Default.LogFilePath;
			Logger.Write(message, e);

			MessageBox.Show(
				e.ToString(),
				message,
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
		}
	}
}
