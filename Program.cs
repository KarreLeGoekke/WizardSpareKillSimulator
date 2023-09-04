using UndertaleSimulator;

List<string> firstName = new List<string>{ "Hooble", "Figgle", "Oople", "Fuga", "Shabby", "Hagno", "Kabby", "Lebba" };
List<string> lastName = new List<string>{ "snoople", "bottom", "darple", "goob", "farb", "doogle", "hoop", "rama", "licious" };
List<string> attackTypes = new List<string>{ "SLAPPED", "PUNCHED", "KICKED", "BANHAMMERED", "PWNED", "OTTOMAN SLAPPED", "KISSED", "MADE FUN OF" };

Random rnd = new Random();

float HP = 150;
float amountLost;

int result = 0;

Console.WriteLine("Welcome to RPG Spare N Slash simulator!\n" +
    "Feel free to do whatever the hell you want.\n\n");

while(true)
{
    Console.WriteLine("To play, press 1.\nTo exit, press 2.");
    string startResponse = Console.ReadLine();

    if(startResponse == 1.ToString())
    {
        result = main();
        break;
    }
    else if(startResponse == 2.ToString())
    {
        Console.WriteLine("Ok goodbye");
        break;
    }
    else {
        Console.WriteLine("Let me tell you this again...\n");
    }
}

int main()
{
    Console.WriteLine("You are a wizard with 150 HP... joyously meandering through the town, when all of a sudden...\n");
    Monster weakMonster = new Monster((firstName[rnd.Next(firstName.Count)] + lastName[rnd.Next(lastName.Count)]), rnd.Next(75, 125), 1);

    while(weakMonster.alive == true && weakMonster.spared == false)
    {
        Console.WriteLine("What do you do?\n\n1 = Spare\n2 = Attack");
        string attackResponse1 = Console.ReadLine();

        if (attackResponse1 == 1.ToString())
        {
            weakMonster.Spare();
        }
        else if (attackResponse1 == 2.ToString())
        {
            weakMonster.Hurt(rnd.Next(10, 30), attackTypes[rnd.Next(attackTypes.Count)]);
            weakMonster.Update();
            if (weakMonster.alive == false) continue;
            Console.WriteLine($"\n{weakMonster.name} attacked you back! It {attackTypes[rnd.Next(attackTypes.Count)]} you!");
            amountLost = rnd.Next(5, 15);
            Console.WriteLine($"Because of this, you have lost {amountLost} HP, and now you have {HP} HP!");
            HP -= amountLost;
        }
        else
        {
            Console.WriteLine("Let me tell you this again...\n");
        }
        weakMonster.Update();

        if (HP <= 0)
        {
            Console.WriteLine("You died while in battle! Game over!");
            return 1;
        }
    }

    Console.WriteLine("Press enter to continue!");
    Console.ReadLine();

    Console.WriteLine("\n");

    Console.WriteLine("Now that you have taken care of the weak creature, you continued meandering through the town, and then to the forest!\n" +
        "You thought it would be safe going around the forest, and then...\n");
    Monster strongMonster = new Monster((firstName[rnd.Next(firstName.Count)] + lastName[rnd.Next(lastName.Count)]), rnd.Next(125, 175), 3);
    while (strongMonster.alive == true && strongMonster.spared == false)
    {
        Console.WriteLine("What do you do?\n\n1 = Spare\n2 = Attack");
        string attackResponse2 = Console.ReadLine();

        if (attackResponse2 == 1.ToString())
        {
            strongMonster.Spare();
            if(strongMonster.spared == false)
            {
                Console.WriteLine($"\n{weakMonster.name} attacked you! It {attackTypes[rnd.Next(attackTypes.Count)]} you!");
                amountLost = rnd.Next(20, 30);
                Console.WriteLine($"Because of this, you have lost {amountLost} HP, and now you have {HP} HP!");
                HP -= amountLost;
            }
        }
        else if (attackResponse2 == 2.ToString())
        {
            strongMonster.Hurt(rnd.Next(10, 30), attackTypes[rnd.Next(attackTypes.Count)]);
            strongMonster.Update();
            if (strongMonster.alive == false) continue;
            Console.WriteLine($"\n{weakMonster.name} attacked you back! It {attackTypes[rnd.Next(attackTypes.Count)]} you!");
            amountLost = rnd.Next(20, 30);
            Console.WriteLine($"Because of this, you have lost {amountLost} HP, and now you have {HP} HP!");
            HP -= amountLost;
        }
        else
        {
            Console.WriteLine("Let me tell you this again...\n");
        }
        strongMonster.Update();

        if (HP <= 0)
        {
            Console.WriteLine("You died while in battle! Game over!");
            return 1;
        }
    }

    Console.WriteLine("Press enter to continue!");
    Console.ReadLine();

    Console.WriteLine("\n");

    Console.WriteLine("You have taken care of the forest creature, and you are continuing your journey once again!\n" +
        "You see a temple, and you enter it. You wonder if there's any treasure to steal. You found gold!\n" +
        "You try to take the gold, and then you turn around and...\n");
    Monster Barbarian = new Monster((firstName[rnd.Next(firstName.Count)] + lastName[rnd.Next(lastName.Count)]), rnd.Next(200, 300), 5);
    Console.WriteLine("This one is a barbarian! So it won't spare you back!");
    while (Barbarian.alive == true)
    {
        Console.WriteLine("What do you do?\n\n1 = Spare\n2 = Attack");
        string attackResponse3 = Console.ReadLine();

        if (attackResponse3 == 1.ToString())
        {
            Console.WriteLine("You can't spare, you fuckwad.");
            Console.WriteLine($"\n{Barbarian.name} attacked you for your stupidity! It {attackTypes[rnd.Next(attackTypes.Count)]} you!");
            amountLost = rnd.Next(20, 30);
            Console.WriteLine($"Because of this, you have lost {amountLost} HP, and now you have {HP} HP!");
            HP -= amountLost;
        }
        else if (attackResponse3 == 2.ToString())
        {
            Barbarian.Hurt(rnd.Next(25, 100), attackTypes[rnd.Next(attackTypes.Count)]);
            Barbarian.Update();
            if(Barbarian.alive == false) continue;
            Console.WriteLine($"\n{Barbarian.name} attacked you! It {attackTypes[rnd.Next(attackTypes.Count)]} you!");
            amountLost = rnd.Next(20, 30);
            Console.WriteLine($"Because of this, you have lost {amountLost} HP, and now you have {HP} HP!");
            HP -= amountLost;
        }
        else
        {
            Console.WriteLine("Let me tell you this again...\n");
        }

        Barbarian.Update();

        if (HP <= 0)
        {
            Console.WriteLine("You died while in battle! Game over!");
            return 2;
        }
    }

    Console.WriteLine("Press enter to continue!");
    Console.ReadLine();
    return 3;
}

if (result == 1)
{
    Console.WriteLine("\nGAME END");
    Console.WriteLine("REASON: DEAD");
}
else if (result == 2)
{
    Console.WriteLine("\nGAME END");
    Console.WriteLine("REASON: FUCK YOU");
}
else if (result == 3)
{
    Console.WriteLine("\nGAME END");
    Console.WriteLine("REASON: NOBODY LIKES YOU EVEN IF YOU WIN THIS GAME LAUGH MY FUCKING ASS OFF");
}