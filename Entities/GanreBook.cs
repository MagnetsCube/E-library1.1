//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_library1._1.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class GanreBook
    {
        public int idGanreBook { get; set; }
        public int idBook { get; set; }
        public int idGanre { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Ganre Ganre { get; set; }
    }
}
