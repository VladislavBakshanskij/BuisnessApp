using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Extension_Methods {
    public static class ComboBox {
        public static void Add<TIn>(this System.Windows.Forms.ComboBox self, TIn value) {
            if (self == null)
                throw new ArgumentNullException(nameof(self));
            self.Items.Add(value);
        }
    }
}
