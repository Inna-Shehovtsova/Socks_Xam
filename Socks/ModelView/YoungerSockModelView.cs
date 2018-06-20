using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Socks.ModelView
{
    public class YoungerSockModelView : BaseSimpleSockModelView
    {
        public YoungerSockModelView() : base(Socks.DataService.DataService.GetSavedYoungerSockModelData())
        {
            BackCommand = new Command(onDisappear);
        }

        public void onDisappear()
        {
            DataService.DataService.SaveYoungerSockData((Model.YoungerSockModel)(_bsm));
        }

    }


}
