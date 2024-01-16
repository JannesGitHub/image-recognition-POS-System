using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Services
{

    public interface IChangeWeightService
    {
        public double NewWeight { get; set; }
    }


    public class ChangeWeightService : IChangeWeightService
    {
        public double NewWeight { get; set;}
    }
}
