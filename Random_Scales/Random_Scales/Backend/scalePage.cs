using Foundation;
using System;
using UIKit;

namespace App2
{
    public partial class scalePage : UIViewController
    {
        public scalePage (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Allows touch interaction
            scaleText.UserInteractionEnabled = true;
            UITapGestureRecognizer tap = new UITapGestureRecognizer(ScaleChange);
            scaleView.AddGestureRecognizer(tap);

            //Randomises the label
            ScaleChange();
        }

        Random r = new Random();
        string[] scales = new string[] { "C", "D", "E", "F", "G", "A", "B", "D"};
        public void ScaleChange()
        {
            int newScale = r.Next(0, scales.Length);

            scaleText.Text = scales[newScale];
        }
    }
}