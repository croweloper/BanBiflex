using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.BanBiFlex.BE.ValidarSitio
{
    public class ValidarSitioRequest
    {
        public int? Piso { get; set; }
        public int? Sitio { get; set; }
        public string Fecha { get; set; }
        public int? UserId { get; set; }
    }
}
