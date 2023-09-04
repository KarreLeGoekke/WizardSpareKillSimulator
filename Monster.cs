using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndertaleSimulator
{
    public class Monster
    {
        float maxHP = 100;
        public string name;
        float hp;
        public bool alive = true;
        public int sparePoints;
        public bool spared = false;

        public Monster(string name, float hp, int sparePoints)
        {
            this.name = name;
            this.hp = hp;
            this.sparePoints = sparePoints;

            Console.WriteLine($"A wild {this.name} has appeared!\nIt has {this.hp} HP!");
        }

        public void Hurt(float amount, string attackType)
        {
            this.hp -= amount;
            Console.WriteLine($"\nYou {attackType} {this.name}!\nIt lost {amount} HP and now has {this.hp} HP!");
        }

        public void Spare()
        {
            sparePoints--;
            if(this.sparePoints == 0) {
                this.spared = true;
                Console.WriteLine($"\nYou have successfully spared {this.name}! Well done!");
            }
            else
            {
                Console.WriteLine($"You tried to spare {this.name}, but it did not accept! You might try to spare again...");
            }
        }

        public void Update()
        {
            if (this.hp <= 0) {
                this.alive = false;
                Console.WriteLine($"\nYou have successfully killed {this.name}! You monster!");
            }
        }
    }
}
