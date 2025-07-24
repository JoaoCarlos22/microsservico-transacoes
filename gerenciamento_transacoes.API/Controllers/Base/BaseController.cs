using Microsoft.AspNetCore.Mvc;

namespace gerenciamento_transacoes.API.Controllers.Base
{
    [Route("api/[controller]")]

    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
