using Cards.Domain;
using Common.SharedKernel.Application;

namespace Cards.Application;

internal sealed record GetAllCardsQuery(Guid UserId): IQuery<IEnumerable<CardResponseDTO>>{}

