using System;
using AlgorithmsDataStructureCourse.Models;
using AlgorithmsDataStructureCourse.Algorithms;
using AlgorithmsDataStructureCourse.Utilities;
using System.Numerics;
using AlgorithmsDataStructureCourse.Data;
using AlgorithmsDataStructureCourse.Interfaces;
using AlgorithmsDataStructureCourse.Services;
using AlgorithmsDataStructureCourse.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructureCourse
{
    class Programs
    {
        public static async Task Main(string[] args)
        {
            //Pokemon squirtle = new Pokemon("squirtle", 100);

            //Fibonacci
            //Console.WriteLine(Fibonacci.calculateFib(100));
            //Console.WriteLine(Fibonacci.calculateFib(6));
            //Console.WriteLine(Fibonacci.calculateFib(10));

            //Grid Traveler
            //Console.WriteLine(GridTraveler.gridTraveler(1, 1));
            //Console.WriteLine(GridTraveler.gridTraveler(2, 3));
            //Console.WriteLine(GridTraveler.gridTraveler(3, 2));
            //Console.WriteLine(GridTraveler.gridTraveler(3,3));
            //Console.WriteLine(GridTraveler.gridTraveler(18, 18));

            //LongestSubstringLength
            //Console.WriteLine(LongestSubstringLength.getLongestSubstringCount_brute("abcdae")); //5
            //Console.WriteLine(LongestSubstringLength.getLongestSubstringCount_brute("abcabcbb")); //3
            //Console.WriteLine(LongestSubstringLength.getLongestSubstringCount_brute("bbbbb")); //1
            //Console.WriteLine(LongestSubstringLength.getLongestSubstringCount_brute("pwwkew")); //3
            //Console.WriteLine(LongestSubstringLength.getLongestSubstringCount_brute("abcajjabdwertyuiolkjhalkajsdfkjahwelukhaskldjfhlaksudhflkajshdflkjasdf")); //15

            //canSum_Bool
            //Console.WriteLine(CanSum.canSum(7, [5,3,4,7])); //True
            //Console.WriteLine(CanSum.canSum(9, [2, 4])); //False
            //Console.WriteLine(CanSum.canSum(9, [2, 1, 3])); //True
            //Console.WriteLine(CanSum.canSum(300, [7, 14])); //True

            //howSum
            //Console.WriteLine(FormatList.formatList(HowSum.howSum(7, [2, 3]))); //[3, 2, 2]
            //Console.WriteLine(FormatList.formatList(HowSum.howSum(7, [5, 3, 4, 7]))); //[4,3]
            //Console.WriteLine(FormatList.formatList(HowSum.howSum(7, [2, 4]))); // null
            //Console.WriteLine(FormatList.formatList(HowSum.howSum(8, [2, 3, 5]))); // [2, 2, 2, 2]
            //Console.WriteLine(FormatList.formatList(HowSum.howSum(300, [7, 14]))); //null

            Console.WriteLine("Running App");

            //await RunInvoiceApp(); // Await the async method

            //Console.ReadKey();

            int monthlyRate = 2549;
            double dailyRate = monthlyRate / 30.0;

            Console.WriteLine($"Daily Rate: {dailyRate}");

            int activeUsers_day1 = 5;
            int activeUsers_day2 = 3;


            double day1_charge = activeUsers_day1 * dailyRate;
            int day1_charge_rounded = (int)day1_charge;
            double accumulated_discrepancy = day1_charge - day1_charge_rounded;

            Console.WriteLine($"Day 1 Charge: {day1_charge}");
            Console.WriteLine($"Day 1 Rounded Charge: {day1_charge_rounded}");
            Console.WriteLine($"Day 1 Accumulated Discrepancy: {accumulated_discrepancy}");
            accumulated_discrepancy -= 1;
            Console.WriteLine($"Accumulated Discrepancy Minus 1: {accumulated_discrepancy}");
            double day2_charge = activeUsers_day2 * dailyRate;
            int day2_charge_rounded = (int)day2_charge;
            accumulated_discrepancy = accumulated_discrepancy + (day2_charge - day2_charge_rounded);

           
            Console.WriteLine($"Day 2 Charge: {day2_charge}");
            Console.WriteLine($"Day 2 Rounded Charge: {day2_charge_rounded}");
            Console.WriteLine($"Day 2 Accumulated Discrepancy: {accumulated_discrepancy}");

            double totalCharge = day1_charge + day2_charge;

            Console.WriteLine($"Total Charge: {totalCharge}");
        }

        public static async Task RunInvoiceApp()
        {
            // 1. Composition Root (Simplified - Use a DI container in a real app)
            IInvoiceRepository invoiceRepository = new InvoiceRepository(); //  implementation
            IInvoiceService invoiceService = new InvoiceService(invoiceRepository);
            IInvoiceOutputService invoiceOutputService = new ConsoleInvoiceOutputService(invoiceRepository); // Could be a PdfInvoiceOutputService, etc.

            //2. Creating an Invoice
            List<InvoiceItem> items = new List<InvoiceItem>
            {
                new InvoiceItem
                {
                    ItemID = Guid.NewGuid(),
                    Description = "Barstools",
                    Quantity = 2,
                    Price = 121.00m
                },
                new InvoiceItem
                {
                    ItemID = Guid.NewGuid(),
                    Description = "Barstools",
                    Quantity = 2,
                    Price = 100.00m
                },
                new InvoiceItem
                {
                    ItemID = Guid.NewGuid(),
                    Description = "Console Table",
                    Quantity = 1,
                    Price = 150.00m
                }
            };

            List<Customer> customers = await invoiceRepository.GetAllCustomers();
            List<Invoice> invoices = new List<Invoice>();

            Console.WriteLine("Which customer would you like to generate an invoice for?");

            foreach(var customer in customers)
            {
                Invoice invoice = await invoiceService.GenerateNewInvoice(customer.CustomerID, items, 6.0m, "USD");
                invoices.Add(invoice);
            }

            //3. Calculate total amount due
            DateTime paymentDate = new DateTime(2025, 12, 1);
            FinelTotalAmountDue totalAmountDue = await invoiceService.CalculateTotalAmountDue(invoices[0], paymentDate);
            //decimal amountDue = await invoiceService.CalculateTotalAmountDue(invoices[0], paymentDate);
            Console.WriteLine($"\nTotal Amount Due on {paymentDate:MM/dd/yyyy}: {totalAmountDue.TotalAmount:C2} Late Fees: {(totalAmountDue.LateFee != 0 ? totalAmountDue.LateFee.ToString("C2") : "N/A")} ");

            //4. Print the Invoice
            await invoiceOutputService.PrintInvoice(invoices[0]);
        }
    }
}

public class Subscription
{
    public Subscription() { }
    public Subscription(int id, int customerId, int monthlyPriceInCents)
    {
        this.Id = id;
        this.CustomerId = customerId;
        this.MonthlyPriceInCents = monthlyPriceInCents;
    }

    public int Id;
    public int CustomerId;
    public int MonthlyPriceInCents;
}

public class User
{
    public User() { }
    public User(int id, string name, DateTime activatedOn, DateTime deactivatedOn, int customerId)
    {
        this.Id = id;
        this.Name = name;
        this.ActivatedOn = activatedOn;
        this.DeactivatedOn = deactivatedOn;
        this.CustomerId = customerId;
    }

    public int Id;
    public string Name;
    public DateTime ActivatedOn;
    public DateTime DeactivatedOn;
    public int CustomerId;
}

public class Challenge
{
    public static int MonthlyCharge(string month, Subscription subscription, User[] users)
    {
        if (subscription == null || users == null || users.Length == 0)
        {
            return 0;
        }

        DateTime monthTarget = DateTime.Parse($"{month}-01");
        DateTime firstMonthDay = FirstDayOfMonth(monthTarget);
        DateTime lastMonthDay = LastDayOfMonth(monthTarget);

        double dailyRate = (double)subscription.MonthlyPriceInCents / DateTime.DaysInMonth(monthTarget.Year, monthTarget.Month);
        int monthlyCharge = 0;
        double accumulatedDiscrepancy = 0;

        for (DateTime currentDay = firstMonthDay; currentDay <= lastMonthDay; currentDay = NextDay(currentDay))
        {
            int activeUsers = 0;
            foreach (var user in users)
            {
                if (user.ActivatedOn <= currentDay && user.DeactivatedOn >= currentDay && user.CustomerId == subscription.CustomerId)
                {
                    activeUsers++;
                }
            }
            double dailyCharge = activeUsers * dailyRate;
            accumulatedDiscrepancy += dailyCharge - (int)dailyCharge;
            monthlyCharge += (int)dailyCharge;

            if (accumulatedDiscrepancy >= 0.5)
            {
                monthlyCharge++;
                accumulatedDiscrepancy -= 1;
            }
            else if (accumulatedDiscrepancy <= -0.5)
            {
                monthlyCharge--;
                accumulatedDiscrepancy += 1;
            }
        }

        return monthlyCharge;
    }

    private static DateTime FirstDayOfMonth(DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1);
    }

    private static DateTime LastDayOfMonth(DateTime date)
    {
        return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }

    private static DateTime NextDay(DateTime date)
    {
        return date.AddDays(1);
    }
}