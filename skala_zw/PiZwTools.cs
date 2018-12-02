using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Media.Imaging;

using zzd = ZwSoft.ZwCAD.DatabaseServices;
using zza = ZwSoft.ZwCAD.ApplicationServices;
using zzc = ZwSoft.ZwCAD.Colors;
using zzg = ZwSoft.ZwCAD.Geometry;
using zze = ZwSoft.ZwCAD.EditorInput;

namespace skala_zw
{
    public class PiZwTools
    {
        /// <summary>
        /// Zwraca ścieżkę do katalofu z programem
        /// </summary>
        public static string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// Zamienia png na bmp
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        public static BitmapImage Konwersja_bitmap_bitmapimage_png(Bitmap bm)
        {
            var memory = new MemoryStream();
            bm.Save(memory, ImageFormat.Png);
            memory.Position = 0;
            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = memory;
            bmp.CacheOption = BitmapCacheOption.OnLoad;
            bmp.EndInit();
            return bmp;
        }

        /// <summary>
        /// Wstawia bloki niezbędne do budowy stylów wymiarowania
        /// </summary>        
        public static void Wymiary_bloki()
        {
            // Get the current database and start a transaction
            zzd.Database db;
            db = zza.Application.DocumentManager.MdiActiveDocument.Database;

            using (zzd.Transaction tr = db.TransactionManager.StartTransaction())
            {
                // Open the Block table for read
                zzd.BlockTable bt;
                bt = tr.GetObject(db.BlockTableId, zzd.OpenMode.ForRead) as zzd.BlockTable;
                string grotbeton = "PI_grotbeton";
                if (!bt.Has(grotbeton))
                {
                    using (zzd.BlockTableRecord btr = new zzd.BlockTableRecord())
                    {
                        btr.Name = grotbeton;
                        // Set the insertion point for the block
                        btr.Origin = new zzg.Point3d(0, 0, 0);


                        // Add a circle to the block
                        zzd.Circle kolo = new zzd.Circle();
                        kolo.Center = new zzg.Point3d(0, 0, 0);
                        kolo.Radius = 0.7;
                        kolo.Color = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 1);
                        kolo.Linetype = "Continuous";
                        // Add the new object to the block table record and the transaction
                        btr.AppendEntity(kolo);
                        // Create a line
                        zzd.Line pionline = new zzd.Line();
                        pionline.StartPoint = new zzg.Point3d(0, 4, 0);
                        pionline.EndPoint = new zzg.Point3d(0, -4, 0);
                        pionline.Color = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 1);
                        pionline.Linetype = "Continuous";
                        btr.AppendEntity(pionline);


                        // Create a line
                        zzd.Line pozline = new zzd.Line();

                        pozline.StartPoint = new zzg.Point3d(-4, 0, 0);
                        pozline.EndPoint = new zzg.Point3d(4, 0, 0);
                        pozline.Color = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 1);
                        pozline.Linetype = "Continuous";
                        btr.AppendEntity(pozline);

                        bt.UpgradeOpen();
                        bt.Add(btr);
                        tr.AddNewlyCreatedDBObject(btr, true);
                    }
                }

                string grotstal = "PI_grotstal";

                if (!bt.Has(grotstal))
                {
                    using (zzd.BlockTableRecord btr1 = new zzd.BlockTableRecord())
                    {
                        btr1.Name = grotstal;
                        // Set the insertion point for the block
                        btr1.Origin = new zzg.Point3d(0, 0, 0);

                        //linia pionowa
                        zzd.Line pionline = new zzd.Line();
                        pionline.StartPoint = new zzg.Point3d(0, 2, 0);
                        pionline.EndPoint = new zzg.Point3d(0, -2, 0);
                        pionline.Color = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 1);
                        pionline.Linetype = "Continuous";
                        btr1.AppendEntity(pionline);
                        //linia pozioma
                        zzd.Line pozline = new zzd.Line();
                        pozline.StartPoint = new zzg.Point3d(-4, 0, 0);
                        pozline.EndPoint = new zzg.Point3d(0, 0, 0);
                        pozline.Color = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 1);
                        pozline.Linetype = "Continuous";
                        btr1.AppendEntity(pozline);
                        //strzałka
                        zzd.Polyline strzalka = new zzd.Polyline();
                        strzalka.AddVertexAt(0, new zzg.Point2d(0, 0), 0, 0, 0);
                        strzalka.AddVertexAt(0, new zzg.Point2d(-2, 0.5), 0, 0, 0);
                        strzalka.AddVertexAt(0, new zzg.Point2d(-2, -0.5), 0, 0, 0);
                        strzalka.AddVertexAt(0, new zzg.Point2d(0, 0), 0, 0, 0);
                        strzalka.Color = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 1);
                        strzalka.Linetype = "Continuous";
                        btr1.AppendEntity(strzalka);

                        bt.UpgradeOpen();
                        bt.Add(btr1);
                        tr.AddNewlyCreatedDBObject(btr1, true);
                    }
                }

                string grotzbrojenie = "PI_grotzbrojenie";

                if (!bt.Has(grotzbrojenie))
                {
                    using (zzd.BlockTableRecord btr2 = new zzd.BlockTableRecord())
                    {
                        btr2.Name = grotzbrojenie;
                        // Set the insertion point for the block
                        btr2.Origin = new zzg.Point3d(0, 0, 0);

                        //linia pionowa
                        zzd.Line pionline = new zzd.Line();
                        pionline.StartPoint = new zzg.Point3d(0, 2, 0);
                        pionline.EndPoint = new zzg.Point3d(0, -2, 0);
                        pionline.Color = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 1);
                        pionline.Linetype = "Continuous";
                        btr2.AppendEntity(pionline);
                        //linia pozioma
                        zzd.Line pozline = new zzd.Line();
                        pozline.StartPoint = new zzg.Point3d(-4, 0, 0);
                        pozline.EndPoint = new zzg.Point3d(0, 0, 0);
                        pozline.Color = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 1);
                        pozline.Linetype = "Continuous";
                        btr2.AppendEntity(pozline);
                        //strzałka
                        zzd.Polyline strzalka = new zzd.Polyline();
                        strzalka.AddVertexAt(0, new zzg.Point2d(-2, 1), 0, 0, 0);
                        strzalka.AddVertexAt(0, new zzg.Point2d(0, 0), 0, 0, 0);
                        strzalka.AddVertexAt(0, new zzg.Point2d(-2, -1), 0, 0, 0);
                        strzalka.Color = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 2);
                        strzalka.Linetype = "Continuous";
                        btr2.AppendEntity(strzalka);

                        bt.UpgradeOpen();
                        bt.Add(btr2);
                        tr.AddNewlyCreatedDBObject(btr2, true);
                    }
                }

                string grotarch = "PI_grotplany";

                if (!bt.Has(grotarch))
                {
                    using (zzd.BlockTableRecord btr3 = new zzd.BlockTableRecord())
                    {
                        btr3.Name = grotarch;
                        // Set the insertion point for the block
                        btr3.Origin = new zzg.Point3d(0, 0, 0);

                        //linia pionowa
                        zzd.Line pionline = new zzd.Line();
                        pionline.StartPoint = new zzg.Point3d(0, 4, 0);
                        pionline.EndPoint = new zzg.Point3d(0, -4, 0);
                        pionline.Color = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 1);
                        pionline.Linetype = "Continuous";
                        btr3.AppendEntity(pionline);
                        //linia pozioma
                        zzd.Line pozline = new zzd.Line();
                        pozline.StartPoint = new zzg.Point3d(-4, 0, 0);
                        pozline.EndPoint = new zzg.Point3d(4, 0, 0);
                        pozline.Color = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 1);
                        pozline.Linetype = "Continuous";
                        btr3.AppendEntity(pozline);
                        //przekreslenie
                        zzd.Line przline = new zzd.Line();
                        przline.StartPoint = new zzg.Point3d(-1, -1, 0);
                        przline.EndPoint = new zzg.Point3d(1, 1, 0);
                        przline.Color = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 2);
                        przline.Linetype = "Continuous";
                        btr3.AppendEntity(przline);

                        bt.UpgradeOpen();
                        bt.Add(btr3);
                        tr.AddNewlyCreatedDBObject(btr3, true);
                    }
                }

                //Save the new object to the database
                tr.Commit();
                // Dispose of the transaction
            }
        }

        /// <summary>
        /// Tworzy styl wymiarowania PI_STANDARD
        /// </summary>        
        public static void Dodaj_styl_PI_STANDARD()
        {
            string nazwastylu = "PI_STANDARD";
            zza.Document doc = zza.Application.DocumentManager.MdiActiveDocument;
            zzd.Database db = doc.Database;

            using (zzd.Transaction tr = db.TransactionManager.StartTransaction())
            {
                zzd.DimStyleTable DimTabb = (zzd.DimStyleTable)tr.GetObject(db.DimStyleTableId, zzd.OpenMode.ForRead);
                zzd.ObjectId dimId = zzd.ObjectId.Null;
                if (!DimTabb.Has(nazwastylu))
                {
                    DimTabb.UpgradeOpen();
                    zzd.DimStyleTableRecord newRecord = new zzd.DimStyleTableRecord();
                    //nazwa stylu wymiarowania
                    newRecord.Name = nazwastylu;
                    //styl tekstu
                    newRecord.Dimtxsty = Dodaj_styl_PI_DIMENSIONTEXT();
                    //określenie liczby miejsc wyświetlanych w precyzyjnych wymiarach kątowych.
                    newRecord.Dimadec = 0;
                    //dodanie alternatywnych wymiarów
                    newRecord.Dimalt = false;
                    //usytuowanie napisu w stosunku do linii
                    newRecord.Dimtad = 1;
                    //rysować tekst zawsze poziomo? 
                    newRecord.Dimtih = false;
                    // rysować tekst nnawet jak się nie mieści
                    newRecord.Dimtix = false;
                    //rozmiar strzałki
                    newRecord.Dimasz = 1;
                    //zmienna dimsah na false wtedy stosowany jest grot strzałki wskazany przez zmienną DIMBLK
                    newRecord.Dimsah = false;
                    //ustawienie grotu strzałek
                    zzd.ObjectId id1 = GetArrowObjectId("DIMBLK", "PI_grotplany");
                    newRecord.Dimblk = id1;
                    //kolor tekstu
                    newRecord.Dimclrt = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 2);
                    //kolor lini wymiaru
                    newRecord.Dimclrd = zzc.Color.FromColorIndex(zzc.ColorMethod.ByAci, 1);
                    //ukrycie pierwszej linii pomocniczej
                    newRecord.Dimse1 = true;
                    //ukrycie drugiej linii pomocniczej
                    newRecord.Dimse2 = true;
                    //miejsc po przecinku
                    newRecord.Dimdec = 1;
                    //wysikość tekstu
                    newRecord.Dimtxt = 2.0;
                    //odległość tekstu od linii
                    newRecord.Dimgap = 1;
                    // tekst w odnośniku zawsze poziomo
                    newRecord.Dimtoh = false;
                    //przemnożenie jednostki
                    newRecord.Dimlfac = 100;
                    //ukrywanie zer końcowych
                    newRecord.Dimzin = 8;
                    newRecord.Dimscale = 1;


                    dimId = DimTabb.Add(newRecord);
                    tr.AddNewlyCreatedDBObject(newRecord, true);
                }
                else
                {
                    dimId = DimTabb[nazwastylu];
                }
                //ustawiamy utworzony styl jako aktualny
                zzd.DimStyleTableRecord DimTabbRecaord = (zzd.DimStyleTableRecord)tr.GetObject(dimId, zzd.OpenMode.ForRead);
                if (DimTabbRecaord.ObjectId != db.Dimstyle)
                {
                    db.Dimstyle = DimTabbRecaord.ObjectId;
                    db.SetDimstyleData(DimTabbRecaord);
                }
                tr.Commit();
            }
        }

        /// <summary>
        /// Tworzy styl tekstu PI_DIMENSION
        /// </summary>
        /// <returns></returns>        
        public static zzd.ObjectId Dodaj_styl_PI_DIMENSIONTEXT()
        {
            zza.Document doc = zza.Application.DocumentManager.MdiActiveDocument;
            zzd.Database db = doc.Database;
            string name = "PI_DIMENSIONTEXT";

            zzd.ObjectId dimstyleID;

            using (zzd.Transaction tr = db.TransactionManager.StartTransaction())
            {
                zzd.TextStyleTable tst = (zzd.TextStyleTable)tr.GetObject(db.TextStyleTableId, zzd.OpenMode.ForWrite);

                if (!tst.Has(name))
                {
                    tst.UpgradeOpen();
                    zzd.TextStyleTableRecord newRecord = new zzd.TextStyleTableRecord();
                    newRecord.Name = name;
                    newRecord.FileName = "simplex.shx";
                    newRecord.XScale = 0.65; // Width factor
                    tst.Add(newRecord);
                    tr.AddNewlyCreatedDBObject(newRecord, true);
                    dimstyleID = tst[name];
                }
                else
                {
                    dimstyleID = tst[name];
                }
                tr.Commit();
                return dimstyleID;
            }

        }

        /// <summary>
        /// Pobiera blok. który można użyć jako strzałkę
        /// </summary>
        /// <param name="arrow"></param>
        /// <param name="newArrName"></param>
        /// <returns></returns>        
        public static zzd.ObjectId GetArrowObjectId(string arrow, string newArrName)

        {
            zzd.ObjectId arrObjId = zzd.ObjectId.Null;
            zza.Document doc = zza.Application.DocumentManager.MdiActiveDocument;
            zzd.Database db = doc.Database;
            string oldArrName = zza.Application.GetSystemVariable(arrow) as string;
            zza.Application.SetSystemVariable(arrow, newArrName);
            if (oldArrName.Length != 0)
                zza.Application.SetSystemVariable(arrow, oldArrName);
            zzd.Transaction tr = db.TransactionManager.StartTransaction();
            using (tr)
            {
                zzd.BlockTable bt = (zzd.BlockTable)tr.GetObject(db.BlockTableId, zzd.OpenMode.ForRead);
                arrObjId = bt[newArrName];
                tr.Commit();
            }
            return arrObjId;
        }

        /// <summary>
        /// Pobiera wartość zmiennej dimscala
        /// </summary>
        /// <returns></returns>        
        public static double DIMSCALA()
        {
            double wartosc = Convert.ToDouble(zza.Application.GetSystemVariable("DIMSCALE"));
            return wartosc;
        }

        /// <summary>
        /// Pobiera wartość zmiennej INSUNITS
        /// </summary>
        /// <returns></returns>
        public static double INSUNITS()
        {
            double wartosc = Convert.ToDouble(zza.Application.GetSystemVariable("INSUNITS"));
            return wartosc;
        }

        /// <summary>
        /// Pobiera wartość zmiennej DIMDEC
        /// </summary>
        /// <returns></returns>
        public static double DIMDEC()
        {
            double wartosc = Convert.ToDouble(zza.Application.GetSystemVariable("DIMDEC"));
            return wartosc;
        }

        /// <summary>
        /// Pobiera wartość zmiennej DIMLFAC
        /// </summary>
        /// <returns></returns>
        public static double DIMLFAC()
        {
            double wartosc = Convert.ToDouble(zza.Application.GetSystemVariable("DIMLFAC"));
            return wartosc;
        }        

        public static void UstawINSUNITS(int wartosc_insunits)
        {
            zza.Application.SetSystemVariable("INSUNITS", wartosc_insunits);
        }
        public static void UstawDIMDEC(int wartosc)
        {
            zza.Application.SetSystemVariable("DIMDEC", wartosc);
        }
        /// <summary>
        /// Ustawia styl grotów
        /// </summary>
        /// <param name="grot"></param>
        public static void Ustawstyl(string grot)
        {
            zza.Application.SetSystemVariable("DIMBLK", grot);
        }

        /// <summary>
        /// Ustastawia dokładność wymiarowania
        /// </summary>
        /// <param name="value"></param>        
        public static void Ustawdokladnosc(double value)
        {
            zza.Application.SetSystemVariable("DIMLFAC", value);
        }

        /// <summary>
        /// Ustawia zmienną dimscala przy podaniu skali
        /// </summary>
        /// <param name="skala"></param>        
        public static void Ustawdimscale(double skala)
        {
            double skalawymiarow = 0.001 * skala;
            zza.Application.SetSystemVariable("DIMSCALE", skalawymiarow);
            zza.Application.SetSystemVariable("DIMFIT", 4);
        }

    }
}
