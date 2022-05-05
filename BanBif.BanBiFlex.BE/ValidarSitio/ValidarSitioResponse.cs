using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.BanBiFlex.BE.ValidarSitio
{
    public class ValidarSitioResponse
    {
        public bool result { get; set; }
        public List<ValidarSitioResult> data { get; set; }
    }
}
