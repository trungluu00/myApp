using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myApp.Cloud.Business.DesignPattern.FactoryMethod
{
    /// <summary>
    /// Sub Classes: các sub class sẽ implement các phương thức của supper class theo nghiệp vụ riêng của nó.
    /// </summary>
    public class DeluxePizza : IPizzaFactory
    {
        private decimal price = 12.5M;

        public decimal GetPrice()
        {
            return price;
        }
    }
}