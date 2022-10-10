using System.Data.SqlClient;
using System.Data;
using Wfm.Domain;
using Wfm.Core;

namespace Wfm.Data
{
    public class WfmMemberRepository
    {
        public List<WfmMemberApprovalDetail> GetDetailsForWfmMemberPage(string UserName)
        {
            List<WfmMemberApprovalDetail> detail = new List<WfmMemberApprovalDetail>();
            using (var conn = new SqlConnection("Data Source=SQL201901.softura.com;User ID=TheodersonT;Password=Th0de6$0nT;Initial Catalog=TheodersonT;Connection Timeout=0"))
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 0;
                    command.CommandText = "sp_wfmMemberLoginGetDetails";
                    command.Parameters.AddWithValue("@UserName", UserName);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            detail.Add(new WfmMemberApprovalDetail()
                            {
                                EmpId = reader.GetInt32("EmpId"),
                                Requestee = reader.GetString("RequestedManager"),
                                RequestedDate = reader.GetDateTime("RequestedDate"),
                                EmployeeManager = reader.GetString("ManagerName"),
                                RequestMessage = reader.GetString("RequestMessage")
                            });
                        }
                    }
                }
            }
            return detail;
        }
        public void LockStatusUpdateForWfmMember(UpdateApprovalCriteria updateApprovalCriteria)
        {
            using (var conn = new SqlConnection("Data Source=SQL201901.softura.com;User ID=TheodersonT;Password=Th0de6$0nT;Initial Catalog=TheodersonT;Connection Timeout=0"))
            {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_ApprovalStatusForSendRequestByWfmMember";
                    command.Parameters.AddWithValue("@EmpId", updateApprovalCriteria.EmpId);
                    command.Parameters.AddWithValue("@ManagerStatus", updateApprovalCriteria.ManagerStatus);
                    command.Parameters.AddWithValue("@ManagerComment", updateApprovalCriteria.ManagerComment);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
