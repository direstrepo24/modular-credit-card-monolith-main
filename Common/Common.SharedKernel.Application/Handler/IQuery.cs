using MediatR;
namespace Common.SharedKernel.Application;
public interface IQuery<TResponse> : IRequest<TResponse>;