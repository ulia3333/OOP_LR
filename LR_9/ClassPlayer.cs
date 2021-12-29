using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_9
{
    public class Game
    {
        public event PlayerStatus check;
        public event Role role;

        public void ToCheck()
        {
            Console.WriteLine("Проверяем состояние игрока..");
            check?.Invoke(this, null);
        }

        public void ToRole(string newRole)
        {
            role?.Invoke(this, null, newRole);
        }
    }
    public class Player
    {
        public int Age { get; set; }
        private string Role;
        private int PlayerStatus;
        public int HarmCounter = 0;
        public int HealCounter = 0;

        Healing heal;
        Attack harm;
        public void RegisterHandlerHeal(Healing heal)
        {
            this.heal = heal;
        }
        public void RegisterHandlerHarm(Attack harm)
        {
            this.harm = harm;
        }
        public int playerStatus
        {
            get { return PlayerStatus; }
            set { PlayerStatus = value; }
        }

        public string role
        {
            get { return Role; }
            set { Role = value; }
        }

        public Player(int age, string role, int playerstatus)
        {
            Age = age;
            Role = role;
            PlayerStatus = playerstatus;
        }

        public void Harm()
        {
            HarmCounter++;
            Console.WriteLine("Игрок ранен!");
            harm?.Invoke($"Общее количество ранений: {HarmCounter}");
        }

        public void Heal()
        {
            HealCounter++;
            Console.WriteLine("Игрок излечен!");
            heal?.Invoke($"Общее количество излечений: {HealCounter}");
        }

        public virtual void HealthCheck(object GG, EventArgs ch)
        {
            if (HarmCounter >= HealCounter)
            {
                Console.WriteLine("Персонаж искалечен и не может продолжать игру! Статус игрока понижен...");
                playerStatus -= 10;
            }
            else Console.WriteLine("Персонаж способен продолжать игру!");
        }

        public void ToRolePlayer(object GG, EventArgs args, string str)
        {
            role = str;
            Console.WriteLine($"Роль игрока изменина: {Role}");
        }
    }

    public class Gammer : Player
    {
        public Gammer(int age, string role, int status) : base(age, role, status)
        {

        }

        public override void HealthCheck(object GG, EventArgs ch)
        {
            if (HarmCounter >= HealCounter)
            {
                Console.WriteLine("Персонаж искалечен и не может продолжать игру! Статус игрока понижен...");
                playerStatus -= 15;
            }
            else Console.WriteLine("Персонаж способен продолжать игру!");
        }

        public void ToRoleGammer(object GG, EventArgs args, string str)
        {
            role = str;
            Console.WriteLine($"Роль игрока изменина: {role}");
        }
    }
}
