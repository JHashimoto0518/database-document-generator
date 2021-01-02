using System;
using Microsoft.SqlServer.Management.Smo;

namespace DatabaseProvider {

	/// <summary>
	/// �g���v���p�e�B�̃w���p�[
	/// </summary>
	public static class ExtendedPropertyHelper {

		/// <summary>
		/// �g���v���p�e�B�̒l���擾���܂��B
		/// </summary>
		/// <param name="properties">�g���v���p�e�B�R���N�V����</param>
		/// <param name="name">�v���p�e�B��</param>
		/// <param name="textIfNotContains">�v���p�e�B�����݂��Ȃ����ɕԋp����܂��B</param>
		/// <returns>�v���p�e�B�̒l</returns>
		public static string GetValue(
			ExtendedPropertyCollection properties,
			string name,
			string textIfNotContains) {

			if (!properties.Contains(name)) {
				return textIfNotContains;
			}

			return properties[name].Value.ToString();
		}

		/// <summary>
		/// �g���v���p�e�B�̒l���擾���܂��B
		/// </summary>
		/// <param name="properties">�g���v���p�e�B�R���N�V����</param>
		/// <param name="name">�v���p�e�B��</param>
		/// <returns>�v���p�e�B�̒l</returns>
		/// <remarks>�v���p�e�B�����݂��Ȃ����͋󕶎����ԋp���܂��B</remarks>
		public static string GetValue(
			ExtendedPropertyCollection properties,
			string name) {

			return ExtendedPropertyHelper.GetValue(properties, name, string.Empty);
		}
	}
}
