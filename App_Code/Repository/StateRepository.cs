using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using JensenEngineers.Data;

namespace JensenEngineers.Repository
{
    public class StateRepository: DbContext
    {

        public List<string> GetAll()
        {
            List<string> data;

            using (IDbConnection connection = Connection)
            {
                connection.Open();


                data = connection
                    .Query<string>("GET_ALL_STATES", null, commandType: CommandType.StoredProcedure)
                    .ToList();
            }
            return data;
        }
    }
}