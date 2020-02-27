using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ContactModel : BaseModel
    {
        public ContactModel():base()
        {

        }

        public ContactModel(BaseModel callingModel) : base(callingModel)
        {

        }
    }
}
