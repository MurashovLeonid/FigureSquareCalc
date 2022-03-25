using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureSquareCalc
{
	public class Circle : IFigure
	{
		public double Radius { get; }

		public Circle(double radius)
		{
			if (radius - Constants.MinRadius < Constants.CalculationAccuracy)
				throw new ArgumentException("Радиус круга не может равняться или быть меньше 0", nameof(radius));
			Radius = radius;
		}
		
		public double GetFigureSquare()
		{
			return Math.PI * Math.Pow(Radius, 2d);
		}
	}
}
