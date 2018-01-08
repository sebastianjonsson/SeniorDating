using SeniorDating.Models;
using System.Linq;
using System.Web.Mvc;

namespace SeniorDating.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db = new ApplicationDbContext();
        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User != null)
            {
                var context = new ApplicationDbContext();
                var username = User.Identity.Name;

                if (!string.IsNullOrEmpty(username))
                {
                    var user = context.Users.SingleOrDefault(u => u.UserName == username);

                    if (user != null)
                    {
                        string Name = user.Name;
                        string Id = user.Id;

                        var friendList = user.Friends;
                        var friendRequests = user.FriendRequests;
                        
                        ViewData.Add("Name", Name);
                        ViewData.Add("Id", Id);
                        ViewData.Add("friendList", friendList);
                        ViewData.Add("friendRequests", friendRequests);
                    }
                }
            }
            base.OnActionExecuted(filterContext);
        }

    }
}