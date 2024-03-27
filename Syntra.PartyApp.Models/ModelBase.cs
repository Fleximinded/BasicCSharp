using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntra.PartyApp.Models
{
    public class ModelBase
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
    }
}
