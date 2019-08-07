using EcommerceApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApplication.Areas.Admin.AdminVM
{
    public class CreateProduct
    {
        public Product Products { get; set; }
        public List<Category> Category { get; set; }
    }
}