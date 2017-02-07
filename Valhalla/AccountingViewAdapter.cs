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

namespace Valhalla
{
    class AccountingViewAdapter : BaseAdapter<Accounting>
    {
        private List<Accounting> AccountingyItems;
        private Context AccountingContext;

        public AccountingViewAdapter(Context context, List<Accounting> items)
        {
            AccountingyItems = items;
            AccountingContext = context;
        }

        public override int Count
        {
            get
            {
                return AccountingyItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Accounting this[int position]
        {
            get { return AccountingyItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(AccountingContext).Inflate(Resource.Layout.DefaultView_row, null, false);
            }
            TextView contentId = row.FindViewById<TextView>(Resource.Id.contentId);
            contentId.Text = AccountingyItems[position].name;

            TextView contentDate = row.FindViewById<TextView>(Resource.Id.contentDate);
            contentDate.Text = AccountingyItems[position].date;


            return row;
        }
    }
}