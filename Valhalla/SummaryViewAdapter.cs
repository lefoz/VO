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
    class SummaryViewAdapter : BaseAdapter<Summary>
    {
        private List<Summary> SummaryItems;
        private Context SummaryContext;

        public SummaryViewAdapter(Context context, List<Summary> items)
        {
            SummaryItems = items;
            SummaryContext = context;
        }

        public override int Count
        {
            get
            {
                return SummaryItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Summary this[int position]
        {
            get { return SummaryItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(SummaryContext).Inflate(Resource.Layout.DefaultView_row, null, false);
            }
            TextView contentId = row.FindViewById<TextView>(Resource.Id.contentId);
            contentId.Text = SummaryItems[position].name;

            TextView contentDate = row.FindViewById<TextView>(Resource.Id.contentDate);
            contentDate.Text = SummaryItems[position].date;


            return row;
        }
    }
}