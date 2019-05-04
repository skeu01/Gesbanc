using System;
using System.Collections.Generic;
using System.Text;

namespace Gesbanc.Model.Entities
{
    public class EntidadEntity : BaseEntity
    {
        public int GrupoEntidadId { get; set; }
        public string Nombre { get; set; }
        public string Poblacion { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public string CodPostal { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Logo { get; set; }
        public bool Estado_Activo { get; set; }

        public virtual GrupoEntidadEntity GrupoEntidad { get; set; }
    }
}
