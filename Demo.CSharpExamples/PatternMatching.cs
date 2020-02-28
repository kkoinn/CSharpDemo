using System.Collections.Generic;
using System.Linq;
using Demo.CSharpExamples.DemoApplication;

namespace Demo.CSharpExamples
{
	class PatternMatching
	{
		public enum State
		{
			Ready,
			NotReady
		}
		public List<(string Type, bool isString, string comment)> FindStringTypes(IEnumerable<object> types)
		{
			return types.Select(o => o is string ? (o.GetType().Name, true, "Yes a string") : (o?.GetType().Name ?? "I'm null", false, "Not a string")).ToList();
		}
		

		public (string Type, string comment) SwitchPattern(object o) =>
			(o)switch
				{
				null => ("I'm null", "It's a int"),
				int i => (i.GetType().Name, "It's a int"),
				TutorialBase p when p.GetTutorial().StartsWith("Java") => (p.GetType().Name, "This is a Java tutorial"),
				var x => ("it's a var pattern with the type" + x.GetType(), "reached var pattern")
				};
		/*public State ChangeState(ITutorial tutorial) => (tutorial) switch
		{
				Tutorial{Category} => Closed,
				(Closed, Open) => Opened,
				(Closed, Lock) when hasKey => Locked,
				(Locked, Unlock) when hasKey => Closed,
				_ => throw new InvalidOperationException($"Invalid transition")
		};*/
	}
}
