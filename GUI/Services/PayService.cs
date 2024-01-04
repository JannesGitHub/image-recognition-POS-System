using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Services
{
    public interface IPayService
    {
        public double TotalPrice { get; set; }
    }

    public class PayService : IPayService
    {
        public double TotalPrice { get; set; }
    }
}
