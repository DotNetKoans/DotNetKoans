using Xunit;
using System.Reflection;
using DotNetCoreKoans.Engine;
using System;
using System.Text;
using System.Linq;

namespace DotNetCoreKoans.Koans
{
    public class AboutDelegates : Koan
	{
		//A delegate is a user defined type just like a class. 
		//A delegate lets you reference methods with the same signature and return type.
		//Once you have the reference to the method, pass them as paramters or call it via the delegate.
		//In other languages this is known as functions as first class citizens.

		//Here is a delegate declaration
		delegate int BinaryOp(int lhs, int rhs);

		private class MyMath
		{
			//Add has the same signature as BinaryOp
			public int Add(int lhs, int rhs)
			{
				return lhs + rhs;
			}
			public static int Subtract(int lhs, int rhs)
			{
				return lhs - rhs;
			}
		}
		[Koan(1)]
		public void DelegatesAreReferenceTypes()
		{
			//If you don't initialize a delegate it will be a null value, just as any other refrence type.
			BinaryOp op;
			Assert.Null(FILL_ME_IN);
		}
		[Koan(2)]
		public void DelegatesCanBeInstantiated()
		{
			MyMath math = new MyMath();
			BinaryOp op = new BinaryOp(math.Add);
			Assert.Equal(FILL_ME_IN, op.GetMethodInfo().Name);
		}
		[Koan(3)]
		public void DelegatesCanBeAssigned()
		{
			MyMath math = new MyMath();
			BinaryOp op = math.Add;
			Assert.Equal(FILL_ME_IN, op.GetMethodInfo().Name);
		}
		[Koan(4)]
		public void DelegatesCanReferenceStaticMethods()
		{
			BinaryOp op = MyMath.Subtract;
			Assert.Equal(FILL_ME_IN, op.GetMethodInfo().Name);
		}
		[Koan(5)]
		public void MethodsCalledViaDelegate()
		{
			MyMath math = new MyMath();
			BinaryOp op = math.Add;
			Assert.Equal(FILL_ME_IN, op(3,3));
		}
		private void PassMeTheDelegate(BinaryOp passed)
		{
            Assert.Equal(FILL_ME_IN, passed(3,3));
        }
		[Koan(6)]
		public void DelegatesCanBePassed()
		{
			MyMath math = new MyMath();
			BinaryOp op = math.Add;
			PassMeTheDelegate(op);
		}
		[Koan(7)]
		public void MethodCanBePassedDirectly()
		{
			MyMath math = new MyMath();
			PassMeTheDelegate(math.Add);
		}
		[Koan(8)]
		public void DelegatesAreImmutable()
		{
			//Like strings it looks like you can change what a delegate references, but really they are immutable objects
			MyMath m = new MyMath();
			BinaryOp a = m.Add;
			BinaryOp original = a;
			Assert.Same(a, original);
			a = MyMath.Subtract;
			//a is now a different instance
			Assert.Same(a, original);
		}
		delegate int Curry(int val);
		public class FunctionalTricks
		{
			public int Add5(int x)
			{
				return x + 5;
			}
			public int Add10(int x)
			{
				return x + 10;
			}
		}
		[Koan(9)]
		public void DelegatesHaveAnInvocationList()
		{
			FunctionalTricks f = new FunctionalTricks();
			Curry adding = f.Add5;
			//So far we've only seen one method attached to a delegate. 
			Assert.Equal(FILL_ME_IN, adding.GetInvocationList().Length);
			//However, you can attach multiple methods to a delegate 
			adding += f.Add10;
			Assert.Equal(FILL_ME_IN, adding.GetInvocationList().Length);
		}
		[Koan(10)]
		public void OnlyLastResultReturned()
		{
			FunctionalTricks f = new FunctionalTricks();
			Curry adding = f.Add5;
			adding += f.Add10;
			//Delegates may have more than one method attached, but only the result of the last method is returned.
			Assert.Equal(FILL_ME_IN, adding(5));
		}
		[Koan(11)]
		public void RemovingMethods()
		{
			FunctionalTricks f = new FunctionalTricks();
			Curry adding = f.Add5;
			adding += f.Add10;
			Assert.Equal(2, adding.GetInvocationList().Length);
			//Remove Add5 from the invocation list
			Assert.Equal(1, adding.GetInvocationList().Length);
			Assert.Equal("Add10", adding.GetMethodInfo().Name);
		}

		private void AssertIntEqualsFourtyTwo(int x)
		{
			Assert.Equal(42, x);
		}
		private void AssertStringEqualsFourtyTwo(string s)
		{
			Assert.Equal("42", s);
		}
		private void AssertAddEqualsFourtyTwo(int x, string s)
		{
			int y = int.Parse(s);
			Assert.Equal(42, x + y);
		}
		[Koan(12)]
		public void BuiltInActionDelegateTakesInt()
		{
			//With the release of generics in .Net 2.0 we got some delegates which will cover most of our needs. 
			//You will see them in the base class libraries, so knowing about them will be helpful. 
			//The first is Action<>. Action<> can take a variety of parameters and has a void return type.
			//  public delgate void Action<T>(T obj);

			Action<int> i = AssertIntEqualsFourtyTwo;
			i((int)FILL_ME_IN);
		}
		[Koan(13)]
		public void BuiltInActionDelegateTakesString()
		{
			// Because the delegate is a template, it also works with any other type. 
			Action<string> s = AssertStringEqualsFourtyTwo;
			s((string)FILL_ME_IN);
		}
		[Koan(14)]
		public void BuiltInActionDelegateIsOverloaded()
		{
			//Action is an overloaded delegate so it can take more than one paramter
			Action<int, string> a = AssertAddEqualsFourtyTwo;
			a(12, (string)FILL_ME_IN);
		}
		public class Seen
		{
			private StringBuilder _letters = new StringBuilder();
			public string Letters
			{
				get { return _letters.ToString(); }
			}
            public void Look(char letter)
			{
				_letters.Append(letter);
			}
		}
		[Koan(15)]
		public void ActionInTheBcl()
		{
			//You will find Action used within the BCL, often when iterating over a container
			string greeting = "Hello world";
			Seen s = new Seen();

			Array.ForEach(greeting.ToCharArray(), s.Look);

			Assert.Equal(FILL_ME_IN, s.Letters);
		}

		private bool IntEqualsFourtyTwo(int x)
		{
			return 42 == x;
		}
		private bool StringEqualsFourtyTwo(string s)
		{
			return "42" == s;
		}
		[Koan(16)]
		public void BuiltInPredicateDelegateIntSatisfied()
		{
			//The Predicate<T> delegate 
			//  public delgate bool Predicate<T>(T obj);
			//Predicate allows you to codify a condition and pass it around. 
			//You use it to determine if an object satisfies some criteria. 

			Predicate<int> i = (Predicate<int>)FILL_ME_IN;
			Assert.True(i(42));
		}
		[Koan(17)]
		public void BuiltInPredicateDelegateStringSatisfied()
		{
			//Because it is a template, you can work with any type
			Predicate<string> s = (Predicate<string>)FILL_ME_IN;
			Assert.True(s("42"));

			//Predicate is not overloaded, so unlike Action<> you cannot do this...
			//Predicate<int, string> a = (Predicate<int, string>)FILL_ME_IN;
			//Assert.True(a(42, "42"));
		}

		private bool StartsWithS(string country)
		{
			return country.StartsWith("S");
		}
		[Koan(18)]
		public void FindingWithPredicate()
		{
			//Predicate can be used to find an element in an array
			var countries = new []{ "Greece", "Spain", "Uruguay", "Japan" };

			Assert.Equal(FILL_ME_IN, Array.Find(countries, StartsWithS));
		}

		private bool IsInSouthAmerica(string country)
		{
			var countries = new[] { "Argentina", "Bolivia", "Brazil", "Chile", "Colombia", "Ecuador", "French Guiana", "Guyana", "Paraguay", "Peru", "Suriname", "Uruguay", "Venezuela" };
			return countries.Contains(country);
		}
		[Koan(19)]
		public void ValidationWithPredicate()
		{
			//Predicate can also be used when verifying 
			var countries = new[] { "Greece", "Spain", "Uruguay", "Japan" };

			Assert.Equal(FILL_ME_IN, Array.TrueForAll(countries, IsInSouthAmerica));
		}

		private string FirstMonth()
		{
			return "January";
		}
		private int Add(int x, int y)
		{
			return x + y;
		}
		[Koan(20)]
		public void FuncWithNoParameters()
		{
			//The Func<> delegate 
			//  public delegate TResult Func<T, TResult>(T arg);
			//Is very similar to the Action<> delegate. However, Func<> does not require any parameters, while does require returns a value.
			//The last type parameter specifies the return type. If you only specify a single 
			//type, Func<int>, then the method takes no paramters and returns an int.
			//If you specify more than one parameter, then you are specifying the paramter types as well.

			Func<string> d = FirstMonth;
			Assert.Equal(FILL_ME_IN, d());
		}
		[Koan(21)]
		public void FunctionReturnsInt()
		{
			//Like Action<>, Func<> is overloaded and can take a variable number of parameters.
			//The first type parameters define the parameter types and the last one is the return type. So the following matches
			//a method which takes two int parameters and returns a int.
			Func<int, int, int> a = Add;
			Assert.Equal(FILL_ME_IN, a(1, 1));
		}

		public class Car
		{
			public string Make { get; set; }
			public string Model { get; set; }
			public int Year { get; set; }
			public Car(string make, string model, int year)
			{
				Make = make;
				Model = model;
				Year = year;
			}
		}
		private int SortByModel(Car lhs, Car rhs)
		{
			return lhs.Model.CompareTo(rhs.Model);
		}
		[Koan(22)]
		public void SortingWithComparison()
		{
			//You could make classes sortable by implementing IComparable or IComparer. But the Comparison<> delegate makes it easier
			//	public delegate int Comparison<T>(T x, T y);
			//All you need is a method which takes two of the same type and returns -1, 0, or 1 depending upon what order they should go in.
			var cars = new[] { new Car("Alfa Romero", "GTV-6", 1986), new Car("BMC", "Mini", 1959) };
			Comparison<Car> by = SortByModel;
			Array.Sort(cars, by);

			Assert.Equal(FILL_ME_IN, cars[0].Model);
		}

		private string Stringify(int x)
		{
			return x.ToString();
		}
		[Koan(23)]
		public void ChangingTypesWithConverter()
		{
			//The Converter<> delegate
			//	public delegeate U Converter<T, U>(T from);
			//Can be used to change an object from one type to another
			var numbers = new[] { 1, 2, 3, 4 };
			Converter<int, string> c = Stringify;

			var result = Array.ConvertAll(numbers, c);

			Assert.Equal(FILL_ME_IN, result);
		}
	}
}