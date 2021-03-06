﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroManager.Controllers.Dispatchers
{
    public interface ICommandHandler<TCommand>
    {
        void Execute(TCommand command);
    }
}
