//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Unitunes.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Autor : Academico
    {
        public Autor()
        {
            this.MediaPublicadas = new HashSet<Media>();
        }
    
    
        public virtual ICollection<Media> MediaPublicadas { get; set; }
        public virtual Album Album { get; set; }
        public virtual Transacao Transacao1 { get; set; }
    }
}