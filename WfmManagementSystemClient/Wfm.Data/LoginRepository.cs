using System.Data;
using System.Data.SqlClient;
using System.Text;
using Wfm.Core;
using Wfm.Domain;

namespace Wfm.Data
{
    public class LoginRepository
    {
        public List<UserDetails> GetUserForLogin(LoginCriteria loginCriteria)
        {
            List<UserDetails> detail = new List<UserDetails>();
            using (var conn = new SqlConnection("Data Source=SQL201901.softura.com;User ID=TheodersonT;Password=Th0de6$0nT;Initial Catalog=TheodersonT;Connection Timeout=0"))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 0;
                    command.CommandText = "sp_GetUserForLogin";
                    command.Parameters.AddWithValue("@UserName", loginCriteria.UserName);
                    command.Parameters.AddWithValue("@Password", loginCriteria.Password);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            detail.Add(new UserDetails()
                            {
                                Username = reader.GetString("UserName"),
                                Password = reader.GetString("Password"),
                                FirstName = reader.GetString("FirstName"),
                                Role = reader.GetString("Role"),
                                Email = reader.GetString("Email")
                            });
                        }
                    }
                }
            }
            return detail;
        }
    }
}
