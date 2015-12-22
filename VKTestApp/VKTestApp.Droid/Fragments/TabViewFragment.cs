﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V4.View;

namespace VKTestApp.Droid.Fragments
{
	public class TabViewFragment : Android.Support.V4.App.Fragment
	{
		private Func<LayoutInflater, ViewGroup, Bundle, View> _view;

		public TabViewFragment(Func<LayoutInflater, ViewGroup, Bundle, View> view)
		{
			_view = view;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);
			return _view(inflater, container, savedInstanceState);
		}
	}
}