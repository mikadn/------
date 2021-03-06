﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;
namespace kursach
{
    [Table]
    public class Uslugi
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID;
        [Column]
        public string Name;
        [Column]
        public int Cena; 
        [Column]
        public string Ed;       
    }
    public class DB13 : DataContext
    {
        public DB13(string cs) : base(cs) { }
        public System.Data.Linq.Table<Uslugi> Uslugi
        {
            get { return this.GetTable<Uslugi>(); }
        }

    }
    public class Met13
    {
        DB13 db13 = new DB13(kursach.Program.Pole.pole);
        public void ADD(string Name, int Cena, string Ed)
        {
            Uslugi pac = new Uslugi();
            pac.Name = Name;
            pac.Cena = Cena; 
            pac.Ed = Ed; 
            db13.Uslugi.InsertOnSubmit(pac);
            db13.SubmitChanges();
        }
        public void Edit(int ID, string Name, int Cena, string Ed)
        {
            Uslugi pac = db13.Uslugi.Where(c => c.ID == ID).FirstOrDefault();
            pac.Name = Name;
            pac.Cena = Cena;
            pac.Ed = Ed;
            db13.SubmitChanges();
        }
        public void Delete(string Name)
        {
            Uslugi pac = db13.Uslugi.Where(c => c.Name == Name).FirstOrDefault();
            db13.Uslugi.DeleteOnSubmit(pac);
            db13.SubmitChanges();
        }
        
    }
}
