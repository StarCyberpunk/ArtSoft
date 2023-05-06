using Artsofte.Models;
using Artsofte.Models.ViewModels;

namespace Artsofte.Services.Interfaces
{
	public interface IProgramming_languageService
	{
        Task<List<string>> spGetAllProgramming_language();
    }
}
