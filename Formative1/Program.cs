// See https://aka.ms/new-console-template for more information
using System;

namespace HouseAffordabilityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Gather Input
            Console.Write("Enter your gross monthly income: ");
            decimal grossIncome = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter your estimated monthly tax deducted: ");
            decimal taxDeducted = Convert.ToDecimal(Console.ReadLine());

            // Estimated monthly expenditures in various categories
            Console.Write("Enter your estimated monthly food expenses: ");
            decimal foodExpenses = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter your estimated monthly transportation expenses: ");
            decimal transportationExpenses = Convert.ToDecimal(Console.ReadLine());

   

            // Ask user to choose between renting or buying
            Console.Write("Do you want to (1) rent or (2) buy? Enter the corresponding number: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            decimal availableMonthlyMoney = CalculateAvailableMonthlyMoney(grossIncome, taxDeducted, foodExpenses, transportationExpenses);
            Console.WriteLine($"Your available monthly money after deductions: {availableMonthlyMoney:C}");

            if (choice == 1)
            {
                // Renting Option
                Console.Write("Enter the monthly rental amount: ");
                decimal monthlyRentalAmount = Convert.ToDecimal(Console.ReadLine());

                if (availableMonthlyMoney > monthlyRentalAmount)
                {
                    Console.WriteLine("You can afford to rent this property!");
                }
                else
                {
                    Console.WriteLine("Renting this property may not be feasible with your current finances.");
                }
            }
            else if (choice == 2)
            {
                // Buying Option
                Console.Write("Enter the purchase price: ");
                decimal purchasePrice = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter the total deposit: ");
                decimal totalDeposit = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter the annual interest rate (e.g., 5.5 for 5.5%): ");
                decimal interestRate = Convert.ToDecimal(Console.ReadLine()) / 100;

                Console.Write("Enter the number of months to repay the home loan: ");
                int numberOfMonths = Convert.ToInt32(Console.ReadLine());

                decimal monthlyRepayment = CalculateMonthlyRepayment(purchasePrice, totalDeposit, interestRate, numberOfMonths);

                if (monthlyRepayment <= availableMonthlyMoney / 3)
                {
                    Console.WriteLine($"Congratulations! You can afford to buy this property with a monthly repayment of {monthlyRepayment:C}");
                }
                else
                {
                    Console.WriteLine("Buying this property may not be feasible with your current finances.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose '1' for renting or '2' for buying.");
            }
        }

        static decimal CalculateAvailableMonthlyMoney(decimal grossIncome, decimal taxDeducted, decimal foodExpenses, decimal transportationExpenses)
        {
            return grossIncome - taxDeducted - foodExpenses - transportationExpenses;
        }

        static decimal CalculateMonthlyRepayment(decimal purchasePrice, decimal totalDeposit, decimal interestRate, int numberOfMonths)
        {
            decimal loanAmount = purchasePrice - totalDeposit;
            decimal monthlyInterestRate = interestRate / 12;
            decimal monthlyRepayment = (loanAmount * monthlyInterestRate) / (1 - (decimal)Math.Pow(1 + (double)monthlyInterestRate, -numberOfMonths));

            return monthlyRepayment;
        }
    }
}