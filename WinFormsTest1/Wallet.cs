﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using Org.BouncyCastle.Utilities.Collections;

namespace WinFormsTest1
{
    //add inheritance for Users
    public  class Wallet
    {
        private string userId;
        private double overallValueDollar;
        private double cashAvailable;
        private List<double> currencyCostPerShare;
        private List<double> shares;
        private List<string> stock;

        //constructor
        public Wallet(string userId)
        {
            this.userId = userId;
            this.overallValueDollar = 0.0;
            this.cashAvailable = 0.0;
            this.currencyCostPerShare = new List<double>();
            this.shares = new List<double>();
            this.stock = new List<string>();
        }

        //getters and setters
        public string getuserId()
        {
            return this.userId;
        }
        public double getCashAvialable()
        {
            return this.cashAvailable;
        }
        public double getOverallValueDollar()
        {
            return this.overallValueDollar;
        }

        public List<string> getStock()
        {
            return this.stock;
        }

        public List<double> getShares()
        {
            return this.shares;
        }

        public List<double> getCurrencyCostPerShare()
        {
            return this.currencyCostPerShare;
        }

        //update in database as well, add more MySQL methods
        public void setUserId(string id)
        {
            this.userId=id;

        }
        public void setOverallValueDollar(double overalVal)
        {
            this.overallValueDollar = overalVal;

        }

        public void setStock(List<string> cur)
        {
            this.stock = cur;
        }

        public void setCurrencyCostPerShare(List<double> curCost)
        {
            this.currencyCostPerShare = curCost;
        }

        public void setShares(List<double> shares)
        {
            this.shares = shares;
        }

        public void setCashAvialable(double cash)
        {
            this.cashAvailable = cash;
        }

        //MySQL methods (CSCI 330 citation) test section 2,3, and 4
        public MySqlConnection connectToMySQL()
        {
            //1. connection string
            string connectionString = "server=sql5.freesqldatabase.com;userid=sql5660962;password=ULGvZCFvPX;database=sql5660962";

            //2. load the connection string
            using var connection = new MySqlConnection(connectionString);

            //3. return connection
            return connection;
        }

        //similiar to a getter, loads object with values from database
        public void databaseToObject(string userId, MySqlConnection connection)
        {
            //1. set object userId
            this.userId = userId;

            //2. open connection
            connection.Open();

            //3. retrieve value of overall cost and cash available
            var wallet = "Select * from wallet where userId = '" + this.userId + "'" ;
            MySqlCommand command = new MySqlCommand(wallet, connection);
            var value = command.ExecuteReader();

            while (value.Read())
            {
                this.overallValueDollar = Convert.ToDouble(value[1].ToString());
                this.cashAvailable = Convert.ToDouble(value[2].ToString());
            }

            

            //4. close value
            value.Close();

            //5. retrieve columns of currencyCost and currencies
            var currency = "Select * from Currency where userId = '" + this.userId + "'";
            MySqlCommand command2 = new MySqlCommand(currency, connection);
            var value2 = command2.ExecuteReader();

            //6. declare/initialize new lists
            List<double> currencyCostPerShare = new List<double>();
            List<double> shares = new List<double>();
            List<string> stock = new List<string>();

            //7. loop through each column of
            while(value2.Read()) 
            {
                currencyCostPerShare.Add(Convert.ToDouble(value2[1]));
                shares.Add(Convert.ToDouble(value2[2]));
                stock.Add(Convert.ToString(value2[3]));
            }

            //8. attach new lists to object
            this.currencyCostPerShare = currencyCostPerShare;
            this.shares = shares;
            this.stock = stock;

            //9. close connections
            value2.Close();
            connection.Close();
        }

        //similiar to setter, loads database with values from object
        public void objectToDatabase(MySqlConnection connection)
        {
            //1. open connection
            connection.Open();

            //2. insert value of overall cost and cash available 
            var insertWallet = "INSERT INTO wallet (userId, overallValueDollar, cashAvailable) VALUES(@newUserId,@newOverallValueDollar, @newCashAvialble)";

            //3. Add parameters to wallet query
            MySqlCommand command = new MySqlCommand(insertWallet, connection);
            command.Parameters.AddWithValue("@newUserId", this.userId);
            command.Parameters.AddWithValue("@newOverallValueDollar", this.overallValueDollar);
            command.Parameters.AddWithValue("@newCashAvialble", this.cashAvailable);
            command.ExecuteNonQuery();

            //4. insert value of currencyCost and currency 
            var insertCurency = "INSERT INTO Curency (userId, currencyCostPerShare, shares, stock) VALUES(@newUserId,@newCurrencyCost, @newShares @newStock)";

            //5. Add parameters to wallet query
            MySqlCommand command2 = new MySqlCommand(insertCurency, connection);

            //6.add the respected values in a loop
            int count = 0;

            foreach (string s in this.stock)
            {
                command2.Parameters.AddWithValue("@newUserId", this.userId);
                command2.Parameters.AddWithValue("@newCurrencyCost", this.currencyCostPerShare[count]);
                command2.Parameters.AddWithValue("@newShares", this.shares[count]);
                command2.Parameters.AddWithValue("@newStock", this.stock[count]);
                command2.ExecuteNonQuery();

                count++;
            }

            //7. close connections
            connection.Close();
        }

        public Boolean CheckExistanceWallet(MySqlConnection connection)
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

            //4. insert statement for currency
            var insertCur = "INSERT INTO Currency (userId, currencyCostPerShare, shares, stock) VALUES(@newUserId,@newCurrencyCostPerShare, @newShares, @newStock)";

            //5. add parameters
            MySqlCommand command2 = new MySqlCommand(insertCur, connection);
            command2.Parameters.AddWithValue("@newUserId", this.userId);
            command2.Parameters.AddWithValue("@newCurrencyCostPerShare", this.currencyCostPerShare);
            command2.Parameters.AddWithValue("@newShares", this.shares);
            command2.Parameters.AddWithValue("@newStock", this.stock);

            //6. execute and close connection
            command.ExecuteNonQuery();
            command2.ExecuteNonQuery();
            connection.Close();
        }

        public void addMoneyToWallet(MySqlConnection connection, double add) 
        { 

            //2. update database
            connection.Open();

            //retrieve cash available from database
            var getWallet = "SELECT * from wallet WHERE userId = '" + this.userId + "'";
            MySqlCommand comm = new MySqlCommand(getWallet, connection);
            var val = comm.ExecuteReader();

            double cashTot = 0.0;

            if (val.Read())
            {
                cashTot = add + Convert.ToDouble(val[2]);
            }

            val.Close();

            this.cashAvailable = cashTot;

            //3. create the update string
            var updateWallet = "UPDATE wallet SET cashAvailable = "+ cashTot +" WHERE userId = '" +this.userId +"'";
            MySqlCommand command = new MySqlCommand(updateWallet, connection);
            command.ExecuteNonQuery();

            //4. close connection and terminate
            connection.Close();
        }

        //test when coin section is added, redo this for regular market
        public Boolean buyStock(MySqlConnection connection, double shares, string name)
        {
            //0. retrieve cost from live connection
            LiveConnection market = new LiveConnection();
            double cost = (Convert.ToDouble(market.retrievePrice(name))) * shares;

            //1.Make sure cash is available before continuing 
            if (this.cashAvailable < cost)
            {
                return false;
            }

            //2. open the connection
            connection.Open();

            //add values locally
            currencyCostPerShare.Add(Convert.ToDouble(market.retrievePrice(name)));
            this.shares.Add(shares);
            this.stock.Add(name);

            //3. insert statement for currencies
            var insertCurrency = "INSERT INTO Currency (userId, currencyCostPerShare, shares, stock) VALUES(@newUserId,@newCurrencyCostPerShare, @newshares, @newStock)";

            //4. retrieve coin values from database
            MySqlCommand command = new MySqlCommand(insertCurrency, connection);
            command.Parameters.AddWithValue("@newUserId", this.userId);
            command.Parameters.AddWithValue("@newCurrencyCostPerShare", market.retrievePrice(name));
            command.Parameters.AddWithValue("@newShares", shares);
            command.Parameters.AddWithValue("@newStock", name);

            //5. execute
            command.ExecuteNonQuery();

            //6. calculate overall cost overall 
            this.overallValueDollar = this.overallValueDollar + cost;

            //6. adjust overall value string
            var updateOverallVal = "UPDATE wallet SET overallValueDollar = " + this.overallValueDollar + " WHERE userId = '" + this.userId + "'";

            //7. make changes in database
            MySqlCommand command2= new MySqlCommand(updateOverallVal, connection);
            command2.ExecuteNonQuery();

            //8. subtract cost from available cash
            this.cashAvailable = this.cashAvailable - cost;

            //9. update cash avialable in database
            var updateCashAvailable = "UPDATE wallet SET cashAvailable = " + this.cashAvailable + " WHERE userId = '" + this.userId + "'";

            //7. make changes in database
            MySqlCommand command3 = new MySqlCommand(updateCashAvailable, connection);
            command3.ExecuteNonQuery();

            //terminate and close connection
            connection.Close();

            return true;
        }

        public void sellStock(MySqlConnection connection, string name, double shares)
        {

            //1. open the connection
            connection.Open();

            //2. select the corresponding row for currency 
            var selectCurrency = "Select * from Currency WHERE userId = '" + this.userId + "' AND stock = '" + name + "'";

            //3. retrieve stock value
            MySqlCommand command = new MySqlCommand(selectCurrency, connection);
            var currencyVal = command.ExecuteReader();

            double cost = 0.00;

            if (currencyVal.Read() )
            {
                //retrive cost
                cost = Convert.ToDouble(currencyVal[1]);

                //2. select the corresponding row for currency deletion
                var deleteCurrency = "Delete from Currency WHERE userId = '" + this.userId + "' AND stock = '" + name +"' AND shares = "+ shares ;
                MySqlCommand co = new MySqlCommand(deleteCurrency, connection);
                currencyVal.Close();
                co.ExecuteNonQuery();

                cost = cost * shares;
                this.cashAvailable = this.cashAvailable + cost;
                this.overallValueDollar = this.overallValueDollar - cost;

            }

            
            

        }

        //new object to update market values or new method?
    }
}
