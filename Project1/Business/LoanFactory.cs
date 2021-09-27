using System;

namespace Project1.Business
{
    /// <inheritdoc/>
    public class LoanFactory : ILoanFactory
    {
        public BasicLoan GetLoan(LoanType creditType)
        {
            switch(creditType)
            {
                case LoanType.Housing:
                    return new HousingLoan(new AmortizationCalculator());
                case LoanType.Personal:
                    return new PersonalLoan(new SimpleInterestCalculator());
                case LoanType.Education:
                    return new EducationLoan(new SimpleInterestCalculator());
                default:
                    throw new ArgumentException("Invalid credit type");
            }


        }
    }
}
