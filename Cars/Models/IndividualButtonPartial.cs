using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class IndividualButtonPartial
    {
        public string ButtonType { get; set; }
        public string Action { get; set; }
        public string Glyph { get; set; }
        public string Text { get; set; }

        public int? ServiceId { get; set; }
        public string ActionParameters
        {
            get
            {
                var param = new StringBuilder(@"/");

                if ((null != ServiceId) && (0 != ServiceId))
                {
                    param.Append(string.Format("{0}", ServiceId));
                }

                return param.ToString();
            }
        }
    }
}
