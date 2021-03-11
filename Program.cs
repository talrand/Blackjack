using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    Game.Play();
                } while (Play() == true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERR - " + ex.Message);
            }
        }
        
        private static bool Play()
        {
            Console.Write("Would you like to play again? (Y/N) : ");
            return Console.ReadLine().Equals("Y", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}