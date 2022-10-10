﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using Wfm.Core;
using Wfm.Core.Abstractions;
using Wfm.Domain;

namespace Wfm.Api.Controllers
{
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService managerService;
        public ManagerController(IManagerService managerService)
        {
            this.managerService = managerService;
        }
        [Authenticate]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [AllowAnonymous]
        public List<UserDetails> GetUserForLogin(LoginCriteria loginCriteria)
        {
            List<UserDetails> detail = new List<UserDetails>();
            detail = managerService.GetUserForLogin(loginCriteria);
            return detail;
        }
        [HttpGet(Name = "GetManagerList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [AllowAnonymous]
        public List<EmployeeDetails> GetDetailsForManagerPage()
        {
            List<EmployeeDetails> detail = new List<EmployeeDetails>();
            detail = managerService.GetDetailsForManagerPage();
            return detail;
        }
        [HttpPost]
        public void LockStatusUpdateForManager(UpdateApprovalCriteria updateApprovalCriteria)
        {
            managerService.LockStatusUpdateForManager(updateApprovalCriteria);
        }
        [HttpGet]
        public List<WfmMemberApprovalDetail> GetDetailsForWfmMemberPage(string UserName)
        {
            List<WfmMemberApprovalDetail> detail = new List<WfmMemberApprovalDetail>();
            detail = managerService.GetDetailsForWfmMemberPage(UserName);
            return detail;
        }
        [HttpPost]
        public void LockStatusUpdateForWfmMember(UpdateApprovalCriteria updateApprovalCriteria)
        {
            managerService.LockStatusUpdateForWfmMember(updateApprovalCriteria);
        }



    }
}
