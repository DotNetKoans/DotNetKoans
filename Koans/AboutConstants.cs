using DotNetCoreKoans.Engine;
using Xunit;

namespace DotNetCoreKoans.Koans
{
    public class AboutConstants : Koan
    {
        const string C = "nested";

        [Step(1)]
        public void ConstantsMustBeInitalizedAsDeclared()
        {
            const int months = 12;
            Assert.Equal(FILL_ME_IN, 1);
        }

        [Step(2)]
        public void ConstantsOfTheSameTypeCanBeDeclaredAtTheSameTime()
        {
            const int months = 12, weeks = 52, days = 365;
            Assert.Equal(typeof(FillMeIn), months.GetType());
            Assert.Equal(typeof(FillMeIn), weeks.GetType());
            Assert.Equal(typeof(FillMeIn), days.GetType());
        }

        [Step(3)]
        public void ConstantsCanBeUsedInExpressionsToInitializeOtherConstants()
        {
            const int months = 12;
            const int weeks = 52;
            const int days = 365;

            const double daysPerWeek = (double)days / (double)weeks;
            const double daysPerMonth = (double)days / (double)months;
            Assert.Equal(FILL_ME_IN, daysPerWeek);
            Assert.Equal(FILL_ME_IN, daysPerMonth);
        }

        [Step(4)]
        public void NestedConstantsAreReferencedWithRelativePaths()
        {
            Assert.Equal("nested", C);
        }

        [Step(5)]
        public void NestedConstantsAreReferencedByTheirCompletePath()
        {
            Assert.Equal("nested", AboutConstants.C);
        }

        class Animal
        {
            public const int Legs = 4;

            public int LegsInAnimal()
            {
                return Legs;
            }

            public class NestedAnimal
            {
                public int LegsInNestedAnimal()
                {
                    return Legs;
                }
            }
        }

        [Step(6)]
        public void NestedClassesInheritConstantsFromEnclosingClasses()
        {
            var nestedAnimal = new Animal.NestedAnimal();
            Assert.Equal(4, nestedAnimal.LegsInNestedAnimal());
        }

        class Reptile : Animal
        {
            public int LegsInReptile()
            {
                return Legs;
            }
        }

        [Step(7)]
        public void SubclassesInheritConstantsFromParentClasses()
        {
            var reptile = new Reptile();
            Assert.Equal(4, reptile.LegsInReptile());
        }

        class MyAnimals
        {
            public const int Legs = 2;

            public class Bird : Animal
            {
                public int LegsInBird()
                {
                    return Legs;
                }
            }
        }

        [Step(8)]
        public void WhoWinsWithBothNestedAndInheritedConstants()
        {
            var bird = new MyAnimals.Bird();
            Assert.Equal(2, bird.LegsInBird());

            /* QUESTION: Which has precedence: The constant in the lexical scope,
               or the constant from the inheritance hierarchy? */
        }
    }
}
