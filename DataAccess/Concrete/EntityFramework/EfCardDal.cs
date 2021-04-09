using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfCardDal : EfEntityRepositoryBase<Card, RentACarProjectDbContext>, ICardDal
    {
    }
}