using System.Data.SqlClient;
using System.Data;
using Wfm.Core;
using Wfm.Domain;
using System.Xml.Linq;
using System.Security.Cryptography;
using System;

namespace Wfm.Data
{
    public class ManagerRepository
    {
        public List<EmployeeDetails> GetDetailsForManagerPage()
        {
            List<EmployeeDetails> detail = new List<EmployeeDetails>();
            using (var conn = new SqlConnection("Data Source=SQL201901.softura.com;User ID=TheodersonT;Password=Th0de6$0nT;Initial Catalog=TheodersonT;Connection Timeout=0"))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 0;
                    command.CommandText = "sp_GetDetailsForManagerPage";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            detail.Add(new EmployeeDetails()
                            {
                                EmpId = reader.GetInt32("EmpId"),
                                Name = reader.GetString("EmpName"),
                                Skill = reader.GetString("SkillName"),
                                Profile = reader.GetString("Profile"),
                                Experience = reader.GetDecimal("Experience"),
                                ManagerName = reader.GetString("ManagerName"),
                                IsLocked = reader.GetBoolean("IsLocked"),
                                LockId = reader.GetInt32("LockId")
                            });
                        }
                    }
                }
            }
            return detail;
        }

        public void LockStatusUpdateForManager(UpdateApprovalCriteria updateApprovalCriteria)
        {
            List<EmployeeDetails> detail = new List<EmployeeDetails>();
            using (var conn = new SqlConnection("Data Source=SQL201901.softura.com;User ID=TheodersonT;Password=Th0de6$0nT;Initial Catalog=TheodersonT;Connection Timeout=0"))
            {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_LockStatusChangeForManager";
                    command.Parameters.AddWithValue("@LockId", updateApprovalCriteria.LockId);
                    command.Parameters.AddWithValue("@RequestMessage", updateApprovalCriteria.RequestMessage);
                    command.Parameters.AddWithValue("@FirstName", updateApprovalCriteria.FirstName);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}