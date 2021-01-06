using System;
using System.Collections.Generic;
using System.Text;

namespace Entity {

	/// <summary>
	/// �g���v���p�e�B�������܂�
	/// </summary>
	public class ExtendedProperties {

		#region �v���p�e�B

		/// <summary>
		/// �g���v���p�e�B���X�g
		/// </summary>
		private Dictionary<string, string> _properties;

		/// <summary>
		/// �v���p�e�B�����݂��Ȃ��ꍇ�ɕԋp���镶����
		/// </summary>
		private string _replaceStringIfNotContains;

		public string ReplaceStringIfNotContains {
			get {
				return _replaceStringIfNotContains;
			}
			set {
				_replaceStringIfNotContains = value;
			}
		}

		#endregion �v���p�e�B

		#region �R���X�g���N�^

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public ExtendedProperties() {

			_replaceStringIfNotContains = null;

			_properties = new Dictionary<string, string>();
		}

		#endregion �R���X�g���N�^

		#region GetValue

		/// <summary>
		/// �v���p�e�B�̒l���擾���܂��B
		/// </summary>
		/// <param name="name">�v���p�e�B��</param>
		/// <returns>�l</returns>
		public string GetValue(string name) {
			if (!_properties.ContainsKey(name)) {
				if (_replaceStringIfNotContains != null) {
					return _replaceStringIfNotContains;
				}

				throw new ArgumentException(string.Format("{0}�͑��݂��Ȃ��g���v���p�e�B�ł��B", name));
			}

			return _properties[name];
		}

		#endregion GetValue

		#region Add
		
		/// <summary>
		/// �v���p�e�B��ǉ����܂��B
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public void Add(string name, string value){
			_properties.Add(name, value);
		}

		#endregion Add
	
	}
}
