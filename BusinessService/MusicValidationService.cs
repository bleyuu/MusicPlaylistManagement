using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class MusicValidationService
    {
        MusicGetService getservices = new MusicGetService();

        public bool CheckIfGenreExists(string genre)
        {
            bool result = getservices.GetMusic(genre) != null;
            return result;
        }

        public bool CheckIfMusicExists(string genre, string songName)
        {
            bool result = getservices.GetMusic(genre, songName) != null;
            return result;
        }

    }
}
