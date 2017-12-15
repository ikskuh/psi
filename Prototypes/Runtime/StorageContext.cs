using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runtime
{
    public sealed class StorageContext
    {
        private readonly ValueStore[] fields;

        public StorageContext(params ValueStore[] fields)
        {
            this.fields = fields.ToArray();
        }

        public ValueStore this[int idx]
        {
            get { return this.fields[idx]; }
            set { this.fields[idx] = value; }
        }
    }
}
