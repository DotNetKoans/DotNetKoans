using Xunit;
using DotNetCoreKoans.Engine;
using System.Reflection;
using System;

namespace DotNetCoreKoans.Koans
{
    public static class ExtensionMethods
    {
        public static string HelloWorld(this Koan koan)
        {
            return "Hello!";
        }

        public static string SayHello(this Koan koan, string name)
        {
            return String.Format("Hello, {0}!", name);
        }

        public static string[] MethodWithVariableArguments(this Koan koan, params string[] names)
        {
            return names;
        }

        public static string SayHi(this String str)
        {
            return "Hi, " + str;
        }
    }

    public class AboutMethods : Koan
    {
        //Extension Methods allow us to "add" methods to any class
        //without having to recompile. You only have to reference the
        //namespace the methods are in to use them. Here, since both the
        //ExtensionMethods class and the AboutMethods class are in the
        //DotNetKoans.CSharp namespace, AboutMethods can automatically
        //find them

        [Step(1)]
        public void ExtensionMethodsShowUpInTheCurrentClass()
        {
            Assert.Equal(FILL_ME_IN, this.HelloWorld());
        }

        [Step(2)]
        public void ExtensionMethodsWithParameters()
        {
            Assert.Equal(FILL_ME_IN, this.SayHello("Cory"));
        }

        [Step(3)]
        public void ExtensionMethodsWithVariableParameters()
        {
            Assert.Equal(FILL_ME_IN, this.MethodWithVariableArguments("Cory", "Will", "Corey"));
        }

        //Extension methods can extend any class by referencing 
        //the name of the class they are extending. For example, 
        //we can "extend" the string class like so:

        [Step(4)]
        public void ExtendingCoreClasses()
        {
            Assert.Equal(FILL_ME_IN, "Cory".SayHi());
        }

        //Of course, any of the parameter things you can do with 
        //extension methods you can also do with local methods

        private string[] LocalMethodWithVariableParameters(params string[] names)
        {
            return names;
        }

        [Step(5)]
        public void LocalMethodsWithVariableParams()
        {
            Assert.Equal(FILL_ME_IN, this.LocalMethodWithVariableParameters("Cory", "Will", "Corey"));
        }

        //Note how we called the method by saying "this.LocalMethodWithVariableParameters"
        //That isn't necessary for local methods

        [Step(6)]
        public void LocalMethodsWithoutExplicitReceiver()
        {
            Assert.Equal(FILL_ME_IN, LocalMethodWithVariableParameters("Cory", "Will", "Corey"));
        }

        //But it is required for Extension Methods, since it needs
        //an instance variable. So this wouldn't work, giving a
        //compile-time error:
        //Assert.Equal(FILL_ME_IN, MethodWithVariableArguments("Cory", "Will", "Corey"));

        class InnerSecret
        {
            public static string Key() { return "Key"; }
            public string Secret() { return "Secret"; }
            protected string SuperSecret() { return "This is secret"; }
            private string SooperSeekrit() { return "No one will find me!"; }
        }

        class StateSecret : InnerSecret
        {
            public string InformationLeak() { return SuperSecret(); }
        }

        //Static methods don't require an instance of the object
        //in order to be called. 
        [Step(7)]
        public void CallingStaticMethodsWithoutAnInstance()
        {
            Assert.Equal(FILL_ME_IN, InnerSecret.Key());
        }

        //In fact, you can't call it on an instance variable
        //of the object. So this wouldn't compile:
        //InnerSecret secret = new InnerSecret();
        //Assert.Equal(FILL_ME_IN, secret.Key());

        
        [Step(8)]
        public void CallingPublicMethodsOnAnInstance()
        {
            InnerSecret secret = new InnerSecret();
            Assert.Equal(FILL_ME_IN, secret.Secret());
        }

        //Protected methods can only be called by a subclass
        //We're going to call the public method called
        //InformationLeak of the StateSecret class which returns
        //the value from the protected method SuperSecret
        [Step(9)]
        public void CallingProtectedMethodsOnAnInstance()
        {
            StateSecret secret = new StateSecret();
            Assert.Equal(FILL_ME_IN, secret.InformationLeak());
        }

        //But, we can't call the private methods of InnerSecret
        //either through an instance, or through a subclass. It
        //just isn't available.

        //Ok, well, that isn't entirely true. Reflection can get
        //you just about anything, and though it's way out of scope
        //for this...
        [Step(10)]
        public void SubvertPrivateMethods()
        {
            InnerSecret secret = new InnerSecret();
            string superSecretMessage = secret.GetType()
                .GetMethod("SooperSeekrit", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Invoke(secret, null) as string;
            Assert.Equal(FILL_ME_IN, superSecretMessage);
        }

        //Up till now we've had explicit return types. It's also
        //possible to create methods which dynamically shift
        //the type based on the input. These are referred to
        //as generics

        public static T GiveMeBack<T>(T p1)
        {
            return p1;
        }

        [Step(11)]
        public void CallingGenericMethods()
        {
            Assert.Equal(typeof(FillMeIn), GiveMeBack<int>(1).GetType());

            Assert.Equal(FILL_ME_IN, GiveMeBack<string>("Hi!"));
        }

        private int ChangeInt(int x)
        {
            x = x + 10;
            return x;
        }

        private string ChangeString(string str)
        {
            str = str + " second";
            return str;
        }

        private class HeapObject
        {
            public string Value { get; set; }
        }

        private struct ValueObject
        {
            public string Value { get; set; }
        }

        private HeapObject ChangeHeapObject(HeapObject obj)
        {
            obj.Value = "changed";
            return obj;
        }

        private ValueObject ChangeValueObject(ValueObject obj)
        {
            obj.Value = "changed";
            return obj;
        }
        
        //When creating a new variable (int, string, List<T>, YourCustomObject)
        //it will always be created in one of two places: the stack, or the heap.
        //This will determine exactly how C# passes the data represented by your
        //variable into methods when passed into them

        [Step(12)]
        public void SimpleTypesAsArguments()
        {
            //Built-in types, such as ints, chars, and floats are value types,
            //so they are created on the stack. This means that when they are
            //passed as arguments into a method, a new one is created
            int x = 9;
            int result = ChangeInt(x);
            Assert.Equal(FILL_ME_IN, result);
            Assert.Equal(FILL_ME_IN, x);
        }

        [Step(13)]
        public void StringsAsArguments()
        {
            //As we learned earlier, strings are immutable, which means they
            //cannot be changed. Therefore, if they are passed into a method
            //and the method tries to modify it, a new string will be created
            string first = "first";
            string result = ChangeString(first);
            Assert.Equal(FILL_ME_IN, first);
            Assert.Equal(FILL_ME_IN, result);
        }

        [Step(14)]
        public void ReferenceTypesAsArguments()
        {
            //Seek oneness like the heap object,
            //and you will find inner peace.
            var heapObject = new HeapObject { Value = "original" };
            var result = ChangeHeapObject(heapObject);
            Assert.Equal(FILL_ME_IN, heapObject.Value);
            Assert.Equal(FILL_ME_IN, result.Value);
            
            //Objects created from classes are allocated on the heap. This
            //means that when they are passed into a method, the reference
            //that was created to represent the data of the object when we
            //called new is what actually gets passed into said method.
            //Therefore, any changes made to the object in the method will
            //apply to the object that was created outside the method as
            //well (in reality, there's always just one object and we've
            //simply passed a "reference" to the object into the method)
        }

        [Step(15)]
        public void ValueTypesAsArguments()
        {
            //Karma states that when a value type is passed
            //as a parameter, a new one will be created.
            var valueObject = new ValueObject { Value = "original" };
            var result = ChangeValueObject(valueObject);
            Assert.Equal(FILL_ME_IN, valueObject.Value);
            Assert.Equal(FILL_ME_IN, result.Value);
            
            //Structs are custom objects that are created on the stack,
            //similarly to built-in types. Therefore, a new copy of
            //the object is passed into the method, leaving the original
            //unchanged when the method tries to modify the object
            //passed into it
        }
    }
}