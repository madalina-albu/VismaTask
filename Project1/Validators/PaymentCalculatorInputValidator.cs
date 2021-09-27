using Project1.Business;
using System;

namespace Project1.Validators
{
    public static class PaymentCalculatorInputValidator
    {
        public static readonly string InvalidInputMessage = "Invalid input parameters.";

        public static bool AreInputParametersValid(int amount, int term, string loanType)
        {
            return IsAmountValid(amount) && IsTermValid(term) && IsLoanTypeValid(loanType);
        }

        private static bool IsAmountValid(int amount)
        {
            return amount >= 1000 && amount <= 100000;
        }

        private static bool IsTermValid(int term)
        {
            return term >= 1 && term <= 30;
        }

        private static bool IsLoanTypeValid(string loanType)
        {
            return Enum.IsDefined(typeof(LoanType), loanType);
        }
    }
}
