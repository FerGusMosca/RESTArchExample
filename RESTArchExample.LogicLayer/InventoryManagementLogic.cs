using Microsoft.Extensions.Configuration;
using RESTArchExample.BusinessEntities;
using RESTArchExample.Common.DTO;
using RESTArchExample.Common.Util;
using RESTArchExample.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample.LogicLayer
{
    public class InventoryManagementLogic
    {

        #region Protected Attributes

        protected CarModelManager CarModelManager { get;set; }

        #endregion

        #region Constructors

        public InventoryManagementLogic()
        {
            Logger.Instance.DoLog("Initializing InventoryManagementLogic...", MessageType.Information);
            ConfigParamManager.Instance.GetConfig("InventoryManagementSettings", "BaseUrl");

            string connectionString= ConfigParamManager.Instance.GetConfig("InventoryManagementSettings", "ConnectionString");
            CarModelManager = new CarModelManager(connectionString);
            Logger.Instance.DoLog("InventoryManagementLogic successfully initialized...", MessageType.Information);
        }

        #endregion

        #region Public Methods

        public CreateCarModelRespDTO CreateCarModel(CreateCarModelReqDTO createCarModelDTO)
        {
            try
            {
                // Lógica para crear un modelo de automóvil usando el DTO
                Logger.Instance.DoLog($"Creating car model: {createCarModelDTO.modelName} (edition:{createCarModelDTO.specialEdition}) company:{createCarModelDTO.company} for Issue Year: {createCarModelDTO.issueYear}", MessageType.Debug);


                CarModel carToBuild=    CarModel.BuildCarModel(createCarModelDTO);

                carToBuild.ValidatePurchae();//Business Rules

                CarModelManager.PersistCarModel(carToBuild);

                Logger.Instance.DoLog($"Car model successfully created", MessageType.Information);

                return new CreateCarModelRespDTO() { success = true };

            }
            catch(Exception ex)
            {
                string msg = $"ERROR creating car model {createCarModelDTO.modelName}:{ex.Message}";
                Logger.Instance.DoLog(msg, MessageType.Error);
                return new CreateCarModelRespDTO() { success = false, error = msg };
            }
            
        }

        public GetCarModelRespDTO GetCarModels(GetCarModelReqDTO getCarModelDTO)
        {
            try
            {
                // Lógica para crear un modelo de automóvil usando el DTO
                Logger.Instance.DoLog($"Fetching car models for filters: ModelName:{getCarModelDTO.modelName} (edition:{getCarModelDTO.specialEdition}) company:{getCarModelDTO.company} for Issue Year: {getCarModelDTO.issueYear}", MessageType.Information);


                List<CarModel> carModels = CarModelManager.GetCarModels(getCarModelDTO);

                List<CarModelDTO> respList = new List<CarModelDTO>();

                carModels.ForEach(x =>
                {

                    respList.Add(new CarModelDTO()
                    {
                        modelName = x.ModelName,
                        bookPrice = x.BookPrice,
                        specialEdition = x.SpecialEdition,
                        company = x.Company,
                        issueYear = x.IssueYear

                    });

                });


                Logger.Instance.DoLog($"Car model successfully found {carModels.Count}", MessageType.Information);

                return new GetCarModelRespDTO() { success = true,CarModels= respList.ToArray() };

            }
            catch (Exception ex)
            {
                string msg = $"ERROR fetching car models :{ex.Message}";
                Logger.Instance.DoLog(msg, MessageType.Error);
                return new GetCarModelRespDTO() { success = false, error = msg };
            }

        }


        public DeleteCarModelRespDTO DeleteCarmOdels(DeleteCarModelReqDTO deleteCarModelDTO)
        {
            try
            {
                Logger.Instance.DoLog($"Deleting car models for filters: ModelName:{deleteCarModelDTO.modelName} (edition:{deleteCarModelDTO.specialEdition}) company:{deleteCarModelDTO.company} for Issue Year: {deleteCarModelDTO.issueYear}", MessageType.Information);

                int delRows = CarModelManager.DeleteCarModels(deleteCarModelDTO);

                Logger.Instance.DoLog($"{delRows} car model successfully deleted", MessageType.Information);

                return new DeleteCarModelRespDTO() { success = true, DeletedCount=delRows };

            }
            catch (Exception ex)
            {
                string msg = $"ERROR deleting car models :{ex.Message}";
                Logger.Instance.DoLog(msg, MessageType.Error);
                return new DeleteCarModelRespDTO() { success = false, error = msg };
            }

        }



        #endregion
    }

}
