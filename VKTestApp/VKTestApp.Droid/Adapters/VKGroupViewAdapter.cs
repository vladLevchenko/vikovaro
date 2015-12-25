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
using Infra.Data;
using Android.Graphics.Drawables;
using Java.Net;
using Android.Graphics;
using System.Net;

namespace VKTestApp.Droid.Adapters
{
    public class VKGroupViewAdapter : BaseAdapter<InfoPoint>
    {
        private List<InfoPoint> _items;
        private Activity _context;
        
        public VKGroupViewAdapter(List<InfoPoint> items, Activity context)
        {
            _items = items;
            _context = context;
        }
        public override InfoPoint this[int position]
        {
            get
            {
                return _items[position];
            }
        }

        public override int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];
            var view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.GroupRowLayout, null);
            view.FindViewById<TextView>(Resource.Id.GroupName).Text = item.Name;
            
            view.FindViewById<ImageView>(Resource.Id.GroupIcon).SetImageBitmap(GetImageBitmapFromUrl(item.ImageLink));

            return view;
        }

        

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }        
    }
}