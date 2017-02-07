using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace Valhalla
{
    class EventViewAdapter  : BaseAdapter<Event>
    {
        private List<Event> eventItems;
        private Context eventContext;

        public EventViewAdapter(Context context, List<Event> items)
        {
            eventItems = items;
            eventContext = context;
        }

        public override int Count
        {
            get
            {
                return eventItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Event this[int position]
        {
            get { return eventItems[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(eventContext).Inflate(Resource.Layout.EventView_row, parent, false);
            }
            TextView eventType = row.FindViewById<TextView>(Resource.Id.eventType);
            eventType.Text = eventItems[position].eventType;

            TextView eventName = row.FindViewById<TextView>(Resource.Id.eventName);
            eventName.Text = eventItems[position].eventName;

            TextView eventDate = row.FindViewById<TextView>(Resource.Id.eventDate);
            eventDate.Text = eventItems[position].eventDate;

            switch (eventItems[position].eventId)
            {
                case 1:
                    row.SetBackgroundResource(Resource.Drawable.Generelforsamling);
                    break;
                case 2:
                    row.SetBackgroundResource(Resource.Drawable.april);
                    break;
                case 3:
                    row.SetBackgroundResource(Resource.Drawable.beerfest);
                    break;
                case 4:
                    row.SetBackgroundResource(Resource.Drawable.sommer);
                    break;
                case 5:
                    row.SetBackgroundResource(Resource.Drawable.oktober);
                    break;
                case 6:
                    row.SetBackgroundResource(Resource.Drawable.julefrokost);
                    break;
                default:
                    break;

            }
            ImageView att = row.FindViewById<ImageView>(Resource.Id.attendes);
            switch (eventItems[position].attend)
            {
                case 0: 
                    att.SetImageResource(Resource.Drawable.exclamation);
                    break;
                case 1:
                   att.SetImageResource(Resource.Drawable.attending);
                    break;
                case 2:
                    att.SetImageResource(Resource.Drawable.notattending);
                    break;
                default:
                    att.SetImageResource(Resource.Drawable.exclamation);
                    break;
            }

            return row;
        }

    }
}