using ABLibrary.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        public ContactModel CreateContact(ContactModel NewContact)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionString("AdressBook")))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", NewContact.FirstName);
                p.Add("@LastName", NewContact.LastName);
                p.Add("@PhoneNumber", NewContact.PhoneNumber);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spCreateContact", p, commandType: CommandType.StoredProcedure);

                NewContact.id = p.Get<int>("@Id");

                return NewContact;
            }
        }
    }
}
