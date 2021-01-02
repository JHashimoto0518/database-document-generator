using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;

// TODO:�폜�\��
using DatabaseProvider.Data;
using Entity;
using Entity.DatabaseDataSetTableAdapters;

namespace DatabaseProvider {

	/// <summary>
	/// SqlServer�̏���񋟂��܂��B
	/// </summary>
	public class SqlProvider : IDisposable {

		#region �v���p�e�B

		#region �폜�\��

		///// <summary>
		///// �T�[�o�[�̃C���X�^���X
		///// </summary>
		//private Server _server;

		//private Entity.ServerDataTable _servers;

		//public Entity.ServerDataTable Servers {
		//    get {
		//        return _servers;
		//    }
		//}

		//public string CurrentDatabaseName {
		//    get {
		//        return _server.ConnectionContext.SqlConnectionObject.Database;
		//    }
		//}

		///// <summary>
		///// �ڑ����̃f�[�^�x�[�X
		///// </summary>
		//public Database CurrentDatabase {
		//    get {
		//        return _server.Databases[_server.ConnectionContext.SqlConnectionObject.Database];
		//    }
		//}

		#endregion �폜�\��		
		
		public string ConnectionString { get; set; }

		public DatabaseDataSet DatabaseDataSet { get; private set; }

		#endregion �v���p�e�B

		#region ������

		//public void ConnectDatabase(string connectionString) {
		//    _server = this.GetServerInstance(connectionString);
		//}

		public void SetDatabaseInfo() {

			this.DatabaseDataSet = new DatabaseDataSet();

			// TODO:�ڑ�����w��ł���悤�ɂ���
			//using (SqlConnection con = new SqlConnection(this.ConnectionString)) {
			//    con.Open();

				using (TablesDataTableTableAdapter ta = new TablesDataTableTableAdapter()) {
					ta.Fill(this.DatabaseDataSet.TablesDataTable , "TestDB", "dbo", "BASE_TABLE");
				}

			//}
		}


		///// <summary>
		///// �T�[�o�[�̃C���X�^���X���擾���܂��B
		///// </summary>
		///// <param name="connectionString">�ڑ�������</param>
		//private Server GetServerInstance(string connectionString) {
		//    ServerConnection connection = new ServerConnection();
		//    connection.ConnectionString = connectionString;
		//    connection.Connect();
		//    return new Server(connection);
		//}

		//private Entity.ServerDataTable GetEntity(Server serverInstance) {
		//    Entity.ServerDataTable servers = this.CreateServersEntity(serverInstance);
		//    servers[0].Databases = this.CreateDatabasesEntity(this.CurrentDatabase);
		//    servers[0].Databases[0].Tables = this.CreateTablesEntity(this.CurrentDatabase.Tables);

		//    return servers;
		//}

		//private Entity.ServerDataTable CreateServersEntity(Server server) {
		//    Entity.ServerDataTable serversEntity = new Entity.ServerDataTable();
		//    serversEntity.AddServerRow(server.Name); 

		//    return serversEntity;
		//}

		//private Entity.DatabaseDataTable CreateDatabasesEntity(Database database) {
		//    Entity.DatabaseDataTable databasesEntity = new Entity.DatabaseDataTable();
		//    databasesEntity.AddDatabaseRow(database.Name);
		//    return databasesEntity;
		//}

		//private Entity.TableDataTable CreateTablesEntity(TableCollection tables) {
		//    Entity.TableDataTable tablesEntity = new Entity.TableDataTable();

		//    foreach (Table table in tables) {
		//        Entity.TableRow tableEntity = tablesEntity.NewTableRow();
		//        tableEntity.Name = table.Name;
		//        tableEntity.LogicalName = ExtendedPropertyHelper.GetValue(table.ExtendedProperties, "Summary");
		//        tableEntity.Remarks = ExtendedPropertyHelper.GetValue(table.ExtendedProperties, "Remarks");
		//        tableEntity.Columns = this.CreateColumnsEntity(table);

		//        tablesEntity.AddTableRow(tableEntity);			
		//    }

		//    return tablesEntity;
		//}

		//private Entity.ColumnDataTable CreateColumnsEntity(Table table) {
		//    Entity.ColumnDataTable columnsEntity = new Entity.ColumnDataTable();

		//    foreach (Column column in table.Columns) {
		//        Entity.ColumnRow columnEntity = columnsEntity.NewColumnRow();
		//        columnEntity.Name = column.Name;
		//        columnEntity.DataType = column.DataType.Name;
		//        columnEntity.MaximumLength = column.DataType.MaximumLength;
		//        columnEntity.NumericPrecision = column.DataType.NumericPrecision;
		//        columnEntity.NumericScale = column.DataType.NumericScale;
		//        columnEntity.Nullable = column.Nullable;
		//        columnEntity.Default = column.DefaultConstraint == null ? string.Empty : column.DefaultConstraint.Text;
		//        columnEntity.InPrimaryKey = column.InPrimaryKey;
		//        columnEntity.Identity = column.Identity;
		//        columnEntity.IdentitySeed = column.IdentitySeed;
		//        columnEntity.IdentityIncrement = column.IdentityIncrement;
		//        columnEntity.Summary = ExtendedPropertyHelper.GetValue(column.ExtendedProperties, "Summary");
		//        columnEntity.Remarks = ExtendedPropertyHelper.GetValue(column.ExtendedProperties, "Remarks");

		//        columnsEntity.AddColumnRow(columnEntity);
		//    }

		//    return columnsEntity;			
		//}

		#endregion ������

		#region �I������

		/// <summary>
		/// ���\�[�X��������܂��B
		/// </summary>
		void IDisposable.Dispose() {
			//if (_server != null) {
			//    if (_server.ConnectionContext != null) {
			//        if (_server.ConnectionContext.IsOpen) {
			//            _server.ConnectionContext.Disconnect(); 
			//        } 
			//    }	
			//}
		}

		#endregion �I������

	}
}
