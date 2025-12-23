using OptiMark.DAL.Models;

namespace OptiMark.API.Services.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUser user, IList<string> roles);
}