using System;


namespace WinFormsTest1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            //connect to market data
            LiveConnection connection = new LiveConnection();

            //load data into labels
            string price = connection.retrievePrice("LTC");
            label3.Text = "$" + price;

            price = connection.retrievePrice("KO");
            label5.Text = "$" + price;

            price = connection.retrievePrice("MSFT");
            label8.Text = "$" + price;

            price = connection.retrievePrice("INTC");
            label10.Text = "$" + price;

            price = connection.retrievePrice("AMD");
            label12.Text = "$" + price;

            price = connection.retrievePrice("GOOGL");
            label14.Text = "$" + price;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //load data into object
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                //1. create object
                Users customer = new Users(textBox2.Text.ToString(), textBox1.Text.ToString()); //working              

                //2. hide labels and buttons
                textBox1.Visible = false;
                textBox2.Visible = false;
                label1.Visible = false;

                //3. add information to database if it does not exist (add aditional objects)
                if (!customer.CheckExistance(customer.connectToMySQL()))
                {
                    //add customer and wallet (testing)
                    //customer.InsertUser(customer.connectToMySQL());
                    //Wallet custWall = new Wallet(customer.getUserId());
                    //custWall.insertNewWallet(custWall.connectToMySQL());

                    //more testing
                    // custWall.addMoneyToWallet(custWall.connectToMySQL(), 199.99);
                    //custWall.buyCoin(custWall.connectToMySQL(), 60.00, "bitcoin");

                    //customer.deleteUser(customer.connectToMySQL());
                }

                //4. display user information if it exist on top section of screen
                //label2.Text = customer.getUserId();

                //more testing
                //Market mar = new Market();
                //List<double> values= mar.getCost()
                /*
                LiveConnection connection = new LiveConnection();
                string test = connection.retrievePrice("LTC");
                label3.Text = test.Substring(1, test.Length);
                */

            }

            else
            {
                //display error message
            }




        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //connect to market data
            LiveConnection connection = new LiveConnection();

            //load data into labels
            string price = connection.retrievePrice("LTC");
            label3.Text = "$" +price;

            price = connection.retrievePrice("KO");
            label5.Text = "$" + price;

            price = connection.retrievePrice("MSFT");
            label8.Text = "$" + price;

            price = connection.retrievePrice("INTC");
            label10.Text = "$" + price;

            price = connection.retrievePrice("AMD");
            label12.Text = "$" + price;

            price = connection.retrievePrice("GOOGL");
            label14.Text = "$" + price;
        }
    }
}