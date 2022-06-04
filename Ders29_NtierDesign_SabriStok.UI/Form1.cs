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
using Ders29_NtierDesign_SabriStok.TypeLayer;

namespace Ders29_NtierDesign_SabriStok.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kategoriDoldur();
            markaDoldur();
            listviewDoldur();
        }
        void kategoriDoldur()
        {
            List<Categories> catlist = cls_BL_Kategoriler.Kategorileri_getir();
            foreach (var item in catlist)
            {
                cmb_kategori.Items.Add(item.CategoryName);
            }
        }

        void markaDoldur()
        {
            List<Suppliers> suplist = cls_BL_Markalar.Markalari_getir();
            foreach (var item in suplist)
            {
                cmb_marka.Items.Add(item.CompanyName);
            }
        }
        void listviewDoldur()
        {
            lst_urunler.Items.Clear();
            cls_BL_Urunler c = new cls_BL_Urunler();
            List<vw_urunlistesi> gelenUrunler = c.Urunleri_getir();

            foreach (var item in gelenUrunler)
            {
                ListViewItem lv = new ListViewItem();

                lv.Text = item.ProductID.ToString();
                lv.SubItems.Add(item.ProductName);
                lv.SubItems.Add(item.UnitPrice.ToString());
                lv.SubItems.Add(item.UnitsInStock.ToString());
                lv.SubItems.Add(item.CategoryName);
                lv.SubItems.Add(item.CompanyName);
                lst_urunler.Items.Add(lv);
            }
        }

        void temizle()
        {
            txt_urunAdi.Text = txt_Fiyat.Text = txt_Stok.Text = "";
            cmb_kategori.SelectedIndex = -1;
            cmb_marka.SelectedIndex = -1;
        }

        private void btn_Kaydet_Click(object sender, EventArgs e)
        {
            if (txt_urunAdi.Text != "" && txt_Fiyat.Text != "" && txt_Stok.Text != "" && cmb_kategori.Text != "" && cmb_marka.Text != "")
            {
                if (listviewID == 0)
                {
                    bool sonuc = cls_BL_Urunler.urun_kaydet(txt_urunAdi.Text, Convert.ToInt32(txt_Fiyat.Text), Convert.ToInt16(txt_Stok.Text), cmb_kategori.SelectedIndex + 1, cmb_marka.SelectedIndex + 1);
                    listviewDoldur();
                    temizle();

                    if (sonuc == true)
                    {
                        MessageBox.Show(cls_Messages.Ortak_Metod("Ürün", "insert", true));
                    }
                    else
                    {
                        MessageBox.Show(cls_Messages.Ortak_Metod("Ürün", "insert", false));
                    }
                }
                else
                {
                    MessageBox.Show("Bu ürün zaten kayıtlı.");
                }
            }
            else
            {
                MessageBox.Show("Ürün Bilgilerini Giriniz!");
            }
        }

        public static int listviewID;

        private void lst_urunler_Click(object sender, EventArgs e)
        {
            listviewID = Convert.ToInt32(lst_urunler.FocusedItem.SubItems[0].Text);
            txt_urunAdi.Text = lst_urunler.FocusedItem.SubItems[1].Text;
            txt_Fiyat.Text = lst_urunler.FocusedItem.SubItems[2].Text;
            txt_Stok.Text = lst_urunler.FocusedItem.SubItems[3].Text;
            cmb_kategori.Text = lst_urunler.FocusedItem.SubItems[4].Text;
            cmb_marka.Text = lst_urunler.FocusedItem.SubItems[5].Text;
        }

        private void btn_Guncelle_Click(object sender, EventArgs e)
        {
            if (listviewID > 0)
            {
                bool sonuc = cls_BL_Urunler.urun_guncelle(listviewID, txt_urunAdi.Text, Convert.ToDecimal(txt_Fiyat.Text), Convert.ToInt16(txt_Stok.Text), cmb_kategori.SelectedIndex + 1, cmb_marka.SelectedIndex + 1);
                listviewDoldur();
                temizle();

                if (sonuc == true)
                {
                    MessageBox.Show(cls_Messages.Ortak_Metod("Ürün", "update", true));
                    listviewID = 0;
                }
                else
                {
                    MessageBox.Show(cls_Messages.Ortak_Metod("Ürün", "update", false));
                }
            }
            else
            {
                MessageBox.Show("Listeden Ürün Seçiniz!");
            }
        }

        private void btn_Sil_Click(object sender, EventArgs e)
        {
            if (listviewID > 0)
            {
                bool sonuc = cls_BL_Urunler.urun_sil(listviewID);
                
                if (sonuc == true)
                {
                    listviewDoldur();
                    MessageBox.Show(cls_Messages.Ortak_Metod("Ürün", "delete", true));
                    temizle();
                    listviewID = 0;
                }
                else
                {
                    MessageBox.Show(cls_Messages.Ortak_Metod("Ürün", "delete", false));
                }
            }
            else
            {
                MessageBox.Show("Listeden Ürün Seçiniz!");
            }
        }

        private void btn_Detay_Click(object sender, EventArgs e)
        {
            if (listviewID > 0)
            {
                frm_Detay f = new frm_Detay(listviewID);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Listeden Ürün Seçiniz!");
            }
        }
    }
}
