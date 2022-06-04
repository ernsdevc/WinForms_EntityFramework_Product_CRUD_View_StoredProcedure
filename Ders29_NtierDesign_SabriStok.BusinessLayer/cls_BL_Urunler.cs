using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ders29_NtierDesign_SabriStok.DataLayer;

namespace Ders29_NtierDesign_SabriStok.BusinessLayer
{
    public class cls_BL_Urunler
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public List<vw_urunlistesi> Urunleri_getir()
        {
            List<vw_urunlistesi> urnList = db.vw_urunlistesi.OrderByDescending(p => p.ProductID).ToList();
            return urnList;
        }

        public static bool urun_kaydet(string ProductName,decimal UnitPrice,short UnitsInStock,int CategoryID,int SupplierID)
        {
            using (NORTHWNDEntities db = new NORTHWNDEntities())
            {
                try
                {
                    db.sp_urun_insert(ProductName, UnitPrice, UnitsInStock, CategoryID, SupplierID);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool urun_guncelle(int ProductID,string ProductName, decimal UnitPrice, short UnitsInStock, int CategoryID, int SupplierID)
        {
            using (NORTHWNDEntities db = new NORTHWNDEntities())
            {
                try
                {
                    db.sp_urun_update(ProductID, ProductName, UnitPrice, UnitsInStock, CategoryID, SupplierID);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool urun_sil(int ProductID)
        {
            using (NORTHWNDEntities db = new NORTHWNDEntities())
            {
                try
                {
                    db.sp_urun_delete(ProductID);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static List<vw_urun_detay> urun_detay(int ProductID)
        {
            using (NORTHWNDEntities db = new NORTHWNDEntities())
            {
                List<vw_urun_detay> urn_detay = db.vw_urun_detay.Where(p => p.ProductID == ProductID).ToList();
                return urn_detay;
            }
        }
    }
}
