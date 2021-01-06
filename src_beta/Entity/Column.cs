using System;
using System.Collections.Generic;
using System.Text;

namespace Entity {

	/// <summary>
	/// 
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

		/// <summary>
		/// true:Null����, false:�s����
		/// </summary>
		private bool _isNullable;

		public bool Nullable {
			get {
				return _isNullable;
			}
			set {
				_isNullable = value;
			}
		}

		/// <summary>
		/// true:�v���C�}���L�[
		/// </summary>
		private bool isPrimaryKey;

		public bool IsPrimaryKey {
			get {
				return isPrimaryKey;
			}
			set {
				isPrimaryKey = value;
			}
		}

		/// <summary>
		/// �f�[�^�^
		/// </summary>
		private DataType _dataType;

		public DataType DataType {
			get {
				return _dataType;
			}
			set {
				_dataType = value;
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
		public Column() {
			_dataType = new DataType();
			_extendedProperties = new ExtendedProperties();
		}

		#endregion �R���X�g���N�^
	
	}

}
