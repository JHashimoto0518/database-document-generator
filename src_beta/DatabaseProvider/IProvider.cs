using System;
using Entity;

namespace DatabaseProvider {

	/// <summary>
	/// �f�[�^�x�[�X����񋟂��܂��B
	/// </summary>
	public interface IProvider {

		/// <summary>
		/// ���������܂��B
		/// </summary>
		/// <param name="connectionString">�ڑ�������</param>
		void Initialize(string connectionString);

	}

}
