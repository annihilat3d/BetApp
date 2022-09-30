using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Model.Models
{
    public class RouletteResponseDTO
    {
        public bool IsSuccesful { get; set; }
        public List<string> Errors { get; set; }
    }
}
