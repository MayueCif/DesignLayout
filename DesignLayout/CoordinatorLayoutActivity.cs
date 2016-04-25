
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
using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace DesignLayout
{
	[Activity (Label = "CoordinatorLayoutActivity", Theme = "@style/Base.Theme.DesignDemo")]			
	public class CoordinatorLayoutActivity : AppCompatActivity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.activity_coordinatorlayout);

			var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.toolbar);
			SetSupportActionBar (toolbar);
			// Create your application here

			var recyclerView = FindViewById<RecyclerView> (Resource.Id.recyclerView);
			recyclerView.SetAdapter (new CustomAdapter ());
			recyclerView.SetLayoutManager (new LinearLayoutManager (this));

		}
	}
}

