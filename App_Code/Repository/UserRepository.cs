using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using Dapper;
using JensenEngineers.Data;

namespace JensenEngineers.Repository
{
    public class UserRepository: DbContext
    {
        public User Get(int id)
        {
            User data = new User();

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var Objparams = new DynamicParameters();

                Objparams.Add("@Id", id);

                data = connection
                    .Query<User>("GET_EMPLOYEE_BY_ID", Objparams, commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
            }
            return data;

        }

        public IEnumerable<User> GetAll()
        {

            IEnumerable<User> data;

            using (IDbConnection connection = Connection)
            {
                connection.Open();

                data = connection
                    .Query<User>("GET_ALL_EMPLOYEE", null, commandType: CommandType.StoredProcedure)
                    .ToList();
            }
            return data;
        }
        public User Add(User user)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@Id", user.Id);
                ObjParm.Add("@FirstName", user.FirstName);
                ObjParm.Add("@LastName", user.LastName);
                ObjParm.Add("@Name", user.Name);
                ObjParm.Add("@Designation", user.Designation);
                ObjParm.Add("@Phone", user.Phone);
                ObjParm.Add("@Email", user.Email);
                ObjParm.Add("@Address", user.Address);
                ObjParm.Add("@City", user.City);
                ObjParm.Add("@State", user.State);
                ObjParm.Add("@Zip", user.Zip);
                ObjParm.Add("@HasReviewAuthorization", user.HasReviewAuthorization);
                ObjParm.Add("@IsInManagement", user.IsInManagement);
                ObjParm.Add("@IsInDirectorPanel", user.IsInDirectorPanel);
                ObjParm.Add("@GeneratedID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                dbConnection.Execute("SAVE_UPDATE_EMPLOYEE", ObjParm, commandType: CommandType.StoredProcedure);
                user.Id = ObjParm.Get<int>("@GeneratedID");
            }
            return user;
        }
    }
}