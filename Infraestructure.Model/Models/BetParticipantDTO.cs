using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model.Models
{
    public class BetParticipantDTO
    {
        public string Name { get; set; }
        public string BetColor { get; set; }
        public double BetMoney { get; set; }
        public int BetNumber { get; set; }
        public string BetType { get; set; }
    }
}
