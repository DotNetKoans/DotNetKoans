using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.DotNet.Cli.Utils;

namespace DotNetCoreKoans.Engine
{
    public class Sensei
    {
        private Reporter Console;
        private ICollection<StepResult> Observations;

        public Sensei(Reporter console)
        {
            Console = console;
            Observations = new List<StepResult>();
        }

        public bool Failed()
        {
            return Observations.Any(s => s is FailedStepResult);
        }

        public void Observe(StepResult result)
        {
            Observations.Add(result);
            if(result.IsFailure)
            {
                throw new SenseiException();
            }
        }

        public void Instruct()
        {
            if (Failed())
            {
                foreach (var result in Observations)
                {
                    result.Report(Console);
                }
                Encourage();
                GuideThroughError();
                AZenlikeStatement();
                ShowProgress();
            }
            else
            {
                EndScreen();
            }
        }

        public void Encourage()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine("The Master says:");
            Console.WriteLine("  You have not yet reached enlightenment.".Cyan());
        }

        private void GuideThroughError()
        {
            
        }

        private void AZenlikeStatement()
        {
            
        }

        private void ShowProgress()
        {
            
        }

        private void EndScreen()
        {
            
        }
    }

    public class SenseiException : Exception { }
}