using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicCollectionMVVM
{
    public class SongListviewModel : INotifyPropertyChanged
    {
        ISongRepository songRepository;

        private SongViewModel _songViewModel;
        public SongViewModel SelectedSong { get{ return _songViewModel;}
            set
            {
                _songViewModel = value;
                OnPropertyChanged("SelectedSong");
            }
        }

        public ObservableCollection<SongViewModel> Songs { get; set; }

        public ICommand AddSong { get; set; }

        public ICommand ClearSong { get; set; }

        public ICommand DeleteSongCommand { get; set; }

        public SongListviewModel()
        {
            songRepository = new DummySongRepository();
            var songList = songRepository.ToList().Select(s => new SongViewModel(s));

            SelectedSong = new SongViewModel();
            Songs = new ObservableCollection<SongViewModel>(songList);

            ClearSong = new RelayCommand(ClearThesong, CanClearSong);
            DeleteSongCommand = new RelayCommand(DeleteSong, CanDeleteSong);
            AddSong = new RelayCommand(AddNewSong, CanAddSong);
        }

        private void ClearThesong()
        {
            SelectedSong = new SongViewModel();
        }

        private bool CanClearSong()
        {
            return true;
        }

        private void DeleteSong()
        {
            Songs.Remove(SelectedSong);
            SelectedSong = new SongViewModel();
        }

        public bool CanDeleteSong()
        {
            return SelectedSong != null;
        }


        private void AddNewSong()
        {
            var svm = new SongViewModel();

            svm.Artist = SelectedSong.Artist;
            svm.Id = SelectedSong.Id;
            svm.Title = SelectedSong.Title;

            Songs.Add(svm);
        }

        private bool CanAddSong()
        {
            if(SelectedSong.Artist == null)
                return false;

            if (SelectedSong.Id <= 0)
                return false;

            if (SelectedSong.Title == null)
                return false;

            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
         
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
