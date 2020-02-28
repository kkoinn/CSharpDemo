namespace Demo.VehicleApp.Remote.Cars
{
	class Volvo
	{
		public string Model { get; }
		public string Code { get; }

		Volvo(string model, string code)
		{
			Model = model;
			Code = code;
		}
		public static Volvo Create(string model, string code)
		{
			return new Volvo(model, code);
		}
	}
}
