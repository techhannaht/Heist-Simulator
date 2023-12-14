using System.Security.Cryptography.X509Certificates;

namespace Heist
{

    public class TeamMember
    {
        public string Name { get; set; } = string.Empty;

        public int SkillLevel { get; set; }

        public double CourageFactor { get; set; }
    }

    class Program
    {

        static void Main()
        {
            List<TeamMember> teamMembers = new List<TeamMember>();

            // Print the message "Plan Your Heist!".
            Console.WriteLine("Plan Your Heist!");

            // Create a way to store a single team member.
            TeamMember singleTeamMember = new TeamMember();


            // Prompt the user to enter a team member's name and save that name.
            Console.WriteLine("Enter your team captain's name:");

            // Read the user input and save it in a variable
            singleTeamMember.Name = Console.ReadLine();

            // Display the entered name
            Console.WriteLine("Nice! Your Team Captains's name has been saved.");
            Console.WriteLine("-------------------------------");

            // Prompt the user to enter a team member's skill level and save that skill level with the name.

            Console.WriteLine("Enter the Team Captain's skill level:");

            singleTeamMember.SkillLevel = int.Parse(Console.ReadLine());


            if (singleTeamMember.SkillLevel <= 0)
            {
                Console.Write("Invalid input. Please enter a positive integer for skill level: ");
                singleTeamMember.SkillLevel = int.Parse(Console.ReadLine());
            };

            Console.WriteLine("Nice! Your Team Captain's skill level has been saved.");
            Console.WriteLine("-------------------------------");

            // Prompt the user to enter a team member's courage factor and save that courage factor with the name.

            Console.WriteLine("Enter the Team Captain's courage factor between 0 and 2:");

            singleTeamMember.CourageFactor = int.Parse(Console.ReadLine());

            if (singleTeamMember.CourageFactor < 0 || singleTeamMember.CourageFactor > 2)
            {
                Console.Write("Invalid input. Please enter a positive integer between 0 and 2: ");
                singleTeamMember.CourageFactor = int.Parse(Console.ReadLine());
            }


            Console.WriteLine("Nice! Your Team Captain's courage factor has been saved.");

            Console.WriteLine("-------------------------------");

            teamMembers.Add(singleTeamMember);

            // Display the team member's information.
            Console.WriteLine("Team Captain Information:");
            Console.WriteLine("Team Captain Name: " + singleTeamMember.Name);
            Console.WriteLine("Team Captain Skill Level: " + singleTeamMember.SkillLevel);
            Console.WriteLine("Team Captain Courage Factor: " + singleTeamMember.CourageFactor);


            // Phase Two: Store several team members
            // List<TeamMember> teamMembers = new List<TeamMember>();

            Console.WriteLine("Enter information for multiple team members (enter a blank name to stop):");

            while (true)
            {
                TeamMember newTeamMember = new TeamMember();

                Console.Write("Enter team member's name (leave blank to stop): ");
                newTeamMember.Name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newTeamMember.Name))
                {
                    break; // Stop collecting team members when a blank name is entered
                }

                Console.Write("Enter team member's skill level (positive integer): ");
                newTeamMember.SkillLevel = int.Parse(Console.ReadLine());
                if (newTeamMember.SkillLevel <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer for skill level.");
                    newTeamMember.SkillLevel = int.Parse(Console.ReadLine());
                }

                Console.Write("Enter team member's courage factor (decimal between 0.0 and 2.0): ");
                newTeamMember.CourageFactor = int.Parse(Console.ReadLine());
                if (newTeamMember.CourageFactor < 0 || newTeamMember.CourageFactor > 2)
                {
                    Console.WriteLine("Invalid input. Please enter a decimal between 0.0 and 2.0 for courage factor.");
                    newTeamMember.CourageFactor = int.Parse(Console.ReadLine());
                }

                teamMembers.Add(newTeamMember);
            }

            // Display the number of team members
            Console.WriteLine($"Total number of team members: {teamMembers.Count}");

            // Display each team member's information
            Console.WriteLine("Team Members Information:");
            foreach (var member in teamMembers)
            {
                DisplayTeamMemberInfo(member);
            }


            static void DisplayTeamMemberInfo(TeamMember teamMember)
            {
                Console.WriteLine($"Name: {teamMember.Name}, Skill Level: {teamMember.SkillLevel}, Courage Factor: {teamMember.CourageFactor}");
            }

            // Stop displaying each team member's information.

            bool BossAsks(string question)
            {
                // Ability to ask a  y/n question
                Console.Write($"{question} (Y/N): ");
                // changes answer to lower case
                string answer = Console.ReadLine().ToLower();

                // while answer does not equal yes or no the question will prompt in terminal and convert answer to lower case
                while (answer != "y" && answer != "n")
                {
                    Console.Write($"{question} (Y/N): ");
                    answer = Console.ReadLine().ToLower();
                }
                // if answer is yes, return true 
                if (answer == "y")
                {
                    return true;

                }
                // if answer is no, return false 

                else
                {
                    return false;
                }
            }

            void ClearScreen()
            {
                {
                    bool isTrue = BossAsks("Ready to Heist?");
                    if (isTrue)
                    {
                        Console.WriteLine("You got it");
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Byeeeeeeeee");
                        return;
                    }
                }
            }

            ClearScreen();


            // Phase Three:

            // Store a value for the bank's difficulty level. Set this value to 100.
            int BankLevel = 100;

            // Find the sum of all skill levels using LINQ

            int totalSkillLevel = teamMembers.Sum(member => member.SkillLevel);

            // Display the total skill level and compare the number with the bank's difficulty level. If the team's skill level is greater than or equal to the bank's difficulty level, Display a success message, otherwise display a failure message.


            void Heist()
            {

                Console.WriteLine("Choose a difficulty level: Easy, Medium, Hard, or Cheater");

                // Take user's difficulty level choice as input and set the number of guesses accordingly.
                // After the user enters the team information, prompt them to enter the number of trial runs the program should perform.

                int maxGuesses;
                string difficultyLevel = Console.ReadLine().ToLower();

                switch (difficultyLevel)
                {
                    case "easy":
                        maxGuesses = 8;
                        break;
                    case "medium":
                        maxGuesses = 6;
                        break;
                    case "hard":
                        maxGuesses = 4;
                        break;
                    case "cheater":
                        maxGuesses = int.MaxValue; // Set to a very large number for "Cheater" mode.
                        break;
                    default:
                        Console.WriteLine("Invalid difficulty level. Defaulting to Medium.");
                        maxGuesses = 6;
                        break;
                }

                // Run the scenario multiple times.
                // Loop through the difficulty / skill level calculation based on the user-entered number of trial runs. Choose a new luck value each time.

                int Wins = 0;
                int Losses = 0;
                Random random = new Random();

                for (int attempt = 1; attempt <= maxGuesses || maxGuesses == int.MaxValue; attempt++)
                {

                    int luckValue = random.Next(-10, 11);
                    int BankLuckValue = BankLevel += luckValue;

                    Console.Write($"({attempt}/{maxGuesses}): ");

                    bool isTrue = BossAsks($"Ah, welcome to the heist. The level of this challenge is {BankLuckValue}. Do you think you can handle it?");

                    if (isTrue)
                    {
                        Console.WriteLine($"Okay then, I can see that the team's combined skills level is {totalSkillLevel} and the bank's difficult level is {BankLuckValue}");
                    }
                    else
                    {
                        Console.WriteLine("I figured you were too scared. BYE");
                        return;
                    }


                    if (BankLuckValue > totalSkillLevel)
                    {
                        Console.WriteLine("Yikes... you're not strong enough for this challenge. Train harder.");
                        Losses++;
                    }
                    else
                    {
                        Console.WriteLine("Whew - you made that look easy! Enjoy your winnings thieves!");
                        Wins++;
                    }
                }

                Console.WriteLine($"Wins: {Wins}, Losses: {Losses}");

            }

            Heist();

        }

    }

}

