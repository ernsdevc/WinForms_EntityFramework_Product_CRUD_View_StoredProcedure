using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ders29_NtierDesign_SabriStok.DataLayer;

namespace Ders29_NtierDesign_SabriStok.BusinessLayer
{
    public class cls_BL_Markalar
    {
        public static List<Suppliers> Markalari_getir()
        {
            using (NORTHWNDEntities db = new NORTHWNDEntities())
            {
                List<Suppliers> suplist = db.Suppliers.ToList();
                return suplist;
            }
        }
    }
}
