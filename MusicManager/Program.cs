using DataService;
using Model;
using System.Data.SqlClient;

namespace MusicManager
{
    public class Program
    {
        private SqlDbData sqlDbData;

        public Program() 
        {
            sqlDbData = new SqlDbData();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            int choice;

            do
            {
                Console.WriteLine("\nMusic Management");
                Console.WriteLine("1. Add Song");
                Console.WriteLine("2. Update Song");
                Console.WriteLine("3. Delete Song");
                Console.WriteLine("4. Show All Songs");
                Console.WriteLine("5. Search Songs by Genre");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        program.AddSong();
                        break;
                    case 2:
                        program.UpdateSong();
                        break;
                    case 3:
                        program.DeleteSong();
                        break;
                    case 4:
                        program.ShowAllSongs();
                        break;
                    case 5:
                        program.SearchSongsByGenre();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        return;
                }
            } while (choice != 6);
        }

        private void AddSong()
        {
            string genre, songName;
            Console.Write("Enter Genre: ");
            genre = Console.ReadLine();
            Console.Write("Enter Song Name: ");
            songName = Console.ReadLine();

            int success = sqlDbData.AddMusic(genre, songName);
            if (success > 0)
            {
                Console.WriteLine("Song added successfully!");
            }
            else
            {
                Console.WriteLine("Error adding song!");
            }
        }

        private void UpdateSong()
        {
            string genre, newSongName;
            Console.Write("Enter Genre of the Song to update: ");
            genre = Console.ReadLine();
            Console.Write("Enter new Song Name: ");
            newSongName = Console.ReadLine();

            int success = sqlDbData.UpdateMusic(genre, newSongName);
            if (success > 0)
            {
                Console.WriteLine("Song updated successfully!");
            }
            else
            {
                Console.WriteLine("Error updating song!");
            }
        }

        private void DeleteSong()
        {
            string songName;
            Console.Write("Enter the song to delete: ");
            songName = Console.ReadLine();

            int success = sqlDbData.DeleteMusic(songName);
            if (success > 0)
            {
                Console.WriteLine("Song deleted successfully!");
            }
            else
            {
                Console.WriteLine("Error deleting song!");
            }
        }

        private void ShowAllSongs()
        {
            List<mpModel> songs = sqlDbData.GetMusic(); 

            if (songs.Count > 0)
            {
                Console.WriteLine("\nSongs:");
                foreach (mpModel song in songs)
                {
                    Console.WriteLine($"Genre: {song.genre}, Song Name: {song.songName}");
                }
            }
            else
            {
                Console.WriteLine("No songs found!");
            }
        }

        private void SearchSongsByGenre()
        {
            string genre;
            Console.Write("Enter Genre to search: ");
            genre = Console.ReadLine();

            List<mpModel> songs = sqlDbData.SearchSongsByGenre(genre);

            if (songs.Count > 0)
            {
                Console.WriteLine("\nSongs:");
                foreach (mpModel song in songs)
                {
                    Console.WriteLine($"Genre: {song.genre}, Song Name: {song.songName}");
                }
            }
            else
            {
                Console.WriteLine("No songs found for that genre!");
            }
        }
    }
}
