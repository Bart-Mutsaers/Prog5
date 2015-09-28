using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicCollectionMVVM
{
    public class SongListviewModel
    {
        ISongRepository songRepository;

        public SongViewModel SongViewModel { get; set; }

        public ObservableCollection<SongViewModel> Songs { get; set; }

        public ICommand AddSong { get; set; }

        public SongListviewModel()
        {
            songRepository = new DummySongRepository();
            var songList = songRepository.ToList().Select(s => new SongViewModel(s));

            SongViewModel = new SongViewModel();
            Songs = new ObservableCollection<SongViewModel>(songList);


            AddSong = new RelayCommand(AddNewSong);
        }



        private void AddNewSong(object parameter)
        {
            var svm = new SongViewModel();

            svm.Artist = SongViewModel.Artist;
            svm.Id = SongViewModel.Id;
            svm.Title = SongViewModel.Title;

            Songs.Add(svm);
            
        }
    }
}
