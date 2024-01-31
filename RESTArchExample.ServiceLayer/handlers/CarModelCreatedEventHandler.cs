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
    public class CarModelCreatedEventHandler : IRequestHandler<CreateCarModelReqDTO, CreateCarModelRespDTO>
    {
        private readonly InventoryManagementLogic _logic;

        public CarModelCreatedEventHandler(InventoryManagementLogic logic)
        {
            _logic = logic;
        }

        public async Task<CreateCarModelRespDTO> Handle(CreateCarModelReqDTO notification, CancellationToken cancellationToken)
        {
            // Lógica específica del manejador de eventos, ahora recibe el DTO directamente
            CreateCarModelRespDTO resp = _logic.CreateCarModel(notification);
            return resp;
        }
    }
}
