using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample.Common.DTO
{
    public class GetCarModelRespDTO:GenericResponse
    {
        #region Public Attributes

        public CarModelDTO[] CarModels { get; set; }

        #endregion
    }
}
