//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ders29_NtierDesign_SabriStok.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NORTHWNDEntities : DbContext
    {
        public NORTHWNDEntities()
            : base("name=NORTHWNDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<vw_urunlistesi> vw_urunlistesi { get; set; }
        public virtual DbSet<vw_urun_detay> vw_urun_detay { get; set; }
    
        public virtual int sp_urun_delete(Nullable<int> productID)
        {
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_urun_delete", productIDParameter);
        }
    
        public virtual int sp_urun_insert(string productName, Nullable<decimal> unitPrice, Nullable<short> unitsInStock, Nullable<int> categoryID, Nullable<int> supplierID)
        {
            var productNameParameter = productName != null ?
                new ObjectParameter("ProductName", productName) :
                new ObjectParameter("ProductName", typeof(string));
    
            var unitPriceParameter = unitPrice.HasValue ?
                new ObjectParameter("UnitPrice", unitPrice) :
                new ObjectParameter("UnitPrice", typeof(decimal));
    
            var unitsInStockParameter = unitsInStock.HasValue ?
                new ObjectParameter("UnitsInStock", unitsInStock) :
                new ObjectParameter("UnitsInStock", typeof(short));
    
            var categoryIDParameter = categoryID.HasValue ?
                new ObjectParameter("CategoryID", categoryID) :
                new ObjectParameter("CategoryID", typeof(int));
    
            var supplierIDParameter = supplierID.HasValue ?
                new ObjectParameter("SupplierID", supplierID) :
                new ObjectParameter("SupplierID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_urun_insert", productNameParameter, unitPriceParameter, unitsInStockParameter, categoryIDParameter, supplierIDParameter);
        }
    
        public virtual int sp_urun_update(Nullable<int> productID, string productName, Nullable<decimal> unitPrice, Nullable<short> unitsInStock, Nullable<int> categoryID, Nullable<int> supplierID)
        {
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            var productNameParameter = productName != null ?
                new ObjectParameter("ProductName", productName) :
                new ObjectParameter("ProductName", typeof(string));
    
            var unitPriceParameter = unitPrice.HasValue ?
                new ObjectParameter("UnitPrice", unitPrice) :
                new ObjectParameter("UnitPrice", typeof(decimal));
    
            var unitsInStockParameter = unitsInStock.HasValue ?
                new ObjectParameter("UnitsInStock", unitsInStock) :
                new ObjectParameter("UnitsInStock", typeof(short));
    
            var categoryIDParameter = categoryID.HasValue ?
                new ObjectParameter("CategoryID", categoryID) :
                new ObjectParameter("CategoryID", typeof(int));
    
            var supplierIDParameter = supplierID.HasValue ?
                new ObjectParameter("SupplierID", supplierID) :
                new ObjectParameter("SupplierID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_urun_update", productIDParameter, productNameParameter, unitPriceParameter, unitsInStockParameter, categoryIDParameter, supplierIDParameter);
        }
    }
}
