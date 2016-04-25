
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
using Android.Support.V4.Widget;
using Android.Support.V7.App;

namespace DesignLayout
{

	[Activity (Label = "SwipeRefreshActivity", Theme = "@style/Base.Theme.DesignDemo")]			
	public class SwipeRefreshActivity : AppCompatActivity
	{
		//http://blog.csdn.net/lmj623565791/article/details/24521483
		private SwipeRefreshLayout swipeRefreshLayout;

		Handler handler = new Handler ();

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.activity_swipe_refresh);

//			SupportFragmentManager.BeginTransaction ()
//				.Add (Resource.Id.fragment_content, new ContentFragment ())
//				.Commit ();


			var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.toolbar);
			SetSupportActionBar (toolbar);

			swipeRefreshLayout = FindViewById<SwipeRefreshLayout> (Resource.Id.swipeRefreshLayout);

//			swipeRefreshLayout.SetColorSchemeColors (new int[] {
//				Android.Resource.Color.HoloBlueLight, Android.Resource.Color.HoloGreenLight,
//				Android.Resource.Color.HoloOrangeLight, Android.Resource.Color.HoloRedLight
//			});
			swipeRefreshLayout.Refresh += (object sender, EventArgs e) => {
				handler.PostDelayed (() => {
					swipeRefreshLayout.Refreshing = false;
				}, 2000);
			};
			
		}
	}
}

