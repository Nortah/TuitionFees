using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace CalculEcolage.Algorithms
{
    public class ToastIOS
    {
        const double LONG_DELAY = 1;


        NSTimer alertDelay;
        UIAlertController alert;

        public void ShowToast(string message)
        {
            ShowAlert(message, LONG_DELAY);
        }


        void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                dismissMessage();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }
        void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }

    }
}
