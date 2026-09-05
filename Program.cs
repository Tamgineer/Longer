using LongerNum;

public static class Program{
	public static void Main(string[] args){
		for(double i = 0; i <= 100; i++)
		{
            Longer x = i;
            Console.WriteLine(i + ": " + x);
        }

		Longer f = double.MaxValue;
		f += f;
        f += f;
        f += f;
        f += f;
        f += f;
        f += f;
        f += f;
        f += f;
        Console.WriteLine(double.MaxValue);
		Console.WriteLine(f);

	}
}
