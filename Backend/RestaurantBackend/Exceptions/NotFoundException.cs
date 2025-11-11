namespace RestaurantBackend.Exceptions
{
	public class NotFoundException<T> : Exception
	{
		public NotFoundException(object key) : base(
			$"{typeof(T).Name} with key {key} not found")
		{}
	}
}