using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ContactUsingFreshMvvm.Interface;
using ContactUsingFreshMvvm.Model;
using FreshMvvm;
using PropertyChanged;
using Xamarin.Forms;

namespace ContactUsingFreshMvvm.PageModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class ContactListPageModel : FreshBasePageModel
    {
        IContactRepository _contactRepository;
        public ObservableCollection<Contact> Contacts { get; set; }
        public ContactListPageModel (IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        
        public override async void Init (object initData)
        {
            Contacts = new ObservableCollection<Contact> ( _contactRepository.GetContactsAsync());
        }
        public override void ReverseInit (object value)
        {
            var newContact = value as Contact;
            if (!Contacts.Contains (newContact)) {
                Contacts.Add (newContact);
            }
            else
            {
                Contacts.Remove(newContact);
            }
        }

        public Command ItemTapCommand
        {
            get
            {
                return new Command((contact
                    ) =>
                {
                    CoreMethods.PushPageModel<DeletePageModel>(contact);
                });
            }
        }

        public Command AddContact
        {
            get
            {
                return new Command(async () => {
                    await CoreMethods.PushPageModel<AddContactPageModel>();
                });
            }
        }
    }
}