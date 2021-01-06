using System;
using System.Collections.Generic;
using System.Text;

namespace Entity {

	/// <summary>
	/// �e�[�u���������܂��B
	/// </summary>
	public class Table {

		#region �v���p�e�B

		/// <summary>
		/// �e�[�u����
		/// </summary>
		private string _name;

		public string Name {
			get {
				return _name;
			}
			set {
				_name = value;
			}
		}

		/// <summary>
		/// �J�������X�g
		/// </summary>
		private Dictionary<string, Column> _columns;

		public Dictionary<string, Column> Columns {
			get {
				return _columns;
			}
			set {
				_columns = value;
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
		public Table() {
			_columns = new Dictionary<string, Column>();
			_extendedProperties = new ExtendedProperties();
		}

		#endregion �R���X�g���N�^

	}
}
