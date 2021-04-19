using System;
using System.Linq;
using System.Reflection;
using Microsoft.DotNet.Cli.Utils;
using Xunit.Sdk;

namespace DotNetCoreKoans.Engine
{
    public class Step
    {

        public Step(TypeInfo typeInfo, MethodInfo methodInfo)
        {
            TypeInfo = typeInfo;
            MethodInfo = methodInfo;
        }

        public TypeInfo TypeInfo { get; }
        public MethodInfo MethodInfo { get; }

        public string Name { get { return $"{TypeInfo.Name} {MethodInfo.Name}"; } }
        public StepResult Meditate()
        {
            var koan = GetKoan();
            var results = new[] {
                Try(() => koan.Setup()),
                Try(() => MethodInfo.Invoke(koan, Array.Empty<object>())),
                Try(() => koan.TearDown())
            };

            return results.Any(r => r is FailedStepResult) ?
                results.First(r => r is FailedStepResult) :
                results.FirstOrDefault();
        }

        public StepResult Try(Action throwable)
        {
            try
            {
                throwable();
            }
            catch (TargetInvocationException e)
            {
                if (e.InnerException is XunitException)
                {
                    return new AssertionFailedStepResult { Step = this, Exception = e.InnerException };
                }
                return new FailedStepResult { Step = this, Exception = e.InnerException ?? e };
            }
            catch (Exception e)
            {
                return new FailedStepResult { Step = this, Exception = e };
            }

            return new SuccessStepResult { Step = this };
        }

        public Koan Instance { get; private set; }

        public Koan GetKoan()
        {
            return Instance ?? (Instance = Activator.CreateInstance(TypeInfo.AsType()) as Koan);
        }
    }

    public abstract class StepResult
    {
        public bool IsSuccess { get; set; }
        public bool IsFailure => !IsSuccess;
        public Step Step { get; set; }
        public Exception Exception { get; set; }

        public virtual void Report(Reporter console)
        {
            console.WriteLine($"{Step.Name} has damaged your karma.".Bold().Red());
            console.WriteLine();

            if (Exception is AssertActualExpectedException assertException)
            {
                console.WriteLine("The truth you are looking for...".Bold().Green());
                console.WriteLine($"{assertException.Actual} is not {assertException.Expected}".Bold().Green());
                console.WriteLine();
            }

            console.WriteLine("Ponder the meaning in these lines:".Cyan());
            console.WriteLine($"{String.Join('\n', Exception.GetStackTracePaths())}".Cyan());
        }
    }

    public class SuccessStepResult : StepResult
    {
        public SuccessStepResult()
        {
            IsSuccess = true;
        }

        public override void Report(Reporter console)
        {
            console.WriteLine($"{Step.Name} has expanded your awareness.".Green());
        }
    }

    public class FailedStepResult : StepResult
    {

    }

    public class AssertionFailedStepResult : FailedStepResult
    { }

    //This attribute is because we can't guarantee the order
    //of the methods when we walk a class. So this allows us
    //to order them to make sure we evaluate them as intended.
    //Note that positioning is relative to the class, not to the
    //entire project
    public class StepAttribute : Attribute
    {
        public int Position { get; set; }

        public StepAttribute(int position) { this.Position = position; }
    }
}
