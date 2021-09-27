using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1.Business
{
    /// <inheritdoc/>
    public class SimpleInterestCalculator : IPaymentPlanCalculator
    {
        public IEnumerable<PaymentDetails> GetPaymentPlan(double amount, double interest, int term)
        {
            var monthlyPayments = new List<PaymentDetails>();

            if (amount <= 0 || term <= 0 || interest < 0 || interest > 100)
                throw new ArgumentException("Invalid arguments! Amount: {amount}, interest : {interest}, term: {term}");

            var monthlyInterest = (amount * interest) / 100 / Constants.MonthsInAYear;
            var monthlyPrincipal = amount / term / Constants.MonthsInAYear;
            var balance = amount;
            var months = 1;

            while (months <= term * Constants.MonthsInAYear)
            {
                monthlyPayments.Add(new PaymentDetails
                {
                    Date = DateTime.Now.AddMonths(months++),
                    Total = Math.Round(monthlyInterest + monthlyPrincipal, 2),
                    Interest = Math.Round(monthlyInterest, 2),
                    Principal = Math.Round(monthlyPrincipal, 2),
                    Balance = Math.Round(balance - monthlyPrincipal, 2)
                });

                balance -= monthlyPrincipal;
            }

            return monthlyPayments.AsEnumerable();
        }
    }
}
