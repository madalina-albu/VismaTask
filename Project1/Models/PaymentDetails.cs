using System;

namespace Project1.Models
{
    /// <summary>
    /// Details for a payment
    /// </summary>
    public class PaymentDetails
    {
        /// <summary>
        /// The due date of the payment
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The total amount due
        /// </summary>
        public double Total { get; set; }

        /// <summary>
        /// The interest part of the payment
        /// </summary>
        public double Interest { get; set; }

        /// <summary>
        /// The amount that will be substracted from the loan amount
        /// </summary>
        public double Principal { get; set; }

        /// <summary>
        /// The remaining amount of the loan after completing this payment
        /// </summary>
        public double Balance { get; set; }
    }
}
