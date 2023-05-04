using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Requests
{
    public class UpdateGroupRequest
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
    }
}
