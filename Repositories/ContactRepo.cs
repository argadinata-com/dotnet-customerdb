using CustomerDb.Models;
using CustomerDb.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerDb.Repositories
{
    public class ContactRepo : MasterRepo<Contact, DataContext>
    {
        private readonly DataContext _db;

        public ContactRepo(DataContext db) : base(db)
        {
            _db = db;
        }

        public override IEnumerable<Contact> Get()
        {
            IEnumerable<Contact> contacts = _db.Contacts.Include(x => x.company)
                .Where(x => x.row_status == 1)
                .OrderBy(x => x.name);

            return contacts;
        }

        public override Contact? Get(int id)
        {
            Contact? contact = _db.Contacts.Include(x => x.company)
                .Where(x => x.row_status == 1 && x.id == id)
                .FirstOrDefault();
            
            return contact;
        }
    }
}
