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
    
    public partial class Whislist
    {
        public Whislist()
        {
            this.MediaDesejadas = new HashSet<Media>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
    
        public virtual ICollection<Media> MediaDesejadas { get; set; }
    }
}