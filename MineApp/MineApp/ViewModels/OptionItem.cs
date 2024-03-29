using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MineApp.Models
{
    public class OpportunitiesOptionItem : OptionItem
    {
        public override string Title { get { return "Opportunities"; } }
        public override string Icon { get { return "opportunity.png"; } }
    }

    public class ContactsOptionItem : OptionItem
    {
        public override string Title { get { return "Contacts"; } }
        public override string Icon { get { return "contact.png"; } }
    }

    public class LeadsOptionItem : OptionItem
    {
        public override string Title { get { return "Leads"; } }
        public override string Icon { get { return "lead.png"; } }
    }

    public class AccountsOptionItem : OptionItem
    {
        public override string Title { get { return "Accounts"; } }
        public override string Icon { get { return "account.png"; } }
    }

    public class OptionItem
    {
        public virtual string Title { get { var n = GetType().Name; return n.Substring(0, n.Length - 10); } }
        public virtual int Count { get; set; }
        public virtual bool Selected { get; set; }
        public virtual string Icon { get { return "item.png"; } }
        public ImageSource IconSource { get { return ImageSource.FromFile(Icon); } }
    }
}

