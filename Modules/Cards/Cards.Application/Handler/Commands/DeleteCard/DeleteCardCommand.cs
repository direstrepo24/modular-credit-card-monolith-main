using Common.SharedKernel.Application;
using Common.SharedKernel.Domain;

namespace Cards.Application;

public sealed record DeleteCardCommand(int id): ICommand<NoResult> { }
