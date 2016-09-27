using System;

using UIKit;

namespace FollowtheWord
{
	public partial class ViewController : UIViewController
	{
		private int currentScore = 0;
		private string currentDirection = "";
		private bool startOver = false;

		private string[] _directions = new string[] {
			"UP",
			"DOWN",
			"LEFT",
			"RIGHT"
		};

		private string[] _arrows = new string[] {
			"orange-down-arrow.png",
			"orange-left-arrow.png",
			"orange-right-arrow.png",
			"orange-up-arrow.png"
		};

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			this.swipeText.Text = currentDirection = GetRandomDirection ();
			this.arrowImage.Image = new UIImage (GetRandomArrowImage ());

			UISwipeGestureRecognizer rightSwipeRecognizer = new UISwipeGestureRecognizer (OnSwipeRightDetected);
			rightSwipeRecognizer.Direction = UISwipeGestureRecognizerDirection.Right;
			View.AddGestureRecognizer (rightSwipeRecognizer);

			UISwipeGestureRecognizer leftSwipeRecognizer = new UISwipeGestureRecognizer (OnSwipeLeftDetected);
			leftSwipeRecognizer.Direction = UISwipeGestureRecognizerDirection.Left;
			View.AddGestureRecognizer (leftSwipeRecognizer);

			UISwipeGestureRecognizer upSwipeRecognizer = new UISwipeGestureRecognizer (OnSwipeUpDetected);
			upSwipeRecognizer.Direction = UISwipeGestureRecognizerDirection.Up;
			View.AddGestureRecognizer (upSwipeRecognizer);

			UISwipeGestureRecognizer downSwipeRecognizer = new UISwipeGestureRecognizer (OnSwipeDownDetected);
			downSwipeRecognizer.Direction = UISwipeGestureRecognizerDirection.Down;
			View.AddGestureRecognizer (downSwipeRecognizer);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			if (this.startOver) {
				Console.WriteLine ("*************** STARTING OVER ***************");
			}
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			if (segue.DestinationViewController is GameOverViewController) {
				var a = (GameOverViewController)segue.DestinationViewController;
				a.SetCallingViewController (this);
				a.CurrentScore = currentScore;
			}
		}

		public void ResetGameStatus()
		{
			this.currentScore = 0;
			ChangeImageAndText ();
		}

		private void OnSwipeRightDetected()
		{
			CheckDirectionAndVerify ("right");
		}

		private void OnSwipeLeftDetected()
		{
			CheckDirectionAndVerify ("left");
		}

		private void OnSwipeUpDetected()
		{
			CheckDirectionAndVerify ("up");
		}

		private void OnSwipeDownDetected()
		{
			CheckDirectionAndVerify ("down");
		}

		private void CheckDirectionAndVerify(string direction)
		{
			if (currentDirection.Equals (direction, StringComparison.InvariantCultureIgnoreCase)) {
				Console.WriteLine ("Plus one score");
				currentScore++;
				ChangeImageAndText ();
			} else {
				this.PerformSegue ("gameOverSegue", null);
				Console.WriteLine ("*************** GAME FUCKEN OVER ***************");
			}
		}

		private void ChangeImageAndText()
		{
			this.swipeText.Text = currentDirection = GetRandomDirection ();
			this.arrowImage.Image = new UIImage (GetRandomArrowImage ());
		}

		private string GetRandomArrowImage()
		{
			Random r = new Random ();
			int randomIndex = r.Next (0, _arrows.Length);

			return _arrows [randomIndex];
		}

		private string GetRandomDirection()
		{
			Random r = new Random ();
			int randomIndex = r.Next (0, _directions.Length);

			return _directions [randomIndex];
		}
	}
}

