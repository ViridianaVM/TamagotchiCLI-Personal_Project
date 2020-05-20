using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiPractice
{
    class Program
    {
        static string userAction;
        static int uAction;
        static public Dog cachito = new Dog("Cachito");
        static void Main(string[] args)
        {
            
            //Code above can be avoided if there is already a Tamagotchi initialized
            cachito.Bark();
            displayMenu();
       
        }

        static void displayMenu()
        {
            Console.WriteLine("Welcome Back! What do you want to do now?");
            Console.WriteLine("1. Feed my Tamagotchi" + "\n" + "2. Play with my Tamagotchi" + "\n" + "3. Take my Tamagotchi to a walk" + "\n" + "4. Put my Tamagotchi to sleep");
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
                        Console.WriteLine("What food will you choose to feed " + cachito.getName());
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
                                    break;
                                }
                            case 2:
                                {
                                    Food cheese = new Food(Food.FoodKind.CHEESE);
                                    cachito.EatCheese(cheese);
                                    break;
                                }
                            case 3:
                                {
                                    Food chocolate = new Food(Food.FoodKind.CHOCOLATE);
                                    cachito.EatChocolate(chocolate);
                                    break;
                                }
                            case 4:
                                {
                                    Food meat = new Food(Food.FoodKind.MEAT);
                                    cachito.EatMeat(meat);
                                    break;
                                }

                        } //Switch Kind of Food

                        break;
                    } //Switch option Feed

                case 2: //Play
                    {
                        cachito.Play();
                        Console.ReadLine();

                        /////////// RESTAR LA CANTIDAD DE CALORIAS GASTADAS  

                        cachito.StopPlaying();
                        Console.ReadLine();

                        break;
                    }

                case 3: //Walk
                    {
                        cachito.Walk();
                        Console.ReadLine();
                        break;
                    }

                case 4: //Sleep
                    {
                        cachito.Sleep();
                        Console.ReadLine();
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
    }
}



