using System;
using Entity;

namespace DatabaseProvider {

	/// <summary>
	/// データベース情報を提供します。
	/// </summary>
	public interface IProvider {

		/// <summary>
		/// 初期化します。
		/// </summary>
		/// <param name="connectionString">接続文字列</param>
		void Initialize(string connectionString);

	}

}
