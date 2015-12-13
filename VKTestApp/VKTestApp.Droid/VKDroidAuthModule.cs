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
using Xamarin.Auth;


namespace VKTestApp.Droid
{
    public class VKDroidAuthModule : IAuthModule
    {
        private ISocialModule _socialModule;

        public Context AppContext { get { return Application.Context; } }

        public void Authenticate(ISocialModule socialModule)
        {
            _socialModule = socialModule;
            if (!_socialModule.IsAuthenticated)
            {
                var acc = RetreiveCredentials();
                if (acc == null)
                    DisplayAuthDialog();
            }
        }

        public void DisplayAuthDialog()
        {
            var intent = GetAuthenticator(_socialModule).GetUI(AppContext);
            intent.SetFlags(ActivityFlags.NewTask);
            AppContext.StartActivity(intent);
        }

        private OAuth2Authenticator GetAuthenticator(ISocialModule socialModule)
        {
            var auth = new OAuth2Authenticator(
                clientId: "5172229",
                scope: "groups",
                authorizeUrl: new Uri(@"https://oauth.vk.com/authorize"),
                redirectUrl: new Uri(@"https://oauth.vk.com/blank.html"));
            auth.AllowCancel = true;
            auth.Completed += OnAuthCompleted;
            return auth;
        }

        public void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (!e.IsAuthenticated)
            {
                throw new Exception("User has not been authenticated");
            }
            else
            {
                //StoreCredentials(e);
                //ShowStoreDialog(e);
                _socialModule.SetCurrentUser(e.Account.Properties["user_id"], e.Account.Properties["access_token"].ToString());
            }
        }

        private void ShowStoreDialog(AuthenticatorCompletedEventArgs e)
        {
           
            //AlertDialog.Builder alert = new AlertDialog.Builder(AppContext);
            //alert.SetTitle("Do you want to remember your credentials?");
            //alert.SetPositiveButton("Yes", (o, args) => StoreCredentials(e));
            //alert.SetNegativeButton("No", (o, args) => { });
            //app.RunOnUiThread(() => { alert.Show(); });
        }

        private void StoreCredentials(AuthenticatorCompletedEventArgs e)
        {
            AccountStore.Create(AppContext.ApplicationContext).Save(e.Account,"vikovaro");
        }

        private Account RetreiveCredentials()
        {
            if(_socialModule.IsAuthenticated)
            {
                return null;
            }
            else
            {
                //var store = AccountStore.Create(MainActivity);
                //var accounts = store.FindAccountsForService("vicovaro");
                //return accounts.FirstOrDefault();     
                return null;        


            }

        }
    }
}