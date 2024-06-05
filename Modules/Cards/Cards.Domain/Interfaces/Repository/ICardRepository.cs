using Common.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;
namespace Cards.Domain;
public interface ICardRepository<TContext> : IBaseRepository<CardEntity, TContext>
    where TContext: DbContext, new()
{

}