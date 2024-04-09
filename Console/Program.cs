using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        CarManager car = new CarManager(new EfCarDal());

        
        car.Add(new Car() { BrandId = 1, ColorId = 1, CarName = "a", ModelYear = 2000, DailyPrice = 200, Description = "Deneme" });

        foreach (var car1 in car.GetAll())
        {
            Console.WriteLine(car1.Description);
        }
    }
}