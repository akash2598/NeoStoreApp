using System;
using System.Drawing;
using NeoStoreApp;
using NeoStoreApp.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer))]
namespace NeoStoreApp.iOS
{
	public class ImageEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || e.NewElement == null)
				return;

			Control.BackgroundColor = UIColor.FromRGB(233, 29, 26);

			Control.Layer.BorderColor = UIColor.White.CGColor;
			Control.Layer.BorderWidth = 2;
			Control.Layer.CornerRadius = 5;
			



			var element = (ImageEntry)this.Element;
			
			var textField = this.Control;
		
	

			textField.LeftViewMode = UITextFieldViewMode.Always;
			textField.LeftView = GetImageView(element.Image, element.ImageHeight, element.ImageWidth);
			
			

			/*	if (!string.IsNullOrEmpty(element.Image))
				{
					switch (element.ImageAlignment)
					{
						case ImageAlignment.Left:
							textField.LeftViewMode = UITextFieldViewMode.Always;
							textField.LeftView = GetImageView(element.Image, element.ImageHeight, element.ImageWidth);
							break;
						case ImageAlignment.Right:
							textField.RightViewMode = UITextFieldViewMode.Always;
							textField.RightView = GetImageView(element.Image, element.ImageHeight, element.ImageWidth);
							break;
					}
				}
			*/
			textField.BorderStyle = UITextBorderStyle.None;




			textField.Layer.MasksToBounds = true;
			
		}

		private UIView GetImageView(string imagePath, int height, int width)
		{
			var uiImageView = new UIImageView(UIImage.FromBundle(imagePath))
			{
				Frame = new RectangleF(0, 0, width * 5, height * 5),


			};
			UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, width * 5, height * 5));

			objLeftView.AddSubview(uiImageView);
			
		


			return objLeftView;
		}

	}
}
