using System;

namespace Demo.CSharpExamples
{
	namespace DemoApplication
	{
		public class TutorialBase
		{
			protected int TutorialId;
			protected string TutorialName;
			protected string Category;
			public TutorialBase(string category) => Category = category;

			//public TutorialBase(string category) => Category = category;


			public void SetTutorial(int pID, string pName)
			{
				TutorialId = pID;
				TutorialName = pName;
			}

			public void SetTutorial(string pName) => TutorialName = pName;

			public string GetTutorial()
			{
				return $"{TutorialName}";
			}
			public string GetTutorialWithCategory()
			{
				return $"{Category} - {TutorialName}";
			}
			public void RenameTutorial(String pNewName)
			{
				TutorialName = pNewName;
			}

			public virtual string BeautifyTutorial()
			{
				return $"{Category.ToUpper()} - {TutorialName}";
			}

		}
		public abstract class Tutorial
		{
			protected  int TutorialId;
			protected string TutorialName;

			public abstract void SetTutorial(int pId, string pName);
			public abstract void SetTutorial(string pName);
			public abstract string GetTutorial();
			public void RenameTutorial(String pNewName)
			{
				TutorialName = pNewName;
			}

		}
		public class CSharpTutorial: Tutorial
		{
			const string CategoryName = "CSharp";
			public override void SetTutorial(int pId, string pName)
			{
				TutorialId = pId;
				TutorialName = pName;
			}
			public override void SetTutorial(string pName)
			{
				TutorialName = pName;
			}

			public override string GetTutorial()
			{
				return $"{CategoryName} - {TutorialName}";
			}
		}

		public class JavaTutorial : TutorialBase
		{
			public JavaTutorial():base("Java")
			{

			}

			public override string BeautifyTutorial()
			{
				return $"{Category} - {TutorialName} - Inside non base method BeautifyTutorial";
			}
		}

	}
}
