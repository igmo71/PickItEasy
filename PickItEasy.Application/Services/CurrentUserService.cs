using Microsoft.AspNetCore.Http;
using PickItEasy.Application.Interfaces;
using System.Security.Claims;

namespace PickItEasy.Application.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid UserId
        {
            get
            {
                var userId = _contextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return string.IsNullOrEmpty(userId) ? Guid.Empty : Guid.Parse(userId);
            }
        }
    }
}
