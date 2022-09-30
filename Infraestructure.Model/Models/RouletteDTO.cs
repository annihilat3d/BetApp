using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model.Models
{
    public class RouletteDTO
    {
        public string Id { get; set; }
        public bool IsOpen { get; set; }
        public bool IsFinished { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ParticipantDTO> Participants { get; set; }
        public string WinnerColor { get; set; }
        public int WinnerNumber { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}
