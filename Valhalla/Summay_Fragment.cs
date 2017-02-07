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

namespace Valhalla
{
    public class Summay_Fragment : Android.Support.V4.App.Fragment
    {
        private List<Summary> mSummaryList;
        private ListView mSummaryListView;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            mSummaryList = new List<Summary>();
            mSummaryList.Add(new Summary() { name = "Regnskab 2016", date = "01-01-20017", content = "AAAAAAAAAAAaaaaaaaaa" });
            mSummaryList.Add(new Summary() { name = "Regnskab 2015", date = "01-01-20016", content = "BBBBBBBBBBBBBBaaaaaaaaaa" });


        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Default_layout, container, false);

            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            //Event listView start----
            mSummaryListView = view.FindViewById<ListView>(Resource.Id.defaultListView);

            SummaryViewAdapter summaryAdapter = new SummaryViewAdapter(this.Activity, mSummaryList);
            mSummaryListView.Adapter = summaryAdapter;
            mSummaryListView.ItemClick += mSummaryListView_ItemClick;

            //EventListView End---
        }

        private void mSummaryListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Show Dialog
            //Android.Support.V4.App.FragmentTransaction transaction = FragmentManager.BeginTransaction();
            //Dialog_Event dialog_event = new Dialog_Event();
            //dialog_event.Show(transaction, "Accounting");
            Console.WriteLine(mSummaryList[e.Position].name +" click");
        }
    }
}