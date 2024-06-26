using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService;
using Model;

namespace BusinessService
{
    public class MusicGetService
    {
        private List<mpModel> GetAllMusic()
        {
            MusicData musicData = new MusicData();

            return musicData.GetMusic();

        }

        public mpModel GetMusic(string genre, string songName)
        {
            mpModel foundMusic = new mpModel();

            foreach (var music in GetAllMusic())
            {
                if (music.genre == genre && music.songName == songName)
                {
                    foundMusic = music;
                }
            }

            return foundMusic;
        }

        public mpModel GetMusic(string genre)
        {
            mpModel foundMusic = new mpModel();

            foreach (var music in GetAllMusic())
            {
                if (music.genre == genre)
                {
                    foundMusic = music;
                }
            }

            return foundMusic;
        }

    }
}
