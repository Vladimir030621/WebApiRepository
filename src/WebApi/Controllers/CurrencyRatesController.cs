using Application.Queries;
using CommonServices.Helpers;
using CommonServices.Models;
using CommonServices.Services;
using Hangfire;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyRatesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IApiResponseService _apiResponseService;

        public CurrencyRatesController(IMediator mediator, IApiResponseService apiResponseService)
        {
            _mediator = mediator;
            _apiResponseService = apiResponseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currencyRates = await _mediator.Send(new GetStoredCurrencyRatesQuery());

            var result = new ResultModel<IEnumerable<Currencyrate>>().Success(currencyRates);

            return _apiResponseService.GetResponse(result);
        }
    }
}
