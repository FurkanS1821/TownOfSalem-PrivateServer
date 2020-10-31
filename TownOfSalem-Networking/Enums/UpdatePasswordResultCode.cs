using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownOfSalem_Networking.Enums
{
    public enum UpdatePasswordResultCode
    {
        Success = 1,
        AccountNameInvalid = 2,
        InvalidOldPassword = 3,
        InvalidNewPassword = 4,
        GenericFailure = 5,
    }
}
