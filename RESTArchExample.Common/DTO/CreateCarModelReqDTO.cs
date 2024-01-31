using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample.Common.DTO
{
    public class CreateCarModelReqDTO: IRequest<CreateCarModelRespDTO>
    {
        #region Public Attributes

        public string company {  get; set; }

        public string modelName { get; set; }

        public string specialEdition { get; set; }


        public int issueYear { get; set; }

        public double? bookPrice { get; set; }

        #endregion
    }
}
