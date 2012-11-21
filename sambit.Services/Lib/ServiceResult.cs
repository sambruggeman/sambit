using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sambit.BLL.Lib
{
    public class BResult
    {
        public bool IsValid
        {
            get
            {
                return !(this.Messages.Count > 0);
            }
        }

        public IDictionary<string, string> Messages { get; set; }

        public int EntityId { get; set; }

        public void AddError(string key, string message)
        {
            this.Messages.Add(key, message);
        }

        public BResult()
        {
            this.Messages = new Dictionary<string, string>();
        }

        public BResult(Dictionary<string, string> messages)
        {
            this.Messages = messages;
        }
    }
}
