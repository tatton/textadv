using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTextAdv
{
    class Program
    {
        static Random Rnd = new Random();
        class GameEntity
        {
            protected int ID=0;
            protected string Name="";
            protected string Description="";
            public GameEntity(int id, string name, string description)
            {
                ID = id;
                Name = name;
                Description = description;
            }
        }

        class Place: GameEntity
        {
            private int North, East, South, West, Up, Down;
            public Place(int id, string name, string description, int north, int east, int south, int west, int up, int down):base(id, name, description)
            {
                North = north;
                East = east;
                South = south;
                West = west;
                Up = up;
                Down = down;
            }
        }

        class Character: GameEntity
        {
            private int CurrentLocation;
            public Character(int id, string name, string description, int location) : base(id, name, description)
            {
                CurrentLocation = location;
            }
        }

        class Item : GameEntity
        {
            private int Location;
            private string Status;
            public Item(int id, string name, string description, int location, string status) : base(id, name, description)
            {
                Location = location;
                Status = status;
            }
        }
        
        private static string GetOpcode(string inputtext)
        {
            int spaceloc=inputtext.IndexOf(" ");
            return inputtext.Substring(0, spaceloc ).ToLower(); ;
        }
        private static string GetOperand(string inputtext)
        {
            int spaceloc = inputtext.IndexOf(" ");
            return inputtext.Substring(spaceloc +1,inputtext.Length - spaceloc-1).ToLower(); ;
        }
        private static void SetUpGame(List<Character> characters, List<Item> items, List<Place> places)
        {
            
            characters.Add(new Character(101,"Goblin","Dirty 5 foot Goblin with a damaged left eye",1));
            items.Add(new Item(301, "bow", "An elvish bow made of carved hardwood", 102, "carried"));
            characters.Add(new Character(102, "Elf", "Tall blonde haired, blue eyed elf holding a bow", 2));
            places.Add(new Place(201, "Smelly ditch", "The muddy ditch smells of rotten food", 0, 2, 0, 0, 0, 0));
            places.Add(new Place(202, "Bumpy Road", "The road is well worn and has many bumps and potholes", 0, 0, 0, 1, 0, 0));
        }
        private static void PlayGame(List<Character> characters, List<Item> items, List<Place> places)
        {
            bool stopGame = false;
            while (!stopGame)
            {
                Console.Write("\n> ");
                string userinput = Console.ReadLine().ToLower();
                //Console.WriteLine("You " + GetOpcode(userinput) + " the " + GetOperand(userinput));
                switch (GetOpcode(userinput))
                {
                    case "get":
                        Console.WriteLine("You reach for the " + GetOperand(userinput));
                        break;
                    case "examine":
                        Console.WriteLine("You look at the " + GetOperand(userinput));
                        break;
                    case "go":
                        Console.WriteLine("You walk to the "+ GetOperand(userinput));
                        break;
                    case "quit":
                        Console.WriteLine("You decide to give up, try again another time.");
                        stopGame = true;
                        break;
                    default:
                        Console.WriteLine("Sorry, you don't know how to " + GetOpcode(userinput));
                        break;
                }
            }
            Console.Write("\nGoodbye.");
        }
            static void Main(string[] args)
        {
            List<Place> places = new List<Place>();
            List<Item> items = new List<Item>();
            List<Character> characters = new List<Character>();
            SetUpGame(characters, items, places);
            PlayGame(characters, items, places);
            Console.ReadLine();
        }
    }
}
