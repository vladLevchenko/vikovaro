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
using Infra.Interfaces;
using Infra.Data;
using Cirrious.CrossCore;
using Cirrious.MvvmCross;
using Android.Graphics;

namespace VKTestApp.Droid
{
    [Activity(Label = "GroupView")]
    public class GroupViewActivity : Activity
    {
		IAppUserModule _userModule;
        ISocialModule _socialModule;
        List<InfoPoint> _userInfoPoints;
        List<InfoPoint> _selectedInfoPoints;
        int count = 0;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GroupsView);
            _socialModule = Mvx.Resolve<ISocialModule>();
			_userModule = Mvx.Resolve<IAppUserModule> ();
			_userInfoPoints = _socialModule.GetUserInfoPoints(_userModule.User);
            _selectedInfoPoints = new List<InfoPoint>();
            // Create your application here
            var listView = FindViewById<ListView>(Resource.Id.List);
            listView.Adapter = new Adapters.VKGroupViewAdapter(_userInfoPoints, this);
            listView.ItemClick += OnListItemClick;
            
        }

        void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = (ListView)sender;
            var item = _userInfoPoints[e.Position];
            if(!e.View.Selected && count<5)
            {
                e.View.Selected = true;
                count++;
            }
            else
            {
                e.View.Selected = false;
                count--;
            }

        }
    }
}