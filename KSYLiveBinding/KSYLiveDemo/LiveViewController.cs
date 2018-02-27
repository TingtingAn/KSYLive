using System;
using KSYLive;
using UIKit;
using AVFoundation;
using CoreVideo;
using CoreGraphics;
using Foundation;

namespace KSYLiveDemo
{
    public partial class LiveViewController : UIViewController
    {
        KSYGPUStreamerKit kit;
        UIView bigView;

        UIButton captureBtn;
        UIButton streamBtn;

        public double KScreenWidth = UIScreen.MainScreen.Bounds.Width;
        public double KScreenHeight = UIScreen.MainScreen.Bounds.Height;

        public LiveViewController() : base("LiveViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            kit = new KSYGPUStreamerKit();
            kit.CameraPosition = AVCaptureDevicePosition.Front;
            kit.GpuOutputPixelFormat = (uint)CVPixelFormatType.CV32BGRA;
            kit.CapturePixelFormat = (uint)CVPixelFormatType.CV32BGRA;
            SetUpUI();
            this.View.BackgroundColor = UIColor.Black;
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

        }

        private void SetUpUI()
        {
            bigView = new UIView();
            bigView.Frame = CalcPreviewRect(16.0f / 9.0f);
            this.View.AddSubview(bigView);

            captureBtn = new UIButton(UIButtonType.RoundedRect);
            captureBtn.Frame = new CGRect(20, 20, 40, 40);
            captureBtn.SetTitle("Preview", UIControlState.Normal);
            captureBtn.TouchUpInside += OnCapture;
            captureBtn.BackgroundColor = UIColor.LightGray;
            captureBtn.Alpha = 0.9f;
            captureBtn.Layer.CornerRadius = 10;
            captureBtn.ClipsToBounds = true;
            this.View.AddSubview(captureBtn);

            streamBtn = new UIButton(UIButtonType.RoundedRect);
            streamBtn.Frame = new CGRect(KScreenWidth - 20, 20, 40, 40);
            streamBtn.SetTitle("start", UIControlState.Normal);
            streamBtn.BackgroundColor = UIColor.LightGray;
            streamBtn.TouchUpInside += OnStream;
            streamBtn.Alpha = 0.9f;
            streamBtn.Layer.CornerRadius = 10;
            streamBtn.ClipsToBounds = true;
            this.View.AddSubview(streamBtn);
        }

        private CoreGraphics.CGRect CalcPreviewRect(nfloat ratio)
        {
            CGRect previewRect = this.View.Frame;
            CGSize size = previewRect.Size;
            CGSize screenSize = UIScreen.MainScreen.Bounds.Size;

            if(size.Width < size.Height){
                previewRect.Height = size.Width * ratio;
                previewRect.Y += (size.Height - previewRect.Height) / 2;
            }
            else{
                previewRect.Width = size.Height * ratio;
                previewRect.X += (size.Width - previewRect.Width) / 2;
            }

            return previewRect;
        }

        private void OnCapture(object sender, EventArgs args)
        {
            if(!kit.VCapDev.IsRunning)
            {
                kit.VideoOrientation = UIApplication.SharedApplication.StatusBarOrientation;
                kit.StartPreview(bigView);
            }
            else{
                kit.StopPreview();
            }
        }

        private void OnStream(object sender, EventArgs args)
        {
            if (kit.StreamerBase.StreamState == KSYStreamState.Idle || kit.StreamerBase.StreamState == KSYStreamState.Error)
            {
                kit.StreamerBase.StartStream(new Foundation.NSUrl(""));
            }
            else
            {
                kit.StreamerBase.StopStream();
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

}

