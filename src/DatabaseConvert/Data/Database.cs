using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConvert.Data {

	/// <summary>
	/// �f�[�^�x�[�X�̃C���X�^���X�������܂��B
	/// </summary>
	public class Database {

		#region �v���p�e�B

		/// <summary>
		/// �e�[�u�����X�g
		/// </summary>
		private List<Table> _tables;

		public List<Table> Tables {
			get {
				return _tables;
			}
		}

		#endregion �v���p�e�B

		#region �R���X�g���N�^
		
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public Database() {
			_tables = new List<Table>();
		}

		#endregion �R���X�g���N�^

	}
}
