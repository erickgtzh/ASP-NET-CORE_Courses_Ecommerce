using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApplication.ViewModels.Card
{
    public class CardIndexVM
    {
        public CardIndexVM()
        {
            CardProductVMList = new List<CardProductVM>();
        }

        public List<CardProductVM> CardProductVMList { get; set; }

        public decimal CardTotalPrice { get; set; }
    }
}
