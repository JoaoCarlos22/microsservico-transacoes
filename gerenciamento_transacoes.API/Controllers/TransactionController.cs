using gerenciamento_transacoes.API.Controllers.Base;
using gerenciamento_transacoes.Application.Features.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gerenciamento_transacoes.API.Controllers
{
    public class TransactionController : BaseController
    {
        private readonly IMediator _mediator;
        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllTransactionsResponse>>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(new GetAllTransactionsRequest(), cancellationToken);
                return Ok(response);

            } catch (Exception erro) 
            {
                return BadRequest(erro.Message);
            }
            
        }
    }
}
