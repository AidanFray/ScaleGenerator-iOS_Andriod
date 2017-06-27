// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ScalesApp
{
    [Register ("scalePage")]
    partial class scalePage
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ExpandButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel modeText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel modeTextRotated { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ScalePhoto { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ScalePhotoRotated { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel scaleText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel scaleTextRotated { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView scaleView { get; set; }

        [Action ("ExpandButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ExpandButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ExpandButton != null) {
                ExpandButton.Dispose ();
                ExpandButton = null;
            }

            if (modeText != null) {
                modeText.Dispose ();
                modeText = null;
            }

            if (modeTextRotated != null) {
                modeTextRotated.Dispose ();
                modeTextRotated = null;
            }

            if (ScalePhoto != null) {
                ScalePhoto.Dispose ();
                ScalePhoto = null;
            }

            if (ScalePhotoRotated != null) {
                ScalePhotoRotated.Dispose ();
                ScalePhotoRotated = null;
            }

            if (scaleText != null) {
                scaleText.Dispose ();
                scaleText = null;
            }

            if (scaleTextRotated != null) {
                scaleTextRotated.Dispose ();
                scaleTextRotated = null;
            }

            if (scaleView != null) {
                scaleView.Dispose ();
                scaleView = null;
            }
        }
    }
}