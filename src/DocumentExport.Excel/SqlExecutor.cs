using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace DocumentExport {

	/// <summary>
	/// SQL�����s����@�\��񋟂��܂��B
	/// </summary>
	internal class SqlExecutor : IDisposable {

		#region �t�B�[���h

		/// <summary>
		/// DB�ڑ�
		/// </summary>
		private OleDbConnection _connection;

		#endregion �t�B�[���h

		#region �v���p�e�B

		/// <summary>
		/// ���s����SQL���i�[����
		/// </summary>
		private OleDbCommand _command;

		public string Sql {
			get {
				return _command.CommandText;
			}
			set {
				_command.CommandText = value;
			}
		}
	
		public OleDbParameterCollection Parameters {
			get {
				return _command.Parameters;
			}
		}
	
		#endregion �v���p�e�B

		#region �R���X�g���N�^

		public SqlExecutor() {
			_command = new OleDbCommand();
		}

		#endregion �R���X�g���N�^

		#region �ڑ�

		/// <summary>
		/// DB�ɐڑ����܂��B
		/// </summary>
		/// <param name="connectionString">�ڑ�������</param>
		public void Connect(string connectionString) {
			_connection = new OleDbConnection(connectionString);
			_connection.Open();

			_command.Connection = _connection;
		}

		#endregion �ڑ�

		#region �o��

		/// <summary>
		/// SQL�����s���܂��B
		/// </summary>
		/// <param name="sql">SQL</param>
		public void ExecuteNonQuery() {
			try {
				_command.ExecuteNonQuery();
			} catch (Exception ex) {
				throw new Exception("�R�}���h�̎��s�ŃG���[���������܂����BCommandText:" + _command.CommandText, ex);
			}
		}

		#endregion �o��

		#region �I������

		/// <summary>
		/// ���\�[�X��������܂��B
		/// </summary>
		void IDisposable.Dispose() {
			if (_command != null) {
				_command.Dispose();
			}

			if (_connection != null) {
				if (_connection.State == System.Data.ConnectionState.Open) {
					_connection.Close();
					_connection.Dispose();
				}
			}
		}

		#endregion �I������

	}
}
