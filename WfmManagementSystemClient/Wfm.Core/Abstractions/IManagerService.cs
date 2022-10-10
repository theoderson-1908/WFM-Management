using Wfm.Domain;

namespace Wfm.Core.Abstractions
{
    public interface IManagerService
    {
        List<UserDetails> GetUserForLogin(LoginCriteria loginCriteria);
        List<EmployeeDetails> GetDetailsForManagerPage();
        void LockStatusUpdateForManager(UpdateApprovalCriteria updateApprovalCriteria);
        List<WfmMemberApprovalDetail> GetDetailsForWfmMemberPage(string UserName);
        void LockStatusUpdateForWfmMember(UpdateApprovalCriteria updateApprovalCriteria);

    }
}
