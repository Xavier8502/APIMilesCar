using MilesCar.Infraestructura.Datos.Contextos;

namespace MilesCar.Infraestructura.Datos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("creando la DB si no existe");
            MyDbContext context = new MyDbContext();
            context.Database.EnsureCreated();
            Console.WriteLine("Listo!");
            Console.ReadKey();
        }
    }
}