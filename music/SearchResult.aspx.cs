using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace music
{
    public partial class SearchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static List<string> GetArray()
        {
            List<string> li = new List<string>();

            for (int i = 0; i < 10; i++)
                li.Add(i + "");

            return li;

        }    
    }
}