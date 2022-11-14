using System.Collections.Generic;
using System.Threading.Tasks;
using ContactUsingFreshMvvm.Model;

namespace ContactUsingFreshMvvm.Interface
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        Task<bool> DeleteContact(Contact contact);
        List<Contact> GetContactsAsync();
        
    }
}