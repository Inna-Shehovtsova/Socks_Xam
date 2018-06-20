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
    public partial class YoungerSockPage : ContentPage
    {
        public YoungerSockPage()
        {
            InitializeComponent();
        }
        //public Socks.ModelView.ManSockModelView wsmv;


        protected override void OnDisappearing()
        {
            //if (wsmv != null)
            //{
            //    wsmv.onDisappear();
            //}
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            // wsmv = (Socks.ModelView.ManSockModelView)BindingContext;
        }
    }
}
