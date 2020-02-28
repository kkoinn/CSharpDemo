namespace Demo.VehicleApp.Remote.Cars
{
	class Honda
	{
		public string Model { get; }
		public string Code { get; }

		Honda(string model, string code)
		{
			Model = model;
			Code = code;
		}
		public static Honda Create(string model, string code)
		{
			return new Honda(model, code);
		}
	}
}
