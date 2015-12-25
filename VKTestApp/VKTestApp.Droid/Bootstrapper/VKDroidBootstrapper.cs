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

using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Infra.Data;
using Infra.Interfaces;
using VKTestApp.VK;
using VKTestApp.Droid;

namespace Bootstrapper
{
    public static class VKDroidBootstrapper
    {
        public static void RegisterTypes()
        {
            MvxSimpleIoCContainer.Initialize();
			Mvx.RegisterSingleton<IAppUserModule> (new VKUserModule ());
			Mvx.RegisterType<ISocialModule, VKSocialModule> ();
            Mvx.RegisterType<NetworkUser, VKUser>();
            Mvx.RegisterType<InfoPoint, VKPage>();
			Mvx.RegisterType<IAuthModule, VKDroidAuthModule>();
            
        }
    }
}