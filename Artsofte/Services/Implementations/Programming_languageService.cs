using Artsofte.DAL.Interfaces;
using Artsofte.Models;
using Artsofte.Services.Interfaces;

namespace Artsofte.Services.Implementations
{
	public class Programming_languageService : IProgramming_languageService
	{
        IBaseRepository<Programming_language> _repoPr;
        public Programming_languageService(IBaseRepository<Programming_language> DeRepo)
        {
            _repoPr = DeRepo;
        }
       
        public async Task<List<string>> spGetAllProgramming_language()
		{
            List<string> r = new List<string>();
            var db_res = await _repoPr.Select();
            foreach (var t in db_res)
            {
                r.Add(t.Name);
            }
            return r;
        }
	}
}
