using MediatR;
using RESTArchExample.Common.DTO;
using RESTArchExample.LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample.ServiceLayer.handlers
{
    public class GetCarModelsEventHandler : IRequestHandler<GetCarModelReqDTO, GetCarModelRespDTO>
    {
        private readonly InventoryManagementLogic _logic;

        public GetCarModelsEventHandler(InventoryManagementLogic logic)
        {
            _logic = logic;
        }


        public async Task<GetCarModelRespDTO> Handle(GetCarModelReqDTO request, CancellationToken cancellationToken)
        {
            // Lógica específica del manejador de eventos, ahora recibe el DTO directamente
            GetCarModelRespDTO resp = _logic.GetCarModels(request);
            return resp;
        }
    }
}
