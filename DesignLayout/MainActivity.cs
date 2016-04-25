using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Support.V4.View;
using Java.Interop;

namespace DesignLayout
{
	[Activity (Label = "DesignLayout", MainLauncher = true, Icon = "@mipmap/icon", Theme = "@style/Base.Theme.DesignDemo")]
	public class MainActivity : AppCompatActivity
	{

		private DrawerLayout drawerLayout;
		private NavigationView navigationView;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar> (Resource.Id.toolbar);
			toolbar.SetNavigationIcon (Resource.Drawable.ic_menu);
			SetSupportActionBar (toolbar);


			drawerLayout = FindViewById<DrawerLayout> (Resource.Id.drawer_layout);
			navigationView = FindViewById<NavigationView> (Resource.Id.nv_menu);
			navigationView.NavigationItemSelected += (object sender, NavigationView.NavigationItemSelectedEventArgs e) => {
				switch (e.MenuItem.ItemId) {
				case Resource.Id.nav_home:
					StartActivity (typeof(SwipeRefreshActivity));
					break;
				case Resource.Id.nav_friends:
					StartActivity (typeof(CollapsingToolbarLayoutActivity));
					break;
				case Resource.Id.coordinator_layout:
					StartActivity (typeof(CoordinatorLayoutActivity));
					break;
				case Resource.Id.coordinator_behavior:
					StartActivity (typeof(CoordinatoBehaviorActivity));
					break;
				default:
					break;
				}
			
				drawerLayout.CloseDrawers ();
			};

		}

		[Export ("floatingclick")]
		public void FloatingClick (View view)
		{
			System.Console.WriteLine ("FloatingClick");
			Snackbar.Make (view, "Snackbar 测试用例！", Snackbar.LengthLong).SetAction ("点击", (v) => {
				Toast.MakeText (this, "别瞎点！", ToastLength.Short).Show ();
			}).Show ();
		}


		public override bool OnCreateOptionsMenu (Android.Views.IMenu menu)
		{
			MenuInflater.Inflate (Resource.Menu.main_menu, menu);
			return true;
		}

		public override bool OnOptionsItemSelected (Android.Views.IMenuItem item)
		{
			switch (item.ItemId) {
			case Android.Resource.Id.Home:
				drawerLayout.OpenDrawer ((int)GravityCompat.Start);
				break;
			default:
				break;
			}
			return base.OnOptionsItemSelected (item);
		}
	}
}


