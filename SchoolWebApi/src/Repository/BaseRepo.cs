using SchoolWebApi.src.Data;

namespace SchoolWebApi.src.Repository
{
    public class BaseRepo
    {
        protected readonly SchoolDb _context;

        protected BaseRepo(SchoolDb context)
        {
            _context = context;
        }

    }
}
