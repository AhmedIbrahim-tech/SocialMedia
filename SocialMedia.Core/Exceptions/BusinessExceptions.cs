using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Exceptions
{
    public class BusinessExceptions : Exception
    {
        public BusinessExceptions()
        {
        }

        public BusinessExceptions(string Message) : base(Message)
        {

        }
    }
}
