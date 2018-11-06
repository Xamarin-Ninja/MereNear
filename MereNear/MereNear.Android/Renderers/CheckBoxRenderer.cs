using System;
using System.ComponentModel;
using Android.Content;
using Android.Widget;
using MereNear.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MereNear.CustomControl.CheckBox), typeof(CheckBoxRenderer))]
namespace MereNear.Droid.Renderers
{
    public class CheckBoxRenderer : ViewRenderer<CustomControl.CheckBox, CheckBox>
    {
        private CheckBox checkBox;

        public CheckBoxRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomControl.CheckBox> e)
        {
            base.OnElementChanged(e);
            var model = e.NewElement;
            checkBox = new CheckBox(Context);
            checkBox.Tag = this;
            CheckboxPropertyChanged(model, null);
            checkBox.SetOnClickListener(new ClickListener(model));
            SetNativeControl(checkBox);
        }
        private void CheckboxPropertyChanged(CustomControl.CheckBox model, String propertyName)
        {
            if (propertyName == null || CustomControl.CheckBox.IsCheckedProperty.PropertyName == propertyName)
            {
                checkBox.Checked = model.IsChecked;
            }

            if (propertyName == null || CustomControl.CheckBox.ColorProperty.PropertyName == propertyName)
            {
                int[][] states = {
                    new int[] { Android.Resource.Attribute.StateEnabled}, // enabled  
                    new int[] {Android.Resource.Attribute.StateEnabled}, // disabled  
                    new int[] {Android.Resource.Attribute.StateChecked}, // unchecked  
                    new int[] { Android.Resource.Attribute.StatePressed}  // pressed  
                };
                var checkBoxColor = (int)model.Color.ToAndroid();
                int[] colors = {
                    checkBoxColor,
                    checkBoxColor,
                    checkBoxColor,
                    checkBoxColor
                };
                var myList = new Android.Content.Res.ColorStateList(states, colors);
                checkBox.ButtonTintList = myList;

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (checkBox != null)
            {
                base.OnElementPropertyChanged(sender, e);

                CheckboxPropertyChanged((CustomControl.CheckBox)sender, e.PropertyName);
            }
        }

        public class ClickListener : Java.Lang.Object, IOnClickListener
        {
            private CustomControl.CheckBox _myCheckbox;
            public ClickListener(CustomControl.CheckBox myCheckbox)
            {
                this._myCheckbox = myCheckbox;
            }
            public void OnClick(global::Android.Views.View v)
            {
                _myCheckbox.IsChecked = !_myCheckbox.IsChecked;
            }
        }
    }
}