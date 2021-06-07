using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Pi_Estate.Models;

namespace Pi_Estate.Data
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var sehir = new List<Sehir>()
            {
                new Sehir() {SehirName="İSTANBUL"},
                new Sehir() {SehirName="ANKARA"},
                new Sehir() {SehirName="İZMİR"},
                new Sehir() {SehirName="BURSA"},
            };
            foreach (var item in sehir)
            {
                context.Sehirs.Add(item);
            }
            context.SaveChanges();
            var semt = new List<Semt>()
            {
                new Semt() {SemtName = "KADIKÖY",SehirId = 1},
                new Semt() {SemtName = "GÜNGÖREN",SehirId = 1},
                new Semt() {SemtName = "BAKIRKÖY",SehirId = 1},
                new Semt() {SemtName = "BEŞİKTAŞ",SehirId = 1},

              
                new Semt() {SemtName = "KIZILAY",SehirId = 2},
                new Semt() {SemtName = "MAMAK",SehirId = 2},
                new Semt() {SemtName = "PURSAKLAR",SehirId = 2},

                new Semt() {SemtName = "KARŞIYAKA",SehirId = 3},
                new Semt() {SemtName = "BOSTANLI",SehirId = 3},
                new Semt() {SemtName = "BORNOVA",SehirId = 3},
                new Semt() {SemtName = "ALSANCAK",SehirId = 3},

                new Semt() {SemtName = "NİLÜFER",SehirId = 4},
                new Semt() {SemtName = "MUDANYA",SehirId = 4},
                new Semt() {SemtName = "EMEK",SehirId = 4},
            };
            foreach (var item in semt)
            {
                context.Semts.Add(item);
            }
            context.SaveChanges();

            var mahalle = new List<Mahalle>()
            {
                new Mahalle() {MahalleName = "ARNAVUTKÖY",SehirId = 1},

                new Mahalle() {MahalleName = "NAMIKKEMAL",SehirId = 2},

                new Mahalle() {MahalleName = "CUMHURİYET",SehirId = 3},


                new Mahalle() {MahalleName = "ALTINŞEHİR",SehirId = 4},

            };
            foreach (var item in mahalle)
            {
                context.Mahalles.Add(item);
            }
            context.SaveChanges();

            var durum = new List<Durum>()
            {
                new Durum() {DurumName = "KİRALIK"},
                new Durum() {DurumName = "SATILIK"},
            };
            foreach (var item in durum)
            {
                context.Durums.Add(item);
            }
            context.SaveChanges();

            var tip = new List<Tip>()
            {
                new Tip() {TipName = "EV", DurumId = 1},
                new Tip() {TipName = "DÜKKAN", DurumId = 1},
                new Tip() {TipName = "EV", DurumId = 2},
                new Tip() {TipName = "DÜKKAN", DurumId = 2},
            };
            foreach (var item in tip)
            {
                context.Tips.Add(item);
            }
            context.SaveChanges();

            var ilan = new List<Ilan>()
            {
                new Ilan {Açıklama="ev güzel", Adres="şan sokak", OdaSayisi=5,BanyoSayisi=2,Kredi=true,Fiyat=25000,MahalleId=1,SemtId=1,SehirId=1,DurumId=1,TipId=1,Alan=250,Telefon="02126121212",Kat="3.kat",UserName="METEHAN"},
                new Ilan {Açıklama="ev güzel", Adres="şan sokak", 
                OdaSayisi=3,BanyoSayisi=1,Kredi=true,Fiyat=15000,MahalleId=2,SemtId=2,SehirId=2,DurumId=2,TipId=2,Alan=150,Telefon="02416414141",Kat="2.kat",UserName="METE"},
                new Ilan {Açıklama="ev güzel", Adres="şan sokak", OdaSayisi=4,BanyoSayisi=1,Kredi=true,Fiyat=18000,MahalleId=3,SemtId=3,SehirId=3,DurumId=3,TipId=3,Alan=145,Telefon="05055552525",Kat="1.kat",UserName="METECAN"},
                new Ilan {Açıklama="ev güzel", Adres="şan sokak", OdaSayisi=5,BanyoSayisi=1,Kredi=true,Fiyat=25000,MahalleId=4,SemtId=4,SehirId=4,DurumId=4,TipId=4,Alan=110,Telefon="05444441444",Kat="4.kat",UserName="METEKAN"}

            };
            foreach (var item in ilan)
            {
                context.Ilans.Add(item);
            }
            context.SaveChanges();
            var resim = new List<Resim>()
            {
                new Resim() {ResimName="1.jpg", IlanId=1},
                new Resim() {ResimName="2.jpg", IlanId=1},

                new Resim() {ResimName="3.jpg", IlanId=2},
            };
            foreach (var item in resim)
            {
                context.Resims.Add(item);
            }
            context.SaveChanges();
            base.Seed(context); 
        }
    }
}
