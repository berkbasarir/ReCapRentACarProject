using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        private readonly ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        [ValidationAspect(typeof(CardValidator))]
        public IResult Add(Card card)
        {
            if (CheckCard(card))
                return new SuccessResult(Messages.CardAlreadyExists);

            _cardDal.Add(card);
            return new SuccessResult(Messages.CardAdded);
        }

        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);
            return new SuccessResult(Messages.CardDeleted);
        }

        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(), Messages.CardsListed);
        }

        public IDataResult<List<Card>> GetByCustomerId(int customerId)
        {
            var getByCustomerId = _cardDal.GetAll(card => card.CustomerId == customerId);
            return new SuccessDataResult<List<Card>>(getByCustomerId);
        }

        public IResult Update(Card card)
        {
            _cardDal.Update(card);
            return new SuccessResult(Messages.CardUpdated);
        }

        public bool CheckCard(Card checkCard)
        {
            var card = _cardDal.Get(c => c.CustomerId == checkCard.CustomerId);

            if (card == null)
                return false;

            if (card.CardNumber == checkCard.CardNumber)
                return true;

            return false;
        }
    }
}