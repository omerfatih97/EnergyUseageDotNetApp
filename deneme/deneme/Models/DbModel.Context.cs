//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace deneme.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DbModels : DbContext
    {
        public DbModels()
            : base("name=DbModels")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<resimler> resimlers { get; set; }
        public virtual DbSet<QR_Code> QR_Code { get; set; }
    
        public virtual ObjectResult<string> KullaniciBilgiAl(string kullanici_adi, string sifre)
        {
            var kullanici_adiParameter = kullanici_adi != null ?
                new ObjectParameter("kullanici_adi", kullanici_adi) :
                new ObjectParameter("kullanici_adi", typeof(string));
    
            var sifreParameter = sifre != null ?
                new ObjectParameter("sifre", sifre) :
                new ObjectParameter("sifre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("KullaniciBilgiAl", kullanici_adiParameter, sifreParameter);
        }
    }
}
