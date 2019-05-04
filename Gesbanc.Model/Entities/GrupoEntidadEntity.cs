using System;
using System.Collections.Generic;
using System.Text;

namespace Gesbanc.Model.Entities
{
    public class GrupoEntidadEntity : BaseEntity
    {
        public string Nombre { get; set; }
        public string Color { get; set; }

        public  virtual List<EntidadEntity> Entidad { get; set; }
    }
}
