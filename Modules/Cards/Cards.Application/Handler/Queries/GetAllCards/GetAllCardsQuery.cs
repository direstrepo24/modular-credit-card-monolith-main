using Cards.Domain;
using Common.SharedKernel.Application;

namespace Cards.Application;

public sealed record GetAllCardsQuery(Guid UserId): IQuery<IEnumerable<CardResponseDTO>>{}

