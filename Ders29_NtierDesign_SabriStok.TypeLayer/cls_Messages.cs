using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ders29_NtierDesign_SabriStok.TypeLayer
{
    public class cls_Messages
    {
        public static string Ortak_Metod(string tabloadi,string CRUD,bool basarilimi)
        {
            string sonuc = "";
            if (basarilimi == true)
            {
                if (CRUD == "insert")
                {
                    sonuc = tabloadi + " tablosuna başarıyla kaydedildi.";
                }
                else if (CRUD == "update")
                {
                    sonuc = tabloadi + " tablosu başarıyla güncellendi.";
                }
                else if (CRUD == "delete")
                {
                    sonuc = tabloadi + " tablosundan başarıyla silindi.";
                }
                else
                {
                    sonuc = tabloadi + " CRUD işlemi yanlış seçildi!";
                }
            }
            else
            {
                if (CRUD == "insert")
                {
                    sonuc = tabloadi + " tablosuna kaydedilemedi.";
                }
                else if (CRUD == "update")
                {
                    sonuc = tabloadi + " tablosu güncellenemedi.";
                }
                else if (CRUD == "delete")
                {
                    sonuc = tabloadi + " tablosundan silinemedi.";
                }
                else
                {
                    sonuc = tabloadi + " CRUD işlemi yanlış seçildi!";
                }
            }
            return sonuc;
        }
    }
        
}
