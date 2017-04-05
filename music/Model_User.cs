using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace music
{
    public class Model_User
    {
        private static int id;
        private static string singername;
        private static int hits;
        private static DateTime hittime;
        private static DateTime graptime;
        public static int ID
        {
            set { id = value; }
            get { return id; }
        }
        public static string SingerName
        {
            set { singername = value; }
            get { return singername; }
        }
        public static int Hits
        {
            set { hits = value; }
            get { return hits; }
        }
        public static DateTime HitTime
        {
            set { hittime = value; }
            get { return hittime; }
        }
        public static DateTime GrapTime
        {
            set { graptime = value; }
            get { return graptime; }
        }

    }
}