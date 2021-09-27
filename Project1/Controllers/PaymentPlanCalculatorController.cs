using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project1.Business;
using Project1.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentPlanCalculatorController : Controller
    {
        private readonly ILogger<PaymentPlanCalculatorController> _logger;
        private readonly ILoanFactory _loanFactory;

        public PaymentPlanCalculatorController(ILogger<PaymentPlanCalculatorController> logger, ILoanFactory loanFactory)
        {
            _logger = logger;
            _loanFactory = loanFactory;
        }

        [HttpGet]
        public IActionResult Get([Required] int amount, [Required] int term, [Required] string loanType)
        {
            if (!PaymentCalculatorInputValidator.AreInputParametersValid(amount, term, loanType))
            {
                return new BadRequestObjectResult(PaymentCalculatorInputValidator.InvalidInputMessage);
            }

            var type = (LoanType)Enum.Parse(typeof(LoanType), loanType);
            var loan = _loanFactory.GetLoan(type);
            _logger.LogInformation(loan.ToString());

            return new JsonResult(loan.GetPaymentPlan(amount, term));
        }
    }
}
