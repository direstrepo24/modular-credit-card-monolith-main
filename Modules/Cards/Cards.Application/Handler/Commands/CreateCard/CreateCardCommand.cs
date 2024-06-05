using Cards.Domain;
using Common.SharedKernel.Application;

namespace Cards.Application;

public sealed record CreateCardCommand(CreateCardRequestDTO Dto): ICommand<CardResponseDTO> { }
