using System;
using System.Linq;

namespace GourmetGame
{
    public class GameInterface
    {
        #region Constants
        private const string DEFAULT_CATEGORY = "massa";
        private const string DEFAULT_CORRECTDISH = "lasanha";
        private const string DEFAULT_WRONGDISH = "bolo de chocolate";
        #endregion

        private static string[] _acceptedAnswers = new string[] { "s", "n" };

        public void Init()
        {
            Console.WriteLine("Pense em um prato que gosta (Digite 'exit' para sair)");

            var game = new GameLogic(DEFAULT_CATEGORY, DEFAULT_CORRECTDISH, DEFAULT_WRONGDISH);
            while (true)
            {
                Console.WriteLine(game.QuestionText);
                var answer = ReadBooleanAnswer();

                if (!game.Choose(answer))
                {
                    Console.WriteLine("Qual o prato que você pensou?");
                    var newDishname = ReadTextAnswer();
                    Console.WriteLine($"{newDishname} é ______ mas {game.DishName} não.");
                    var dishCategory = ReadTextAnswer();

                    game.InsertDish(dishCategory, newDishname);
                }

                if (game.Success)
                {
                    Console.WriteLine("Acertei de novo!");
                    Console.WriteLine("Pense em um prato que gosta (Digite 'exit' para sair)");
                    game.Restart();
                }
            }
        }

        private bool ReadBooleanAnswer()
        {
            var console = ReadTextAnswer();
            if (!_acceptedAnswers.Contains(console[0].ToString().ToLower()))
            {
                Console.WriteLine("Escreva 's' ou 'n'");
                return ReadBooleanAnswer();
            }

            return string.Equals("s", console[0].ToString());
        }

        private string ReadTextAnswer()
        {
            var console = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(console))
            {
                Console.WriteLine("Escreva alguma coisa!");
                return ReadTextAnswer();
            }

            if ("exit".Equals(console.ToLower()))
                Environment.Exit(0);

            return console;
        }
    }
}
