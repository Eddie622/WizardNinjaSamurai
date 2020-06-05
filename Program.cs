using System;

namespace Human
{
    class Human
    {
        // Fields for Human
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;
        private int maxHealth;

        public int MaxHealth
        {
            get { return maxHealth; }
        }

        // add a public "getter" property to access health
        public int Health
        {
            get { return health; }
        }

        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        public Human(string Name)
        {
            this.Name = Name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
            maxHealth = 100;
        }
        // Add a constructor to assign custom values to all fields
        public Human(string Name, int Str, int Int, int Dex, int hp)
        {
            this.Name = Name;
            Strength = Str;
            Intelligence = Int;
            Dexterity = Dex;
            health = hp;
            maxHealth = hp;
        }

        // Build Attack method
        public virtual void Attack(Human target)
        {
            int dmg = Strength * 3;
            target.ManageDamage(-dmg);
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        }

        public int ManageDamage(int dmg)
        {
            health += dmg;
            return health;
        }
    }

    class Wizard : Human
    {
        public Wizard(string Name) : base(Name, 3, 25, 3, 50){}
        public override void Attack(Human target)
        {
            int dmg = Intelligence * 5;
            target.ManageDamage(-dmg);
            this.ManageDamage(dmg);
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            Console.WriteLine($"{Name} healed self for {dmg} health!");
        }
        public void Heal(Human target)
        {
            int heal = Intelligence * 5;
            target.ManageDamage(heal);
            Console.WriteLine($"{Name} healed {target.Name} for {heal} hp!");
        }
    }

    class Ninja : Human
    {
        public Ninja(string Name) : base(Name, 3, 3, 175, 100){}
        public override void Attack(Human target)
        {
            Random rand = new Random();
            int dmg = Dexterity * 5;
            if(rand.Next(6) == 0)
            {
                dmg += 10;
            }
            target.ManageDamage(-dmg);
            this.ManageDamage(dmg);
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            Console.WriteLine($"Holy Frick! That's A LOT OF DMG");
        }
        public void Steal(Human target)
        {
            int dmg = 5;
            target.ManageDamage(-dmg);
            this.ManageDamage(dmg);
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            Console.WriteLine($"{Name} healed self for {dmg} health!");
        }
    }

    class Samurai : Human
    {
        public Samurai(string Name) : base(Name, 3, 3, 3, 200){}
        public override void Attack(Human target)
        {
            int dmg;
            if(target.Health <= 50)
            {
                dmg = target.Health;
            }
            else
            {
                dmg = Strength;
            }
            
            target.ManageDamage(-dmg);
            this.ManageDamage(dmg);
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        }
        public int Meditate(){
            health = MaxHealth;
            Console.WriteLine($"{Name} meditated to full hp!");
            return health;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human Player = new Human("Player");
            Human Enemy = new Human("Enemy", 5, 5, 5, 1055);
            Wizard AllyOne = new Wizard("Gandalf");
            Ninja AllyTwo = new Ninja("Sekiro");
            Samurai AllyThree = new Samurai("Mr. Samurai");

            Console.WriteLine(AllyThree.Health);
            Enemy.Attack(AllyThree);
            Console.WriteLine(AllyThree.Health);
            AllyThree.Meditate();
            Console.WriteLine(AllyThree.Health);
            AllyOne.Attack(Enemy);
            AllyTwo.Attack(Enemy);
            Console.WriteLine(Enemy.Health);
            AllyThree.Attack(Enemy);
            Console.WriteLine(Enemy.Health);
            AllyThree.Attack(Enemy);
            Console.WriteLine(Enemy.Health);
            AllyThree.Attack(Enemy);
            Console.WriteLine(Enemy.Health);
            AllyOne.Heal(Enemy);
            Console.WriteLine(Enemy.Health);
            Console.WriteLine(AllyTwo.Health);
            Enemy.Attack(AllyTwo);
            Console.WriteLine(AllyTwo.Health);
            Enemy.Attack(AllyTwo);
            Console.WriteLine(AllyTwo.Health);
            AllyTwo.Steal(Enemy);
            Console.WriteLine(AllyTwo.Health);
            Console.WriteLine(Enemy.Health);
        }
    }
}