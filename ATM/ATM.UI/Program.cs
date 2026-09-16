using ATM.Infrastructure.Repositories;
using ATM.Services;
using ATM.UI.Services;

namespace ATM.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var userRepository = new FileUserRepository();

            var atmService = new AtmService(userRepository);

            var menuService = new MenuService(atmService);

            menuService.Run();





        }
    }
}
