using MacroContext.Contract.Dto;
using MacroManager.Controllers.Controllers;
using MacroManager.Controllers.IViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Controllers.IViews.Package
{
    public interface IViewIndex: IView<PackageController>
    {
        void Initialize(PackageDto[] packages, Nullable<Guid> packageId = null);

    }
}
