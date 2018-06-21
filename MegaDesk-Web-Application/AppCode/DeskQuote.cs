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
        //public decimal BasePrice { get; set; }
        //public decimal SurfaceCost { get; set; }
        public enum RushDays
        {
            ThreeDays,
            FiveDays,
            SevenDays,
            Standard
        }

        public decimal CalcTotalCost(int Width, int Depth, int NumOfDrawers, string RushDays, string Surface)
        {
            //Calc Surface Price
            decimal basePrice = 200.00M;
            int size = Width * Depth;
            decimal potentialLargeSurfaceCost = 0.00M;
            if (size > 1000)
            {
                potentialLargeSurfaceCost = (size - 1000.00M);
            }
            decimal surfacePrice = basePrice + potentialLargeSurfaceCost;

            // Calc Line Cost
            decimal materialCost = 0.00M;
            switch (Surface)
            {
                case "Oak":
                    materialCost = 200.00M;
                    break;
                case "Laminate":
                    materialCost = 100.00M;
                    break;
                case "Pine":
                    materialCost = 50.00M;
                    break;
                case "Rosewood":
                    materialCost = 300.00M;
                    break;
                case "Veneer":
                    materialCost = 125.00M;
                    break;
            }
            decimal drawerCost = NumOfDrawers * 50.00M;
            decimal lineCost = drawerCost + materialCost;

            //Calc Rush Cost
            decimal rushCost = 0.00M;
            switch (RushDays)
            {
                case "ThreeDays":
                    if (size < 1000)
                    {
                        rushCost = 60.00M;
                    }
                    if (size < 2000)
                    {
                        rushCost = 70.00M;
                    }
                    else
                    {
                        rushCost = 80.00M;
                    }
                    break;
                case "FiveDays":
                    if (size < 1000)
                    {
                        rushCost = 40.00M;
                    }
                    if (size < 2000)
                    {
                        rushCost = 50.00M;
                    }
                    else
                    {
                        rushCost = 60.00M;
                    }
                    break;
                case "SevenDays":
                    if (size < 1000)
                    {
                        rushCost = 30.00M;
                    }
                    if (size < 2000)
                    {
                        rushCost = 35.00M;
                    }
                    else
                    {
                        rushCost = 40.00M;
                    }
                    break;
                case "Standard":
                    rushCost = 0.00M;
                    break;
            }

            //Add it all up together
            decimal totalCost = surfacePrice + lineCost + rushCost;
            return totalCost;
        }
    }
}
