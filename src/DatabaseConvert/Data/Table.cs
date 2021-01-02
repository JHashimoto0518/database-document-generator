using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConvert.Data {

	/// <summary>
	/// �e�[�u���̃C���X�^���X�������܂��B
	/// </summary>
	public class Table {

		#region �v���p�e�B

		/// <summary>
		/// �����e�[�u����
		/// </summary>
		private string _physicalName;

		public string PhysicalName {
			get {
				return _physicalName;
			}
			set {
				_physicalName = value;
			}
		}

		/// <summary>
		/// �_���e�[�u����
		/// </summary>
		private string _logicalName;

		public string LogicalName {
			get {
				return _logicalName;
			}
			set {
				_logicalName = value;
			}
		}

		/// <summary>
		/// ���l
		/// </summary>
		private string _remarks;

		public string Remarks {
			get {
				return _remarks;
			}
			set {
				_remarks = value;
			}
		}

		private List<Column> _columns;

		public List<Column> Columns {
			get {
				return _columns;
			}
			set {
				_columns = value;
			}
		}
	
		/// <summary>
		/// �v���p�e�B�����X�g
		/// </summary>
		public List<string> PropertyNames {
			get {
				// TODO:�v���p�e�B���𓮓I�Ɏ擾������
				List<string> list = new List<string>();
				list.Add("PhysicalName");
				list.Add("LogicalName");
				list.Add("Remarks");
				return list;
			}
		}

		/// <summary>
		/// �v���p�e�B�l���X�g
		/// </summary>
		public List<string> PropertyValues {
			get {
				List<string> list = new List<string>();
				list.Add(_physicalName);
				list.Add(_logicalName);
				list.Add(_remarks);
				return list;
			}
		}

		///// <summary>
		///// �J�������X�g
		///// </summary>
		//private Dictionary<string, Column> _columns;

		//public Dictionary<string, Column> Columns {
		//    get {
		//        return _columns;
		//    }
		//    set {
		//        _columns = value;
		//    }
		//}

		///// <summary>
		///// �g���v���p�e�B
		///// </summary>
		//private ExtendedProperties _extendedProperties;

		//public ExtendedProperties ExtendeProperties {
		//    get {
		//        return _extendedProperties;
		//    }
		//}

		#endregion �v���p�e�B

		#region �R���X�g���N�^

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public Table() {
			//_columns = new Dictionary<string, Column>();
			//_extendedProperties = new ExtendedProperties();
			_columns = new List<Column>();
		}

		#endregion �R���X�g���N�^

	}
}
