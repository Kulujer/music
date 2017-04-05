using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace music
{
    /// <summary>
    /// Song类
    /// </summary>
    public class Model_Song
    {
        private static int id;
        private static string songname;
        private static string singername;
        private static string typename;
        private static string weburl;
        private static DateTime grapdatetime;
        private static DateTime hittime;
        private static int hits;
        public static int ID
        {
            set { id = value; }
            get { return id; }
        }
        public static string SongName
        {
            set { songname = value; }
            get { return songname; }
        }
        public static string SingerName
        {
            set { singername = value; }
            get { return singername; }
        }
        public static string TypeName
        {
            set { typename = value; }
            get { return typename; }
        }
        public static string WebUrl
        {
            set { weburl = value; }
            get { return weburl; }
        }
        public static DateTime GrapDateTime
        {
            set { grapdatetime = value; }
            get { return grapdatetime; }
        }
        public static DateTime HitTime
        {
            set { hittime = value; }
            get { return hittime; }
        }
        public static int Hits
        {
            set { hits = value; }
            get { return hits; }
        }
    }
}