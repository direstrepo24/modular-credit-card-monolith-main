using Cards.Domain;
using Common.SharedKernel.Application;

namespace Cards.Application;

internal sealed record CreateCardCommand(CreateCardRequestDTO Dto): ICommand<CardResponseDTO> { }
