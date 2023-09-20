using CustomerDb.Models;
using CustomerDb.Repositories;

namespace CustomerDb.Repositories
{
    public class CompanyRepo : MasterRepo<Company, DataContext>
    {
        public CompanyRepo(DataContext db) : base(db)
        {

        }
    }
}
