using System;
using System.Collections.Generic;
using System.Text;

namespace Entity {

	/// <summary>
	/// �f�[�^�x�[�X�������܂��B
	/// </summary>
	public class Database {

		#region �v���p�e�B
		
		private Dictionary<string, Table> _tables;

		public Dictionary<string, Table> Tables {
			get {
				return _tables;
			}
			set {
				_tables = value;
			}
		}
	
		/// <summary>
		/// �g���v���p�e�B
		/// </summary>
		private ExtendedProperties _extendedProperties;

		public ExtendedProperties ExtendeProperties {
			get {
				return _extendedProperties;
			}
		}

		#endregion �v���p�e�B

		#region �R���X�g���N�^
		
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public Database() {
			_extendedProperties = new ExtendedProperties();
		}

		#endregion �R���X�g���N�^

	}
}
