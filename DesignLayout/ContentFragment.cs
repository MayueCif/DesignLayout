
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Java.Interop;

namespace DesignLayout
{

	public class ContentFragment : Android.Support.V4.App.Fragment
	{
		public ContentFragment ()
		{
			
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{

			var view = inflater.Inflate (Resource.Layout.fragment_content, null);

			var recyclerView = view.FindViewById<RecyclerView> (Resource.Id.recyclerView);
			recyclerView.SetAdapter (new CustomAdapter ());
			recyclerView.SetLayoutManager (new LinearLayoutManager (Activity));

			return view;
		}
	}


	public class CustomViewHolder : RecyclerView.ViewHolder
	{
		public TextView Name { get; private set; }

		public CustomViewHolder (View itemView) : base (itemView)
		{
			// Locate and cache view references:
			Name = itemView.FindViewById<TextView> (Resource.Id.name);
		}
	}


	public class CustomAdapter : RecyclerView.Adapter
	{
		List<string> data = new List<string> {
			"C#", "Javascript", "C++", "Swift", "Json",  "HTML", "Golang",
			"C#", "Javascript", "C++", "Swift", "Json",  "HTML", "Golang",
			"C#", "Javascript", "C++", "Swift", "Json",  "HTML", "Golang"
		};

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{
			View itemView = LayoutInflater.From (parent.Context).
				Inflate (Resource.Layout.item_recycler_view, parent, false);
			CustomViewHolder vh = new CustomViewHolder (itemView);
			return vh;
		}

		public override void OnBindViewHolder (RecyclerView.ViewHolder holder, int position)
		{
			CustomViewHolder vh = holder as CustomViewHolder;
			vh.Name.Text = data [position];
		}

		public override int ItemCount {
			get { return data.Count; }
		}
	}
}

