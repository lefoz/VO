using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.App;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Valhalla
{
    public class Event_Fragment : Android.Support.V4.App.Fragment
    {
        private List<Event> mEventList;
        private ListView mEventListView;
       

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            mEventList = new List<Event>();
            mEventList.Add(new Event() {eventId= 1, eventType = "Generelforsamling", eventName = "", eventDate = "04/02-2017",attend = 1 });
            mEventList.Add(new Event() { eventId = 2, eventType = "April Arrangement", eventName = "Ølbrygning", eventDate = "04/04-2017", attend = 2 });
            mEventList.Add(new Event() { eventId = 3, eventType = "Øl Fest", eventName = "", eventDate = "06/06-2017", attend = 0 });
            mEventList.Add(new Event() { eventId = 4, eventType = "Sommer Fest", eventName = "", eventDate = "08/08-2017", attend = 0 });
            mEventList.Add(new Event() { eventId = 5, eventType = "Oktober Arrangement", eventName = "PaintBall", eventDate = "10/10-2017", attend = 0 });
            mEventList.Add(new Event() { eventId = 6, eventType = "Julefrokost", eventName = "", eventDate = "12/12-2017", attend = 0 });

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Event_layout, container, false);
           
            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            //Event listView start----
            mEventListView = view.FindViewById<ListView>(Resource.Id.eventListView);
            

            EventViewAdapter eventAdapter = new EventViewAdapter(this.Activity, mEventList);
            mEventListView.Adapter = eventAdapter;
            mEventListView.ItemClick += MEventListView_ItemClick;

            //EventListView End---
        }

        private void MEventListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Show Dialog
            Android.Support.V4.App.FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_Event dialog_event = new Dialog_Event();
            dialog_event.Show(transaction, "Event");
            Console.WriteLine(mEventList[e.Position].eventType);
        }
    }
}