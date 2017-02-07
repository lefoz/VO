using System;

using SupportActionBarDrawerToggle = Android.Support.V7.App.ActionBarDrawerToggle;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Views;

namespace Valhalla
{
    class ActionBarToggle : SupportActionBarDrawerToggle
    {
        private ActionBarActivity mHostActivity;
        private int mOpenResource;
        private int mClosedResource;

        public ActionBarToggle (ActionBarActivity host, DrawerLayout drawerLayout, int opendResource, int closedResource) : base(host, drawerLayout, opendResource, closedResource)
        {
            mHostActivity = host;
            mOpenResource = opendResource;
            mClosedResource = closedResource;
        }

        public override void OnDrawerOpened(View drawerView)
        {
            base.OnDrawerOpened(drawerView);
        }

        public override void OnDrawerClosed(View drawerView)
        {
            base.OnDrawerClosed(drawerView);
        }

        public override void OnDrawerSlide(View drawerView, float slideOffset)
        {
            base.OnDrawerSlide(drawerView, slideOffset);
        }

    }
}