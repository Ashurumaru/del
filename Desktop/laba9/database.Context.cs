﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace laba9
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dddEntities : DbContext
    {
        public dddEntities()
            : base("name=dddEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Договоры> Договоры { get; set; }
        public virtual DbSet<Поставлено> Поставлено { get; set; }
        public virtual DbSet<Поставщики> Поставщики { get; set; }
        public virtual DbSet<ФизическиеЛица> ФизическиеЛица { get; set; }
        public virtual DbSet<ЮридическиеЛица> ЮридическиеЛица { get; set; }
        public virtual DbSet<View_1> View_1 { get; set; }
        public virtual DbSet<View_2> View_2 { get; set; }
        public virtual DbSet<View_3> View_3 { get; set; }
    
        public virtual ObjectResult<sp_dgvr_agr_Result> sp_dgvr_agr(Nullable<System.DateTime> var1, Nullable<System.DateTime> var2)
        {
            var var1Parameter = var1.HasValue ?
                new ObjectParameter("var1", var1) :
                new ObjectParameter("var1", typeof(System.DateTime));
    
            var var2Parameter = var2.HasValue ?
                new ObjectParameter("var2", var2) :
                new ObjectParameter("var2", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_dgvr_agr_Result>("sp_dgvr_agr", var1Parameter, var2Parameter);
        }
    
        public virtual int sp_dgvr_mdf(string action, Nullable<int> nom_dgvr, Nullable<System.DateTime> dgvr_date, Nullable<int> dgvr_kod_post, string dgvr_comment)
        {
            var actionParameter = action != null ?
                new ObjectParameter("Action", action) :
                new ObjectParameter("Action", typeof(string));
    
            var nom_dgvrParameter = nom_dgvr.HasValue ?
                new ObjectParameter("nom_dgvr", nom_dgvr) :
                new ObjectParameter("nom_dgvr", typeof(int));
    
            var dgvr_dateParameter = dgvr_date.HasValue ?
                new ObjectParameter("dgvr_date", dgvr_date) :
                new ObjectParameter("dgvr_date", typeof(System.DateTime));
    
            var dgvr_kod_postParameter = dgvr_kod_post.HasValue ?
                new ObjectParameter("dgvr_kod_post", dgvr_kod_post) :
                new ObjectParameter("dgvr_kod_post", typeof(int));
    
            var dgvr_commentParameter = dgvr_comment != null ?
                new ObjectParameter("dgvr_comment", dgvr_comment) :
                new ObjectParameter("dgvr_comment", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dgvr_mdf", actionParameter, nom_dgvrParameter, dgvr_dateParameter, dgvr_kod_postParameter, dgvr_commentParameter);
        }
    }
}