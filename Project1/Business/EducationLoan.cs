namespace Project1.Business
{
    public class EducationLoan : BasicLoan
    {
        public override double InterestRate { get => 1.0; }

        public override string Name { get => "Education Loan"; }

        public EducationLoan(IPaymentPlanCalculator calculator) : base(calculator)
        {
        }
    }
}
