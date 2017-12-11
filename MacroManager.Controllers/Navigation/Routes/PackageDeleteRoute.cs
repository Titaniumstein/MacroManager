using MacroContext.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Controllers.Navigation.Routes
{
    public class PackageDeleteRoute : IRoute
    {
        public PackageDeleteRoute(PackageDto package)
        {
            Package = package;
        }

        public PackageDto Package { get; private set; }
    }
}
