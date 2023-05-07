using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoCO2.Controllers;

    public class Functions
    {
        // variable to convert gallon to liters
        private readonly double literInGallon = 4.54;

        // variable to convert liter to Kg of Co2
        private readonly double literToKgCo2 = 2.68;

        // data for food average emissions
        readonly Dictionary<string, double> foodEmissions = new()
        {
            { "Beef", 0.155 },
            { "Lamb", 0.0584 },
            { "Prawns", 0.0407 },
            { "Cheese", 0.0279 },
            { "Pork", 0.024 },
            { "Chicken", 0.0182 },
            { "Fish", 0.0134 },
            { "Chocolate", 0.019 },
            { "Egg", 0.0053 },
            { "Tomato", 0.00213 },
            { "Berries", 0.001527 },
            { "Rice", 0.0016 },
            { "Banana", 0.11 },
            { "Tofu", 0.0008 },
            { "Apple", 0.06 },
            { "Brassicas", 0.0005 },
            { "Nuts", 0.0005 },
            { "Orange", 0.05 },
            { "Potatoes", 0.0005 },
            { "Root Vegetables", 0.0004 }
        };
        // data for fabric average emissions
        readonly Dictionary<string, double> fabrics = new()
        {
            { "Wool", 13.89 },
            { "Acrylic Fabric", 11.53 },
            { "Cotton", 8.3 },
            { "Silk", 7.63 },
            { "Nylon", 7.31 },
            { "Polyester", 6.4 },
            { "Linen", 5.4 }
        };
        // driving calcuation, returns a string of total emissions from varaibles
        public string DrivingCalculation(string mpg, string distance)
        {
            double gallons = int.Parse(distance) / int.Parse(mpg);
            double litersConversion = literInGallon * gallons;
            double kgOfCo2 = litersConversion * literToKgCo2;
            return kgOfCo2.ToString();
        }
        // food calculations, returns a string of total emissions from variables
        public string FoodCalculation(string foodName, string amount)
        {
            double emissionPerUnitOfFood = foodEmissions[foodName];
            return (emissionPerUnitOfFood * int.Parse(amount)).ToString();
        }
        // clothes calculations, returns a string of total emissions from variables
        public string ClothesCalculation(string clothesMaterial, string amount)
        {
            double emissionPerFabric = fabrics[clothesMaterial];
            return (emissionPerFabric * int.Parse(amount)).ToString();
        }
    }
