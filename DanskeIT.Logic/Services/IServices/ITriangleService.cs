using DanskeIT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanskeIT.Logic.Services.IServices
{
    public interface ITriangleService
    {
        string CheckTriangle(Triangle triangle);
        double CalculateArea(Triangle triangle);
        IList<TriangleResponse> SortTriangles(IList<Triangle> triangleList);
    }
}
