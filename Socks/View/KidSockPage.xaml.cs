using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Socks.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KidSockPage : ContentPage
    {
        Socks.ModelView.KidSockModelView wsmv;
        public KidSockPage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            if (wsmv != null)
            {
                wsmv.onDisappear();
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            wsmv = (Socks.ModelView.KidSockModelView)BindingContext;
        }
    }
}
