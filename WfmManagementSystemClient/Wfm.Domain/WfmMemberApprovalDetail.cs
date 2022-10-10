namespace Wfm.Domain
{
    public class WfmMemberApprovalDetail
    {
        public int EmpId { get; set; }
        public string? Requestee { get; set; }
        public DateTime? RequestedDate { get; set; }
        public string? EmployeeManager { get; set; }
        public string? RequestMessage { get; set; }
    }
}
