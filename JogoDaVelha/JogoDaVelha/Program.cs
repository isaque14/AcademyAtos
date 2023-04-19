using JogoDaVelha.Entities;

namespace JogoDaVelha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repeat = ' ';

            do
            {
                Console.Clear();
                ToPlay.Start();
                Console.WriteLine("Deseja reiniciar a partida? (s/n)");
                repeat = char.Parse(Console.ReadLine());
            } while (repeat == 's' || repeat == 'S');
        }
    }
}