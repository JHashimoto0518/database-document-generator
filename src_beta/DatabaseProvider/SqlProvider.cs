using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SqlServer.Management.Common;
using Smo = Microsoft.SqlServer.Management.Smo;

namespace DatabaseProvider {

	/// <summary>
	/// SqlServer�̏���񋟂��܂��B
	/// </summary>
	public class SqlProvider : IProvider {

		#region �t�B�[���h

		/// <summary>
		/// �T�[�o�[
		/// </summary>
		private Smo.Server _server;

		/// <summary>
		/// �e�[�u�����
		/// </summary>
		private Dictionary<string, Entity.Table> _tables;

		public Dictionary<string, Entity.Table> Tables {
			get {
				return _tables;
			}
		}

		#endregion �t�B�[���h

		#region ������

		/// <summary>
		/// ���������܂��B
		/// </summary>
		public void Initialize(string connectionString) {

			this.Connect(connectionString);

			Smo.Database database = this.GetCurrentDatabase();

			this.SetTables(database);
			foreach (Smo.Table table in database.Tables) {
				this.SetColumns(table);
			}

			this.Disconnect();
		}

		/// <summary>
		/// �ڑ����̃f�[�^�x�[�X���擾���܂��B
		/// </summary>
		/// <returns>�f�[�^�x�[�X</returns>
		private Smo.Database GetCurrentDatabase(){
			return _server.Databases[_server.ConnectionContext.SqlConnectionObject.Database];
		}

		/// <summary>
		/// �f�[�^�x�[�X�ɐڑ����܂��B
		/// </summary>
		private void Connect(string connectionString) {
			ServerConnection connection = new ServerConnection();
			connection.ConnectionString = connectionString;
			connection.Connect();
			_server = new Smo.Server(connection);
		}

		/// <summary>
		/// �f�[�^�x�[�X�Ƃ̐ڑ���ؒf���܂��B
		/// </summary>
		private void Disconnect() {
			_server.ConnectionContext.Disconnect();
		}

		/// <summary>
		/// �e�[�u������ݒ肵�܂��B
		/// </summary>
		/// <param name="database">�f�[�^�x�[�X</param>
		private void SetTables(Smo.Database database) {
			_tables = new Dictionary<string, Entity.Table>();

			foreach (Smo.Table source in database.Tables) {
				Entity.Table destination = new Entity.Table();
				destination.Name = source.Name;
				destination.ExtendeProperties.ReplaceStringIfNotContains = string.Empty;
				this.SetExtendedProperties(source.ExtendedProperties, destination.ExtendeProperties);
				
				_tables.Add(destination.Name, destination);
			}
		}

		private void SetColumns(Smo.Table table) {

			Entity.Table destination = _tables[table.Name];

			foreach (Smo.Column item in table.Columns) {
				Entity.Column col = new Entity.Column();
				destination.Columns.Add(item.Name, col);
				col.Name = item.Name;
				col.IsPrimaryKey = item.InPrimaryKey;
				col.Nullable = item.Nullable;

				col.DataType.Name = item.DataType.Name;
				col.DataType.MaximumLength = item.DataType.MaximumLength;
				col.DataType.NumericPrecision = item.DataType.NumericPrecision;
				col.DataType.NumericScale = item.DataType.NumericScale;
				col.DataType.IsIdentity = item.Identity;
				col.DataType.IdentitySeed = item.IdentitySeed;
				col.DataType.IdentityIncrement = item.IdentityIncrement;

				col.ExtendeProperties.ReplaceStringIfNotContains = string.Empty;
				this.SetExtendedProperties(item.ExtendedProperties, col.ExtendeProperties);
			}

		}

		/// <summary>
		/// �g���v���p�e�B��ݒ肵�܂��B
		/// </summary>
		/// <param name="source">�擾��</param>
		/// <param name="destination">�ݒ��</param>
		private void SetExtendedProperties(
			Smo.ExtendedPropertyCollection source,
			Entity.ExtendedProperties destination) {

			foreach (Smo.ExtendedProperty property in source) {
				destination.Add(property.Name, property.Value.ToString());
			}
		}

		#endregion ������

	}
}
