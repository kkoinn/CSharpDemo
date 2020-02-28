using System;
using System.Collections.Generic;
using System.Linq;
using Demo.CSharpExamples.DemoApplication;

namespace Demo.CSharpExamples
{
	class Program
	{
		private static IEnumerable<object> Source => new object[] { "test", 1, new object[] { 1, 2, 3, new object[] { 4, 3, 2 } }, "test", null };

		static void Main(string[] args)
		{
			Console.WriteLine("Recursive iterators");
			RecursiveIterators r = new RecursiveIterators();
			Console.WriteLine("Flatten with yield");
			r.Flatten(Source).ToList().ForEach(s => Console.WriteLine(s));
			Console.WriteLine();
			Console.WriteLine("Flatten without yield");
			r.FlattenNotYield(Source).ToList().ForEach(s => Console.WriteLine(s));
			Console.WriteLine();
			Console.WriteLine("Recursive print all items, with lambda adding a prefix");
			Source.FlattenExt(s => "prefix:" + (s?.ToString() ?? "I'm null")).ToList().ForEach(k => Console.WriteLine(k));
			Console.WriteLine();
			Console.WriteLine("Sum intervall recursive");
			Console.WriteLine(r.SumTheIntervall(1, 3).ToString());
			Console.WriteLine();
			Console.WriteLine("Inheritance polymorphism");
			Console.WriteLine("Abstract Class");
			CSharpTutorial pTutor = new CSharpTutorial();
			pTutor.SetTutorial(1, "First tutorial");
			Console.WriteLine(pTutor.GetTutorial());
			pTutor.SetTutorial("Second tutorial");
			Console.WriteLine(pTutor.GetTutorial());
			pTutor.RenameTutorial("Renamed cSharp tutorial");
			Console.WriteLine(pTutor.GetTutorial());
			Console.WriteLine();
			Console.WriteLine("Base class non abstract");
			JavaTutorial pTutor2 = new JavaTutorial();
			pTutor2.SetTutorial(1, "First tutorial");
			Console.WriteLine(pTutor2.GetTutorial());
			Console.WriteLine(pTutor2.GetTutorialWithCategory());
			pTutor2.SetTutorial("Second tutorial");
			Console.WriteLine(pTutor2.GetTutorial());
			Console.WriteLine(pTutor2.GetTutorialWithCategory());
			pTutor2.RenameTutorial("Renamed to Third tutorial");
			Console.WriteLine(pTutor2.GetTutorialWithCategory());
			Console.WriteLine(pTutor2.BeautifyTutorial());
			Console.WriteLine();
			Console.WriteLine("Interfaces");
			Interfaces i = new Interfaces();
			i.Tutorials.ForEach(a =>
			{
				if (a is GoTutorial t)
				{
					Console.WriteLine(t.BeautifyTutorial());
					var (tutorialId, tutorialName, category) = t;
					Console.WriteLine($"Deconstructed object: {tutorialId}, {tutorialName}, {category}");
				}
				Console.WriteLine(a.ConstructTutorial());
				Console.WriteLine(a.GetTutorialFullName());
			});
			Console.WriteLine();
			Console.WriteLine("Pattern matching");
			PatternMatching p = new PatternMatching();
			p.FindStringTypes(Source).ForEach(a => Console.WriteLine($"{a.Type} {a.isString} {a.comment}"));
			var (type, comment) = p.SwitchPattern(7);
			Console.WriteLine($"Type: {type} {comment}");
			var ps = p.SwitchPattern("I'm a string");
			Console.WriteLine($"Type: {ps.Type} {ps.comment}");
			ps = p.SwitchPattern(new TutorialBase("Java"));
			Console.WriteLine($"Type: {ps.Type} {ps.comment}");
			Console.ReadKey();
		}
	}
}


//1 > 1 + 1				1 + 1 + 1 = 3
//	2 > 2 + 1			2 + 2 + 1 = 5
//		3 > 3			3 + 3 = 6


//metod 1: 1 + 5 (sum)
//metod 2: 2 + 3 (sum)
//metod 3: 3 (ingen sum)