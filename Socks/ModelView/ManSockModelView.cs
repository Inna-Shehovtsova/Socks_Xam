using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Socks.ModelView
{
    public class ManSockModelView : BaseSimpleSockModelView
    {
        public ManSockModelView() : base(Socks.DataService.DataService.GetSavedManSockModelData())
        {
            BackCommand = new Command(onDisappear);

        }
        public void onDisappear()
        {
            DataService.DataService.SaveManSockData((Model.ManSockModel)(_bsm));
        }
    }
}
