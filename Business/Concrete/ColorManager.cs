using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constant;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine(Messages.ColorAdded);
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine(Messages.ColorDeleted);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _colorDal.Get(c => c.Id == colorId);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine(Messages.ColorUpdated);
        }
    }
}
