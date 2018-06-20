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
    public partial class WomenSocksPage : ContentPage
    {
        public Socks.ModelView.WomenSockModelView wsmv;
        public WomenSocksPage()
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
            wsmv = (Socks.ModelView.WomenSockModelView)BindingContext;
        }

    }
}
