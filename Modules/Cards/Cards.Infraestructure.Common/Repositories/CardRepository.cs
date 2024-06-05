using Cards.Domain;
using Cards.Infraestructure.Persistence;
using Common.SharedKernel.Domain;
using Common.SharedKernel.Infraestructure;

namespace Cards.Infraestructure.Common;

public class CardRepository(IDbFactory<CardDbContext> dbFactory): BaseRepository<CardEntity, int, CardDbContext>
(dbFactory), ICardRepository<CardDbContext>
{

}
