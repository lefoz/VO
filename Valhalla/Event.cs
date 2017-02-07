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
    class Event
    {
        public int  eventId { get; set; }
        public string eventType { get; set; }
        public string eventName { get; set; }
        public string eventDate { get; set; }
        public int attend { get; set; }
       
        //public ImageView attendens { get; set; }

        public Event()
        {

        } 
    }
}