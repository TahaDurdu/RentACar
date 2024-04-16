using System;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface IColorService
	{
        List<Color> GetlAll();
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
    }
}

