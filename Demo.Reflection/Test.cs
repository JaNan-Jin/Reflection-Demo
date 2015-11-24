using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Reflection
{
   public class Test:IReflection.IReflection
    {

        public string SayHello()
        {
            return "Hello " + this.Name;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
