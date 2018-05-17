using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dune.Models;
using Dune.Settings;
using Microsoft.Extensions.Options;

namespace Dune.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection db;
        private readonly IOptions<ConnectionStrings> connectionStrings;


        public UserRepository(IOptions<ConnectionStrings> connectionStrings)
        {
            this.connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));

            db = new SqlConnection(this.connectionStrings.Value.Default);
        }

        public void InsertUser(User user)
        {
            using (IDbConnection dbConnection = db)
            {
                string sQuery = "INSERT INTO dbo.Users (UserId, Username, Email, Password)"
                              + "VALUES(@UserId, @Username, @Email, @Password)";

                dbConnection.Open();
                dbConnection.Execute(sQuery, user);
            }
        }
    }
}
