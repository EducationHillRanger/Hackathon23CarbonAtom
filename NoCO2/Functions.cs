using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoCO2.Controllers;

    public class Functions
    {
        private string key;

        private const string SYSTEMIS = "IMPERIAL";

        MySQLDatabase user = new MySQLDatabase();

        public Functions(string key) {
            this.key = key;
            // database.createNewUser(key);
        }

        public void setDailyTotalEmissions(string key, string amount) {
            user.setDailyTotalEmissions(key, amount);
            user.incrementTotalEmissions(key, amount);
        }

        public void incrementDailyTotalEmissions(string key, string amount) {
            user.incrementDailyTotalEmissions(key, amount);
            user.incrementTotalEmissions(key, amount);
        }

        public void setDailyTransportEmissions(string key, string amount) {
            user.setDailyTransportEmissions(key, amount);
            incrementDailyTotalEmissions(key, amount);
        }

        public void incrementDailyTransportEmissions(string key, string amount) {
            user.incrementDailyTransportEmissions(key, amount);
            incrementDailyTotalEmissions(key, amount);
        }

        public void setDailyClothingEmissions(string key, string amount) {
            user.setDailyClothingEmissions(key, amount);
            incrementDailyTotalEmissions(key, amount);
        }

        public void incrementDailyClothingEmissions(string key, string amount) {
            user.incrementDailyTransportEmissions(key, amount);
            incrementDailyTotalEmissions(key, amount);
        }

        public void setDailyFoodEmissions(string key, string amount) {
            user.setDailyFoodEmissions(key, amount);
            incrementDailyTotalEmissions(key, amount);
        }

        public void incrementDailyFoodEmissions(string key, string amount) {
            user.incrementDailyFoodEmissions(key, amount);
            incrementDailyTotalEmissions(key, amount);
        }



        public void updateDailyEmissions(string key, string amount) {
            // int temp = database.getDailyEmissions(key);
            // temp += amount;
            // database.setDailyEmissions(key, temp);
        }

        public double km(double km) {
            return km * 0.62;
        }

        public double mk(double miles) {
            return miles * 1.61;
        }

        public double lk(double lbs) {
            return lbs * 0.45;
        }

        public double kl(double kg) {
            return kg * 2.2;
        }

        public double gk(double grams) {
            return (grams / 1000);
        }

        public double kg(double kg) {
            return kg * 1000;
        }
        
    }
