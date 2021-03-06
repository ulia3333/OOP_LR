using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_7
{
    interface Shop
    {
        void Producer();
        void Instruction();
    }

    interface Discounts
    {
        public void InfoAboutDiscounts()
        {
            Console.WriteLine("% Новые скидки!!! %");
        }

        public void GetDiscounts()
        {
            Console.WriteLine("% Получите скидку прямо сейчас!!! %");
        }
    }

    public abstract class Product : Discounts
    {
        protected string name;
        protected int workingLife;
        protected string description;

        public string Name
        {
            get
            {
                return name;
            }
        }
        public int WorkingLife
        {
            get
            {
                return workingLife;
            }
            set
            {
                if (value > 11)
                {
                    throw new WrongWorkingLifeValue("Недопустимое значение для срока службы", (int)value);
                }
                else workingLife = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " " + name + " " + description + " " + workingLife;
        }

        public virtual void priceIncrease()
        {
            Console.WriteLine("Цена повышена!");
        }

        public virtual void priceReduction()
        {
            Console.WriteLine("Цена понижена!");
        }

        public abstract void Available();
        public abstract void unAvailable();
    }

    public abstract class Device : Product, Discounts, Shop
    {
        protected int minPrice;
        protected string productModel;
        public void Producer()
        {
            Console.WriteLine("Товар компании Sony");
        }

        void Shop.Instruction()
        {
            Console.WriteLine("Дополнительные инструкции читайте на официальном сайте");
        }

        public override string ToString()
        {
            return base.ToString() + " " + productModel + " " + minPrice;
        }
        public abstract void Instruction();

        public void InfoAboutDiscounts()
        {
            Console.WriteLine("% Новые скидки!!! %");
        }
        public void GetDiscounts()
        {
            Console.WriteLine("% Получите скидку прямо сейчас!!! %");
        }
    }

    public sealed class PrintDevice : Product, Discounts
    {
        public string ProducingCountry { get; }
        public PrintDevice(string nameOfPD, int workingLifeOfPD, string DescriptionOfPD, string producingCountry)
        {
            this.name = nameOfPD;
            this.workingLife = workingLifeOfPD;
            this.description = DescriptionOfPD;
            ProducingCountry = producingCountry;
        }

        public string GetProducingCountry()
        {
            Console.WriteLine(ProducingCountry);
            return ProducingCountry;
        }

        public override void Available()
        {
            Console.WriteLine("Печатающее устройство есть в наличии!!");
        }
        public override void unAvailable()
        {
            Console.WriteLine("Печатающего устройства нет в наличии!!");
        }

        public override string ToString()
        {
            return base.ToString() + " " + ProducingCountry;
        }
    }

    public class Skaner : Product, Discounts
    {
        public string ProducingCountryS { get; }
        public Skaner(string nameOfPD, int workingLifeOfPD, string DescriptionOfPD, string producingCountrys)
        {
            this.name = nameOfPD;
            this.workingLife = workingLifeOfPD;
            this.description = DescriptionOfPD;
            ProducingCountryS = producingCountrys;
        }

        public string GetProducingCountryS()
        {
            Console.WriteLine(ProducingCountryS);
            return ProducingCountryS;
        }
        public override void Available()
        {
            Console.WriteLine("Сканер есть в наличии!!");
        }
        public override void unAvailable()
        {
            Console.WriteLine("Сканера нет в наличии!!");
        }

        public override string ToString()
        {
            return base.ToString() + " " + ProducingCountryS;
        }
    }

    public class Computer : Device, Shop
    {
        public string processorOfComp { get; }
        public Computer(string nameOfComp, int workingLifeOfComp, string DescriptionOfComp, string processor, int miniPrice, string compModel)
        {
            this.name = nameOfComp;
            this.workingLife = workingLifeOfComp;
            this.description = DescriptionOfComp;
            if (miniPrice <= 500)
            {
                throw new IsNotRightPrice("Недопустимое значение для стоимости товара", miniPrice);
            }
            else this.minPrice = miniPrice;
            this.productModel = compModel;
            processorOfComp = processor;
        }
        public override void Available()
        {
            Console.WriteLine("Компьютер есть в наличии!!");
        }
        public override void unAvailable()
        {
            Console.WriteLine("Компьютера нет в наличии!!");
        }

        void Shop.Instruction()
        {
            Console.WriteLine("Дополнительные инструкции читайте на официальном сайте");
        }

        public override void Instruction()
        {
            Console.WriteLine("Тут якобы дополнительные инструкции, но нет :)");
        }

        public override string ToString()
        {
            return base.ToString() + " " + processorOfComp;
        }
    }

    public class Tablet : Device, Shop
    {
        public double scrdiagonal;
        public double ScreenDiagonal
        {
            get { return scrdiagonal; }
            set
            {
                if (value < 3)
                {
                    throw new IsNotScreenDiagonal("Недопустимое значение для диагонали экрана", (double)value);
                }
                else scrdiagonal = value;
            }
        }

        public Tablet(string nameOfComp, int workingLifeOfTabl, string DescriptionOfTabl, double screenDiagonal, int miniPrice, string compModel)
        {
            this.name = nameOfComp;
            this.workingLife = workingLifeOfTabl;
            this.description = DescriptionOfTabl;
            this.minPrice = miniPrice;
            if (compModel.Length <= 1)
            {
                throw new IsNotRightModel("НЕдопустимое значение для модели", compModel);
            }
            else this.productModel = compModel;
            ScreenDiagonal = screenDiagonal;
        }

        public override void Available()
        {
            Console.WriteLine("Планшет есть в наличии!!");
        }
        public override void unAvailable()
        {
            Console.WriteLine("Планшета нет в наличии!!");
        }
        void Shop.Instruction()
        {
            Console.WriteLine("Дополнительные инструкции читайте на официальном сайте");
        }
        public override void Instruction()
        {
            Console.WriteLine("Тут якобы дополнительные инструкции, но нет :)");
        }

        public override string ToString()
        {
            return base.ToString() + " " + ScreenDiagonal;
        }
    }

    class IPrinter
    {
        public void IAmPrinting(object someObj)
        {
            Console.WriteLine(someObj.ToString());
        }
    }
}
