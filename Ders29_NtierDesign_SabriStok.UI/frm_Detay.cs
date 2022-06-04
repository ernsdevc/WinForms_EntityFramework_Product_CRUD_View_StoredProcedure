using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ders29_NtierDesign_SabriStok.BusinessLayer;
using Ders29_NtierDesign_SabriStok.DataLayer;

namespace Ders29_NtierDesign_SabriStok.UI
{
    public partial class frm_Detay : Form
    {
        public frm_Detay()
        {
            InitializeComponent();
        }

        int listviewID = 0;

        public frm_Detay(int listviewID) : this()
        {
            this.listviewID = listviewID;
        }

        private void frm_Detay_Load(object sender, EventArgs e)
        {
            using (NORTHWNDEntities db = new NORTHWNDEntities())
            {
                lbl_productID.Text = listviewID.ToString();
                List<vw_urun_detay> urn_detay = cls_BL_Urunler.urun_detay(listviewID);
                foreach (var item in urn_detay)
                {
                    lbl_productname.Text = item.ProductName.ToString();
                    lbl_quantityperunit.Text = item.QuantityPerUnit.ToString();
                    lbl_unitsonorder.Text = item.UnitsOnOrder.ToString();
                    lbl_reorderlevel.Text = item.ReorderLevel.ToString();
                    if (Convert.ToInt32(item.Discontinued) == 0)
                    {
                        lbl_discontinued.Text = "Pasif";
                    }
                    else
                    {
                        lbl_discontinued.Text = "Aktif";
                    }
                }
            }
        }
    }
}
