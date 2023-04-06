using System;
using DotNetKoans.Engine;
using Xunit;

namespace DotNetKoans.Koans;

public class AboutClasses : Koan
{
	// You can create your own custom types by using
	// struct, class, interface, and enum constructs.
	// C# is an object-oriented language. Classes and objects are
	// the two main aspects of object-oriented programming.
	// A class is a template for objects, and an object is an
	// instance of a class. Classes are declared by using the
	// class keyword followed by a unique identifier.

	class Foo1
	{

	}

	[Step(1)]
	public void InstancesOfAClassesCanBeCreatedWithNew()
	{
		// A type that is defined as a class is a reference type.
		// when you declare a variable of a reference type, the variable
		// contains the value null until you explicitly create an instance
		object foo = null;
		Assert.NotNull(foo);
	}

	class Foo2
	{
		public int Int { get; set; }
		internal string _str;

		private DateTime _canNotSeeMe = DateTime.Now;
	}

	[Step(2)]
	public void InstanceMembersCanBeSetByAssigningToThem()
	{
		// Try to assign visible class members
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

		public override string ToString()
		{
			return base.ToString();
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Val);
		}
	}

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