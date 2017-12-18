using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroManager.Controllers.IViews;
using MacroManager.Controllers.IViews.Package;
using MacroContext.Contract.Dto;
using MacroContext.Contract.Queries;
using MacroManager.Controllers.Dispatchers;
using MacroContext.Contract.Commands;
using MacroManager.Controllers;

namespace MacroManager.Controllers.Controllers
{
    public class PackageController : IController
    {
        private ViewCollection _views;
        private ICommandDispatcher _commandDispatcher;
        private IQueryDispatcher _queryDispatcher;
        private IThreadDispatcher _threadDispatcher;

        public ViewCollection Views { get { return _views; } }


        public PackageController(IThreadDispatcher threadDispatcher, ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, ViewCollection views)
        {
            _views = views;
            _views.SetController(this);
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _threadDispatcher = threadDispatcher;

        }


        public void LoadIndexView(Nullable<Guid> selectPackageId = null)
        {
            var packages = this.GetAllPackages();
            _threadDispatcher.Dispatch(()=>_views.IndexView.Initialize(packages, selectPackageId));
        }

        public void LoadEditView(PackageDto package)
        {
            _views.EditView.Initialize(package);
        }

        public void LoadDetailView(PackageDto package)
        {
            _views.DetailView.Initialize(package);
        }

        public void LoadDeleteView(PackageDto package)
        {
            _views.DeleteView.Initialize(package);
        }


        public void AddPackage(PackageDto package)
        {
            var command = new AddPackageCommand(package);
            _commandDispatcher.Submit(command);
        }

        public void EditPackage(PackageDto package)
        {

            var command = new EditPackageCommand(package);
            _commandDispatcher.Submit(command);
        }

        public void RemovePackage(PackageDto package)
        {

            var command = new RemovePackageCommand(package);
            _commandDispatcher.Submit(command);
        }



        public PackageDto[] GetAllPackages()
        {
            var query = new GetAllPackagesQuery();
            var results = _queryDispatcher.Submit(query);
            return results;

        }















        //public bool RemovePatient (Guid patientId)
        //{
        //    bool success = false;
        //    var command = new DeletePatientCommand(patientId);
        //    _callback.Completed += () => success = true;

        //    //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
        //    _commandDispatcher.Execute(command);
        //    return success;
        //    //return result;
        //}




        //public PatientDto GetPatient(Guid patientId)
        //{
        //    var query = new GetPatientByIdQuery(patientId);
        //    //_callback.Completed += () => success = true;
        //    //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
        //    var patient = _queryDispatcher.Execute(query);
        //    return patient;

        //}

        //public IEnumerable<PatientDto> FindPatientsByName(string text)
        //{
        //    //bool success = false;

        //    var query = new FindPatientsBySearchTextQuery(text);
        //    //_callback.Completed += () => success = true;
        //    //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
        //    var patients = _queryDispatcher.Execute(query);
        //    return patients;
        //}

        //public IEnumerable<PackageDto> GetAllPatients()
        //{
        //    var query = new GetAllPackagesQuery();
        //    var packages = _queryDispatcher.Execute(query) as IEnumerable<PatientDto>;
        //    return patients;
        //}

    }
}
