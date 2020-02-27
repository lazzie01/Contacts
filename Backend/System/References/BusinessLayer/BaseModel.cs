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
        protected DBContext DBContext { get; }

        public BaseModel()
        {
            DBContext = new DBContext();
        }

        public BaseModel(BaseModel callingModel)
        {
            DBContext = callingModel.DBContext;
        }

        public void Dispose()
        {
            ((IDisposable)DBContext).Dispose();
        }
    }
}
