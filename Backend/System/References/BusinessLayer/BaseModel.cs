using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BaseModel: IDisposable
    {
        protected DBContext DB { get; }

        public BaseModel()
        {
            DB = new DBContext();
        }

        public BaseModel(BaseModel callingModel)
        {
            DB = callingModel.DB;
        }

        public void Dispose()
        {
            ((IDisposable)DB).Dispose();
        }
    }
}
