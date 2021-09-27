using Project1.Models;
using System.Collections.Generic;

namespace Project1.Business
{
    public class HousingLoan : BasicLoan
    {
        public override double InterestRate { get => 6; }

        public override string Name { get => "Housing Loan"; }

        public HousingLoan(IPaymentPlanCalculator calculator) : base(calculator)
        {
        }
    }
}
