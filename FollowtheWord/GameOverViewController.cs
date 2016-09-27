using System;

using UIKit;

namespace FollowtheWord
{
	public partial class GameOverViewController : UIViewController
	{
		public int CurrentScore { get; set; }
		private ViewController CallingViewController;

		public GameOverViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			this.startOverBtn.TouchUpInside += HanldeStartOverBtnClick;
			this.scoreLabel.Text = string.Format ("Score : {0}", CurrentScore);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public void SetCallingViewController(ViewController vc) {
			CallingViewController = vc;
		}

		private void HanldeStartOverBtnClick(object sender, EventArgs e) {
			UIAlertController alert = UIAlertController.Create("Start Over", "You will start the game over", UIAlertControllerStyle.Alert);
			alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, (action) => {
				this.DismissViewController(true, () => {
					CallingViewController.ResetGameStatus();
				});
			}));

			this.PresentViewController (alert, true, null);
		}
	}
}


