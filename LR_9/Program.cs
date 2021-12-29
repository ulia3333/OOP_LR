using System;

namespace LR_9
{
    public delegate void Healing(string str);
    public delegate void Attack(string str);
    public delegate void PlayerStatus(object obj, EventArgs args);
    public delegate void Role(object obj, EventArgs args, string str);
    public delegate void LevelOfLife(Player id);

    class Program
    {
        static void Main(string[] args)
        {
            Attack Massege = (str) => Console.WriteLine(str);
            LevelOfLife Level = (show) => Console.WriteLine($"Общее количество ранений: {show.HarmCounter}");

            Game game = new Game();
            Player player1 = new Player(19, "Ловец", 96);
            Player player2 = new Player(21, "Загонщик", 106);
            Player player3 = new Player(20, "Охотник", 103);
            Player player4 = new Player(16, "Вратарь", 88);
            Gammer gammer1 = new Gammer(24, "Загонщик", 155);
            Gammer gammer2 = new Gammer(28, "Ловец", 219);

            player1.Harm();
            player1.RegisterHandlerHarm(Massege);
            player1.Harm();

            game.check += player1.HealthCheck;
            game.check += gammer1.HealthCheck;
            game.ToCheck();
            player1.Harm();
            player1.Harm();
            Level(player1);
            game.ToCheck();
            Level(player1);

            game.role += player1.ToRolePlayer;
            game.ToRole("Вратарь");
            game.role += player1.ToRolePlayer;
            game.role += gammer1.ToRoleGammer;
            game.ToRole("Охотник");

            string str1 = "Woop <- this must   be changed";
            Func<string, string> func;
            Action<string, char> action;
            func = ClassStrings.OneSpace;
            str1 = func(str1);
            Console.WriteLine(str1);
            action = ClassStrings.AddLeter;
            action(str1, 'W');
            func += ClassStrings.Replacer;
            str1 = func(str1);
            Console.WriteLine(str1);
            func += ClassStrings.MyToUpper;
            str1 = func(str1);
            Console.WriteLine(str1);
            func += ClassStrings.AddPlus;
            str1 = func(str1);
            Console.WriteLine(str1);

        }
    }
}
