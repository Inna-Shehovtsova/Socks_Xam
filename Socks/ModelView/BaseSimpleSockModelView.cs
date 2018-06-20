using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;


namespace Socks.ModelView
{
    public class BaseSimpleSockModelView : INotifyPropertyChanged
    {
        public ICommand AddRowCommand { protected set; get; }
        public ICommand ResetCommand { protected set; get; }
        public ICommand TakeOffRowCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        protected Socks.Model.SimpleSockKnitModel _bsm;
        double plotX;
        double plotY;
        string[] sockImage = {"woman_000_Nosok.png", "woman_001_Nosok.png", "woman_002_Nosok.png",
            "woman_003_Nosok.png", "woman_004_Nosok.png", "woman_005_Nosok.png", "woman_006_Nosok.png",
            "woman_007_Nosok.png", "woman_008_Nosok.png", "woman_009_Nosok.png", "woman_010_Nosok.png",
            "woman_011_Nosok.png", "woman_012_Nosok.png", "woman_013_Nosok.png","woman_014_Nosok.png" };
        public List<int> Sizes
        {
            get
            {
                return _bsm._sizes;
            }

        }


        private void setCommand()
        {
            AddRowCommand = new Command(addRow);
            ResetCommand = new Command(Reset);
            TakeOffRowCommand = new Command(TakeOffRow);
        }

        public BaseSimpleSockModelView(Socks.Model.SimpleSockKnitModel inputModel)
        {
            _bsm = inputModel;
            setCommand();
        }


        public int CurrentRow
        {
            get
            {
                return _bsm.CurrentRow;
            }
            set
            {
                if (_bsm.CurrentRow != value)
                {
                    _bsm.CurrentRow = value;
                    OnPropertyChanged("CurrentDescription");
                    OnPropertyChanged("CurrentRow");
                    OnPropertyChanged("SockImageSourse");
                }
            }
        }

        public int CurrentSize
        {
            get
            {
                return _bsm.CurrentSize;
            }
            set
            {
                if (_bsm.CurrentSize != value)
                {
                    _bsm.CurrentSize = value;
                    OnPropertyChanged("CurrentSize");
                    OnPropertyChanged("CurrentDescription");
                    OnPropertyChanged("AllDescription");
                    OnPropertyChanged("CurrentKnittingSize");
                }
            }
        }

        public string CurrentDescription
        {
            get
            {
                return _bsm.CurrentDescription;
            }
        }

        public string SockImageSourse
        {
            get
            {
                if (_bsm.Part == Parts.Zero)
                    return sockImage[0];
                /*Mangeta, 
    Top, 
    Heel,
    MainPart, 
    MainPart, 
    Toe*/
                if (_bsm.Part == Parts.Mangeta)
                {
                    return sockImage[1];
                }
                if (_bsm.Part == Parts.Top1)
                {
                    return sockImage[2];
                }
                if (_bsm.Part == Parts.Top2)
                {
                    return sockImage[3];
                }
                if (_bsm.Part == Parts.Top3)
                {
                    return sockImage[4];
                }
                if (_bsm.Part == Parts.Top4)
                {
                    return sockImage[5];
                }
                if (_bsm.Part == Parts.Heel1)
                {
                    return sockImage[6];
                }
                if (_bsm.Part == Parts.Heel2)
                {
                    return sockImage[7];
                }
                if (_bsm.Part == Parts.Heel3)
                {
                    return sockImage[8];
                }
                if (_bsm.Part == Parts.MainPart1)
                {
                    return sockImage[9];
                }
                if (_bsm.Part == Parts.MainPart2)
                {
                    return sockImage[10];
                }
                if (_bsm.Part == Parts.MainPart3)
                {
                    return sockImage[11];
                }
                if (_bsm.Part == Parts.MainPart4)
                {
                    return sockImage[12];
                }
                if (_bsm.Part == Parts.MainPart5)
                {
                    return sockImage[13];
                }
                if (_bsm.Part == Parts.Toe)
                {
                    return sockImage[14];
                }

                return sockImage[0];
            }
        }

        public string AllDescription
        {
            get
            {
                string ret = "";
                foreach (string d in _bsm.AllDescription)
                    ret += d + "\n";
                return ret;
            }
        }
        public string CurrentKnittingSize
        {
            get { return _bsm.KnittingSize; }
        }
       
        private void addRow()
        {
            int row = CurrentRow;
            row++;
            CurrentRow = row;
        }
        private void TakeOffRow()
        {
            int row = CurrentRow;
            row--;
            if (row > -1)
                CurrentRow = row;

        }
        private void Reset()
        {
            CurrentRow = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        
    }
}



