using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Socks.ModelView
{
    public class WomenSockModelView : BaseSimpleSockModelView
    {
        public WomenSockModelView() : base(Socks.DataService.DataService.GetSavedWomanSockModelData())
        {

            BackCommand = new Command(onDisappear);
        }

        public void onDisappear()
        {
            DataService.DataService.SaveWomanSockData((Model.WomanSockModel)(_bsm));
        }

    }
}
