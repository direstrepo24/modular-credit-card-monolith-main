using MediatR;
namespace Common.SharedKernel.Application;
public interface ICommand : IRequest, IBaseCommand;
public interface ICommand<TResponse> : IRequest<TResponse>, IBaseCommand;
public interface IBaseCommand;