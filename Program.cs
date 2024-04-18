using System;

namespace Attribute_pract
{
    public abstract class Spirit
    {
        public abstract void Passport();
    }

    public class Monster : Spirit
    {
        string name;
        int health, ammo;

        public Monster()
        {
            this.health = 100;
            this.ammo = 100;
            this.name = "Noname";
        }

        public Monster(string name) : this()
        {
            this.name = name;
        }

        public Monster(int health, int ammo, string name)
        {
            this.health = health;
            this.ammo = ammo;
            this.name = name;
        }

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value > 0) health = value;
                else health = 0;
            }
        }

        public int Ammo
        {
            get
            {
                return ammo;
            }
            set
            {
                if (value > 0) ammo = value;
                else ammo = 0;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public override void Passport()
        {
            Console.WriteLine("Monster {0} \t health = {1} ammo = {2}", name, health, ammo);
        }
    }

    public class Daemon : Monster
    {
        int brain;

        public Daemon()
        {
            brain = 1;
        }

        [BrainValidate(3)] //создание атрибута описанного в классе BrainValidate Attribute
        public Daemon(string name, int brain) : base(name)
        {
            this.brain = brain;
        }

        public Daemon(int health, int ammo, string name, int brain) : base(health, ammo, name)
        {
            this.brain = brain;
        }

        public override void Passport()
        {
            Console.WriteLine("Daemon {0} \t health = {1} ammo = {2} brain = {3}", Name, Health, Ammo, brain);
        }

        public void Think()
        {
            Console.Write(Name + " is");
            for (int i = 0; i < brain; i++)
            {
                Console.Write(" thinking");
            }
            Console.WriteLine("...");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Daemon daemon = new Daemon(2, 3, "daemon", 1); //false
            Daemon daemon1 = new Daemon(2, 3, "daemon1", 6); //true
            bool daemonIsValid = ValidateDaemon(daemon);
            Console.WriteLine($"{daemonIsValid}");
            Console.WriteLine("");
            Console.ReadLine();
        }
        static bool ValidateDaemon(Daemon daemon)
        {
            Type type = typeof(Daemon);
            object[] attrs = type.GetCustomAttributes(false);
            foreach (object attr in attrs)
            {
                if (attr is BrainValidateAttribute brainValidateAttr)
                {
                    if (daemon.brain >= brainValidateAttr.Brain)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }   
}