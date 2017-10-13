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

        public void Instruct(Path path)
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
                ShowProgressOn(path);
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
            Random rand = new Random(DateTime.Now.Millisecond);

            // Quotes from http://www.zen-buddhism.net/quotes/zen-quotes.html
            List<string> statements = new List<string> {
                "You should study not only that you become a mother when your child is born, but also that you become a child.",
                "The one who is good at shooting does not hit the center of the target.",
                "When an ordinary man attains knowledge, he is a sage; when a sage attains understanding, he is an ordinary man.",
                "Think with your whole body.",
                "What is the sound of one hand clapping?",
                "I come to realize that mind is no other than mountains and rivers and the great wide earth, the sun and the moon and stars.",
                "In a mind clear as still water, even the waves, breaking, are reflecting its light.",
                "You will not be punished for your anger; you will be punished by your anger.",
                "Zen is not some kind of excitement, but concentration on our usual everyday routine.",
                "Before enlightenment; chop wood, carry water. After enlightenment; chop wood, carry water.",
                "You cannot travel the path until you have become the path itself",
                "You only lose what you cling to.",
                "Doubt everything. Find your own light.",
                "It is a man's own mind, not his enemy or foe, that lures him to evil ways"
            };
            
            Console.WriteLine(String.Format("  \"{0}\"", statements[rand.Next(statements.Count())]));
        }

        private void ShowProgressOn(Path path)
        {
            int stepCount = 0;
            path.ForEachStep(s => stepCount++);

            Console.WriteLine(String.Format("  {0} steps remain on the path.", stepCount - Observations.Count(o => o.IsSuccess)).Green());
        }

        private void EndScreen()
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine("The Master says:");
            Console.WriteLine("  You have reached enlightenment.".Cyan());
        }
    }

    public class SenseiException : Exception { }
}