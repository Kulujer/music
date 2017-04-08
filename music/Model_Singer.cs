using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace music
{
    public class Model_Singer
    {
        private Guid id;
        private string singername;
        private int hits;
        private DateTime hittime;
        private DateTime graptime;
        public Guid ID
        {
            set { id = value; }
            get { return id; }
        }
        public string SingerName
        {
            set { singername = value; }
            get { return singername; }
        }
        public int Hits
        {
            set { hits = value; }
            get { return hits; }
        }
        public DateTime HitTime
        {
            set { hittime = value; }
            get { return hittime; }
        }
        public DateTime GrapTime
        {
            set { graptime = value; }
            get { return graptime; }
        }

    }
}