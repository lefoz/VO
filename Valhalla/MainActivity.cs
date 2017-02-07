using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportFragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System.Collections.Generic;

namespace Valhalla
{
    [Activity(Label = "Valhalla Ordenen", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/VoTheme")]
    public class MainActivity : ActionBarActivity 
    {
        private SupportToolbar mToolbar;
        private ActionBarDrawerToggle mDrawerToggle;
        private DrawerLayout mDrawerLayout;
        private ListView mLeftDrawer;
        private ArrayAdapter mLeftAdapter;
        private List<string> mLeftDataSet;
        private SupportFragment mCurrentFragment;
        private Event_Fragment mEvent_Fragment;
        private Member_Fragment mMember_Fragment;
        private Stack<SupportFragment> mStackFragment;
        private Picture_Fragment mPicture_Fragment;
        private Summay_Fragment mSummary_Fragment;
        private Accounting_Fragment mAccounting_Fragment;
        private Statutes_Fragment mStatutes_Fragment;
        private MyAccount_Fragment mMyAccount_Fragment;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            //ToolBar Start----
            mToolbar = FindViewById<SupportToolbar>(Resource.Id.toolbar);
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            mLeftDrawer = FindViewById<ListView>(Resource.Id.left_drawer);
            SetSupportActionBar(mToolbar);

            mEvent_Fragment = new Event_Fragment();
            mMember_Fragment = new Member_Fragment();
            //mPicture_Fragment = new Picture_Fragment();
            //mSummary_Fragment = new Summay_Fragment();
            //mAccounting_Fragment = new Accounting_Fragment();
            //mStatutes_Fragment = new Statutes_Fragment();
            //mMyAccount_Fragment = new MyAccount_Fragment();
            mStackFragment = new Stack<SupportFragment>();


            var trans = SupportFragmentManager.BeginTransaction();
            //trans.Add(Resource.Id.fragment_container, mMyAccount_Fragment, "Picture fragment");
            //trans.Hide(mMyAccount_Fragment);
            //trans.Add(Resource.Id.fragment_container, mStatutes_Fragment, "Picture fragment");
            //trans.Hide(mStatutes_Fragment);
            //trans.Add(Resource.Id.fragment_container, mAccounting_Fragment, "Picture fragment");
            //trans.Hide(mAccounting_Fragment);
            //trans.Add(Resource.Id.fragment_container, mSummary_Fragment, "Picture fragment");
            //trans.Hide(mSummary_Fragment);
            //trans.Add(Resource.Id.fragment_container, mPicture_Fragment, "Picture fragment");
            //trans.Hide(mPicture_Fragment);
            trans.Add(Resource.Id.fragment_container, mMember_Fragment, "Member fragment");
            trans.Hide(mMember_Fragment);
            trans.Add(Resource.Id.fragment_container, mEvent_Fragment, "EventList fragment");
            trans.Commit();
            mCurrentFragment = mEvent_Fragment;

            mLeftDataSet = new List<string>();
            mLeftDataSet.Add("Arrangementer");
            mLeftDataSet.Add("Medlemmer");
            mLeftDataSet.Add("Billeder");
            mLeftDataSet.Add("Referater");
            mLeftDataSet.Add("Regnskaber");
            mLeftDataSet.Add("Vedtægter");
            mLeftDataSet.Add("Min Konto");
            mLeftDataSet.Add("LogOut");
            mLeftAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, mLeftDataSet);
            mLeftDrawer.Adapter = mLeftAdapter;
            mLeftDrawer.ItemClick += MLeftDrawer_ItemClick;

            mDrawerToggle = new ActionBarDrawerToggle(
                this,                               //host Activity
                mDrawerLayout,                      //Drawer layout
                Resource.String.openDrawer,         //Opend Message
                Resource.String.closeDrawer);       //Closed Message

            mDrawerLayout.SetDrawerListener(mDrawerToggle);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            mDrawerToggle.SyncState();
            //ToolBar End----

            
        }

        private void MLeftDrawer_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
             
            switch (mLeftDataSet[e.Position])
            {
                case "Arrangementer":
                    Console.WriteLine("arrangement fragment valgt");
                    ShowFragment(mEvent_Fragment);
                    mDrawerLayout.CloseDrawers();
                    break;
                case "Medlemmer":
                    Console.WriteLine("Medlems fragment valgt");
                    ShowFragment(mMember_Fragment);
                    mDrawerLayout.CloseDrawers();
                    break;
                case "Billeder":
                    Console.WriteLine("Billeder fragment valgt");
                    //ShowFragment(mPicture_Fragment);
                    mDrawerLayout.CloseDrawers();
                    break;
                case "Referater":
                    Console.WriteLine("Referat fragment valgt");
                    ShowFragment(mSummary_Fragment);
                    mDrawerLayout.CloseDrawers();
                    break;
                case "Regnskaber":
                    Console.WriteLine("Regnskabs fragment valgt");
                    //ShowFragment(mAccounting_Fragment);
                    mDrawerLayout.CloseDrawers();
                    break;
                case "Vedtægter":
                    Console.WriteLine("Vedtægts fragment valgt");
                    //ShowFragment(mStatutes_Fragment);
                    mDrawerLayout.CloseDrawers();
                    break;
                case "Min Konto":
                    Console.WriteLine("Medlemskonto fragment valgt");
                    //ShowFragment(mMyAccount_Fragment);
                    mDrawerLayout.CloseDrawers();
                    break;
                case "LogOut":
                    Console.WriteLine("LogOut valgt");
                    //ShowFragment(mMember_Fragment);
                    mDrawerLayout.CloseDrawers();
                    break;
                default:
                    Console.WriteLine("Default!");
                    mDrawerLayout.CloseDrawers();
                    break;
            }
            
        }
        
        private void ShowFragment(SupportFragment fragment)
        {
            var trans = SupportFragmentManager.BeginTransaction();
            trans.Hide(mCurrentFragment);
            trans.Show(fragment);
            trans.AddToBackStack(null);
            trans.Commit();
            mStackFragment.Push(mCurrentFragment);
            mCurrentFragment = fragment;
        }

        public override void OnBackPressed()
        {
            if (SupportFragmentManager.BackStackEntryCount > 0)
            {
                SupportFragmentManager.PopBackStack();
                mCurrentFragment = mStackFragment.Pop();
            }
            else
            {
                base.OnBackPressed();
            }
            
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            mDrawerToggle.OnOptionsItemSelected(item);
            return base.OnOptionsItemSelected(item);
        }
    }
}

