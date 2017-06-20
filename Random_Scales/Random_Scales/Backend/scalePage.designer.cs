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

namespace App2
{
    [Register ("scalePage")]
    partial class scalePage
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel scaleText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView scaleView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (scaleText != null) {
                scaleText.Dispose ();
                scaleText = null;
            }

            if (scaleView != null) {
                scaleView.Dispose ();
                scaleView = null;
            }
        }
    }
}