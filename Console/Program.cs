using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

internal class Program
{
    private static void Main(string[] args)
    {
        CarManager car = new CarManager(new EfCarDal());

        foreach (var car1 in car.GetCarsByColorId(1,1))
        {
            Console.WriteLine(car1.Description);
        }
    }
}