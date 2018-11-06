using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MereNear.CustomControl;
using MereNear.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ReturnType = MereNear.CustomControl.ReturnType;

[assembly: ExportRenderer(typeof(BaseEntry), typeof(BaseEntryRenderer))]
namespace MereNear.iOS.Renderers
{
    public class BaseEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            BaseEntry entry = (BaseEntry)this.Element;

            if (this.Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                if (entry != null)
                {
                    SetReturnType(entry);

                    Control.ShouldReturn += (UITextField tf) =>
                    {
                        entry.InvokeCompleted();
                        return true;
                    };
                }
            }
        }

        private void SetReturnType(BaseEntry entry)
        {
            ReturnType type = entry.ReturnType;

            switch (type)
            {
                case ReturnType.Go:
                    Control.ReturnKeyType = UIReturnKeyType.Go;
                    break;
                case ReturnType.Next:
                    Control.ReturnKeyType = UIReturnKeyType.Next;
                    break;
                case ReturnType.Send:
                    Control.ReturnKeyType = UIReturnKeyType.Send;
                    break;
                case ReturnType.Search:
                    Control.ReturnKeyType = UIReturnKeyType.Search;
                    break;
                case ReturnType.Done:
                    Control.ReturnKeyType = UIReturnKeyType.Done;
                    break;
                default:
                    Control.ReturnKeyType = UIReturnKeyType.Default;
                    break;
            }
        }
    }
}