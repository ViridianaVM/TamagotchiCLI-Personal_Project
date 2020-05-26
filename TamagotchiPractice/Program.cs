using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.CodeDom.Compiler;

namespace TamagotchiPractice
{
    class Program
    {
        static string userAction;  //To read action from UI
        static int uAction;        //User action converted to int
        private const string DATA_FILENAME = "TamagotchiInformation.dat";  //To save Tamagotchi info
        static public Dog cachito = new Dog("Cachito");
        static void Main(string[] args)
        {

            //Code above can be avoided if there is already a Tamagotchi initialized
            LoadInfo();
            cachito.Bark();
            displayInfo();
            displayMenu();
       
        }

        static void displayMenu()
        {
            Console.WriteLine("Welcome Back! What do you want to do now?");
            Console.WriteLine("1. Feed my Tamagotchi" + "\n" + "2. Play with my Tamagotchi" + "\n" + "3. Take my Tamagotchi to a walk" + "\n" + "4. Put my Tamagotchi to sleep" + "\n" + "5. Display my info" + "\n" + "6. Exit");
            userAction = Console.ReadLine();
            uAction = Convert.ToInt32(userAction);
            Console.Clear();
            actionToTake();
        }

        static void actionToTake()
        {
            switch (uAction)
            {
                case 1:  //Feed
                    {
                        string foodKind;
                        int food;
                        Console.WriteLine("What food will you choose to feed " + cachito.Name);
                        Console.WriteLine("1. Veggies" + "\n" + "2. Cheese" + "\n" + "3. Chocolate" + "\n" + "4. Meat");
                        foodKind = Console.ReadLine();
                        food = Convert.ToInt32(foodKind);
                        Console.Clear();

                        switch (food)
                        {
                            case 1:
                                {
                                    Food veggies = new Food(Food.FoodKind.VEGGIES);
                                    cachito.EatVeggies(veggies);
                                    //Console.ReadLine();
                                    break;
                                }
                            case 2:
                                {
                                    Food cheese = new Food(Food.FoodKind.CHEESE);
                                    cachito.EatCheese(cheese);
                                    Console.ReadLine();
                                    break;
                                }
                            case 3:
                                {
                                    Food chocolate = new Food(Food.FoodKind.CHOCOLATE);
                                    cachito.EatChocolate(chocolate);
                                    Console.ReadLine();
                                    break;
                                }
                            case 4:
                                {
                                    Food meat = new Food(Food.FoodKind.MEAT);
                                    cachito.EatMeat(meat);
                                    break;
                                }

                        } //Switch Kind of Food
                        SaveInfo();
                        break;
                    } //Switch option Feed

                case 2: //Play
                    {
                        cachito.Play();
                        Console.ReadLine();

                        /////////// RESTAR LA CANTIDAD DE CALORIAS GASTADAS  

                        cachito.StopPlaying();
                        Console.ReadLine();
                        SaveInfo();
                        break;
                    }

                case 3: //Walk
                    {
                        cachito.Walk();
                        Console.ReadLine();
                        SaveInfo();
                        break;
                    }

                case 4: //Sleep
                    {
                        cachito.Sleep();
                        Console.ReadLine();
                        SaveInfo();
                        break;
                    }

                case 5: //Display Info
                    {
                        cachito.DisplayInfo();
                        Console.ReadLine();
                        break;
                    }
                case 6: //Exit
                    {
                        //SaveInfo();
                        Console.Clear();
                        Console.WriteLine("See you later!");
                        Console.ReadLine();
                        System.Environment.Exit(1);
                        break;

                    }

                default:
                    {
                        Console.WriteLine("Sorry. This option is invalid. Try again");
                        displayMenu();
                        break;
                    }
            }
            Console.Clear();
            displayMenu();
        }

        public static void SaveInfo()
        {
            try
            {
                // Create a FileStream that will write data to file.
                Stream myStream = File.Create(DATA_FILENAME);
                BinaryFormatter formatter = new BinaryFormatter();
                // Save current dog object created
                formatter.Serialize(myStream, cachito);
                myStream.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to save Tamagotchi's information");
                Console.Write(ex.Message);
                Console.ReadLine();
            }
        }

        public static void LoadInfo()
        {

            // Check if there is already information of a Tamagotchi
            if (File.Exists(DATA_FILENAME))
            {
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    // Create a FileStream will gain read access to the data file.
                    FileStream readerFileStream = new FileStream(DATA_FILENAME, FileMode.Open, FileAccess.Read);
                    // Reconstruct information of our friends from file.
                    cachito = (Dog)formatter.Deserialize(readerFileStream);
                    // Close the readerFileStream when we are done
                    readerFileStream.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("There seems to be a file that contains TamagotchiPractice's information but somehow there is a problem with reading it.");
                    Console.Write(ex.Message);
                    Console.ReadLine();
                } // end try-catch

            } 

        } // end LoadInfo()

        static void displayInfo()
        {
            Console.WriteLine("Current Total Calories: " + cachito.m_totalKalories);

        }
    }
}



