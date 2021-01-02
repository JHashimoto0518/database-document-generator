using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace DocumentExport.Excel {

	/// <summary>
	/// Excelのマクロを実行する機能を提供します。
	/// </summary>
	internal class MacroExecutor {

		public void Execute(string filePath, string macroName) {
			Application application = null;
			Workbooks workbooks = null;
			Workbook workbook = null;

			try {
				application = new ApplicationClass();
				workbooks = application.Workbooks;

				workbook = workbooks.Open(
					filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing
					, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
					, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

				application.Run(
					macroName, Type.Missing, Type.Missing, Type.Missing, Type.Missing
					, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
					, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
					, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
					, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
					, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing
					, Type.Missing);
			} finally {
				if (workbook != null) {
					try {
						workbook.Close(true, Type.Missing, Type.Missing); 
					} catch {
					}
				}

				if (application != null) {
					try {
						application.Quit();
					} catch {
					}
				}

				ReleaseComObjects(workbook, workbooks, application);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="objects"></param>
		private void ReleaseComObjects(params object[] objects) {
			try {
				for (int i = 0; i < objects.Length; i++) {
					if (objects[i] == null)
						continue;
					if (Marshal.IsComObject(objects[i]) == false)
						continue;

					Marshal.ReleaseComObject(objects[i]);
					objects[i] = null;					
				}
			} catch {
			}
		}
	}
}
