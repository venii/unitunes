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
    
    public partial class Album
    {
        public Album()
        {
            this.Musica = new HashSet<Musica>();
            this.Autor = new HashSet<Autor>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public System.DateTime DataCriacao { get; set; }
    
        public virtual ICollection<Musica> Musica { get; set; }
        public virtual ICollection<Autor> Autor { get; set; }
    }
}
