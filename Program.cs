using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkGladiator2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Gladiator gladiatorOne = null;
            Gladiator gladiatorTwo = null;
            Warrior warrior = null;
            Magician magician = null;
            string userInput = "";

            Console.WriteLine("Выбериите тип первого  бойца. 1 - Воин, 2 - Боевой маг.");

            switch (userInput= Console.ReadLine())
            {                
                case "1":
                    gladiatorOne = new Warrior();
                    warrior = gladiatorOne as Warrior;
                    break;

                    case "2":
                    gladiatorOne = new Magician();
                    magician = gladiatorTwo as Magician;
                    break;
            }

            Console.WriteLine("Выбериите тип второго  бойца. 1 - Воин, 2 - Боевой маг.");

            switch (userInput = Console.ReadLine())
            {
                case "1":
                    gladiatorTwo = new Warrior();
                    warrior = gladiatorOne as Warrior;
                    break;

                case "2":
                    gladiatorTwo = new Magician();
                    magician = gladiatorTwo as Magician;
                    break;
            }

            if (warrior != null && magician != null)
            {
                while (true)
                {
                    gladiatorOne.ChangeHealth(gladiatorOne.Health, gladiatorTwo.Damage);
                    gladiatorTwo.ChangeHealth(gladiatorTwo.Health, gladiatorOne.Damage);
                    Console.WriteLine(gladiatorOne.Health);
                    Console.WriteLine(gladiatorTwo.Health);

                    if (gladiatorTwo.Health <= 0)
                    {
                        Console.WriteLine($"победил {gladiatorOne.Name}");
                        break;
                    }

                    if (gladiatorOne.Health <= 0)
                    {
                        Console.WriteLine($"победил {gladiatorTwo.Name}");
                        break;
                    }
                }
            }

            Console.ReadLine();
        }        
    }

    class Gladiator
    {
        private int _health = 100;
        protected int _damage = 15;
        Random random = new Random();

        public string Name { get; private set; }
        public int Health => _health;
        public int Damage => _damage;

        public Gladiator()
        {
            SetName();
        }

        public int ChangeHealth (int health, int damage)
        {
            
            int minDamage = 0;
            int maxDamage = damage;

            health -= random.Next(minDamage,maxDamage);
            _health = health;
            return Health;
        }

        public void SetName()
        {
            Console.WriteLine("Вы на арене ! Назовите своё имя!");
            Name = Console.ReadLine();
        }
    }

    class Magician : Gladiator
    {
        public void UseTalent()
        {
            int magicDamage = 10;
            Console.WriteLine("Маг произносит заклинание и огненый шар летит а противника");
            _damage += magicDamage;
        }
    }

    class Warrior : Gladiator
    {
        public void UseTalent()
        {
            int additionalDamage = 15;
            Console.WriteLine("Воин размашисто рубит противника");
            _damage += additionalDamage;
        }
    }
}
