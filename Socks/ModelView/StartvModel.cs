using System.ComponentModel;

using System.Windows.Input;
using Xamarin.Forms;


namespace Socks.ModelView
{
    class StartViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

       
        public ICommand CountWomanSockCommand { protected set; get; }
        public ICommand CountKidSockCommand { protected set; get; }
        public ICommand CountYoungerSockCommand { protected set; get; }
        public ICommand CountManSockCommand { protected set; get; }
        public INavigation Navigation { get; set; }
        public Page page { get; set; }
        double px;
        double py;

        public StartViewModel() {
            px = 22;
            py = 35;
            CountWomanSockCommand = new Command(CountWomanSock);
            CountKidSockCommand = new Command(CountKidSock);
            CountYoungerSockCommand = new Command(CountYongerSock);
            CountManSockCommand = new Command(CountManSock);
        }
        public double PlotX
        {
            get { return px; }
            set
            {
                
                if (px != value )
                px = value;
                OnPropertyChanged("PlotX");
            }
        }
        public double PlotY
        {
            get { return py; }
            set
            {
                
                if (py != value)
                    py = value;
                OnPropertyChanged("PlotY");
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private bool IfNoTrueThick()
        {
            if ((PlotY < 5) || (PlotY > 160))
            {
                if (page != null)
                    page.DisplayAlert("Ограничение плотности", "Плотность вязания по высоте должна быть больше 5 и меньше 160 рядов на 10 см.", "ОK");
                return false;

            }
            if ((PlotX < 5) || (PlotX > 60))
            {
                if (page != null)
                    page.DisplayAlert("Ограничение плотности", "Плотность вязания по ширине должна быть больше 5 и меньше 60 петель на 10 см.", "ОK");

                return false;

            }
            return true;
        }

        private void CountWomanSock()
        {
            if (!IfNoTrueThick())
                return;
            Model.WomanSockModel wsm = new Model.WomanSockModel(PlotX, PlotY);
            DataService.DataService.SaveMiniWomanSockData(wsm);
            Navigation.PushAsync(new View.WomenSocksPage() { BindingContext = new WomenSockModelView() });
        }

        private void CountKidSock()
        {
            if (!IfNoTrueThick())
                return;
            Model.KidSockModel wsm = new Model.KidSockModel(PlotX, PlotY);
            DataService.DataService.SaveMiniKidSockData(wsm);
            Navigation.PushAsync(new View.KidSockPage() { BindingContext = new KidSockModelView() });
        }

        private void CountYongerSock()
        {
            if (!IfNoTrueThick())
                return;
            Model.YoungerSockModel wsm = new Model.YoungerSockModel(PlotX, PlotY);
            DataService.DataService.SaveMiniYoungerSockData(wsm);
            Navigation.PushAsync(new View.YoungerSockPage() { BindingContext = new YoungerSockModelView() , Title = "Подростковые носки"});
        }
        private void CountManSock()
        {
            if (!IfNoTrueThick())
                return;
            Model.ManSockModel wsm = new Model.ManSockModel(PlotX, PlotY);
            DataService.DataService.SaveMiniManSockData(wsm);
            Navigation.PushAsync(new View.ManSockPage() { BindingContext = new ManSockModelView() });
        }
    }
}
