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

namespace RemotePush
{
    public class UserItemAdapter : BaseAdapter<UserItem>
    {
        Activity activity;
        int layoutResourceId;
        List<UserItem> items = new List<UserItem>();

        public UserItemAdapter(Activity activity, int layoutResourceId)
        {
            this.activity = activity;
            this.layoutResourceId = layoutResourceId;
        }

        //Returns the view for a specific item on the list
        //public override View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
        //{
        //    var row = convertView;
        //    var currentItem = this[position];
        //    CheckBox checkBox;

        //    if (row == null)
        //    {
        //        var inflater = activity.LayoutInflater;
        //        row = inflater.Inflate(layoutResourceId, parent, false);

        //        checkBox = row.FindViewById<CheckBox>(Resource.Id.checkToDoItem);

        //        checkBox.CheckedChange += async (sender, e) => {
        //            var cbSender = sender as CheckBox;
        //            if (cbSender != null && cbSender.Tag is UserItemWrapper && cbSender.Checked)
        //            {
        //                cbSender.Enabled = false;
        //                if (activity is ToDoActivity)
        //                    await ((ToDoActivity)activity).CheckItem((cbSender.Tag as UserItemWrapper).UserItem);
        //            }
        //        };
        //    }
        //    else
        //        checkBox = row.FindViewById<CheckBox>(Resource.Id.checkToDoItem);

        //    checkBox.Text = currentItem.Text;
        //    checkBox.Checked = false;
        //    checkBox.Enabled = true;
        //    checkBox.Tag = new UserItemWrapper(currentItem);

        //    return row;
        //}

        public void Add(UserItem item)
        {
            items.Add(item);
            NotifyDataSetChanged();
        }

        public void Clear()
        {
            items.Clear();
            NotifyDataSetChanged();
        }

        public void Remove(UserItem item)
        {
            items.Remove(item);
            NotifyDataSetChanged();
        }

        #region implemented abstract members of BaseAdapter

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            throw new NotImplementedException();
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override UserItem this[int position]
        {
            get
            {
                return items[position];
            }
        }

        #endregion
    }
}