using System;
using System.Collections.Generic;
using System.Text;

namespace HasinCard.Core.Domain
{
    public class SysUsersRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string TelNo { get; set; }
        public string QQ { get; set; }
    }
}
