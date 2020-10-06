using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Extension_Methods {
    public static class Objects {
        public static TOut With<TIn, TOut>(this TIn self, Func<TIn, TOut> function) 
            where TIn : class 
            where TOut : class 
        {
            return self == null ? null : function(self);
        }
    }
}
