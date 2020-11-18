using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1.Extension_Methods {
    public static class Owner {
        public static string FIO(this DB_OwnersCarsDataSet.OwnerRow self) => $"{self.FirstName} {self.SecondName} {self.MiddleName}";
    }
}
