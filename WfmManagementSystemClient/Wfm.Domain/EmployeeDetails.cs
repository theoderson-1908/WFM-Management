﻿namespace Wfm.Domain
{
    public class EmployeeDetails
    {
        public int EmpId { get; set; }
        public string? Name { get; set; }
        public string? Skill { get; set; }
        public string? Profile { get; set; }
        public decimal Experience { get; set; }
        public string? ManagerName { get; set; }
        public bool? IsLocked { get; set; }
        public int LockId { get; set; }
    }
}
