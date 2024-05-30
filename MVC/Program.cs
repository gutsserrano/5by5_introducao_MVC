using Controllers;
using Models;
using System.Drawing;

namespace MVC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Executar();
        }

        static int Menu()
        {
            bool conversao;
            int op;

            do
            {
                Title(">>>>>BD Carros<<<<<");
                Console.WriteLine("1 - Inserir Carro");
                Console.WriteLine("2 - Alterar Carro");
                Console.WriteLine("3 - Deletar Carro");
                Console.WriteLine("4 - Ver todos os Carro");
                Console.WriteLine("5 - Ver um Carro específico");
                Console.WriteLine("0 - Sair");
                conversao = int.TryParse(Console.ReadLine(), out op);
            } while (!conversao);

            return op;
        }

        static void Executar()
        {
            int option;
            do
            {
                option = Menu();

                switch(option)
                {
                    case 1:
                        InsertCar();
                        break;
                    case 2:
                        UpdateCar();
                        break;
                    case 3:
                        DeleteCar();
                        break;
                    case 4:
                        GetAllCars();
                        break;
                    case 5:
                        GetCar();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("\nEntrada Inválida!");
                        break;
                }
            }while(option != 0);
        }

        static void InsertCar()
        {
            string name, color;
            int year;

            Title(">>>>>Inserir Carro<<<<<");
            name = ReadString("Digite o Nome do carro: ");
            color = ReadString("Digite a cor do carro: ");
            year = ReadInt("Digite o ano do carro:");

            Car car = new Car()
            {
                Name = name,
                Color = color,
                Year = year
            };

            Console.WriteLine(new CarController().Insert(car) ? "\nRegistro inserido!" : "\nErro ao registrar");
            Console.ReadKey();
        }

        static void UpdateCar()
        {
            Title(">>>>>Editar Carro<<<<<");
            Console.WriteLine();
            foreach (var item in new CarController().GetAll())
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            int id = ReadInt("Digite o Id do carro a ser Editado: ");
            string name = ReadString("Digite o Nome do carro: ");
            string color = ReadString("Digite a cor do carro: ");
            int year = ReadInt("Digite o ano do carro:");

            Car car = new Car()
            {
                Id = id,
                Name = name,
                Color = color,
                Year = year
            };

            Console.WriteLine(new CarController().Update(car) ? "\nRegistro Atualizado!" : "\nErro ao atualizar");
            Console.ReadKey();
        }

        static void DeleteCar()
        {
            Title(">>>>>Deletar Carro<<<<<");
            Console.WriteLine();
            foreach (var item in new CarController().GetAll())
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }

            int id = ReadInt("Digite o Id do carro a ser Deletado: ");

            Console.WriteLine(new CarController().Delete(id) ? "\nRegistro Deletado!" : "\nErro ao Deletar registro");
            Console.ReadKey();
        }

        static void GetAllCars()
        {
            Title(">>>>>Todos os carros<<<<<");
            foreach (var item in new CarController().GetAll())
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        static void GetCar()
        {
            Title(">>>>>Buscar um carro<<<<<");

            int id = ReadInt("Digite o Id do carro a ser Buscado: ");
            Car car = new CarController().Get(id);
            if(car != null)
            {
                Console.WriteLine(car);
            }
            else
            {
                Console.WriteLine("\nCarro não Encontrado!");
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void Title(string title)
        {
            Console.Clear();
            Console.WriteLine(title);
        }

        static string ReadString(string msg)
        {
            string result;
            do
            {
                Console.WriteLine(msg);
                result = Console.ReadLine();
            } while (result == "");
            return result;
        }

        static int ReadInt(string msg)
        {
            int result;
            bool convertion;

            do
            {
                Console.WriteLine(msg);
                convertion = int.TryParse(Console.ReadLine(), out result);

                if (!convertion)
                {
                    Console.WriteLine("Digite um numero!");
                    Thread.Sleep(2);
                }
            } while (!convertion);

            return result;
        }
    }
}
