using RESTArchExample.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample.BusinessEntities
{
    public class CarModel
    {
        #region Protected Static Consts

        protected static string _INVALID_CAR_COMPANY_PEUGEOT = "Peugeot";

        #endregion


        #region Public Attributes

        public int Id { get; set; }

        public string Company { get; set; }

        public string ModelName { get; set; }

        public string SpecialEdition { get; set; }

        public int IssueYear { get; set; }


        public double? BookPrice { get; set; }

        #endregion

        #region Public Static Methods


        public static CarModel BuildCarModel(CreateCarModelReqDTO dto)
        {
            CarModel carModel = new CarModel()
            {
                Company = dto.company,
                ModelName = dto.modelName,
                SpecialEdition = dto.specialEdition,
                IssueYear = dto.issueYear,
                BookPrice = dto.bookPrice

            };
            return carModel;
        
        
        }

        #endregion


        #region Public Methods

        public void ValidatePurchae()
        {
            if (Company == _INVALID_CAR_COMPANY_PEUGEOT)
                throw new Exception($"Could not accept car models of company {_INVALID_CAR_COMPANY_PEUGEOT}");
        
        
        }

        #endregion

    }
}
