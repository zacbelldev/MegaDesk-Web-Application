using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Web_Application.AppCode
{
    public class DeskQuote : Desk
    {
        public string CustName { get; set; }
        public DateTime QuoteDate { get; set; }
        public string RushDays { get; set; }

        public int CalcTotalCost(int Width, int Depth, int NumOfDrawers, string RushDays, string Surface)
        {
            //Calc Surface Price
            int basePrice = 200;
            int size = Width * Depth;
            int potentialLargeSurfaceCost = 0;
            if (size > 1000)
            {
                potentialLargeSurfaceCost = (size - 1000);
            }
            int surfacePrice = basePrice + potentialLargeSurfaceCost;

            // Calc Line Cost
            int materialCost = 0;
            switch (Surface)
            {
                case "Oak":
                    materialCost = 200;
                    break;
                case "Laminate":
                    materialCost = 100;
                    break;
                case "Pine":
                    materialCost = 50;
                    break;
                case "Rosewood":
                    materialCost = 300;
                    break;
                case "Veneer":
                    materialCost = 125;
                    break;
            }
            int drawerCost = NumOfDrawers * 50;
            int lineCost = drawerCost + materialCost;

            //Calc Rush Cost
            int rushCost = 0;
            switch (RushDays)
            {
                case "Three":
                    if (size < 1000)
                    {
                        rushCost = 60;
                    }
                    if (size < 2000)
                    {
                        rushCost = 70;
                    }
                    else
                    {
                        rushCost = 80;
                    }
                    break;
                case "Five":
                    if (size < 1000)
                    {
                        rushCost = 40;
                    }
                    if (size < 2000)
                    {
                        rushCost = 50;
                    }
                    else
                    {
                        rushCost = 60;
                    }
                    break;
                case "Seven":
                    if (size < 1000)
                    {
                        rushCost = 30;
                    }
                    if (size < 2000)
                    {
                        rushCost = 35;
                    }
                    else
                    {
                        rushCost = 40;
                    }
                    break;
                case "No Rush":
                    rushCost = 0;
                    break;
            }

            //Add it all up together
            int totalCost = surfacePrice + lineCost + rushCost;
            return totalCost;
        }
    }
}