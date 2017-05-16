using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TMTK
{
    public partial class StJudesPage : ContentPage
    {
        public StJudesPage()
        {
            InitializeComponent();
            //Browser.Source = @"https://fundraising.stjude.org/site/Donation2?idb=1299678909&df_id=3520&3520.donation=form1&FR_ID=67250&mfc_pref=T&PROXY_ID=67250&PROXY_TYPE=21";
			var htmlSource = new HtmlWebViewSource();
			htmlSource.Html = @"<html><body style=""text-align:center"">
			  <h1>Donate To Robins St. Jude Page</h1>
			  <p>Your browser should have opened to take you to Robin's St. Jude page automatically</p><p>If it didn't please open your browser and go to http://www.robinsbigseminar.com/stjude</p>
			  <p>Thank You! Team Robin</p></body></html>";
			Browser.Source = htmlSource;
			Device.OpenUri(new Uri(@"http://www.robinsbigseminar.com/stjude"));
        }
    }
}
