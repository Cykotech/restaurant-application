namespace RestaurantBackend.Features
{
	public interface IHandler<TRequest, TResponse>
	{
		public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
	}
}