using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Utilities.Collections;

namespace WinFormsTest1
{
    internal class Users
    {
        private string userId;
        private string password;

        //constructor
        public Users(string userId, string password)
        {
            this.userId = userId;
            this.password = password;
        }

        //getters and setters
        public string getUserId()
        {
            return this.userId;
        }
        public string getPassword()
        {
            return this.password;
        }

        public void setUserId(string userId)
        {
            this.userId = userId;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        //add an add cash function
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
            var user = "Select * from users";

            //3. load string and execute reader
            MySqlCommand command = new MySqlCommand(user, connection);
            var values = command.ExecuteReader();

            //4. check if username exist
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

        public void InsertUser(MySqlConnection connection)
        {
            //1. open the connection
            connection.Open();

            //2. insert statement
            var insert = "INSERT INTO users (userId, password) VALUES(@newUserId,@newPassword)";

            //3. Add parameters to query
            MySqlCommand command = new MySqlCommand(insert, connection);
            command.Parameters.AddWithValue("@newUserId", this.userId);
            command.Parameters.AddWithValue("@newPassword", this.password);

            //4. execute and close connection
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void deleteUser(MySqlConnection connection)
        {
            //1.open connection
            connection.Open();

            //2.delete with cascade
            var delete = ("DELETE from users WHERE userId = '" + this.userId + "'" );

            //3. add connection string
            MySqlCommand command = new MySqlCommand(delete, connection);
            
            //4. execute and terminate
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
