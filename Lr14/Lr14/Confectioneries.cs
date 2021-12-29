using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lr14
{
    interface IHasInfo
    {
        void DisplayInfo();
    }
    [Serializable]
    public class Confectioneries : IHasInfo
    {
        public string Name { get; set; }
        public Confectioneries()
        {

        }
        public int Price { get; set; }
        public Confectioneries(int price)
        {
            Price = price;
        }

        public Confectioneries(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Название товара: {Name} \nЦена товара за кг(в BYN): {Price}");
        }
    }
    [Serializable]
    public class Candy : Confectioneries
    {
        [NonSerialized]
        public readonly string strForNonSer = "String for non serialize";
        public string Filling { get; set; }
        public Candy()
        {

        }
        public Candy(string name, int price, string filling) : base(name, price)
        {
            Filling = filling;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Название конфеты: {Name} \nЦена конфет за кг(в BYN): {Price} \nНачинка конфеты: {Filling} \n");
        }
        public override string ToString()
        {
            return "Название: " + Name + "\nЦена: " + Price + "\nНачинка: " + Filling + "\n";
        }
    }
    [DataContract]
    public class Cookie : Confectioneries
    {
        [DataMember]
        public bool IsNuts { get; set; }
        public Cookie(string name, int price, bool isNuts) : base(name, price)
        {
            IsNuts = isNuts;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Название печенья: {Name} \nЦена печенья за кг(в BYN): {Price}");
            if (IsNuts == true)
            {
                Console.WriteLine("Печенье содержит арахис \n");
            }
            else
            {
                Console.WriteLine("Печенье не содержит арахис \n");
            }
        }
        public override string ToString()
        {
            return "Название: " + Name + "\nЦена: " + Price + "\n";
        }
    }

    class Child
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Old { get; set; }
    }
}
