//using PickItEasy.Application.Interfaces;
//using System.Security.Claims;

//namespace PickItEasy.WebApi.Services
//{
//    public class CurrentUserService : ICurrentUserService
//    {
//        private readonly IHttpContextAccessor _contextAccessor;

//        public CurrentUserService(IHttpContextAccessor contextAccessor)
//        {
//            _contextAccessor = contextAccessor;
//        }

//        public Guid UserId
//        {
//            get
//            {
//                var userId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
//                return string.IsNullOrEmpty(userId) ? Guid.Empty : Guid.Parse(userId);
//            }
//        }
//    }
//}
