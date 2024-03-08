using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

internal class Program
{
    private static void Main(string[] args)
    {
        CarManager car = new CarManager(new InMemoryDal());

        foreach (var car1 in car.GetAll())
        {
            Console.WriteLine(car1.Description);
        }
    }
}