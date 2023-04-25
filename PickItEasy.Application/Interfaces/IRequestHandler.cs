namespace PickItEasy.Application.Interfaces
{
    public interface IRequestHandler
    {
    }

    public interface IRequestHandler<TRequest> : IRequestHandler
        where TRequest : IRequest
    {
        Task Handle(TRequest request);
    }

    public interface IRequestHandler<TRequest, TResponse> : IRequestHandler
        where TRequest : IRequest<TResponse> 
        where TResponse : IResponse
    {
        Task<TResponse> Handle(TRequest request);
    }
}
