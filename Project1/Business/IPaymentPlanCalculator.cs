using Project1.Models;
using System.Collections.Generic;

namespace Project1.Business
{
    /// <summary>
    /// Interface for actions regarding the payment plan
    /// </summary>
    public interface IPaymentPlanCalculator
    {
        /// <summary>
        /// Calculates and retrieves the payment plan
        /// </summary>
        /// <param name="amount">The total amount of the loan</param>
        /// <param name="interest">The interest rate of the loan</param>
        /// <param name="term">The duration in years</param>
        /// <returns>A collection of PaymentDetails</returns>
        public IEnumerable<PaymentDetails> GetPaymentPlan(double amount, double interest, int term);
    }
}
