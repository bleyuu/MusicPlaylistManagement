using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataService;
using Model;

namespace BusinessService
{
    public class MusicTransactionService
    {
        MusicValidationService validationServices = new MusicValidationService();
        MusicData musicData = new MusicData();

        public bool CreateMusic(mpModel music)
        {
            bool result = false;

            if (validationServices.CheckIfGenreExists(music.genre))
            {
                result = musicData.AddMusic(music) > 0;
            }

            return result;
        }

        public bool CreateMusic(string genre, string songName)
        {
            mpModel music = new mpModel { genre = genre, songName = songName };

            return CreateMusic(music);
        }

        public bool UpdateMusic(mpModel music)
        {
            bool result = false;

            if (validationServices.CheckIfGenreExists(music.genre))
            {
                result = musicData.UpdateMusic(music) > 0;
            }

            return result;
        }

        public bool UpdateMusic(string genre, string songName)
        {
            mpModel music = new mpModel { genre = genre, songName = songName };

            return UpdateMusic(music);
        }

        public bool DeleteMusic(mpModel music)
        {
            bool result = false;

            if (validationServices.CheckIfGenreExists(music.genre))
            {
                result = musicData.DeleteMusic(music) > 0;
            }

            return result;
        }

    }
}
