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
    class Dog
    {
        private String m_name;
        private String m_size;
        //private Timer timer = new System.Timers.Timer();
        private Stopwatch m_stopwatch;
        private DateTime m_dob;
        private int m_dinnerAmounts;

        public Dog(String name)
        {
            m_name = name;
            m_size = "small";
            m_stopwatch = new Stopwatch();
            m_dob = DateTime.Now;
        }

        public Dog(String name, String size)
        {
            m_name = name;
            m_size = size;
            m_stopwatch = new Stopwatch();
            m_dob = DateTime.Now;
        }

        public String getName()
        {
            return m_name;
        }

        public String getSize()
        {
            return m_size;
        }

        public int getAge()
        {
            DateTime currentDate = DateTime.Now.AddDays(15);
            TimeSpan total = currentDate - m_dob;
            double totalDays = total.TotalDays;
            return (int)Math.Round(totalDays);
        }

        public void Bark()
        {
            Console.WriteLine("Woof Woof");
        }


        public void Play()
        {
            m_stopwatch.Start();
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
        }

        public void Eat()
        {
            //Food newMeal = new Food(Food.FoodKind.CHOCOLATE);


        }
    }
}
