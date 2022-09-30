using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.Rules
{
    public interface IRulesRepository
    {
        Task<Entities.Rules> Get();
    }
}
