using System.Net;

namespace SocialMedia.Api.Controllers
{
    //[Authorize(Roles = nameof(RoleType.Administrator))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public SecurityController(ISecurityService securityService, IMapper mapper, IPasswordService passwordService)
        {
            _securityService = securityService;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SecurityDto securityDto)
        {
            var security = _mapper.Map<Security>(securityDto);

            security.Password = _passwordService.Hash(security.Password); // Hash Password
            await _securityService.RegisterUser(security);

            securityDto = _mapper.Map<SecurityDto>(security);

            var response = new BaseGenericResult<SecurityDto>(true, (int)HttpStatusCode.OK, "Data Loading Success", securityDto);

            return StatusCode(response.StatusCode, response);
        }

    }
}