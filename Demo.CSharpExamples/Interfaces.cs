using System;
using System.Collections.Generic;

namespace Demo.CSharpExamples
{
	public class TutorialFactory
	{
		public static ITutorial Create<T>(int tutorialId, string tutorialName, string category)
		{
			if (typeof(T) == typeof(GoTutorial))
			{
				return  new GoTutorial(tutorialId, tutorialName, category);
			}
			if (typeof(T) == typeof(PythonTutorial))
			{
				return new PythonTutorial(tutorialId, tutorialName, category);
			}

			throw new NotImplementedException();
		}
	}
	public abstract class MustInitializeTutorialBase
	{
		internal int TutorialId
		{
			get;
			set;
		}

		internal string TutorialName
		{
			get;
			set;
		}
		internal string Category
		{
			get;
			set;
		}

		protected MustInitializeTutorialBase(int tutorialId,  string tutorialName,  string category)
		{
			TutorialId = tutorialId;
			TutorialName = tutorialName;
			Category = category;
		}
	}
	public interface ITutorial
	{
		string ConstructTutorial();
		string GetTutorialFullName()
		{
			return "I am a default method in the interface!";
		}
	}

	class Interfaces
	{
		public List<ITutorial> Tutorials
		{
			get =>
				new List<ITutorial>()
				{
					new PythonTutorial(0, "Python Tutorial", "Old but Trendy"),
					new GoTutorial(0, "Go Tutorial", "New and trendy")
				};
			set => throw new NotImplementedException();
		}

		public ITutorial ConstructCustomTutorial(int numberOfPages, string name) => (numberOfPages) switch
			{
			    _ when numberOfPages < 5 => TutorialFactory.Create<PythonTutorial>(0, name, "Old but Trendy"),
				_ => TutorialFactory.Create<GoTutorial>(1, name, "New and trendy")
			};
}


	public class PythonTutorial : MustInitializeTutorialBase, ITutorial
	{
		public PythonTutorial(int tutorialId, string tutorialName, string category):base(tutorialId,  tutorialName, category)
		{

		}
		public string GetTutorialFullName()
		{
			return $"The {TutorialName} is constructed as a {Category} category";
		}
		public string ConstructTutorial()
		{
			return $"The {TutorialName} is constructed, defined as a {Category} category";
		}
		public void Deconstruct(out int tutorialId, out string tutorialName, out string category)
		{
			tutorialId = TutorialId;
			tutorialName = TutorialName;
			category = Category;
		}
	}
	public class GoTutorial : MustInitializeTutorialBase, ITutorial
	{
		public GoTutorial(int tutorialId, string tutorialName, string category) : base(tutorialId, tutorialName, category)
		{

		}

		public string ConstructTutorial()
		{
			return $"The {TutorialName} is constructed as a {Category} category";
		}

		public void Deconstruct(out int tutorialId, out string tutorialName, out string category)
		{
			tutorialId = TutorialId;
			tutorialName = TutorialName;
			category = Category;
		}

		public string GetTutorialFullName()
		{
			return $"Not default interface {TutorialName} - {TutorialId}";
		}
		public string BeautifyTutorial()
		{
			return "I'm a beatified tutorial";
		}
	}
}
