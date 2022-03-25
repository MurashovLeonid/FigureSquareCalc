using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureSquareCalc
{
    public class Triangle : ITriangle
    {
		private double eps = Constants.CalculationAccuracy;
		public double SideA { get; }
		public double SideB { get; }
		public double SideC { get; }

		public Triangle(double sideA, double sideB, double sideC)
		{
			if (sideA < eps)
				throw new ArgumentException("Значение для стороны указано неверно", nameof(sideA));

			if (sideB < eps)
				throw new ArgumentException("Значение для стороны указано неверно", nameof(sideB));

			if (sideC < eps)
				throw new ArgumentException("Значение для стороны указано неверно", nameof(sideC));

			var maxSide = Math.Max(sideA, Math.Max(sideB, sideC));
			var perimeter = sideA + sideB + sideC;
			if ((perimeter - maxSide) - maxSide < Constants.CalculationAccuracy)
				throw new ArgumentException("Наибольшая сторона треугольника не может быть больше суммы двух других сторон");

			SideA = sideA;
			SideB = sideB;
			SideC = sideC;

			_isRightTriangle = new Lazy<bool>(GetIsRectangularTriangle);
		}

		private readonly Lazy<bool> _isRightTriangle;
		public bool IsRightTriangle => _isRightTriangle.Value;

		private bool GetIsRectangularTriangle()
		{
			double maxSide = SideA, b = SideB, c = SideC;
			if (b - maxSide > Constants.CalculationAccuracy)
				Helper.SidesSwap(ref maxSide, ref b);

			if (c - maxSide > Constants.CalculationAccuracy)
				Helper.SidesSwap(ref maxSide, ref c);

			return Math.Abs(Math.Pow(maxSide, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) < Constants.CalculationAccuracy;
		}

		public double GetFigureSquare()
		{
			var perimeter = (SideA + SideB + SideC) / 2d;
			var square = Math.Sqrt(perimeter * (perimeter - SideA) * (perimeter - SideB) * (perimeter - SideC)																
			);

			return square;
		}
	}
}

