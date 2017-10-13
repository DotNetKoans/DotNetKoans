using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace DotNetCoreKoans.Engine
{
    public abstract class Path : IEnumerable<Type>
    {
        internal Type[] Types;

        public int Walk(Sensei sensei)
        {
            try
            {
                ForEachStep(step => {
                    sensei.Observe(step.Meditate());
                });
            }
            catch(SenseiException e)
            { }
            
            sensei.Instruct(this);

            return sensei.Failed() ? -1 : 0;
        }

        public void ForEachKoan(Action<TypeInfo> action)
        {
            foreach (var type in this)
            {
                action(type.GetTypeInfo());
            }
        }

        public void ForEachStep(Action<Step> action)
        {
            ForEachKoan(typeInfo => {
                var methods = typeInfo.GetMethods()
                .Where(m => m.GetCustomAttributes(typeof(StepAttribute), false).Any())
                .OrderBy(m => m.GetCustomAttributes(typeof(StepAttribute), false)
                                .Cast<StepAttribute>().Single().Position)
                .ToArray();

            foreach (var methodInfo in methods)
            {
                action(new Step(typeInfo, methodInfo));
            }
        });

            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Type>)Types).GetEnumerator();
        }

        IEnumerator<Type> IEnumerable<Type>.GetEnumerator()
        {
            return ((IEnumerable<Type>)Types).GetEnumerator();
        }
    }
}