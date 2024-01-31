using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample.Common.DTO
{
    public class GetCarModelReqDTO : IRequest<GetCarModelRespDTO>
    {
        #region Public Attributes

        [FromQuery]
        public string? company { get; set; }

        [FromQuery]
        public string? modelName { get; set; }

        [FromQuery]
        public string? specialEdition { get; set; }


        [FromQuery]
        public int? issueYear { get; set; }

       
        #endregion
    }
}
