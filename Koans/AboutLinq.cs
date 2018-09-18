using DotNetCoreKoans.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DotNetCoreKoans.Koans
{
    public class AboutLinq : Koan
    {
        /*
         *LINQ (Language Integrated Query).
         * LINQ provides language-level querying capabilities and a higher-order function API to C# and VB as a way to write expressive, declarative code.
         * All LINQ query operations consist of three distinct actions:

            1. Obtain the data source.

            2. Create the query.

            3. Execute the query.
         */

        [Step(1)]
        public void FilterArrayData()
        {
            //This sample uses "where" to find all elements of an array less than 5.

            // The Three Parts of a LINQ Query:

            //  1. Data source.
            int[] numbers = { 5, 1, 9, 8, 6, 7 };

            // 2. Query creation.
            var lowNums =
                from n in numbers
                where n < 5
                select n;

            // 3. Query execution.
            Assert.Equal(FILL_ME_IN, lowNums.Count());
        }

        [Step(2)]
        public void PutYourDataInOrderUsingOrderBy()
        {
            string[] customers = { "John", "Bill", "Maria", "George", "Anna" };

            var orderedCustomers =
                 from cust in customers
                 orderby cust ascending //You can also use descending here for reverse order.
                 select cust;

            Assert.Equal(FILL_ME_IN, orderedCustomers.First());
            Assert.Equal(FILL_ME_IN, orderedCustomers.Last());
        }

        [Step(3)]
        public void GetJustTheDataYouWantUsingTake()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

             //Get just the 3 first numbers.
            var first3Numbers = numbers.Take(3);

            Assert.Equal(FILL_ME_IN, first3Numbers.Count());
        }

        [Step(4)]
        public void UseAnyToDoSmartChecksOnYourData()
        {
            string[] words = { "believe", "relief", "receipt", "field" };

            bool iAfterE = words.Any(w => w.Contains("ei")); //Check if any of your words contain 'ei'
            Assert.Equal(FILL_ME_IN, iAfterE);
        }
    }
}
