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
        private int id;
        private string songname;
        private string singername;
        private string typename;
        private string weburl;
        private DateTime grapdatetime;
        private DateTime hittime;
        private int hits;
        public int ID
        {
            set { id = value; }
            get { return id; }
        }
        public string SongName
        {
            set { songname = value; }
            get { return songname; }
        }
        public string SingerName
        {
            set { singername = value; }
            get { return singername; }
        }
        public string TypeName
        {
            set { typename = value; }
            get { return typename; }
        }
        public string WebUrl
        {
            set { weburl = value; }
            get { return weburl; }
        }
        public DateTime GrapDateTime
        {
            set { grapdatetime = value; }
            get { return grapdatetime; }
        }
        public DateTime HitTime
        {
            set { hittime = value; }
            get { return hittime; }
        }
        public int Hits
        {
            set { hits = value; }
            get { return hits; }
        }
    }
}