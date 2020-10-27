﻿#pragma warning disable xUnit2009
using Xunit;
using DotNetCoreKoans.Engine;
using System.Threading;
using System;
using System.Globalization;

namespace DotNetCoreKoans.Koans
{
    class AboutDestructuring : Koan
    {
        /// Destructuring is a language feature that lets you extract a property inside a data structure

        #region 1: Destructuring with tuples

        // Tuples can be destrucure
        [Step(1)]
        public void TupleCanBeDestructured()
        {
            // If you don't know tuples, look at AboutTuples.cs
            var batman = ("Bruce", "Wayne");

            var (firstName, lastName) = batman; // This is destructuring

            Assert.Equal(FILL_ME_IN, firstName);
            Assert.Equal(FILL_ME_IN, lastName);
        }

        // you can avoid destructuring a property
        [Step(2)]
        public void AvoidDestructuringAProperty()
        {
            // Use _ whn you don't need to extract a property
            var batman = ("Bruce", "Wayne");

            var (_, lastName) = batman;

            Assert.Equal(FILL_ME_IN, lastName);
        }


        #endregion

        #region 2: Destructuring with object

        // Object can be destructured
        [Step(3)]
        public void ObjectCanBeDestructured()
        {
            var batman = new Batman("Bruce", "Wayne");

            var (firstName, lastName) = batman; // use Deconstruct(out string fistName, out string lastName)

            Assert.Equal(FILL_ME_IN, firstName);
            Assert.Equal(FILL_ME_IN, lastName);
        }


        // you can avoid destructuring a property
        [Step(4)]
        public void ObjectAvoidDestructuringAProperty()
        {
            // Use _ when you don't need to extract a property
            var batman = new Batman("Bruce", "Wayne");

            var (_, lastName) = batman; // use Deconstruct(out string fistName, out string lastName)

            Assert.Equal(FILL_ME_IN, lastName);
        }


        // You can "configure" object destructuring
        [Step(5)]
        public void ObjectDestrucuringCanBeConfigure()
        {
            // Use _ whn you don't need to extract a property
            var batman = new Batman("Bruce", "Wayne");

            var (firstName, _, heroName) = batman; // use Deconstruct(out string firstName, out string lastName, out string heroName)

            Assert.Equal(FILL_ME_IN, heroName);

            // Do you think it is a good practice ?
        }

        class Batman
        {
            private readonly string firstName;
            private readonly string lastName;

            public Batman(string firstName, string lastName)
            {
                this.firstName = firstName;
                this.lastName = lastName;
            }


            public void Deconstruct(out string fistName, out string lastName)
            {
                fistName = this.firstName;
                lastName = this.lastName;
            }

            public void Deconstruct(out string firstName, out string lastName, out string heroName)
            {
                Deconstruct(out firstName, out lastName);
                heroName = "Batman";
            }

        }
        #endregion


    }
}
