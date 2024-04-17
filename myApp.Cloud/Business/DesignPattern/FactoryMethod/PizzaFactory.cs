using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myApp.Cloud.Business.DesignPattern.FactoryMethod
{
    /// <summary>
    /// Factory Class: một class chịu tránh nhiệm khởi tạo các đối tượng sub class dựa theo tham số đầu vào. 
    /// Lưu ý: lớp này là Singleton hoặc cung cấp một public static method cho việc truy xuất và khởi tạo đối tượng. 
    /// Factory class sử dụng if-else hoặc switch-case để xác định class con đầu ra.
    /// </summary>
    public class PizzaFactory
    {
        public enum PizzaType
        {
            HamAndMushroom,
            Seafood,
            Deluxe
        }

        public IPizzaFactory CreatePizza(PizzaType pizzaType)
        {
            switch (pizzaType)
            {
                case PizzaType.HamAndMushroom:
                    return new HamAndMushroomPizza();
                case PizzaType.Seafood:
                    return new SeefoodPizza();
                case PizzaType.Deluxe:
                    return new DeluxePizza();
                default:
                    return new HamAndMushroomPizza();
            }
        }
    }
}