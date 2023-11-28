using MySql.Data.MySqlClient;
using System;
using System.Xml.Linq;


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
            textBox3.Text = Convert.ToDecimal(price).ToString("C");

            price = connection.retrievePrice("KO");
            textBox4.Text = Convert.ToDecimal(price).ToString("C");

            price = connection.retrievePrice("MSFT");
            textBox5.Text = Convert.ToDecimal(price).ToString("C");

            price = connection.retrievePrice("INTC");
            textBox6.Text = Convert.ToDecimal(price).ToString("C");

            price = connection.retrievePrice("AMD");
            textBox7.Text = Convert.ToDecimal(price).ToString("C");

            price = connection.retrievePrice("GOOGL");
            textBox8.Text = Convert.ToDecimal(price).ToString("C");

            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            tabControl2.Appearance = TabAppearance.FlatButtons;
            tabControl2.ItemSize = new Size(0, 1);
            tabControl2.SizeMode = TabSizeMode.Fixed;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //load data into object
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                //1. create objects
                Users customer = new Users(textBox2.Text.ToString(), textBox1.Text.ToString()); //working
                Wallet custWall = new Wallet(customer.getUserId());

                // 1.5 validate password
                if (customer.validatePassword(customer.connectToMySQL(), customer.getPassword()) == false && customer.CheckExistance(customer.connectToMySQL()))
                {
                    //show error message
                    label5.Visible = true;
                }

                //2. hide labels and buttons
                //textBox1.Visible = false;
                //textBox2.Visible = false;
                //label1.Visible = false;

                //3. add information to database if it does not exist (add aditional objects)
                if (!customer.CheckExistance(customer.connectToMySQL()))
                {
                    //add customer and wallet (testing)
                    customer.InsertUser(customer.connectToMySQL());
                    custWall.insertNewWallet(custWall.connectToMySQL());

                    //more testing
                    // custWall.addMoneyToWallet(custWall.connectToMySQL(), 199.99);
                    //custWall.buyCoin(custWall.connectToMySQL(), 60.00, "bitcoin");

                    //customer.deleteUser(customer.connectToMySQL());
                }

                //4. Customer exist, load from database
                else
                {
                    custWall.databaseToObject(custWall.getuserId(), custWall.connectToMySQL());

                }
                //display user information if it exist on top section of screen
                //label2.Text = customer.getUserId();

                //more testing
                //Market mar = new Market();
                //List<double> values= mar.getCost()
                /*
                LiveConnection connection = new LiveConnection();
                string test = connection.retrievePrice("LTC");
                label3.Text = test.Substring(1, test.Length);
                */

                //switch user interface
                tabControl2.SelectedIndex = 1;
                label3.Visible = true;
                label3.Text = customer.getUserId();
                textBox9.Text = Convert.ToDecimal(custWall.getCashAvialable()).ToString("C");
                textBox10.Text = Convert.ToDecimal(custWall.getOverallValueDollar()).ToString("C");

            }

            else
            {
                //display error message
                label5.Visible = true;
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
            textBox3.Text = Convert.ToDecimal(price).ToString("C");

            price = connection.retrievePrice("KO");
            textBox4.Text = Convert.ToDecimal(price).ToString("C");

            price = connection.retrievePrice("MSFT");
            textBox5.Text = Convert.ToDecimal(price).ToString("C");

            price = connection.retrievePrice("INTC");
            textBox6.Text = Convert.ToDecimal(price).ToString("C");

            price = connection.retrievePrice("AMD");
            textBox7.Text = Convert.ToDecimal(price).ToString("C");

            price = connection.retrievePrice("GOOGL");
            textBox8.Text = Convert.ToDecimal(price).ToString("C");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            label20.Visible = false;
        }


        //requires testing below
        private void button3_Click(object sender, EventArgs e)
        {
            //remove list Box items
            listBox1.Items.Clear();

            //switch the winform tab to tab 2
            tabControl1.SelectedIndex = 1;

            //load new object with data from database
            Wallet wall = new Wallet(label3.Text);
            wall.databaseToObject(wall.getuserId(), wall.connectToMySQL());

            //pull wall values to local varaible for traversal
            List<double> localCurrencyCostPerShare = wall.getCurrencyCostPerShare();
            List<double> localShares = wall.getShares();
            List<string> localStock = wall.getStock();

            //load text box with values
            listBox1.BeginUpdate();
            int count = 0;

            foreach (string s in localStock)
            {
                listBox1.Items.Add("stock: " + localStock[count] + " shares: " + localShares[count] + " valued At: " + (localShares[count] * localCurrencyCostPerShare[count]));

                count++;
            }

            listBox1.EndUpdate();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //retrieve stock value for selected stock
            LiveConnection connection = new LiveConnection();
            label17.Text = connection.retrievePrice(textBox11.Text);
            label17.Visible = true;

            //retrive shares from database
            Wallet cust = new Wallet(label3.Text);
            

            try
            {
                cust.databaseToObject(label3.Text, cust.connectToMySQL());

                List<string> list = cust.getStock();
                List<double> list2 = cust.getShares();

                //update stock owned
                int i = 0;
                while (!list[i].Equals(textBox11.Text))
                {
                    i++;
                }

                

            }
            catch 
            {

                
            
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label20.Visible = false;

            if (!textBox11.Text.Equals("") && !textBox13.Text.Equals(""))
            {
                //load the database into the object
                Wallet wall = new Wallet(label3.Text);
                wall.databaseToObject(wall.getuserId(), wall.connectToMySQL());

                //commence trade
                bool val = wall.buyStock(wall.connectToMySQL(), Convert.ToDouble(textBox13.Text), textBox11.Text);

                if (val == false)
                {
                    label20.Visible = true;
                }

                //update database
                //wall.objectToDatabase(wall.connectToMySQL());

                //update values at top of page
                textBox9.Text = Convert.ToDecimal(wall.getCashAvialable()).ToString("C");
                textBox10.Text = Convert.ToDecimal(wall.getOverallValueDollar()).ToString("C");

                List<string> list = wall.getStock();
                List<double> list2 = wall.getShares();

                //update stock owned
                int i = 0;
                while (!list[i].Equals(textBox11.Text))
                {
                    i++;
                }

                
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label20.Visible = false;

            if (!textBox11.Text.Equals("") && !textBox10.Text.Equals(""))
            {
                //load the database into the object
                Wallet wall = new Wallet(label3.Text);
                wall.databaseToObject(wall.getuserId(), wall.connectToMySQL());

                //commence trade
                wall.sellStock(wall.connectToMySQL(), textBox11.Text.ToString().Replace('$', ' '), Convert.ToDouble((textBox14.Text).ToString().Replace('$', ' ')));

                //update values at top of page
                textBox9.Text = Convert.ToDecimal(wall.getCashAvialable()).ToString("C");
                textBox10.Text = Convert.ToDecimal(wall.getOverallValueDollar()).ToString("C");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Wallet wall = new Wallet(label3.Text);
            wall.databaseToObject(wall.getuserId(), wall.connectToMySQL());
            wall.addMoneyToWallet(wall.connectToMySQL(), Convert.ToDouble(textBox12.Text));

            

            //update values at top of page
            textBox9.Text = Convert.ToDecimal(wall.getCashAvialable()).ToString("C");
            textBox10.Text = Convert.ToDecimal(wall.getOverallValueDollar()).ToString("C");
        }
    }
}