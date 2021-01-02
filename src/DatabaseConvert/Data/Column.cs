using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseConvert.Data {

	/// <summary>
	/// �J�����̃C���X�^���X�������܂��B
	/// </summary>
	public class Column {

		#region �v���p�e�B

		/// <summary>
		/// ���O
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

		private string _dataType;

		public string DataType {
			get {
				return _dataType;
			}
			set {
				_dataType = value;
			}
		}

		private string _maximumLength;

		public string MaximumLength {
			get {
				return _maximumLength;
			}
			set {
				_maximumLength = value;
			}
		}

		private string _numelicPrecision;

		public string NumelicPrecision {
			get {
				return _numelicPrecision;
			}
			set {
				_numelicPrecision = value;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		private string _notNull;

		public string NotNull {
			get {
				return _notNull;
			}
			set {
				_notNull = value;
			}
		}

		private string _default;

		public string Default {
			get {
				return _default;
			}
			set {
				_default = value;
			}
		}
	
		/// <summary>
		/// 
		/// </summary>
		private string _primaryKey;

		public string PrimaryKey {
			get {
				return _primaryKey;
			}
			set {
				_primaryKey = value;
			}
		}

		private string _identity;

		public string Identity {
			get {
				return _identity;
			}
			set {
				_identity = value;
			}
		}

		private string _summary;

		public string Summary {
			get {
				return _summary;
			}
			set {
				_summary = value;
			}
		}

		/// <summary>
		/// �v���p�e�B�����X�g
		/// </summary>
		public List<string> PropertyNames {
			get {
				List<string> list = new List<string>();
				list.Add("Name");
				list.Add("DataType");
				list.Add("MaximumLength");
				list.Add("NumelicPrecision");
				list.Add("NotNull");
				list.Add("Default");
				list.Add("PrimaryKey");
				list.Add("Identity");
				list.Add("Summary");
				return list;
			}
		}

		/// <summary>
		/// �v���p�e�B�l���X�g
		/// </summary>
		public List<string> PropertyValues {
			get {
				List<string> list = new List<string>();
				list.Add(_name);
				list.Add(_dataType);
				list.Add(_maximumLength);
				list.Add(_numelicPrecision);
				list.Add(_notNull);
				list.Add(_default);
				list.Add(_primaryKey);
				list.Add(_identity);
				list.Add(_summary);
				return list;
			}
		}
	
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
		public Column() {
			//_dataType = new DataType();
			//_extendedProperties = new ExtendedProperties();
		}

		#endregion �R���X�g���N�^
	
	}

}
