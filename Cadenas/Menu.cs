using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadenas
{
    internal static class Menu
    {
        private static bool watch = true;
        private static string input = "";
        
        public static void MainLoop()
        {
            Console.WriteLine("OPERACIONES CON CADENAS");
            do
            {
                Console.WriteLine();
                PrintOptions();
                if (Enum.TryParse(Console.ReadLine().Trim(), out Option option))
                {
                    switch (option)
                    {
                        case Option.Exit:
                            watch = false;
                            break;
                        case Option.Replace:
                            MinLengthMiddeware(Replace);
                            break;
                        case Option.Find:
                            MinLengthMiddeware(Find);
                            break;
                        case Option.StartWith:
                            MinLengthMiddeware(StartWith);
                            break;
                        case Option.ZeroFill:
                            ZeroFill();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Lo siento, no he entendido la opción que ha ingresado.");
                }
            } while (watch);
        }
        private static void PrintOptions()
        {
            Console.WriteLine("Opciones:");
            Console.WriteLine();

            Console.WriteLine("1.- Sustituir...");
            Console.WriteLine("2.- Buscar...");
            Console.WriteLine("3.- Comienza por...");
            Console.WriteLine("4.- Rellenar dígito con ceros a la izquierda hasta 12 caracteres");
            Console.WriteLine("0.- Salir");
            Console.WriteLine();
        }
        private static void MinLengthMiddeware(Action action)
        {
            Console.Write("Introduzca una cadena de 40 o más caracteres: ");
            input = Console.ReadLine().Trim();
            if (Utils.IsFortyCharactersLong(input))
            {
                action();
            }
            else
            {
                Console.WriteLine($"La cadena introducida posee únicamente {input.Length} caracteres.");
            }
        }
        private static void Replace()
        {
            string message = "Introduzca la palabra a sustituir y la palabra sustituta separadas por un espacio: ";
            Console.Write(message);
            string replaceInput = Console.ReadLine().Trim();
            while (!replaceInput.Contains(' '))
            {
                Console.WriteLine(message);
                replaceInput = Console.ReadLine().Trim();
            }
            string result = Utils.ReplaceFrom(input, replaceInput);
            Console.WriteLine(result);
        }
        private static void Find()
        {
            Console.Write("Introduzca la búsqueda: ");
            string search = Console.ReadLine().Trim();
            string result = Utils.Find(input, search);
            Console.WriteLine(result);
        }
        private static void StartWith()
        {
            Console.Write("Introduzca la búsqueda: ");
            string search = Console.ReadLine().Trim();
            string result = Utils.StartWith(input, search);
            Console.WriteLine(result);
        }
        private static void ZeroFill()
        {
            Console.Write("Introduzca un número: ");
            string number = Console.ReadLine().Trim();
            string result = Utils.ZeroFill(number);
            Console.WriteLine(result);
        }
    }
}
