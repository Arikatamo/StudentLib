using StudentBlank.Controller;
using StudentBlank.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBlank
{
    public class ControllClass
    {
        public Student stud;
        public Facultet fac;
        public CatZaraH cat;
        public FormEdu form;
        public Sex sex;
        public Rating rating;
        public Subject subject;
        public Passport passport;
        public Residence residence;
        public Ratings Ratings;
        public FinImport finance;
        public CvalLvL cval;
        public ControllClass()
        {
            cval = new CvalLvL();
            finance = new FinImport();
            Ratings = new Ratings();
            residence = new Residence();
            passport = new Passport();
            subject = new Subject();
            rating = new Rating();
            sex = new Sex();
            form = new FormEdu();
            stud = new Student();
            fac = new Facultet();
            cat = new CatZaraH();
        }
    }
}
