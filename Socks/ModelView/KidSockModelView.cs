using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Socks.ModelView
{
	public class KidSockModelView : BaseSimpleSockModelView
    {
        public KidSockModelView() : base(Socks.DataService.DataService.GetSavedKidSockModelData())
        {
            BackCommand = new Command(onDisappear);

        }


        public void onDisappear()
        {
            DataService.DataService.SaveKidSockData((Model.KidSockModel)(_bsm));
        }

    }
}
