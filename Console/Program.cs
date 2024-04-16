using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        CarManager cardelete = new CarManager(new EfCarDal());

        
        CarDetailDtoTest();
        // CarAddTest();
    }

    private static void CarDetailDtoTest()
    {
        CarManager car1 = new CarManager(new EfCarDal());

        foreach (var c in car1.carDetailDtos())
        {
            Console.WriteLine(c.CarName + " - " + c.BrandName + " - " + c.ColorName + " - " + c.DailyPrice);
        }
    }

    private static void CarAddTest()
    {
        CarManager car = new CarManager(new EfCarDal());


        car.Add(new Car() { BrandId = 1, ColorId = 1, CarName = "a", ModelYear = 2000, DailyPrice = 200, Description = "Deneme" });

        foreach (var car1 in car.GetAll())
        {
            Console.WriteLine(car1.Description);
        }
    }
}