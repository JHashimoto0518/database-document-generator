using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DatabaseProvider;
using Entity;

namespace DatabaseProvider {
	public partial class MainForm : Form {

		#region フィールド

		/// <summary>
		/// SQLServer情報取得
		/// </summary>
		private SqlProvider _provider;

		#endregion フィールド

		#region コンストラクタ
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainForm() {
			InitializeComponent();

			this.Load += new EventHandler(MainForm_Load);
		}

		#endregion コンストラクタ

		#region 初期化

		/// <summary>
		/// ロード
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void MainForm_Load(object sender, EventArgs e) {
			_provider = new SqlProvider();
			_provider.Initialize(@"Server=localhost;Database=master;User Id=sa;Password=t6Eww7lL4teE;");
		}
		
		#endregion

		private void button1_Click(object sender, EventArgs e) {
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0}\t{1}\t{2}", "物理ﾃｰﾌﾞﾙ名", "論理ﾃｰﾌﾞﾙ名", "備考");
			sb.AppendLine();

			foreach (Table table in _provider.Tables.Values){
				sb.AppendFormat("{0}\t{1}\t{2}", table.Name, table.ExtendeProperties.GetValue("Summary"), table.ExtendeProperties.GetValue("Remarks"));
				sb.AppendLine();
			}

			System.IO.File.WriteAllText(@"c:\temp\TableList.txt", sb.ToString());
		}

		private void button2_Click(object sender, EventArgs e) {

			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", "列名", "型", "桁数", "NotNull", "Key", "Identity", "備考");
			sb.AppendLine();

			foreach (Column col in _provider.Tables["T_Task"].Columns.Values) {
				sb.AppendFormat(
					"{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}",
					col.Name,
					col.DataType.Name,
					this.GetMaximumLengthText(col.DataType),
					col.Nullable ? string.Empty : "○",
					col.IsPrimaryKey ? "PK" : string.Empty,
					this.GetIdentityText(col.DataType),		
					col.ExtendeProperties.GetValue("Summary"));
				sb.AppendLine();
			}

			System.IO.File.WriteAllText(@"c:\temp\Tables.txt", sb.ToString());
		}

		private string GetMaximumLengthText(DataType dataType) {
			if (dataType.Name == "datetime") {
				return string.Empty;
			}

			if (dataType.NumericPrecision == 0) {
				return dataType.MaximumLength.ToString();
			} else {
				return string.Format("{0}({1})", dataType.NumericPrecision, dataType.NumericScale);
			}
		}

		private string GetIdentityText(DataType dataType) {
			if (!dataType.IsIdentity) {
				return string.Empty;
			}

			return string.Format("{0}({1})", dataType.IdentitySeed, dataType.IdentityIncrement);
		}
	}
}