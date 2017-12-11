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

namespace MacroManager.Controllers.Controllers
{
    public class PackageController : IController
    {
        private IViewIndex _indexView;
        private IViewCreate _createView;
        private IViewEdit _editView;
        private IViewDetail _detailView;
        private IViewDelete _deleteView;

        private ICommandDispatcher _commandDispatcher;
        private IQueryDispatcher _queryDispatcher;

        public IViewBase IndexView { get { return _indexView; } }
        public IViewBase CreateView { get { return _createView; } }
        public IViewBase EditView { get { return _editView; } }
        public IViewBase DetailView { get { return _detailView; } }
        public IViewBase DeleteView { get { return _deleteView; } }


        public PackageController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher, IViewCreate createView, IViewIndex indexView, IViewEdit editView, IViewDetail detailView, IViewDelete deleteView)
        {
            _indexView = indexView;
            _createView = createView;
            _editView = editView;
            _detailView = detailView;
            _deleteView = deleteView;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;

            _indexView.SetController(this);
            _createView.SetController(this);
            _editView.SetController(this);
            _detailView.SetController(this);
            _deleteView.SetController(this);
        }


        public void LoadIndexView(Nullable<Guid> selectPackageId = null)
        {
            _indexView.Initialize(selectPackageId);
        }

        public void LoadEditView(PackageDto package)
        {
            _editView.Initialize(package);
        }

        public void LoadDetailView(PackageDto package)
        {
            _detailView.Initialize(package);
        }

        public void LoadDeleteView(PackageDto package)
        {
            _deleteView.Initialize(package);
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
