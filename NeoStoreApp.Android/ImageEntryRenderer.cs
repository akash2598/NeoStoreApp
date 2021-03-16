

using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using NeoStoreApp;
using NeoStoreApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer))]
namespace NeoStoreApp.Droid
{
    public class ImageEntryRenderer : EntryRenderer
    {
        ImageEntry element;
        public ImageEntryRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

              GradientDrawable gd = new GradientDrawable();
                gd.SetColor(Android.Graphics.Color.Rgb(233, 29, 26));
                gd.SetCornerRadius(10);
                gd.SetStroke(5, global::Android.Graphics.Color.White);
                Control.SetBackground(gd); 
          

            element = (ImageEntry)this.Element; 



            var editText = this.Control;
            editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, null, null);

          
            editText.CompoundDrawablePadding = 20;

        }

        private BitmapDrawable GetDrawable(string imageEntryImage)
        {
            int resID = Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth * 6, element.ImageHeight * 5, true));
        }

    }
}
