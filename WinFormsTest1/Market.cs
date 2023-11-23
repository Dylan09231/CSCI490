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

    internal class Market
    {
        private List <string> coin;
        private List <double> cost;

        public Market()
        {
            
        }

        //getters
        public List<string> getCoin()
        {
            return this.coin;
        }

        public List<double> getCost()
        {
            return this.cost;
        }

        //setters

        public void setCoin(List<string> value)
        {
            this.coin = value;

        }

        public void setCost(List<double> cost)
        {
            this.cost = cost;
        }

        

    }
}
