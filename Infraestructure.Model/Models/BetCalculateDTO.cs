using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model.Models
{
    public class BetCalculateDTO
    {
        public List<ParticipantDTO> Participants { get; set; }
        public string WinnerColor { get; set; }
        public int WinnerNumber { get; set; }
    }
}
