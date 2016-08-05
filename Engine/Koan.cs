using System;

namespace DotNetCoreKoans.Engine
{
    public class Koan
    {
        public static dynamic FILL_ME_IN = new Object();
        public virtual void Setup() { }
        public virtual void TearDown() { }

    }

    //This is just used when we need a type
    public abstract class FillMeIn { }
}