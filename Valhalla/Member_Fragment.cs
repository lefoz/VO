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
    public class Member_Fragment : Android.Support.V4.App.Fragment
    {
        private List<Member> mMemberList;
        private ListView mMemberListView;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.Member_layout, container, false);

            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            //Event listView start----
            mMemberListView = view.FindViewById<ListView>(Resource.Id.memberListView);
            mMemberList = new List<Member>();
            mMemberList.Add(new Member() { name = "Max Lydal Hansen", phone = "41256387", email = "max@hotmail.com" });
            mMemberList.Add(new Member() { name = "Martin Hein Birkedal", phone = "12457935", email = "martin@gmail.com" });
            mMemberList.Add(new Member() { name = "Kasper Frederiksen", phone = "54789632", email = "kasper@jubii.dk" });
            mMemberList.Add(new Member() { name = "Ian Bønneland", phone = "48523697", email = "Ian@hotmail.com" });
            mMemberList.Add(new Member() { name = "Henrik Lund", phone = "23548961", email = "henrik@msn.com" });
            mMemberList.Add(new Member() { name = "Peter Koch", phone = "78523694", email = "peter@jubii.dk" });

            MemberViewAdapter memberAdapter = new MemberViewAdapter(this.Activity, mMemberList);
            mMemberListView.Adapter = memberAdapter;
            mMemberListView.ItemClick += mMemberListView_ItemClick;

            //EventListView End---
        }

        private void mMemberListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Show Dialog
            Android.Support.V4.App.FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_Member dialog_member = new Dialog_Member();
            dialog_member.Show(transaction, "Member");
            Console.WriteLine(mMemberList[e.Position].name);
        }
    }
}
