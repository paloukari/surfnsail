using System;
using System.Collections.Generic;
using System.Text;

namespace surfnsail.Code
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct)
]
    public class SportAttribute : System.Attribute
    {
        int _sportID = -1;
        public SportAttribute(int sportID)
        {
            SportID = sportID;
        }

        public int SportID
        {
            get
            {
                return _sportID;
            }

            set
            {
                _sportID = value;
            }
        }
    }

}
