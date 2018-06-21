using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Android.Graphics.Drawables;
//using Android.Graphics.Drawables.Shapes;
//using Android.Graphics;
//using Android.Content;
 
namespace Socks.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
		//ShapeDrawable drawable;
        public StartPage()
		{
            InitializeComponent();
            BindingContext = new Socks.ModelView.StartViewModel() { Navigation = this.Navigation, page = this };
			var scr3eensize = Device.Info.PixelScreenSize;
			var scalesize = Device.Info.ScaledScreenSize;
			var scale = Device.Info.ScalingFactor;
			//var dens = Resources.DisplayMetrics.Density;
            //string backgroundname = Device.OnPlatform(iOS: "startpage_BG.png", Android: "startpage_BG.png");
            //this.BackgroundImage = backgroundname;

        }

    }
}
