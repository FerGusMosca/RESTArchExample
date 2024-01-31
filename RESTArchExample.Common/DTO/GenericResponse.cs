using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample.Common.DTO
{
    public class GenericResponse
    {
        #region Public Attributes

        public bool success {  get; set; }

        public string error { get;set; }

        #endregion
    }
}
