using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;

namespace DataService
{
    public class SqlDbData
    {
        string connectionString
        = "Data Source =LAPTOP-GMHVQIRU\\SQLEXPRESS; Initial Catalog = MusicPlaylist; Integrated Security = True;";

        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<mpModel> GetMusic()
        {
            string selectStatement = "SELECT genre, songName FROM Songs";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<mpModel> mp = new List<mpModel>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string genre = reader["genre"].ToString();
                string songName = reader["songName"].ToString();

                mpModel readMusic = new mpModel();
                readMusic.genre = genre;
                readMusic.songName = songName;

                mp.Add(readMusic);
            }

            sqlConnection.Close();

            return mp;
        }

        public int AddMusic(string genre, string songName)
        {
            int success;

            string insertStatement = "INSERT INTO Songs VALUES (@genre, @songName)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@genre", genre);
            insertCommand.Parameters.AddWithValue("@songName", songName);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int UpdateMusic(string genre, string songName)
        {
            int success;

            string updateStatement = $"UPDATE Songs SET songName = @SongName WHERE genre = @genre";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@genre", genre);
            updateCommand.Parameters.AddWithValue("@SongName", songName);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int DeleteMusic(string songName)
        {
            int success;

            string deleteStatement = $"DELETE FROM Songs WHERE songName = @songName";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@songName", songName);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public List<mpModel> SearchSongsByGenre(string genre)
        {
            List<mpModel> songs = new List<mpModel>();

            string searchStatement = $"SELECT genre, songName FROM Songs WHERE genre = @genre";
            SqlCommand searchCommand = new SqlCommand(searchStatement, sqlConnection);
            searchCommand.Parameters.AddWithValue("@genre", genre);

            sqlConnection.Open();

            SqlDataReader reader = searchCommand.ExecuteReader();

            while (reader.Read())
            {
                string retrievedGenre = reader["genre"].ToString();
                string retrievedSongName = reader["songName"].ToString();

                mpModel song = new mpModel();
                song.genre = retrievedGenre;
                song.songName = retrievedSongName;

                songs.Add(song);
            }

            sqlConnection.Close();

            return songs;
        }

    }
}
