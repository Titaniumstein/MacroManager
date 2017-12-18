using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroManager.Controllers.IViews;
using MacroContext.Contract.Dto;
using MacroContext.Contract.Queries;
using MacroManager.Controllers.Dispatchers;
using MacroContext.Contract.Commands;
using MacroManager.Controllers.IViews.Orchestrator;
using MacroManager.Controllers.Controllers.Orchestrator;
using MacroManager.Controllers.Navigation;
using MacroManager.Controllers.Navigation.Routes;

namespace MacroManager.Controllers.Controllers.Orchestrator
{
    public class OrchestratorController : IController
    {
        private IViewStartup _view;
        private IOrchestrator _orchestrator;
        private IRouter _router;

        public IViewBase View { get { return _view; } }

        public OrchestratorController(IViewStartup view, IOrchestrator orchestrator, IRouter router)
        {
            _router = router;
            _orchestrator = orchestrator;
            _view = view;
            _view.SetController(this);
        }


        public async void Initialize()
        {
            await Task.Run(()=>_orchestrator.Initialize());
            _router.GoTo(new PackageIndexRoute());
        }

    }
}

