using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LongerNum
{
	public class Longer
	{
		public double Mantissa { get; set; }
		public int Exponent { get; set; }
		public Longer(int x)
		{
			double m = x;
			int e = 0;
			while(m >= 10)
			{
				m /= 10;
				e++;
			}
			Mantissa = m;
			Exponent = e;
		}

		public Longer(double x)
		{
			int e = 0;
			while(x >= 10)
			{
				x /= 10;
				e++;
			}

			Mantissa = x;
			Exponent = e;
		}

        private Longer(double mantissa, int exponent)
        {
            // Re-normalize the number if addition made the mantissa >= 10 or < 1
            while (Math.Abs(mantissa) >= 10)
            {
                mantissa /= 10;
                exponent++;
            }
            while (Math.Abs(mantissa) < 1 && mantissa != 0)
            {
                mantissa *= 10;
                exponent--;
            }

            Mantissa = mantissa;
            Exponent = exponent;
        }

        // = operator
        public static implicit operator Longer(int x){ return new Longer(x); }
		public static implicit operator Longer(double x) { return new Longer(x); }

        public static Longer operator +(Longer a, Longer b)
        {
            // Step 1: Find the exponent difference to align the decimal points
            int diff = a.Exponent - b.Exponent;

            double adjustedMantissaA = a.Mantissa;
            double adjustedMantissaB = b.Mantissa;

            // Step 2: Shift the mantissa of the smaller number
            if (diff > 0)
            {
                // A is bigger, shift B
                adjustedMantissaB = b.Mantissa / Math.Pow(10, diff);
                return new Longer(adjustedMantissaA + adjustedMantissaB, a.Exponent);
            }
            else if (diff < 0)
            {
                // B is bigger, shift A
                adjustedMantissaA = a.Mantissa / Math.Pow(10, -diff);
                return new Longer(adjustedMantissaA + adjustedMantissaB, b.Exponent);
            }

            // Exponents match exactly
            return new Longer(adjustedMantissaA + adjustedMantissaB, a.Exponent);
        }

        public override string ToString()
		{
			return $"{Mantissa}E+{Exponent}";
		}
	}
}