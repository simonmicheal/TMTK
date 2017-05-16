using System;
using TMTK;
using TMTK.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NoHelperEntry), typeof(NoHelperEntryRenderer))]
namespace TMTK.iOS
{
	public class NoHelperEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.SpellCheckingType = UITextSpellCheckingType.No;             // No Spellchecking
				Control.AutocorrectionType = UITextAutocorrectionType.No;           // No Autocorrection
				Control.AutocapitalizationType = UITextAutocapitalizationType.None; // No Autocapitalization
			}
		}
	}
}
