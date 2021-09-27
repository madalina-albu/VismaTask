namespace Project1.Business
{
    public class PersonalLoan : BasicLoan
    {
        public override double InterestRate { get => 4.0; }

        public override string Name { get => "Personal Loan"; }

        public PersonalLoan(IPaymentPlanCalculator calculator) : base(calculator)
        {
        }
    }
}
