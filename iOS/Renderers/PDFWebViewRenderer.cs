using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using System.IO;
using System.Net;
using Xamarin.Forms;
using TMTK;

[assembly: ExportRenderer(typeof(PDFWebView), typeof(PDFWebViewRenderer))]
namespace TMTK
{
   public class PDFWebViewRenderer : ViewRenderer<PDFWebView, UIWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<PDFWebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                SetNativeControl(new UIWebView());
            }
            if (e.OldElement != null)
            {
                // Cleanup
            }
            if (e.NewElement != null)
            {
                var pdfWebView = Element as PDFWebView;
                string fileName = Path.Combine(NSBundle.MainBundle.BundlePath, string.Format("Content/{0}", WebUtility.UrlEncode(pdfWebView.Uri)));
                Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName, false)));
                Control.ScalesPageToFit = true;
            }
        }
    }
}