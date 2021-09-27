namespace Project1.Business
{
    /// <summary>
    /// Interface that creates loans
    /// </summary>
    public interface ILoanFactory
    {
        /// <summary>
        /// Creates and returns a loan object based on the loan type
        /// </summary>
        /// <param name="loanType">The type of the loan</param>
        /// <returns>The loan object</returns>
        public BasicLoan GetLoan(LoanType loanType);
    }
}
