using DanskeIT.Data.Entities;
using DanskeIT.Logic.Logic.ILogic;
using DanskeIT.Logic.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanskeIT.Logic.Services
{
    public class TriangleService : ITriangleService
    {
        private readonly ITriangleLogic _triangleLogic;
        public TriangleService(ITriangleLogic triangleLogic)
        {
            _triangleLogic = triangleLogic;
        }

        public string CheckTriangle(Triangle triangle)
        {
            return _triangleLogic.CheckTriangle(triangle);
        }

        public double CalculateArea(Triangle triangle)
        {
            return _triangleLogic.CalculateArea(triangle);
        }

        public IList<TriangleResponse> SortTriangles(IList<Triangle> triangleList)
        {
            return _triangleLogic.SortTriangles(triangleList);
        }
    }
}
