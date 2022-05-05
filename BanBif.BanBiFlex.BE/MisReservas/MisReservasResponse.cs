using BanBif.BanBiFlex.BE.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.BanBiFlex.BE.MisReservas
{
    public class MisReservasResponse
    {
        public bool result { get; set; }
        public List<MisReservasResult> data { get; set; }
    }
}
