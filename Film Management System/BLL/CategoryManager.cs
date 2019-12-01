using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Film_Management_System.DAL;
using Film_Management_System.Models;

namespace Film_Management_System.BLL
{
    public class CategoryManager
    {
        CategoryGateway categoryGateway = new CategoryGateway();

        public List<Category> GetAllCategories()
        {
            return categoryGateway.GetAllCategories();
        }
    }
}