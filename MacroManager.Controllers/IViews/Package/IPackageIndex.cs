﻿using MacroManager.Controllers.Controllers;
using MacroManager.Controllers.IViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Controllers.IViews.Package
{
    public interface IPackageIndex: IView<PackageController>
    {
        void Initialize(Nullable<Guid> packageId = null);

    }
}
