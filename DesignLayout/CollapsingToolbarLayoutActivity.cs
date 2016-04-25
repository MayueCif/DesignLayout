
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
using Android.Support.Design.Widget;
using Android.Graphics;
using Android.Support.V7.Widget;

namespace DesignLayout
{
	[Activity (Label = "CollapsingToolbarLayoutActivity", Theme = "@style/Base.Theme.DesignDemo")]			
	public class CollapsingToolbarLayoutActivity : AppCompatActivity
	{
		//http://blog.csdn.net/u010687392/article/details/46906657
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.activity_collapsingtoolbarlayout);
			// Create your application here
			var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.toolbar);
			SetSupportActionBar (toolbar);

			//使用CollapsingToolbarLayout必须把title设置到CollapsingToolbarLayout上，设置到Toolbar上则不会显示  
			CollapsingToolbarLayout collapsingToolbarLayout = (CollapsingToolbarLayout)FindViewById (Resource.Id.collapsing_toolbar_layout);  
			collapsingToolbarLayout.Title = "CollapsingTL";  
			//通过CollapsingToolbarLayout修改字体颜色  
			//collapsingToolbarLayout.SetExpandedTitleColor();//设置还没收缩时状态下字体颜色  
			//collapsingToolbarLayout.SetCollapsedTitleTextColor();//设置收缩后Toolbar上字体的颜色  

			var recyclerView = FindViewById<RecyclerView> (Resource.Id.recyclerView);
			recyclerView.SetAdapter (new CustomAdapter ());
			recyclerView.SetLayoutManager (new LinearLayoutManager (this));
		}
	}
}

