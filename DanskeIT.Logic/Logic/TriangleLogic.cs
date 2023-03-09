using DanskeIT.Data.Entities;
using DanskeIT.Logic.Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DanskeIT.Logic.Logic
{
    public class TriangleLogic : ITriangleLogic
    {
        public TriangleLogic() { }

        public string CheckTriangle(Triangle triangle)
        {
            switch (GetTriangleType(triangle))
            {
                case TriangleType.Equilateral:
                    return "Equilateral Triangle";
                case TriangleType.Isosceles:
                    return "Isosceles Triangle";
                default:
                    return "Scalene Triangle";
            }
        }

        public double CalculateArea(Triangle triangle)
        {
            double area = 0;
            
            int side1 = triangle.X; int side2 = triangle.Y; int side3 = triangle.Z;
           
            double semiperimeter = (side1 + side2 + side3) / 2;
            area = Math.Sqrt(semiperimeter * (semiperimeter - side1) * (semiperimeter - side2) * (semiperimeter - side3));

            return area;
        }

        public IList<TriangleResponse> SortTriangles(IList<Triangle> triangleList)
        {
            List<TriangleResponse> result = new List<TriangleResponse>();

            foreach (Triangle triangle in triangleList)
            {
                TriangleType triangleType = GetTriangleType(triangle);
                double area = CalculateArea(triangle);

                result.Add(new TriangleResponse() { 
                    X = triangle.X,
                    Y = triangle.Y,
                    Z = triangle.Z,
                    TriangleType=triangleType.ToString(),
                    Area = area    
                });
            }
            return result.OrderBy(a => a.Area).ToList();
        }

        private TriangleType GetTriangleType(Triangle triangle)
        {
            if (triangle.X == triangle.Y && triangle.Y == triangle.Z)
            {
                return TriangleType.Equilateral;
            }
            else if (triangle.X == triangle.Y || triangle.Y == triangle.Z || triangle.Z == triangle.X)
            {
                return TriangleType.Isosceles;
            }
            else
            {
                return TriangleType.Scalene;
            }
        }
    }
}
