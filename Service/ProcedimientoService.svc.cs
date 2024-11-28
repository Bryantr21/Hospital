using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Hospital.Models;

namespace Hospital.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ProcedimientoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ProcedimientoService.svc o ProcedimientoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ProcedimientoService : IProcedimientoService
    {
        private readonly HospitalesEntities _context;
        public ProcedimientoService()
        {
            _context = new HospitalesEntities();
        }
       
    }
}
