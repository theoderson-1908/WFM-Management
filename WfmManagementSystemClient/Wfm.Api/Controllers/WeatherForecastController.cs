using Microsoft.AspNetCore.Mvc;
using Wfm.Core;
using Wfm.Core.Abstractions;
using Wfm.Domain;
using Wfm.Service;

namespace Wfm.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastController : ControllerBase
    {
        
        private readonly IManagerService managerService;
       
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger , IManagerService managerService)
        {
            _logger = logger;
            this.managerService = managerService;
        }

        [HttpGet(Name = "GetManagerList")]
        public IEnumerable<EmployeeDetails> Get()
        {
            List<EmployeeDetails> detail = new List<EmployeeDetails>();
            try
            {
                detail = managerService.GetDetailsForManagerPage();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return detail;
        }


        [HttpPost]
        public List<UserDetails> GetUserForLogin(LoginCriteria loginCriteria)
        {
            List<UserDetails> detail = new List<UserDetails>();
            detail = managerService.GetUserForLogin(loginCriteria);
            return detail;
        }

        //[HttpGet]
        //public void LockStatusUpdateForManager(UpdateApprovalCriteria updateApprovalCriteria)
        //{
        //    managerService.LockStatusUpdateForManager(updateApprovalCriteria);
        //}
        //[HttpGet(Name = "GetManagerList")]
        //public List<WfmMemberApprovalDetail> GetDetailsForWfmMemberPage(string UserName)
        //{
        //    List<WfmMemberApprovalDetail> detail = new List<WfmMemberApprovalDetail>();
        //    detail = managerService.GetDetailsForWfmMemberPage(UserName);
        //    return detail;
        //}
        //[HttpPost]
        //public void LockStatusUpdateForWfmMember(UpdateApprovalCriteria updateApprovalCriteria)
        //{
        //    managerService.LockStatusUpdateForWfmMember(updateApprovalCriteria);
        //}
    }
}