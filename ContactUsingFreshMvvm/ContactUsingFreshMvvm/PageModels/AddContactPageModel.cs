using System.Windows.Input;
using ContactUsingFreshMvvm.Interface;
using ContactUsingFreshMvvm.Model;
    
using FreshMvvm;
using Xamarin.Forms;

namespace ContactUsingFreshMvvm.PageModels
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class AddContactPageModel:FreshBasePageModel
    {
        IContactRepository _contactRepository;

        public AddContactPageModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            this.WhenAny(HandleContactChanged, o => o.Contact);
        }

        void HandleContactChanged(string propertyName)
        {
            //handle the property changed, nice
        }

        public Contact Contact { get; set; }
        //use getter to check if Name is null or empty

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
        public Command SaveCommand
        {
            get
            {
                return new Command(() => {
                    _contactRepository.AddContact(Contact);
                    CoreMethods.PopPageModel(Contact);
                }
                );
            }
        }
    }
}