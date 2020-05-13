using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamagotchiPractice
{
    class Food
    {
        private int m_kalories;
        public enum FoodKind
        {
            VEGGIES, CHEESE, CHOCOLATE, MEAT
        }

        public Food (FoodKind kind)
        {
            switch(kind)
            {
                case FoodKind.VEGGIES:
                {
                    m_kalories = 50;
                    break;
                }
                case FoodKind.CHEESE:
                {
                    m_kalories = 150;
                    break;
                }
                case FoodKind.CHOCOLATE:
                {
                    m_kalories = 200;
                    break;
                }
                case FoodKind.MEAT:
                {
                    m_kalories = 180;
                    break;
                }
            }
        }

        public int getCalories()
        {
            return m_kalories;
        }
    }
}
