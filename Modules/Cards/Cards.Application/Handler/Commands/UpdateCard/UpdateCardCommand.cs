using Cards.Domain;
using Common.SharedKernel.Application;

namespace Cards.Application;

internal sealed record UpdateCardCommand(int Id, UpdateCardRequestDTO Dto): ICommand<CardResponseDTO> { }
