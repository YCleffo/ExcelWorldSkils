//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExcelWorldSkils.View.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Journals
    {
        public int IdJournal { get; set; }
        public int IdStudent { get; set; }
        public Nullable<int> IdSubject { get; set; }
        public Nullable<int> Evaluation { get; set; }
        public Nullable<int> IdGroup { get; set; }
    
        public virtual Groups Groups { get; set; }
        public virtual Students Students { get; set; }
        public virtual Subjects Subjects { get; set; }
    }
}
