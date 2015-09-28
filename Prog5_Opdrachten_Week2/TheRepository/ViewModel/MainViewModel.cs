using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Linq;

namespace TheRepository.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ICarRepository _carRepository;

        public ObservableCollection<CarVM> MyCars { get; set; }

        public double TotalePrijs { 
            get
            {
                return MyCars.Sum(c => c.Prijs);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
          // oude code
          //  var cars = carRepository.GetAllCars().Where(c => !c.Actief).ToList();
            var cars = carRepository.GetAllCars().Where(c => c.Actief).ToList();
            this.MyCars = new ObservableCollection<CarVM>(cars.Select(c => new CarVM(c)));
        }

        public void SetRepository(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
        }
    }
}