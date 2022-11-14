using ContactUsingFreshMvvm.Model;
using FreshMvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using ContactUsingFreshMvvm.Interface;
using Xamarin.Forms;

namespace ContactUsingFreshMvvm.PageModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class DeletePageModel:FreshBasePageModel
    {
        IContactRepository _contactRepository;

        public DeletePageModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            this.WhenAny(HandleContactChanged, o => o.Contact);
        }

        void HandleContactChanged(string propertyName)
        {
            //handle the property changed, nice
        }

        public Contact Contact { get; set; }

        public override void Init(object initData)
        {
            if (initData != null)
            {
                Contact = (Contact)initData;
            }
            else
            {
                Contact = new Contact();
            }
        }
        public Command DeleteCommand
        {
            get
            {
                return new Command(() => {
                        _contactRepository.DeleteContact(Contact);
                        CoreMethods.PopPageModel(Contact);
                    }
                );
            }
        }
    }

    
}
