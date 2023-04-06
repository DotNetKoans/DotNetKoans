using Xunit;
using System.Collections.Generic;
using System;
using System.Collections;
using DotNetKoans.Engine;

namespace DotNetKoans.Koans;

public class AboutGenericContainers : Koan
{
	[Step(1)]
	public void ArrayListSizeIsDynamic()
	{
		//When you worked with Array, the fact that Array is fixed size was glossed over.
		//The size of an array cannot be changed after you allocate it. To get around that
		//you need a class from the System.Collections namespace such as ArrayList
		ArrayList list = new ArrayList();
		Assert.Equal(FILL_ME_IN, list.Count);

		list.Add(42);
		Assert.Equal(FILL_ME_IN, list.Count);
	}

	[Step(2)]
	public void ArrayListHoldsObjects()
	{
		ArrayList list = new ArrayList();
		System.Reflection.MethodInfo method = list.GetType().GetMethod("Add");
		Assert.Equal(typeof(FillMeIn), method.GetParameters()[0].ParameterType);
	}

	[Step(3)]
	public void MustCastWhenRetrieving()
	{
		//There are a few problems with ArrayList holding object references. The first 
		//is that you must cast the items you fetch back to the original type.
		ArrayList list = new ArrayList();
		list.Add(42);
		int x = 0;
		//x = (int)list[0];
		Assert.Equal(42, x);
	}

	[Step(4)]
	public void ArrayListIsNotStronglyTyped()
	{
		//Having to cast everywhere is tedious. But there is also another issue lurking
		//ArrayList can hold more than one type. 
		ArrayList list = new ArrayList();
		list.Add(42);
		list.Add("forty two");
		Assert.Equal(FILL_ME_IN, list[0]);
		Assert.Equal(FILL_ME_IN, list[1]);

		//While there are a few cases where it could be nice, instead what it means is that 
		//anytime your code works with an array list you have to check that the element is 
		//of the type you expect.
	}

	[Step(5)]
	public void Boxing()
	{
		short s = 5;
		object os = s;
		Assert.Equal(s.GetType(), os.GetType());
		Assert.Equal(s, os);

		//While it is true that everything is an object and all the above passes, not everything is quite as it seems.
		//Under the covers .NET allocates memory for all value type objects (int, double, bool,...) on the stack. This is 
		//considerably more efficient than a heap allocation. .NET also has the ability to put a value type onto the heap.
		//(for calling methods and other reasons). The process of putting stack data into the heap is called "boxing". The 
		//process of taking the value type off the heap is called "unboxing". We won't go into the details (see Jeffrey 
		//Richter's book if you want details). This subject comes up because every time you put a value type into an 
		//ArrayList it must be boxed. Every time you read it from the ArrayList it must be unboxed. This can be a significant
		//cost.
	}

	[Step(6)]
	public void ABetterDynamicSizeContainer()
	{
		//ArrayList is a .NET 1.0 container. With .NET 2.0 generics were introduced and with it a new set of collections in
		//System.Collections.Generic The array like container is List<T>. List<T> (read "list of T") is a generic class. 
		//The "T" in the definition of List<T> is the type argument. You cannot declare an instance of List<T> without also
		//supplying a type in place of T.
		var list = new List<int>();
		Assert.Equal(FILL_ME_IN, list.Count);

		list.Add(42);
		Assert.Equal(FILL_ME_IN, list.Count);

		//Now just like int[], you can have a type safe dynamic sized container
		//list.Add("forty two"); //<--Unlike ArrayList this is illegal.

		//List<T> also solves the boxing/unboxing issues of ArrayList. Unfortunately, you'll have to take Microsoft's word for it
		//as I can't find a way to prove it without some ugly MSIL beyond the scope of these Koans.
	}

	public class Widget
	{
	}

	[Step(7)]
	public void ListWorksWithAnyType()
	{
		//Just as with Array, list will work with any type
		List<Widget> list = new List<Widget>();
		list.Add(new Widget());
		Assert.Equal(FILL_ME_IN, list.Count);
	}

	[Step(8)]
	public void InitializingWithValues()
	{
		//Like array you can create a list with an initial set of values easily
		var list = new List<int> { 1, 2, 3 };
		Assert.Equal(FILL_ME_IN, list.Count);
	}

	[Step(9)]
	public void AddMultipleItems()
	{
		//You can add multiple items to a list at once
		List<int> list = new List<int>();
		list.AddRange(new[] { 1, 2, 3 });
		Assert.Equal(FILL_ME_IN, list.Count);
	}

	[Step(10)]
	public void RandomAccess()
	{
		//Just as with array, you can use the subscript notation to access any element in a list.
		List<int> list = new List<int> { 5, 6, 7 };
		Assert.Equal(FILL_ME_IN, list[2]);
	}

	[Step(11)]
	public void BeyondTheLimits()
	{
		List<int> list = new List<int> { 1, 2, 3 };
		//You cannot attempt to get data that doesn't exist
		Assert.Throws(typeof(FillMeIn), delegate () { int x = list[3]; });
	}

	[Step(12)]
	public void ConvertingToFixedSize()
	{
		List<int> list = new List<int> { 1, 2, 3 };
		Assert.Equal(FILL_ME_IN, list.ToArray());
	}

	[Step(13)]
	public void InsertingInTheMiddle()
	{
		List<int> list = new List<int> { 1, 2, 3 };
		list.Insert(1, 6);
		Assert.Equal(FILL_ME_IN, list.ToArray());
	}

	[Step(14)]
	public void RemovingItems()
	{
		List<int> list = new List<int> { 2, 1, 2, 3 };
		list.Remove(2);
		Assert.Equal(FILL_ME_IN, list.ToArray());
	}

	[Step(15)]
	public void StackPushPop()
	{
		var stack = new Stack<int>();
		Assert.Equal(FILL_ME_IN, stack.Count);

		stack.Push(42);
		Assert.Equal(FILL_ME_IN, stack.Count);

		int x = stack.Pop();
		Assert.Equal(FILL_ME_IN, x);

		Assert.Equal(FILL_ME_IN, stack.Count);
	}

	[Step(16)]
	public void StackOrder()
	{
		var stack = new Stack<int>();
		stack.Push(1);
		stack.Push(2);
		stack.Push(3);

		Assert.Equal(FILL_ME_IN, stack.ToArray());
	}

	[Step(17)]
	public void PeekingIntoAQueue()
	{
		Queue<string> queue = new Queue<string>();
		queue.Enqueue("one");
		Assert.Equal(FILL_ME_IN, queue.Peek());
		queue.Enqueue("two");
		Assert.Equal(FILL_ME_IN, queue.Peek());
	}

	[Step(18)]
	public void RemovingItemsFromTheQueue()
	{
		Queue<string> queue = new Queue<string>();
		queue.Enqueue("one");
		queue.Enqueue("two");
		Assert.Equal(FILL_ME_IN, queue.Dequeue());
		Assert.Equal(FILL_ME_IN, queue.Count);
	}

	[Step(19)]
	public void AddingToADictionary()
	{
		//Dictionary<TKey, TValue> is .NET's key value store. The key and the value do not need to be the same types.
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		Assert.Equal(FILL_ME_IN, dictionary.Count);
		dictionary[1] = "one";
		Assert.Equal(FILL_ME_IN, dictionary.Count);
	}

	[Step(20)]
	public void AccessingData()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["one"] = "uno";
		dictionary["two"] = "dos";
		//The most common way to locate data is with the subscript notation.
		Assert.Equal(FILL_ME_IN, dictionary["one"]);
		Assert.Equal(FILL_ME_IN, dictionary["two"]);
	}

	[Step(21)]
	public void AccessingDataNotAdded()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["one"] = "uno";
		Assert.Throws(typeof(FillMeIn), delegate () { string s = dictionary["two"]; });
	}

	[Step(22)]
	public void CatchingMissingData()
	{
		//To deal with the throw when data is not there, you could wrap the data access in a try/catch block...
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["one"] = "uno";
		string result;
		try
		{
			result = dictionary["two"];
		}
		catch (Exception ex)
		{
			result = "dos";
		}
		Assert.Equal(FILL_ME_IN, result);
	}

	[Step(23)]
	public void PreCheckForMissingData()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["one"] = "uno";
		string result;
		if (dictionary.ContainsKey("two"))
		{
			result = dictionary["two"];
		}
		else
		{
			result = "dos";
		}
		Assert.Equal(FILL_ME_IN, result);
	}

	[Step(24)]
	public void TryGetValueForMissingData()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["one"] = "uno";
		string result;
		if (!dictionary.TryGetValue("two", out result))
		{
			result = "dos";
		}
		Assert.Equal(FILL_ME_IN, result);
	}

	[Step(25)]
	public void InitializingADictionary()
	{
		//Although it is not common, you can initialize a dictionary...
		var dictionary = new Dictionary<string, string> { { "one", "uno" }, { "two", "dos" } };
		Assert.Equal(FILL_ME_IN, dictionary["one"]);
		Assert.Equal(FILL_ME_IN, dictionary["two"]);
	}

	[Step(26)]
	public void ModifyingData()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["one"] = "uno";
		dictionary["two"] = "dos";
		dictionary["one"] = "ein";
		Assert.Equal(FILL_ME_IN, dictionary["one"]);
	}

	[Step(27)]
	public void KeyExists()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["one"] = "uno";
		Assert.Equal(FILL_ME_IN, dictionary.ContainsKey("one"));
		Assert.Equal(FILL_ME_IN, dictionary.ContainsKey("two"));
	}

	[Step(28)]
	public void ValueExists()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary["one"] = "uno";
		Assert.Equal(FILL_ME_IN, dictionary.ContainsValue("uno"));
		Assert.Equal(FILL_ME_IN, dictionary.ContainsValue("dos"));
	}

	[Step(29)]
	public void AddingDataViaSubscript()
	{
		//The Dictionary also has some smarts built-in... You can use
		//the subscript operator, [], to add data to it. Consider
		//carefully the foreach loop below.
		Dictionary<string, int> one = new Dictionary<string, int>();
		one["jim"] = 53;
		one["amy"] = 20;
		one["dan"] = 23;

		Dictionary<string, int> two = new Dictionary<string, int>();
		two["jim"] = 54;
		two["jenny"] = 26;

		foreach (KeyValuePair<string, int> item in two)
		{
			one[item.Key] = item.Value;
		}

		Assert.Equal(FILL_ME_IN, one["jim"]);
		Assert.Equal(FILL_ME_IN, one["jenny"]);
		Assert.Equal(FILL_ME_IN, one["amy"]);
	}
}