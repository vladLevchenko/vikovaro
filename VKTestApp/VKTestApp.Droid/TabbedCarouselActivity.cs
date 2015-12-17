﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;


namespace VKTestApp.Droid
{
	[Activity (Label = "TabbedCarouselActivity")]			
	public class TabbedCarouselActivity : FragmentActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.TabbedCarouselView);

			// Create your application here
		}
	}
}

