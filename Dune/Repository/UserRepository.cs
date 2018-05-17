using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dune.Models;

namespace Dune.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection db;

        public UserRepository()
        {
            db = new SqlConnection(@"Server=DARRENS-DESKTOP; Database=Dune; Trusted_Connection=True");
        }

        public bool InsertUser(User user)
        {
            using (IDbConnection dbConnection = db)
            {
                string sQuery = "INSERT INTO dbo.Users (UserId, Username, Email, Password)"
                              + " VALUES(@UserId, @Username, @Email, @Password)";

                dbConnection.Open();
                dbConnection.Execute(sQuery, user);
            }

            return true;
        }
    }
}
