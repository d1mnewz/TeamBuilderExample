using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamBuilderExample
{
    public class Program
    {
        static void Main()
        {
            Team @new = new TeamBuilder().Create("23c16-3pr")
                .WithColor(ConsoleColor.Cyan)
                .WithHomeTown("Rivne")
                .WithPlayers()
                .Build();
            PrintTeam(@new);
            

        }
        public static void PrintTeam(Team obj)
        {
            Console.ForegroundColor = obj.Color;
            Console.WriteLine(String.Format("\t{0} from {1}\t", obj.Name, obj.HomeTown));
            Console.WriteLine("Players : ");
            foreach (var el in obj.Players)
            {
                Console.WriteLine(el);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public class Team
    {
        public String Name;
        public List<String> Players;
        public String HomeTown;
        public ConsoleColor Color;

        public Team(
              String name
            ,List<String> players
            ,String hometown
            ,ConsoleColor color)
        {
            this.Color = color;
            this.HomeTown = hometown;
            this.Name = name;
            this.Players = players;
        }

    }

    public class TeamBuilder
    {
        private String _name;
        private List<String> _players = new List<String>();
        private String _homeTown;
        private ConsoleColor _color;
        public TeamBuilder Create(String name)
        {
            this._name = name;
            return this;
        }
        public TeamBuilder WithPlayers()
        {
            for (int i = 0; i < 11; i++)
            {
                this._players.Add(Faker.Name.FullName());
            }
            return this;
        }
        public TeamBuilder WithColor(ConsoleColor color)
        {
            this._color = color;
            return this;
        }

        public TeamBuilder WithHomeTown(String home)
        {
            this._homeTown = home;
            return this;
        }
        public Team Build()
        {
            return new Team(this._name, this._players, this._homeTown, this._color);
        }


    }
}
