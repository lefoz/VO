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
    public class Accounting_Fragment : Android.Support.V4.App.Fragment
    {
        private List<Accounting> mAccountingList;
        private ListView mAccountingListView;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            mAccountingList = new List<Accounting>();
            mAccountingList.Add(new Accounting() {name = "Regnskab 2016", date = "01-01-20017", });
            mAccountingList.Add(new Accounting() { name = "Regnskab 2015", date = "01-01-20016" });


        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Default_layout, container, false);

            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            //Event listView start----
            mAccountingListView = view.FindViewById<ListView>(Resource.Id.defaultListView);

            AccountingViewAdapter accountingAdapter = new AccountingViewAdapter(this.Activity, mAccountingList);
            mAccountingListView.Adapter = accountingAdapter;
            mAccountingListView.ItemClick += AccountListView_ItemClick;

            //EventListView End---
        }

        private void AccountListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Show Dialog
            //Android.Support.V4.App.FragmentTransaction transaction = FragmentManager.BeginTransaction();
            //Dialog_Event dialog_event = new Dialog_Event();
            //dialog_event.Show(transaction, "Accounting");
            Console.WriteLine(mAccountingList[e.Position].name);
        }
    }
}
