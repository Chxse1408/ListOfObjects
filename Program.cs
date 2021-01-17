using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Console_ListOfObjects

{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<VideoGames> videoGames = new List<VideoGames>();

            addGames(videoGames);
            DisplayGame(videoGames);
            SaveGame(videoGames);

            Console.ReadKey();
        }

        private static void addGames(List<VideoGames> videoGames)
        {
            Console.WriteLine("\n\t\tAdd Video Games\n");

            bool doneAdding = false;
            do
            {
                VideoGames videoGame = new VideoGames();

                //getting data
                Console.Write("Name: ");
                videoGame.NameOfGame = Console.ReadLine();
                Console.Write("Year of Release: ");
                videoGame.YearOfRelease = GetAge();
                Console.WriteLine("What genre is your game? ");
                videoGame.Genre = GetGenre();
                Console.Write("Is this a rare game?(true/false): ");
                videoGame.IsRare = IsRare();

                //adds game to list
                videoGames.Add(videoGame);

                //add another game?
                Console.Write("Add another game?(Y/N):");
                string addAnother = Console.ReadLine().ToUpper();
                if (addAnother == "N")
                {
                    doneAdding = true;
                }
            } while (!doneAdding);
        }

        private static bool IsRare()
        {
            bool validResponse = false;
            bool isRare = false;

            do
            {
                validResponse = true;
                if (bool.TryParse(Console.ReadLine(), out bool rarity))
                {
                    isRare = rarity;
                }
                else
                {
                    Console.WriteLine("Please enter \'true\' or  \'false\'.");
                    validResponse = false;
                }
            } while (!validResponse);
            return isRare;
        }

        private static void SaveGame(List<VideoGames> games)
        {
            string dataPath = @"Data\\VideoGames.txt";
            string gameString;

            foreach (VideoGames videoGames1 in games)
            {
                gameString = videoGames1.NameOfGame + "," + videoGames1.YearOfRelease + "," + videoGames1.Genre + "," + videoGames1.IsRare + "\n";
                File.AppendAllText(dataPath, gameString);
            }
        }

        private static VideoGames.genres GetGenre()
        {
            bool validResponse = false;

            VideoGames.genres gameGenre = 0;
            foreach (VideoGames.genres genre in Enum.GetValues(typeof(VideoGames.genres)))
            {
                Console.Write(" | " + genre);
            }
            Console.WriteLine();
            do
            {
                validResponse = true;
                if (Enum.TryParse(Console.ReadLine().ToLower().Trim(), out VideoGames.genres genre))
                {
                    gameGenre = genre;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid genre.");
                    validResponse = false;
                }
            } while (!validResponse);
            return gameGenre;
        }

        private static int GetAge()
        {
            bool validResponse = false;
            int yearOfRelease = 0;

            do
            {
                validResponse = true;
                if (int.TryParse(Console.ReadLine(), out int year))
                {
                    yearOfRelease = year;
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer.");
                    validResponse = false;
                }
            } while (!validResponse);
            return yearOfRelease;
        }

        private static void DisplayGame(List<VideoGames> videoGames)
        {
            Console.Clear();
            Console.WriteLine("\n\t\tDisplay Video Games\n");

            foreach (VideoGames videogame in videoGames)
            {
                Console.WriteLine($"\nGame: {videogame.NameOfGame}" +
                    $"\nYear of Release: {videogame.YearOfRelease}" +
                    $"\nGenre: {videogame.Genre}");
                Console.WriteLine($"Rare Game?: {videogame.IsRare}");
            }
        }
    }
}