using System;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface IBrandService
	{
		List<Brand> GetlAll();
		void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);

    }
}

