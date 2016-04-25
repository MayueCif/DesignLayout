
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
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Util;

namespace DesignLayout
{
	[Activity (Label = "CoordinatoBehaviorActivity", Theme = "@style/Base.Theme.DesignDemo")]			
	public class CoordinatoBehaviorActivity : AppCompatActivity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.activity_coordinatorbehavior);
			;

			var depentent = (TextView)FindViewById (Resource.Id.depentent);
			depentent.Click += (object sender, EventArgs e) => {
				ViewCompat.OffsetTopAndBottom (depentent, 5);
			};
			//使用代码关联Behavior
//			var child = (TextView)FindViewById (Resource.Id.child);
//			CoordinatorLayout.LayoutParams _params =
//				(CoordinatorLayout.LayoutParams)child.LayoutParameters;
//			_params.Behavior = new CustomBehavior ();
		}
	}


	[Register ("com.myue.designlayout.CustomBehavior")]
	public class CustomBehavior:CoordinatorLayout.Behavior
	{

		//实现构造函数 并进行注册 否则报 Could not inflate Behavior subclass 错误
		public CustomBehavior (Context context, IAttributeSet attrs) : base (context, attrs)
		{
		}

		public override bool OnDependentViewChanged (CoordinatorLayout parent, Java.Lang.Object child, View dependency)
		{
			var view = child.JavaCast<TextView> ();
			int offset = dependency.Top - view.Top;

			ViewCompat.OffsetTopAndBottom (view, offset);
			return true;
		}

		public override bool LayoutDependsOn (CoordinatorLayout parent, Java.Lang.Object child, View dependency)
		{
			return child is TextView;
		}

		#region 滑动相关

		public override bool OnStartNestedScroll (CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View directTargetChild, View target, int nestedScrollAxes)
		{
			return base.OnStartNestedScroll (coordinatorLayout, child, directTargetChild, target, nestedScrollAxes);
		}

		public override void OnNestedPreScroll (CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, int dx, int dy, int[] consumed)
		{
			base.OnNestedPreScroll (coordinatorLayout, child, target, dx, dy, consumed);
		}

		public override bool OnNestedFling (CoordinatorLayout coordinatorLayout, Java.Lang.Object child, View target, float velocityX, float velocityY, bool consumed)
		{
			return base.OnNestedFling (coordinatorLayout, child, target, velocityX, velocityY, consumed);
		}

		#endregion
	}
}

