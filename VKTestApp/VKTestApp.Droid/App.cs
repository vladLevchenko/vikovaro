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

using Bootstrapper;


namespace VKTestApp.Droid
{
    [Application(Label ="@string/app_name")]
    public class App: Application
    {
        public App(IntPtr h, JniHandleOwnership jho) : base(h, jho)
        {
        }

        public override void OnCreate()
        {
            VKDroidBootstrapper.RegisterTypes();
            base.OnCreate();            
        }        
    }
}