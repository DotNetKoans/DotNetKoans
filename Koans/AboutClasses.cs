using System;
using DotNetCoreKoans.Engine;
using Xunit;

namespace DotNetCoreKoans.Koans
{
    public class AboutClasses : Koan
    {

        class Foo1
        {

        }

        /// <summary>
        /// Objects instantiation.
        /// </summary>
        [Step(1)]
        public void InstancesOfAClassesCanBeCreatedWithNew()
        {
            object foo = null;
            Assert.NotNull(foo);
        }

        class Foo2
        {
            public int Int { get; set; }
            internal string _str;
        }

        /// <summary>
        /// Instance members.
        /// </summary>
        [Step(2)]
        public void InstanceMembersCanBeSetByAssigningToThem()
        {
            var foo = new Foo2();
            Assert.Equal(1, foo.Int);
            Assert.Equal("Bar", foo._str);
        }

        class Foo3
        {
            private bool _boom = true;
            public bool Internal { get => _boom; set { _boom = value; } }

            public void Do()
            {
                if (_boom)
                {
                    throw new InvalidOperationException(nameof(Do));
                }
            }
        }

        /// <summary>
        /// Accessors.
        /// </summary>
        [Step(3)]
        public void UseAccessorsToReturnInstanceVariables()
        {
            var foo = new Foo3();
            // make sure it won't explode
            foo.Do();

        }
        class Foo4
        {
            public string Bar { get; }
            public Foo4(string @value = default(string)) => Bar = @value;
        }

        /// <summary>
        /// Constructors.
        /// </summary>
        [Step(4)]
        public void UseConstructorsToDefineInitialValues()
        {
            Foo4 foo = default(Foo4);
            Assert.Equal("Bar", foo.Bar);
        }

        [Step(5)]
        public void DifferentObjectsHasDifferentInstanceVariables()
        {
            Foo4 foo1 = new Foo4();
            Foo4 foo2 = new Foo4();
            Assert.NotEqual(foo1.Bar, foo2.Bar);
        }

        class Foo5
        {
            public int Val { get; }
            public Foo5(int val = 0) => Val = val;
            public Foo5 Self() =>
                throw new InvalidOperationException(nameof(Self));

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

            public override string ToString()
            {
                return base.ToString();
            }

        }

        /// <summary>
        /// System.Object base class methods
        /// </summary>
        [Step(6)]
        public void MemberMethodSelfRefersToContainingObject()
        {
            Foo5 foo = new Foo5();
            Assert.Equal(foo, foo.Self());
        }

        [Step(7)]
        public void ToStringProvidesStringRepresentationOfAnObject()
        {
            Foo5 foo = new Foo5();
            Assert.Equal("Foo5", foo.ToString());
        }

        [Step(8)]
        public void EqualsDeterminesObjectComparison()
        {
            Foo5 foo1 = new Foo5(3);
            Foo5 foo2 = new Foo5(3);
            // you can define how objects are compared
            Assert.True(Object.Equals(foo1, foo2));
            // references are still different
            Assert.False(Object.ReferenceEquals(foo1, foo2));
        }

    }
}
