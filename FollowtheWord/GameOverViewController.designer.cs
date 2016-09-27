// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace FollowtheWord
{
	[Register ("GameOverViewController")]
	partial class GameOverViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel highestScoreLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel scoreLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton startOverBtn { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (highestScoreLabel != null) {
				highestScoreLabel.Dispose ();
				highestScoreLabel = null;
			}
			if (scoreLabel != null) {
				scoreLabel.Dispose ();
				scoreLabel = null;
			}
			if (startOverBtn != null) {
				startOverBtn.Dispose ();
				startOverBtn = null;
			}
		}
	}
}
