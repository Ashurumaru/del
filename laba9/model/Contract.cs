using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba9.model
{
    internal class Contract
    {
        public int НомерДоговора { get; set; }
        public DateTime ДатаДоговора { get; set; }
        public int КодПоставщика { get; set; }
        public string Комментарий { get; set; }
    }
}
