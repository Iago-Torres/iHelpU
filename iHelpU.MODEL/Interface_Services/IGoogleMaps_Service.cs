using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHelpU.MODEL.Interface_Services
{
    public interface IGoogleMaps_Service
    {
        Task<List<string>> ObterPaisesAsync();
    }
}
