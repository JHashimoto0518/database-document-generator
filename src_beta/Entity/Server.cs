using System;
using System.Collections.Generic;
using System.Text;

namespace Entity {

	/// <summary>
	/// �c�a�T�[�o�[�������܂��B
	/// </summary>
	public class Server {

		#region �v���p�e�B

		/// <summary>
		/// �f�[�^�x�[�X���X�g
		/// </summary>
		private Dictionary<string, Database> _databases;

		public Dictionary<string, Database> Databases {
			get {
				return _databases;
			}
			set {
				_databases = value;
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
		public Server() {
			_extendedProperties = new ExtendedProperties();
		}

		#endregion �R���X�g���N�^

	}
}
