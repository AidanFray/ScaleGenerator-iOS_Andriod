using Android.App;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace Random_Scales_Andriod
{
    public static class Page
    {
        public static void Set_ActionBar(ActionBar bar)
        {
            ColorDrawable colorDrawable = new ColorDrawable(Color.ParseColor("#D86867"));
            bar.SetBackgroundDrawable(colorDrawable);
        }
    }
}