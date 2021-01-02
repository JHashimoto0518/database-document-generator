using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DocumentExport.Excel {

	/// <summary>
	/// �N�G���𐶐�����@�\��񋟂��܂��B
	/// </summary>
	internal class QueryBuilder {

		#region �t�B�[���h

		/// <summary>
		/// �N�G���̃e���v���[�g
		/// </summary>
		private const string WithCreateQueryTemplate = @"
			SELECT
				*
			INTO
				[{0}]
			FROM (
				{1}
			)";

		private const string OnlyInsertQueryTemplate = @"
			INSERT INTO [{0}$]
				SELECT
					*
				FROM (
					{1}
				)";

		/// <summary>
		/// �N�G��
		/// </summary>
		private StringBuilder _query;

		/// <summary>
		/// �����ɃG�N�X�|�[�g�ł���s���̏��
		/// </summary>
		private const int ExportableRowCountLimit = 49;		// 50�ȏ�́u�N�G�������G�����܂��v�̃G���[�BJet OleDB �v���o�C�_�̐���

		/// <summary>
		/// �ǉ����ꂽ�s��
		/// </summary>
		private int _rowCount;

		/// <summary>
		/// 
		/// </summary>
		private bool _isAddingValue;

		#endregion �t�B�[���h

		#region �v���p�e�B

		/// <summary>
		/// �������ꂽ�N�G���̃��X�g
		/// </summary>
		private List<string> _queryList;
	
		private string _tableName;

		/// <summary>
		/// �G�N�X�|�[�g��̃e�[�u����
		/// </summary>		
		public string TableName {
			get {
				return _tableName;
			}
		}

		#endregion �v���p�e�B

		#region ������

		/// <summary>
		/// ���������܂��B
		/// </summary>
		/// <param name="tableName">�G�N�X�|�[�g��̃e�[�u����</param>
		public void Initialize(string tableName) {
			_rowCount = 0;
			_tableName = tableName;
			_isAddingValue = false;
			_query = new StringBuilder();
			_queryList = new List<string>();
		}

		#endregion ������

		#region �N�G���擾

		/// <summary>
		/// �������ꂽ�N�G���̃��X�g���擾���܂��B
		/// </summary>
		/// <returns></returns>
		public List<string> GetQueryList() {
			if (_query.Length != 0) {
				_queryList.Add(this.CreateQuery());
				_query.Length = 0;
			}

			return _queryList;
		}

		#endregion �N�G���擾

		#region �N�G������


		public void AddValue(string name, object value) {

			if (!_isAddingValue) {
				_rowCount++;
				_query.Append(" SELECT ").Append(_rowCount).Append(" AS [ID]");
				_isAddingValue = true;
			}

			this.AddValueToQuery(name, value);
		}

		/// <summary>
		/// �T�u�N�G���𐶐����܂��B
		/// </summary>
		/// <param name="row">�G�N�X�|�[�g����s</param>
		/// <param name="id">���R�[�h�̃L�[�ƂȂ�A��</param>
		/// <returns></returns>
		private void AddValueToQuery(string name, object value) {
			_query.Append(", ");

			if (value.GetType() == typeof(String)) {
				string s = value.ToString().Replace("'", "''");
				s = "'" + s + "'";
				_query.Append(s);
			} else {
				_query.Append(value);
			}

			_query.Append(" AS [").Append(name).Append("]");
		}

		public void EndAddition() {
			_query.Append(" FROM [Dummy$]");
			_query.Append("UNION");

			_isAddingValue = false;

			if (_rowCount == ExportableRowCountLimit) {
				_queryList.Add(this.CreateQuery());
				_query.Length = 0;
			}
		}

		#endregion �N�G������

		#region �N�G������(old)

		/// <summary>
		/// �G�N�X�|�[�g����s��ǉ����܂��B
		/// </summary>
		/// <param name="row"></param>
		public void AddRow(DataRow row) {
			_rowCount++;

			_query.Append(this.CreateSubQuery(row, _rowCount));
			_query.Append("UNION");

			if (_rowCount == ExportableRowCountLimit) {
				_queryList.Add(this.CreateQuery());
				_query.Length = 0;
			}
		}

		/// <summary>
		/// �N�G���𐶐����܂��B
		/// </summary>
		/// <returns></returns>
		private string CreateQuery() {
			_query.Length = _query.Length - "UNION".Length;

			if (_rowCount > 1) {	// 1���̂Ƃ�OrderBy���w�肷��ƃG���[
				_query.AppendLine("ORDER BY [ID]");
			}

			return string.Format(
				_queryList.Count == 0 ? WithCreateQueryTemplate : OnlyInsertQueryTemplate,	// 2��ڈȍ~��INSERT�݂̂łȂ��ƃG���[
				_tableName,
				_query.ToString()
			);
		}

		/// <summary>
		/// �T�u�N�G���𐶐����܂��B
		/// </summary>
		/// <param name="row">�G�N�X�|�[�g����s</param>
		/// <param name="id">���R�[�h�̃L�[�ƂȂ�A��</param>
		/// <returns></returns>
		private string CreateSubQuery(DataRow row, int id) {
			StringBuilder sb = new StringBuilder();
			sb.Append(" SELECT ").Append(id).Append(" AS [ID]");
			foreach (DataColumn col in row.Table.Columns) {
				// TODO:
				if (col.ColumnName == "Enabled") continue;

				sb.Append(", ");

				if (col.DataType == typeof(String)) {
					string value = row.ItemArray[col.Ordinal].ToString();
					value = value.Replace("'", "''");
					value = "'" + value + "'";
					sb.Append(value);
				} else {
					sb.Append(row.ItemArray[col.Ordinal]);
				}

				sb.Append(" AS [").Append(col.ColumnName).Append("]");
			}

			sb.Append(" FROM [Dummy$]");
			return sb.ToString();
		}
 
		#endregion �N�G������

	}

}
