using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataService
{
    public class MusicData
    {
        List<mpModel> musics;
        SqlDbData sqlData;
        public MusicData()
        {
            musics = new List<mpModel>();
            sqlData = new SqlDbData();
        }

        public List<mpModel> GetMusic()
        {
            musics = sqlData.GetMusic();
            return musics;
        }

        public int AddMusic(mpModel music)
        {
            return sqlData.AddMusic(music.genre, music.songName);
        }

        public int UpdateMusic(mpModel music)
        {
            return sqlData.UpdateMusic(music.genre, music.songName);
        }

        public int DeleteMusic(mpModel music)
        {
            return sqlData.DeleteMusic(music.songName);
        }

        public List<mpModel> SearchSongsByGenre(string genre)
        {
            return sqlData.SearchSongsByGenre(genre);
        }
    }
}
