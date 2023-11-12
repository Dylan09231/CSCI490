using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Utilities.Collections;

namespace WinFormsTest1
{
    //add inheritance for Users
    internal class Wallet
    {
        private string userId;
        private double overallValueDollar;
        private double cashAvailable;
        private List<double> currencyCost;
        private List<string> currencies;

        //constructor
        public Wallet(string userId)
        {
            this.userId = userId;
            this.overallValueDollar = 0.0;
            this.cashAvailable = 0.0;
            this.currencyCost = new List<double>();
            this.currencies = new List<string>();
        }

        //getters and setters
        public double getCashAvialable()
        {
            return this.cashAvailable;
        }
        public double getOverallValueDollar()
        {
            return this.overallValueDollar;
        }

        public List<string> getCurrencies()
        {
            return this.currencies;
        }

        public List<double> getCurrencyCost()
        {
            return this.currencyCost;
        }

        //update in database as well, add more MySQL methods

        public void setOverallValueDollar(double overalVal)
        {
            this.overallValueDollar = overalVal;

        }

        public void setCurrencies(List<string> cur)
        {
            this.currencies = cur;
        }

        public void setCurrencyCost(List<double> curCost)
        {
            this.currencyCost = curCost;
        }

        public void setCashAvialable(double cash)
        {
            this.cashAvailable = cash;
        }

        //MySQL methods (CSCI 330 citation)
        public MySqlConnection connectToMySQL()
        {
            //1. connection string
            string connectionString = "server=sql5.freesqldatabase.com;userid=sql5660962;password=ULGvZCFvPX;database=sql5660962";

            //2. load the connection string
            using var connection = new MySqlConnection(connectionString);

            //3. return connection
            return connection;
        }

        public Boolean CheckExistance(MySqlConnection connection)
        {
            //1. open connection
            connection.Open();

            //2. statement to get info from the database
            var wallet = "Select * from wallet";

            //3. load string and execute reader
            MySqlCommand command = new MySqlCommand(wallet, connection);
            var values = command.ExecuteReader();

            //4. check if username exist in wallet
            while (values.Read())
            {
                if (values[0].Equals(this.userId))
                {
                    values.Close();
                    return true;
                }
            }

            //close connections and return
            values.Close();
            connection.Close();
            return false;
        }

        public void insertNewWallet(MySqlConnection connection)
        {

            //1. open the connection
            connection.Open();

            //2. insert statement for wallet
            var insertWallet = "INSERT INTO wallet (userId, overallValueDollar, cashAvailable) VALUES(@newUserId,@newOverallValueDollar, @newCashAvialble)";

            //3. Add parameters to wallet query
            MySqlCommand command = new MySqlCommand(insertWallet, connection);
            command.Parameters.AddWithValue("@newUserId", this.userId);
            command.Parameters.AddWithValue("@newOverallValueDollar", this.overallValueDollar);
            command.Parameters.AddWithValue("@newCashAvialble", this.cashAvailable);


            //5. execute and close connection
            command.ExecuteNonQuery();
            connection.Close();
        }

        //test when coin section is added
        public Boolean buyCoin(MySqlConnection connection, double cost, string coinName)
        {
            //1.Make sure cash is available before continuing 
            if(this.cashAvailable < cost)
            {
                return false;
            }

            //2. open the connection
            connection.Open();

            //3. insert statement for currencies
            var insertCurrency = "INSERT INTO Currency (userId, currencyCost, currencies) VALUES(@newUserId,@newCurrencyCost, @newCurrencies)";

            //4. Add parameters to Currency query
            MySqlCommand command = new MySqlCommand(insertCurrency, connection);
            command.Parameters.AddWithValue("@newUserId", this.userId);
            command.Parameters.AddWithValue("@newCurrencyCost", cost);
            command.Parameters.AddWithValue("@newCurrencies", coinName);

            //5. execute
            command.ExecuteNonQuery();

            //6. calculate overall cost difference
            this.overallValueDollar = this.overallValueDollar - cost;

            //6. adjust overall value string
            var updateOverallVal = "UPDATE Wallet SET overallValueDollar = '" + this.overallValueDollar + "'WHERE userId = '" + this.userId + "'";

            //7. make changes in database
            MySqlCommand command2= new MySqlCommand(updateOverallVal, connection);
            command2.ExecuteNonQuery();

            //8. subtract cost from available cash
            this.cashAvailable = this.cashAvailable - cost;

            //9. update cash avialable in database
            var updateCashAvailable = "UPDATE Wallet SET cashAvailable = '" + this.cashAvailable + "'WHERE userId = '" + this.userId + "'";

            //7. make changes in database
            MySqlCommand command3 = new MySqlCommand(updateCashAvailable, connection);
            command2.ExecuteNonQuery();

            //terminate and close connection
            connection.Close();

            return true;
        }
    }
}
