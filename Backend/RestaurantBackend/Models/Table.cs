namespace RestaurantBackend.Models
{
	public class Table
	{
		public int Id { get; init; }
		public int ServerId { get; private set; }
		public Staff? Server { get; private set; }
		public int TableNumber { get; private set; }
		public int Seats { get; private set; } = 1;
		public TableStatus Status { get; private set; } = TableStatus.Open;
		// public List<StatusChange> StatusChangedAt { get; init; }
		
		public List<Order> Orders { get; private set; } = new();

		public Table(int serverId, int tableNumber)
		{
			ServerId = serverId;
			TableNumber = tableNumber;

			// StatusChangedAt = new List<StatusChange>();
			// StatusChange initialStatus = new(TableStatus.Open, DateTime.Now);
			// StatusChangedAt.Add(initialStatus);
		}

		public Table(
			int serverId, int tableNumber,
			int seats)
		{
			ServerId = serverId;
			TableNumber = tableNumber;
			Seats = seats;

			// StatusChangedAt = new List<StatusChange>();
			// StatusChange initialStatus = new(TableStatus.Open, DateTime.Now);
			// StatusChangedAt.Add(initialStatus);
		}

		public void CloseTable()
		{
			// Status = TableStatus.Closed;
			// StatusChange newStatus = new(TableStatus.Closed, DateTime.Now);
			// StatusChangedAt.Add(newStatus);
		}
	}

	public enum TableStatus
	{
		Open = 0,
		Closed = 1
	}

	public struct StatusChange
	{
		public TableStatus Status { get; set; }
		public DateTime TimeStamp { get; set; }

		public StatusChange(TableStatus status, DateTime timeStamp)
		{
			Status = status;
			TimeStamp = timeStamp;
		}
	}
}