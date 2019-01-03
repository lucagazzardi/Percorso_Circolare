using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Enumeratori
{
    public class ResourceStatus
    {
        public enum Status
        {
            [Description("Disponibile")]
            Available = 1,

            [Description("Non disponibile")]
            Unavailable = 2
        }

        public static string GetDescription(Status status)
        {
            Type type = status.GetType();

            var desc = (DescriptionAttribute[])type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if(desc.Length > 0)
            {
                return desc[0].Description;
            }

            return status.ToString();                
        }
    }

    
}
