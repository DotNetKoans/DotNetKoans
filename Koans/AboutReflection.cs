using Xunit;
using System;
using DotNetKoans.Engine;
using System.Reflection;

namespace DotNetKoans.Koans;

public class AboutReflection : Koan
{
	// Reflection enables you to obtain information about loaded assemblies and types defined within them.
	// You can use reflection to create type instances at runtime, and to invoke and access them.
	// Assemblies contain modules, modules contain types and types contain members.
	// Reflection provides objects that encapsulate assemblies, modules and types.
	// You can use reflection to dynamically create an instance of a type, bind the type to an existing object,
	// or get the type from an existing object.
	// You can then invoke the type's methods or access its fields and properties.

	[Step(1)]
	public void GettingAType()
	{
		// Everything in .NET is derived from object.
		// Object contains the method GetType(), which will return its type.
		// This is the most basic form of reflection.

		object thisIsAStringType = "a string";
		Assert.Equal(typeof(string), thisIsAStringType.GetType());
	}

	[Step(2)]
	public void ViewingTheAssemblyOfAnObject()
	{
		// All .NET projects (.csproj), when compiled are called assemblies.
		// The GetName() method will return the name of the assembly that contains this class, which will be the same as the .csproj file.
		
		Assembly a = typeof(AboutReflection).Module.Assembly;

		Assert.Equal("DotNetKoans", a.GetName().Name);
	}

	[Step(3)]
	public void InspectingTheTypesInAnExternalAssembly()
	{
		// By now you will have noticed that DotNetKoans is cleverly using Xunit assertions as its teaching mechanic
		// Xunit is an example of an external assembly installed via package manager
		// Using reflection we can inspect its types
		// Hint: we're using a type that we already know about to get the Xunit assembly and all of its types

		Assembly a = typeof(Assert).Module.Assembly;

		Type[] types = a.GetTypes();

		Assert.Contains(typeof(Assert), types);
	}


	[Step(4)]
	public void ExposingNonPublicConstructor()
	{
		// Reflection can be dangerous!
		// It is possible to access non-public members, types and methods in an assembly.
		// Never execute these methods or set private members as it will likely cause undefined behaviour. 
		// They are inaccessible for a reason!

		// When inspecting the Assert class (via F12/Go to Definition), we can see that there is a protected constructor without a body.
		// We can use reflection to retrieve non public constructors and execute them.
		
		// We specify BindingFlags to only retrieve non public, instance constructors.
		ConstructorInfo[] constructors = typeof(Assert).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
				
		// We don't know for sure how many constructors there are in the Assert class
		// when using reflection so we can be safe and check for null before invoking the first element in the array.
		ConstructorInfo constructor = constructors[0];

		// the Invoke method returns object, but because we have retrieved this from reflecting the Assert type, we can infer that its return type is Assert
        object assertInstance = constructor?.Invoke(null);

		Assert.Equal(typeof(Assert), assertInstance.GetType());
	}

	[Step(5)]
	public void ExposingNonPublicFields()
	{
		// At the end of this file, there is a class called ACustomType, which contains a private string field that is set by the constructor.
		// We can use reflection to access this instance variable when we otherwise wouldn't be able to.
		
		string aLocalPrivateString = "this string will be private in ACustomType";
		string aLocalPublicString = "this string will be public in ACustomType";
		ACustomType aCustomType = new ACustomType(aLocalPrivateString, aLocalPublicString);

		// Get the Type of our class
		Type customType = typeof(ACustomType);

		// Get our non-public instance members
		FieldInfo[] fields = customType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

		// Retrieving a public field as we are allowed to
		Assert.Equal(aLocalPublicString, aCustomType.publicString);

		// We know that there is only one non-public instance field in ACustomType,
		// so we know the value is what we set as the privateString parameter when we called the constructor above.
		FieldInfo privateField = fields[0];

		// As in the previous step, our reflected value is of type object, which we know from the class below is a string.
		object privateFieldValue = privateField.GetValue(aCustomType);

		Assert.Equal(typeof(string), privateFieldValue.GetType());
		Assert.Equal(aLocalPrivateString, privateFieldValue);
	}	
}

public class ACustomType
{
	public ACustomType(string privateString, string publicString)	
	{
		this.privateString = privateString;
		this.publicString = publicString;
	}
	private string privateString;
	public string publicString;
}