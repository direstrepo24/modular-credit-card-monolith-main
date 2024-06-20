using Common.SharedKernel.Application;
using Common.SharedKernel.Domain;

namespace Cards.Application;

internal sealed record DeleteCardCommand(int id): ICommand<NoResult> { }
