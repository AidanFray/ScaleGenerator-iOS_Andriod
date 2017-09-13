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
    [Register ("KeyTabPage")]
    partial class KeyTabPage
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton test { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (test != null) {
                test.Dispose ();
                test = null;
            }
        }
    }
}