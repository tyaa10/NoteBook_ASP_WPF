//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NoteBook.Domain.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Nullable<int> user_type_id { get; set; }
    
        //[ForeignKey("State")]
        //public virtual State State { get; set; }
    }
}
