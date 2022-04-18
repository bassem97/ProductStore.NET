using System;
using System.Collections.Generic;
using System.Text;

namespace TB.Service
{
    public static class MyExtensionProduct
    {
        public static void UpperName(this ProductManage pm) {

            foreach (var item in pm.Products)
            {
                item.Label = item.Label.ToUpper();
            }
        
        }

        public static bool InCategory(this ProductManage pm, string cat)
        {
            foreach (var item in pm.Products)
            {
                if (item.Category.Name.Equals(cat))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
