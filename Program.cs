// Scrabble
using System;
using System.Reflection;
using System.Text.RegularExpressions;
namespace Work
{
    class Program
    {
        public static  int score;
        static void Main() 
        { 

            string user_input = Console.ReadLine();

            if (!Regex.IsMatch(user_input, @"\P{IsCyrillic}"))
            {
                // Сработает если все символы - кириллица
                var output = Program.ScoreRU(user_input);
                Console.WriteLine(output);
            }
            else if (!Regex.IsMatch(user_input, @"\P{IsBasicLatin}"))
            {
                // Сработает если все символы - кириллица
                var output = Program.ScoreUS(user_input);
                Console.WriteLine(output);
            }




        }
        public static int ScoreUS(string scrabble)
        {
            var people = new Dictionary<int, List<string>>()
            {
                [1] = ["a", "e", "i", "o", "u", "l", "n", "s", "t", "r"],
                [2] = ["d", "g"],
                [3] = ["b", "c", "m", "p"],
                [4] = ["f", "h", "v", "w", "y"],
                [5] = ["k"],
                [8] = ["j", "x"],
                [10] = ["q", "z"]
            };
            string title_scrabble = scrabble.ToLower();
            foreach(char i in title_scrabble)
            {
                foreach(var j in people)
                {
                    foreach(var k in j.Value)
                    {
                        if (k == i.ToString())
                        {
                            score += j.Key;
                        }
                    }
                }
            }
            return score;
        }
        public static int ScoreRU(string scrabble)
        {
            var people = new Dictionary<int, List<string>>()
            {
                [1] = ["а", "в", "е", "и", "н", "о", "р", "с", "т"],
                [2] = ["д", "к", "л", "м", "п", "у"],
                [3] = ["б", "г", "ё", "ь", "я"],
                [4] = ["й", "ы"],
                [5] = ["ж", "з", "ч", "ц", "ч"],
                [8] = ["ш", "э", "ю"],
                [10] = ["ф", "щ", "ъ"]
            };
            string title_scrabble = scrabble.ToLower();
            foreach (char i in title_scrabble)
            {
                foreach (var j in people)
                {
                    foreach (var k in j.Value)
                    {
                        if (k == i.ToString())
                        {
                            score += j.Key;
                        }
                    }
                }
            }
            return score;
        }
    }
}
//A, E, I, O, U, L, N, S, T, R – 1 очко;
//D, G – 2 очка;
//B, C, M, P – 3 очка;
//F, H, V, W, Y – 4 очка;
//K – 5 очков;
//J, X – 8 очков;
//Q, Z – 10 очков.