using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1.Business
{
    public class AmortizationCalculator : IPaymentPlanCalculator
    {
        public IEnumerable<PaymentDetails> GetPaymentPlan(double amount, double interest, int term)
        {
            var monthlyPayments = new List<PaymentDetails>();

            if (amount <= 0 || term <= 0 || interest < 0 || interest > 100)
                throw new ArgumentException("Invalid arguments! Amount: {amount}, interest : {interest}, term: {term}");

            var monthlyInterestRate = interest / Constants.MonthsInAYear / 100;
            var termInMonths = term * Constants.MonthsInAYear;
            var balance = amount;
            var months = 1;

            var monthlyAmortizationPayment = amount * (monthlyInterestRate * Math.Pow((1 + monthlyInterestRate), termInMonths)) / (Math.Pow((1 + monthlyInterestRate), termInMonths) - 1);

            while (months <= term * Constants.MonthsInAYear)
            {
                var currentInterest = balance * monthlyInterestRate;
                var currentPrincipal = monthlyAmortizationPayment - currentInterest;
                var currentBalance = balance - currentPrincipal;

                monthlyPayments.Add(new PaymentDetails
                {
                    Date = DateTime.Now.AddMonths(months++),
                    Total = Math.Round(monthlyAmortizationPayment, 2),
                    Interest = Math.Round(currentInterest, 2),
                    Principal = Math.Round(currentPrincipal, 2),
                    Balance = Math.Round(currentBalance, 2)
                });

                balance -= currentPrincipal;
            }

            return monthlyPayments.AsEnumerable();
        }
    }
}
