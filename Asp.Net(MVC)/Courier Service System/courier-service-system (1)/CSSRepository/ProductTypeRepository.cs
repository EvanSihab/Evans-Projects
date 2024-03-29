﻿using CSSEntity;
using CSSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSRepository
{
    public class ProductTypeRepository : Repository<ProductType>,IProductTypeRepository
    {
        private DataContext context;

        public ProductTypeRepository() { this.context = DataContext.getInstance(); }

        public int UpdateProductType(ProductType pt)
        {
                ProductType ptToUpdate = this.context.ProductTypes.SingleOrDefault(t => t.Id == pt.Id);
                ptToUpdate.ShipmentCost = Convert.ToInt32(pt.ShipmentCost);
                ptToUpdate.Vat =Convert.ToInt32(pt.Vat);
                return this.context.SaveChanges();
        }
        public List<ProductType> GetAllTypeForCheck(ProductType productType)
        {
            return (this.context.ProductTypes.Where(pd => pd.Name == productType.Name)).ToList();
        }
    }
}
