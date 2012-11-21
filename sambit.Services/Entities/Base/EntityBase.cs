using sambit.BLL.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sambit.BLL.Base;

namespace sambit.BLL.Entities.Base
{
    public abstract class EntityBase : IEntityBase
    {
        public BResult _result { get; protected set; }
    }
}
