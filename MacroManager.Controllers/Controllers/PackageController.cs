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
        private IPackageIndex _view;
        private ICommandDispatcher _commandDispatcher;

        public PackageController(ICommandDispatcher commandDispatcher)
        {
            //_view = view;
            _commandDispatcher = commandDispatcher;
        }


        public void LoadIndexView(Nullable<Guid> selectPackageId = null)
        {
            _view.Initialize(selectPackageId);
        }



        public void AddPackage(PackageDto package)
        {

            var command = new AddPackageCommand(package);
            _commandDispatcher.Submit(command);
        }



        //public PackageDto[] GetAllPackages()
        //{
        //    var query = new GetAllPackagesQuery();

        //}

        //public void LoadEditView(PatientDto patient)
        //{
        //    _viewsPkg.EditView.BindToPatient(patient);
        //}

        //public void LoadCreateView(PatientDto defaultPatientProperties)
        //{
        //    _viewsPkg.CreateView.BindToPatient(defaultPatientProperties);
        //}







        //public bool AddPatient(PatientDto patient, ContactInfoDto contactInfo, HealthIdentificationDto healthId)
        //{
        //    contactInfo.Address = new ValueObjects.ContactInformation.Address();
        //    contactInfo.PrimaryPhoneNumber = new ValueObjects.ContactInformation.PhoneNumber();
        //    contactInfo.SecondaryPhoneNumber = new ValueObjects.ContactInformation.PhoneNumber();
        //    healthId.Healthcard = new ValueObjects.Health.Healthcard(); //temp

        //    bool success = false;
        //    var command = new AddPatientCommand(patient, contactInfo, healthId);
        //    _callback.Completed += () => success = true;
        //    _commandDispatcher.Execute(command);
        //    return success;
        //    //return result;

        //}



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


        //public bool UpdatePatient(PatientDto patient)
        //{

        //    bool success = false;

        //    var command = new UpdatePatientCommand(patient);
        //    _callback.Completed += () => success = true;
        //    //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
        //    _commandDispatcher.Execute(command);
        //    return success;
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
