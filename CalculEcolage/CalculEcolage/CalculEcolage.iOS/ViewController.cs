using System;
using Xuni.iOS.FlexChart;
using UIKit;
using Foundation;
using System.IO;

namespace FlexChartShare
{/*
    public partial class ViewController : UIViewController
    {
        void ShareEventHandler(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Fees20.db3");
            string title = "Tuitions";

            NSObject[] activityItems = { FromObject(title), NSUrl.FromFilename(filePath) };
            UIActivityViewController activityViewController = new UIActivityViewController(activityItems, null);
            activityViewController.ExcludedActivityTypes = new NSString[] { };
            if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                activityViewController.PopoverPresentationController.SourceView = View;
                activityViewController.PopoverPresentationController.SourceRect = new CoreGraphics.CGRect((View.Bounds.Width / 2), (View.Bounds.Height / 4), 0, 0);
            }
            this.PresentViewController(activityViewController, true, null);
        }

        public FlexChart chart;
        public UIBarButtonItem shareButton;
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            chart = new FlexChart();
            this.Title = "Export Image";
            this.EdgesForExtendedLayout = UIRectEdge.None;

            shareButton = new UIBarButtonItem(UIBarButtonSystemItem.Action, ShareEventHandler);
            this.NavigationItem.RightBarButtonItem = shareButton;
            this.chart.BindingX = "Name";
            this.chart.Series.Add(new Series(this.chart, "Sales, Sales", "Sales"));
            this.chart.Series.Add(new Series(this.chart, "Expenses, Expenses", "Expenses"));
            this.chart.Series.Add(new Series(this.chart, "Downloads, Downloads", "Downloads"));
            View.AddSubview(chart);
        }
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            chart.Frame = new CoreGraphics.CGRect(5, 5, View.Bounds.Width - 10, View.Bounds.Height - 10);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }*/
}