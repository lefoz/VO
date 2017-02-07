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
    class MemberViewAdapter : BaseAdapter<Member>
    {
        private List<Member> memberItems;
        private Context memberContext;

        public MemberViewAdapter(Context context, List<Member> items)
        {
            memberItems = items;
            memberContext = context;
        }

        public override int Count
        {
            get
            {
                return memberItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Member this[int position]
        {
            get { return memberItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(memberContext).Inflate(Resource.Layout.MemberView_row, parent, false);
            }
            TextView name = row.FindViewById<TextView>(Resource.Id.name);
            name.Text = memberItems[position].name;

            TextView phone = row.FindViewById<TextView>(Resource.Id.phone);
            phone.Text = memberItems[position].phone;

            TextView email = row.FindViewById<TextView>(Resource.Id.email);
            email.Text = memberItems[position].email;

            return row;
        }

    }
   
}