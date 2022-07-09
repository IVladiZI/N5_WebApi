using N5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Infrastructure.Repositories
{
    public class PostReporitory
    {
        public IEnumerable<Permission> GetPosts()
        {
            var posts = Enumerable.Range(1, 10).Select(x => new Permission
            {
                Id = x,
                Name = "",
                LastName ="",
                TypePermission = 0,
                Date = DateTime.Now
            });
            return posts;
;        }
    }
}
