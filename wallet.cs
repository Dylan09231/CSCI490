using System;
using System.Collections.Generic;

namespace app
{
	
	class wallet
	{
		//stores currency user invested in
		private List<string> curencies {get; set;}

		//stores U.S dollar equivalent
		private List<double> dollarList {get; set;}
		
		private string userId {get; set;}

		//overall value of wallet in dollars 
		private double overallValueDollar {get; set;}

		//constructor
		wallet(string user)
		{
			this.curencies = new List<string> {};
			this.dollarList = new List<double> {};
			this.userId = user;
			this.overallValueDollar = 0.00;  
		}

		int addCryptoToWallet(string crypto, double cost)
		{ 	try
			{
				this.curencies.Add(crypto);
				this.dollarList.Add(cost);
				this.overallValueDollar += cost;
			} 
			catch
			{
				return 1;
			}

			return 0;
		}

		//update with market values
		int updateCurencies( string cryptoName, double cost)
		{
			int count= 0;

    		foreach(string s in this.curencies )
			{
				if(s.Equals(cryptoName))
				{
					this.dollarList[count] = cost;
					return 0;
				}

				count++;
			}

			return 1;
		}

	}
}




