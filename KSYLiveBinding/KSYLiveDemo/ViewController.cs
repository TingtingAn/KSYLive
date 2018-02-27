using System;
using System.Collections.Generic;
using Foundation;
using KSYLive;
using UIKit;

namespace KSYLiveDemo
{
    public partial class ViewController : UIViewController
    {
        public double KScreenWidth = UIScreen.MainScreen.Bounds.Width;
        public double KScreenHeight = UIScreen.MainScreen.Bounds.Height;

        public KSYStreamerBase streamBase;
        private UIButton _beginLive;

        public ViewController()
        {
            this.View.BackgroundColor = UIColor.White;
            _beginLive = new UIButton(UIButtonType.Custom);
            _beginLive.Frame = new CoreGraphics.CGRect((KScreenWidth - 200) / 2.0, KScreenHeight - 200, 200, 40);
            _beginLive.SetTitle("Begin", UIControlState.Normal);
            _beginLive.BackgroundColor = UIColor.Blue;
            _beginLive.Layer.CornerRadius = 10;
            _beginLive.TouchUpInside += (sender, e) =>
            {
                LiveViewController live = new LiveViewController();
                live.Title = "Live Back";
                this.NavigationController.PushViewController(live,true);
            };
            this.View.AddSubview(_beginLive);
        }

        protected ViewController(IntPtr handle) : base(handle)
        {
            

            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
