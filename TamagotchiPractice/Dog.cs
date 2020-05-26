using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace TamagotchiPractice
{
    [Serializable]
    class Dog
    {
        public String Name { get; set; }
        public String Size { get; set; }
        private static Stopwatch m_stopwatch;
        private DateTime m_dob;
        public int m_totalKalories;
        private Food chocolateMeal = new Food(Food.FoodKind.CHOCOLATE);
        private Food cheeseMeal = new Food(Food.FoodKind.CHEESE);
        private Food veggiesMeal = new Food(Food.FoodKind.VEGGIES);
        private Food meatMeal = new Food(Food.FoodKind.MEAT);

        public Dog(String name)
        {
            Name = name;
            Size = "small";
            m_stopwatch = new Stopwatch();  //Timer to Play
            m_dob = DateTime.Now;           //For timer to play
        }

        public Dog(String name, String size)
        {
            Name = name;
            Size = size;
            m_stopwatch = new Stopwatch();
            m_dob = DateTime.Now;
        }


        public int getAge()
        {
            DateTime currentDate = DateTime.Now.AddDays(15);   //Adding 15 days to date
            TimeSpan total = currentDate - m_dob;
            double totalDays = total.TotalDays;
            return (int)Math.Round(totalDays);
        }

        public int getKalories()
        {
            return m_totalKalories;
        }

        public void Bark()
        {
            Console.WriteLine("Woof Woof");
        }

        /// <summary>
        /// PLAYING FUNCTIONS
        /// </summary>
        public void Play()
        {
            if (m_totalKalories < 50)
            {
                Console.WriteLine("Sorry! I am not string enough to play right now! I need more energy or go to sleep.");
            }
            else
            {
                //Right now will rest just 50 kal. But it should rest the kalories according to the time playing
                m_totalKalories -= 50;
                m_stopwatch.Start();
                Console.WriteLine(Name + " has started to play!");
            }
            
        }

        public void StopPlaying()
        {
            m_stopwatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = m_stopwatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("Time Playing " + elapsedTime);
            m_stopwatch.Reset();
            Console.WriteLine(Name + " just stoped playing.");
        }


        /// <summary>
        /// EATING FUNCTIONS
        /// </summary>

        public void EatChocolate(Food chocolateMeal)
        {
            m_totalKalories = m_totalKalories + chocolateMeal.getCalories();
            if (m_totalKalories < 350)
            {
                Console.WriteLine("Thanks for the chocolate but I am still hungry. I will need to eat more later!");
            }
            else
            {
                Console.WriteLine("Thanks for the chocolate! I am so full that I don't need to ear for the rest of the day");
            }
        }

        public void EatCheese(Food cheeseMeal)
        {
            m_totalKalories = m_totalKalories + cheeseMeal.getCalories();
            if (m_totalKalories < 350)
            {
                Console.WriteLine("Thanks for the cheese but I am still hungry. I will need to eat more later!");
            }
            else
            {
                Console.WriteLine("Thanks for the cheese! I am so full that I don't need to eat for the rest of the day");
            }
        }

        public void EatVeggies(Food veggiesMeal)
        {
            m_totalKalories = m_totalKalories + veggiesMeal.getCalories();
            if (m_totalKalories < 350)
            {
                Console.WriteLine("Thanks for the veggies but I am still hungry. I will need to eat more later!");
            }
            else
            {
                Console.WriteLine("Thanks for the veggies! I am so full that I don't need to eat for the rest of the day");
            }
        }

        public void EatMeat(Food meatMeal)
        {
            m_totalKalories = m_totalKalories + meatMeal.getCalories();
            if (m_totalKalories < 350)
            {
                Console.WriteLine("Thanks for the meat but I am still hungry. I will need to eat more later!");
            }
            else
            {
                Console.WriteLine("Thanks for the meat! I am so full that I don't need to eat for the rest of the day");
            }
        }


        /// <summary>
        /// SLEEPING FUNCTION
        /// </summary>
        /// 
        public void Sleep()
        {
            Console.WriteLine("I'll go and rest. Thanks");
            m_totalKalories += 50;
        }


        /// <summary>
        /// WALKING FUNCTION
        /// </summary>
        /// 
        public void Walk()
        {
            if (m_totalKalories < 50)
            {
                Console.WriteLine("Sorry. I don't have enough energy to walk. I need to eat or rest");
            }
            else
            {
                m_totalKalories -= 50;
                Console.WriteLine("Woof! I am super excited to walk with you!");
            }
            
        }

        public void DisplayInfo()
        {
            Console.WriteLine("                               __                ||");
            Console.WriteLine("            ,               , \" e`--o            ||");
            Console.WriteLine("           ((              (  | __,-'            ||  My name is " + Name + ".");
            Console.WriteLine("            \\\\~------------'\\_;/                 ||  I am " + getAge() + " days old.");
            Console.WriteLine("            (                  /                 ||  My total kalories so far:" + m_totalKalories);
            Console.WriteLine("            /).____________.  )                  ||");
            Console.WriteLine("           (( (           (( (                   ||");
            Console.WriteLine("            ``-'           ``-'                  ||");
        }


        //CREAR UNA FUNCION QUE SE LLAME TOSTRING
        //SE MANDA A LLAMAR CUANDO HAGA DISPLAYINFO PARA MOSTRAR EL ASCCII DEL PERRITO Y TODA SU INFO

    }
}
