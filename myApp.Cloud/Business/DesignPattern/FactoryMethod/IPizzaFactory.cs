using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myApp.Cloud.Business.DesignPattern.FactoryMethod
{
    /// <summary>
    /// Super Class: môt supper class trong Factory Pattern có thể là một interface, abstract class hay một class thông thường.
    /// </summary>
    public interface IPizzaFactory
    {
        /// <summary>
        /// Return price
        /// </summary>
        /// <returns></returns>
        decimal GetPrice();
    }
}