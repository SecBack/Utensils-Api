using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public class UserJoinGroupRequest
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
    }
}
