using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.CSharpExamples
{

	interface IAthlete
	{
		string Name { get; set; }
		int Age { get; set; }
	}

	class Skiier:IAthlete	
	{
		public string Name { get; set; }
		public int Age { get; set; }
	}

	class AthleteDecorator : IAthlete
	{
		private IAthlete _athlete;
		public AthleteDecorator(IAthlete athlete)
		{
			_athlete = athlete;
		}
		public string Name { get; set; }
		public int Age { get; set; }
	}
	class SkiGears:AthleteDecorator
	{
		private List<string> gears = new List<string>();
		public SkiGears(IAthlete athlete) : base(athlete)
		{
		}

		public void AddGear(string gear)
		{
			gears.Append(gear);
		}

		public void PrintGears()
		{
			
			gears.ForEach(f => Console.WriteLine(f));
		}
	}

	class DecoratorApp
	{
		public void run()
		{
			IAthlete a = new Skiier();
			a.Name = "Ingemar";
			a.Age = 60;

			SkiGears s = new SkiGears(a);
			s.AddGear("helmet");
			s.AddGear("boots");
			Console.WriteLine();
		}
	}
}
