using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adapter
{
    public interface IAdapter
    {
        public string GetAdapterName();
        public string GetAdapterVersion();
        public string GetAdapterType();
    }
}