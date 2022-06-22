using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X_Forms.PersonenDb.Nav
{
    public class FlyoutMenueFlyoutMenuItem
    {
        public FlyoutMenueFlyoutMenuItem()
        {
            TargetType = typeof(FlyoutMenueFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}