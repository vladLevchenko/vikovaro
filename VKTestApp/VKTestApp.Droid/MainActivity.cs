using System;

using Android.App;
using Android.Widget;
using Android.OS;
using Xamarin.Auth;
using System.Threading.Tasks;
using Infra.Interfaces;
using Cirrious.CrossCore;
using Android.Content;
using Android.Runtime;

namespace VKTestApp.Droid
{
	[Activity (Label = "VKTestApp.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        private ISocialModule _socialModule;
		private IAppUserModule _userModule;
        private IAuthModule _authModule;
        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            _socialModule = Mvx.Resolve<ISocialModule>();
			_userModule = Mvx.Resolve<IAppUserModule> ();
			_authModule = new VKDroidAuthModule (_userModule, _socialModule, this);// Mvx.Resolve<IAuthModule>();
            
			
			SetContentView (Resource.Layout.Main);


			Button button = FindViewById<Button> (Resource.Id.myButton);
            var loadGroupsBtn = FindViewById<Button>(Resource.Id.loadGroupsBtn);
			
			button.Click += delegate {
                _authModule.Authenticate();               
            };

            loadGroupsBtn.Click += delegate
            {
                var intent = new Intent(this, typeof(GroupViewActivity));
                StartActivityForResult(intent,0);
                
                
            };

            
		}

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {

            base.OnActivityResult(requestCode, resultCode, data);

        }





    }
}


