using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCollectionMVVM
{
    interface ISongRepository
    {
        List<Song> ToList();

    }
}
