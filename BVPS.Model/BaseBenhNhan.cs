using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVPS.Model
{
    public class BaseBenhNhan
    {
        public BaseBenhNhan(string MaBN)
        {
            this.MaBN = MaBN;
        }

        public BaseBenhNhan()
        {

        }

        public bool FlagNeedSync { set; get; }

        public string MaBN { protected set; get; }
        public int Id { set; get; }
    }
}
