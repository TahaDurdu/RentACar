using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

internal class Program
{
    private static void Main(string[] args)
    {
        RentalAdd();

        //GetCustomerUserId();
        //CustomerAddedTest();
        //UserDeleteTest();
        //CarDetailDtoTest();
        //CarAddTest();
    }

    private static void RentalAdd()
    {
        RentalManager rentalManager = new RentalManager(new EfRentalDal());

        rentalManager.Add(new Rental { CarId = 1, CustomerId = 2, RentDate = DateTime.Now });

        foreach (var rent in rentalManager.Add(new Rental { CarId = 1, CustomerId = 2, RentDate = DateTime.Now }).Message)
        {

            Console.WriteLine(rent);
        }
    }

    private static void GetCustomerUserId()
    {
        CustomerManager customer = new CustomerManager(new EfCustomerDal());

        var result = customer.GetCustomerIdByUserId(2, 1).Data;
        var message = customer.GetCustomerIdByUserId(2, 1).Message;

        foreach (var customers in result)
        {
            Console.WriteLine(customers.CompanyName + " " + message);
        }
    }

    private static void CustomerAddedTest()
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

        customerManager.Add(new Customer { UserId = 1, CompanyName = "Coşkun Anonim Firması" });
        foreach (var customer in customerManager.GetAll().Data)
        {
            Console.WriteLine(customer.UserId + " - " + customer.CustomerId + " - " + customer.CompanyName);

        }
    }

    private static void UserDeleteTest()
    {
        UserManager userManager = new UserManager(new EfUserDal());

        userManager.Delete(new User { UserId = 2, FirstName = "Taha", LastName = "Durdu", Email = "tahadurdu2588@gmail.com", Password = "12345Taha" });

        foreach (var user in userManager.GetAll().Data)
        {
            Console.WriteLine(user.FirstName + " - " + user.LastName + " - " + user.Email + " - " + user.Password);

        }
    }

    private static void CarDetailDtoTest()
    {
        CarManager car1 = new CarManager(new EfCarDal());

        var result = car1.carDetailDtos();

        Console.WriteLine(result.Message);
        foreach (var c in result.Data)
        {
            
            Console.WriteLine(c.CarName + " - " + c.BrandName + " - " + c.ColorName + " - " + c.DailyPrice);
        }
    }

    private static void CarAddTest()
    {
        CarManager car = new CarManager(new EfCarDal());


        car.Add(new Car() { BrandId = 1, ColorId = 1, CarName = "a", ModelYear = 2000, DailyPrice = 200, Description = "Deneme" });

        foreach (var car1 in car.GetAll().Data)
        {
            Console.WriteLine(car1.Description);
        }
    }
}