using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class ProductController : ApiController
    {
        static List<Product> _productList = null;
        // GET: api/Product
        void Initialize()
        {
            _productList = new List<Product>()
            {
                new Product() { Id=1, Name="smartphones" , QtyInStock=10, Description="Apple Product", Supplier="Broadcom"},

               new Product() { Id=2, Name="ipad" , QtyInStock=15, Description="Apple Product", Supplier="Broadcom"},

            };
        }
        public ProductController()
        {
            if (_productList == null)
            {
                Initialize();
            }
        }
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _productList);
        }

        // GET: api/Product/5
        public HttpResponseMessage Get(int id)
        {
            Product product = _productList.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not Found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        // POST: api/Product
        public HttpResponseMessage Post(Product product)
        {
            if (product != null)
            {
                _productList.Add(product);
            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // PUT: api/Product/5
        public HttpResponseMessage Put(int id, Product objProduct)
        {
            Product product = _productList.Where(x => x.Id == id).FirstOrDefault();
            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found");
            }
            else
            {
                foreach (Product temp in _productList)
                {
                    if (temp.Id == id)
                    {
                        temp.Name = objProduct.Name;
                        temp.QtyInStock = objProduct.QtyInStock;
                        temp.Description = objProduct.Description;
                        temp.Supplier = objProduct.Supplier;
                    }
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Data Modified");
            }

        }

        // DELETE: api/Product/5
        public HttpResponseMessage Delete(int id)
        {

            Product product = _productList.Where(x => x.Id == id).FirstOrDefault();
            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found");
            }
            else
            {
                if (product != null)
                {
                    _productList.Remove(product);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }
        }
    }
}

        