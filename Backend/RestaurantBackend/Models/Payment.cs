namespace RestaurantBackend.Models
{
	public class Payment
	{
		public int Id { get; init; }
		public int OrderId { get; init; }
		public Order? Order { get; init; }
		public decimal Amount { get; set; }
		public DateTime? PaidAt { get; set; }
		public PaymentMethod? PaymentMethod { get; set; }

		public Payment(int orderId, decimal amount)
		{
			if (amount <= 0)
				throw new ArgumentException("Amount must be greater than zero", nameof(amount));
			
			OrderId = orderId;
			Amount = amount;
		}

		private void SetPaymentMethod(PaymentMethod paymentMethod)
		{
			PaymentMethod = paymentMethod;
		}

		private void SetPaidTimestamp(DateTime paidAt)
		{
			PaidAt = paidAt;
		}
	}

	public enum PaymentMethod
	{
		Cash = 1,
		Card = 2,
		Other = 3
	}
}