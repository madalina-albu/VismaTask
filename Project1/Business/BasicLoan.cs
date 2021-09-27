using Project1.Models;
using System.Collections.Generic;

namespace Project1.Business
{
    public abstract class BasicLoan
    {
        public abstract double InterestRate { get; }

        public abstract string Name { get; }

        public readonly IPaymentPlanCalculator Calculator;

        public BasicLoan(IPaymentPlanCalculator calculator)
        {
            this.Calculator = calculator;
        }

        public IEnumerable<PaymentDetails> GetPaymentPlan(double amount, int term)
        {
            return Calculator.GetPaymentPlan(amount, InterestRate, term);
        }

        public override string ToString()
        {
            return $"{Name} with Interest Rate: {InterestRate}";
        }
    }
}
