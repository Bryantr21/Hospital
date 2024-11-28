using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Hospital.Models;

namespace Hospital.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EspecialidadeService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EspecialidadeService.svc o EspecialidadeService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EspecialidadeService : IEspecialidadeService
    {
        private readonly HospitalesEntities _context;
        public EspecialidadeService()
        {
            _context = new HospitalesEntities();
        }
        public void DoWork()
        {
        }
    }
}
