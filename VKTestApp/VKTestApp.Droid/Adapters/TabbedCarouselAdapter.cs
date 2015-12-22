using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V4.View;
using Android.Support.V4.App;

using VKTestApp.Droid.Fragments;




namespace VKTestApp.Droid
{
	public class TabbedCarouselAdapter: FragmentPagerAdapter
	{
		private List<Android.Support.V4.App.Fragment> _fragmentList = new List<Android.Support.V4.App.Fragment>();


		public TabbedCarouselAdapter (Android.Support.V4.App.FragmentManager fm)
			:base(fm)
		{
			
		}

		#region implemented abstract members of PagerAdapter

		public override int Count {
			get {
				return _fragmentList.Count;
			}
		}

		#endregion

		#region implemented abstract members of FragmentPagerAdapter

		public override Android.Support.V4.App.Fragment GetItem (int position)
		{
			return _fragmentList [position];
		}

		#endregion

		public void AddFragment(TabViewFragment fragment)
		{
			_fragmentList.Add(fragment);
		}

		public void AddFragmentView(Func<LayoutInflater, ViewGroup, Bundle, View> view)
		{
			_fragmentList.Add(new TabViewFragment(view));
		}
	}

	public class ViewPageListenerForActionBar : ViewPager.SimpleOnPageChangeListener
	{
		private ActionBar _bar;
		public ViewPageListenerForActionBar(ActionBar bar)
		{
			_bar = bar;
		}
		public override void OnPageSelected(int position)
		{
			_bar.SetSelectedNavigationItem(position);
		}
	}

	public static class ViewPagerExtensions
	{
		public static ActionBar.Tab GetViewPageTab(this ViewPager viewPager, ActionBar actionBar, string name)
		{
			var tab = actionBar.NewTab();
			tab.SetText(name);
			tab.TabSelected += (o, e) =>
			{
				viewPager.SetCurrentItem(actionBar.SelectedNavigationIndex, false);
			};
			return tab;
		}
	}

}

