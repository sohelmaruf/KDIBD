using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using JensenEngineers.Data;

namespace JensenEngineers.Repository
{
    public class ApplicationUserRepository : DbContext
    {
        public ApplicationUser Add(ApplicationUser user)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                DynamicParameters ObjParm = new DynamicParameters();

                ObjParm.Add("@Id", user.Id);
                ObjParm.Add("@EmailId", user.EmailId);
                ObjParm.Add("@Password", user.GetEncryptedPasssword());
                ObjParm.Add("@UserRoleId", user.UserRoleId);
                ObjParm.Add("@Username",  user.Username);
                ObjParm.Add("@GeneratedID", dbType: DbType.Int32, 
                    direction: ParameterDirection.Output);

                dbConnection.Execute("SAVE_UPDATE_APPLICATIONUSER", 
                    ObjParm, commandType: CommandType.StoredProcedure);
                user.Id = ObjParm.Get<int>("@GeneratedID");
            }
            return user;
        }

        public IEnumerable<UserRole> GetUserRoles()
        {
            IEnumerable<UserRole> data;

            using (IDbConnection connection = Connection)
            {
                connection.Open();

                data = connection
                    .Query<UserRole>("GET_ALL_USERROLE", null, commandType: CommandType.StoredProcedure)
                    .ToList();
            }
            return data;
        }

        public ApplicationUser Get(ApplicationUserLoginDTO user)
        {

            ApplicationUser data = new ApplicationUser();

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                var Objparams = new DynamicParameters();

                Objparams.Add("@USERNAME", user.Username);
                Objparams.Add("@PASSWORD", user.Password);

                data = connection
                    .Query<ApplicationUser>("GET_APPLICATIONuSER_BY_EMAIL_OR_USERNAME", Objparams, commandType: CommandType.StoredProcedure)
                    .FirstOrDefault();
            }
            return data;
            
        }
        
    }
}