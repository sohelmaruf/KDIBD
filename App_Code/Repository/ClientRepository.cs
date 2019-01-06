using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using Dapper;
using JensenEngineers.Data;

namespace JensenEngineers.Repository
{
    public class ClientRepository : DbContext
    {
        public Client Get(int id)
        {
            Client data = new Client();

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var Objparams = new DynamicParameters();

                Objparams.Add("@Id", id);

                data = connection
                    .Query<Client>("GET_CUSTOMER_BY_ID", Objparams, commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
            }
            return data;

        }

        public IEnumerable<Client> GetAll()
        {

            IEnumerable<Client> data;

            using (IDbConnection connection = Connection)
            {
                connection.Open();

                data = connection
                    .Query<Client>("GET_ALL_CUSTOMER", null, commandType: CommandType.StoredProcedure)
                    .ToList();
            }
            return data;
        }

        public Client Add(Client client)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Id", client.Id);
                ObjParm.Add("@Title", client.Title);
                ObjParm.Add("@KeyPerson", client.KeyPerson);
                ObjParm.Add("@Address", client.Address);
                ObjParm.Add("@Phone", client.Phone);
                ObjParm.Add("@AltPhone", client.AltPhone);
                ObjParm.Add("@Email", client.Email);
                ObjParm.Add("@Notes", client.Notes);
                ObjParm.Add("@City", client.City);
                ObjParm.Add("@State", client.State);
                ObjParm.Add("@Zip", client.Zip);
                ObjParm.Add("@Notes", client.Notes);
                ObjParm.Add("@GeneratedID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                dbConnection.Execute("SAVE_UPDATE_CUSTOMER", ObjParm, commandType: CommandType.StoredProcedure);
                client.Id = ObjParm.Get<int>("@GeneratedID");
            }
            return client;
        }
    }
}