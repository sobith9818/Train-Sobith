using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobith_forma
{
    public class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string numercount { get; set; }
        public string passdelsts { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Date { get; set; }
        public string TrainNo { get; set; }
        public string TrainName { get; set; }
        public string ClassType { get; set; }
        public string Quota { get; set; }
    }
}
