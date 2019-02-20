using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lab4
{
    interface IMovable
    {
        void Move();
        void Sounds();
    }

    public abstract class Animal
    {
        public int Weight { get; set; }
        public int YearOfBirth { get; set; }
        public string Family { get; set; }

        public abstract void Description();
        public abstract void Move();
        public abstract void Sounds();

        public Animal (int weight, int yearOfBirth, string family)
        {
            Weight = weight;
            YearOfBirth = yearOfBirth;
            Family = family;
        }

        public virtual void GeneralInf()
        {
            WriteLine("Основная информация");
        }
    }

    public abstract class Mammals : Animal
    {
        public Mammals(int weight, int yearOfBirth, string family) : base(weight, yearOfBirth, family) { }
        public abstract void Color();
    }

    public class Tiger : Mammals, IMovable
    {
        public Tiger(int weight, int yearOfBirth, string family) : base(weight, yearOfBirth, family) { }

        public override void GeneralInf()
        {
            WriteLine("Это тигр");
        }

        public override void Description()
        {
            WriteLine("Тигр — вид хищных млекопитающих семейства кошачьих, один из четырёх представителей рода " +
                      "пантера, который относится к подсемейству больших кошек. ");
        }

        public override void Color()
        {
            WriteLine("Окрас данных животных в основном ржаво-красный и ржаво-коричневый. При этом по всему телу " +
                      "тигра «разбросаны» полосы коричневого или черного цвета.");
        }

        public override void Move()
        {
            WriteLine("Передвигается благодаря 4 лапам.");
        }

        void IMovable.Move()
        {
            WriteLine("Передвигается тигр крупным шагом и почти бесшумно.");
        }

        public override void Sounds()
        {
            WriteLine("Способен издавать рёв.");
        }

        void IMovable.Sounds()
        {
            WriteLine("А также фыркать, шипеть и урчать.");
        }

        public override string ToString()
        {
            return "Вес тигра " + Weight + "кг; Год рождения " + YearOfBirth + "; Семейство: " + Family;
        }
    }

    public class Lion : Mammals
    {
        public Lion(int weight, int yearOfBirth, string family) : base(weight, yearOfBirth, family) { }

        public override void Description()
        {
            WriteLine("Львы характеризуются как очень сильные животные, которые способны охотиться и побеждать больших зверей.");
        }

        public override void Color()
        {
            WriteLine("Окрас этих животных чаще всего темно-коричневый, рыжий с красноватым и желтоватым оттенком.");
        }

        public override void Move()
        {
            WriteLine("Передвигается благодаря 4 лапам.");
        }

        public override void Sounds()
        {
            WriteLine("Способен издывать рев, фыркание, шипение, урчание.");
        }

        public override string ToString()
        {
            return "Вес льва " + Weight + "кг; Год рождения " + YearOfBirth + "; Семейство: " + Family;
        }
    }

    public abstract class Birds : Animal
    {
        public int Wingspan { get; set; }

        public Birds(int weight, int yearOfBirth, string family, int wingspan) : base(weight, yearOfBirth, family)
        {
            Wingspan = wingspan;
        }
    }

    public class Parrot : Birds
    {
        public Parrot(int weight, int yearOfBirth, string family, int wingspan) : base(weight, yearOfBirth, family, wingspan) { }

        public override void Description()
        {
            WriteLine("Характерной особенностью попугая является его яркая окраска: синяя, красная или зеленая, у многих развиты длинные хохолки и хвосты.");
        }

        public override void Move()
        {
            WriteLine("Большинство видов этих птиц прекрасно летают и лазят по деревьям.");
        }

        public override void Sounds()
        {
            WriteLine("Могут издавать различные звуки и говорить, как люди.");
        }

        public override string ToString()
        {
            return "Вес попугая " + Weight + "г; Год рождения " + YearOfBirth + "; Семейство: " + Family + "; Размах крыльев " + Wingspan + " см";
        }
    }

    public class Owl : Birds
    {
        public Owl(int weight, int yearOfBirth, string family, int wingspan) : base(weight, yearOfBirth, family, wingspan) { }

        public override void Description()
        {
            WriteLine("Сова –  это хищная ночная птица. Голова совы круглая с большими глазами, когти длинные и острые, а клюв хищный и короткий.");
        }

        public override void Move()
        {
            WriteLine("Полет совы почти бесшумен, это происходит благодаря особому строению перьев.");
        }

        public override void Sounds()
        {
            WriteLine("Издают время от времени резкий крик");
        }

        public override string ToString()
        {
            return "Вес совы " + Weight + "кг; Год рождения " + YearOfBirth + "; Семейство: " + Family + "; Размах крыльев " + Wingspan + " см";
        }
    }

    public abstract class Fish : Animal
    {
        public Fish(int weight, int yearOfBirth, string family) : base(weight, yearOfBirth, family) { }
        public abstract void Features();
    }

    public sealed class Shark : Fish
    {
        public Shark(int weight, int yearOfBirth, string family) : base(weight, yearOfBirth, family) { }

        public override void Description()
        {
            WriteLine("В своём большинстве акулы - это крупные рыбы с длинным туловищем, имеющим максимально обтекаемую форму, что позволяет им развивать впечатляющую " +
                      "скорость и совершать дальние путешествия.");
        }

        public override void Move()
        {
            WriteLine("Плавает с приоткрытой пастью.");
        }

        public override void Sounds()
        {
            WriteLine("Эти рыбы не обмениваются звуками, а общаются языком тела");
        }

        public override void Features()
        {
            WriteLine("Имеют невероятно острое зрения, слух и обоняние.");
        }

        public override string ToString()
        {
            return "Вес акулы " + Weight + "т; Год рождения " + YearOfBirth + "; Семейство: " + Family;
        }
    }

    class Obiect : Object
    {
        public override string ToString()
        {
            WriteLine("Метод ToString");
            return "";
        }
        public bool Equals()
        {
            WriteLine("Метод Equalse");
            return false;
        }
        public override int GetHashCode()
        {
            WriteLine("Метод GetHashCode");
            return 0;
        }
        public new Type GetType()
        {
            Type a = null;
            WriteLine("Метод GetType");
            return a;
        }
    }

    class Printer
    {
        public virtual string IAmPrinting(Animal obj)
        {
            return obj.GetType() + " " + obj.ToString();
        }
    }

    //laba 6

    enum Days { Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };

    public struct Structura
    {
        int size;
        string name;
    }

    class ZooContainer
    {
        public string Name { get; set; }
        public List<Animal> Anim = new List<Animal>();

        public ZooContainer(string name)
        {
            Name = name;
        }

        public void Add(params Animal[] animals)
        {
            Anim.AddRange(animals);
        }

        public void Delete(Animal animals)
        {
            Anim.Remove(animals);
        }

        public void Display()
        {
            WriteLine("\n---------------------------" + this.Name + "---------------------------");
            foreach (var x in Anim)
                WriteLine(x.ToString());
            WriteLine();
        }
    }

    class ZooController
    {
        private ZooContainer zoo;

        public ZooController(ZooContainer zoo)
        {
            this.zoo = zoo;
        }

    }
}
