using Microsoft.VisualStudio.TestTools.UnitTesting;
using DanskeIT.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanskeIT.Logic.Logic.ILogic;
using DanskeIT.Logic.Logic;
using DanskeIT.Data.Entities;

namespace DanskeIT.Logic.Services.Tests
{
    [TestClass()]
    public class TriangleServiceTests
    {
        private readonly ITriangleLogic _triangleLogic;
           
        public TriangleServiceTests()
        {
            _triangleLogic = new TriangleLogic();
        }

        [TestMethod()]
        public void CheckTriangleIsEquilateral()
        {
            Triangle triangle = new Triangle() { X = 4, Y = 4, Z = 4 };
            string result = _triangleLogic.CheckTriangle(triangle);
            Assert.IsFalse(result != "Equilateral Triangle", "All sides should be equal");
        }
        [TestMethod()]
        public void CheckTriangleIsNotEquilateral()
        {
            Triangle triangle = new Triangle() { X = 4, Y = 4, Z = 6 };
            string result = _triangleLogic.CheckTriangle(triangle);
            Assert.IsFalse(result == "Equilateral", "All sides should not be equal");
        }
        [TestMethod()]
        public void CheckTriangleIsIsosceles()
        {
            Triangle triangle = new Triangle() { X = 4, Y = 4, Z = 6 };
            string result = _triangleLogic.CheckTriangle(triangle);
            Assert.IsFalse(result != "Isosceles Triangle", "All sides should be equal");
        }
        [TestMethod()]
        public void CheckTriangleIsNotIsosceles()
        {
            Triangle triangle = new Triangle() { X = 5, Y = 4, Z = 6 };
            string result = _triangleLogic.CheckTriangle(triangle);
            Assert.IsFalse(result == "Isosceles", "All sides should not be equal");
        }

        [TestMethod()]
        public void CheckTriangleIsScalene()
        {
            Triangle triangle = new Triangle() { X = 4, Y = 5, Z = 6 };
            string result = _triangleLogic.CheckTriangle(triangle);
            Assert.IsFalse(result != "Scalene Triangle", "All sides should be equal");
        }
        [TestMethod()]
        public void CheckTriangleIsNotScalene()
        {
            Triangle triangle = new Triangle() { X = 4, Y = 4, Z = 6 };
            string result = _triangleLogic.CheckTriangle(triangle);
            Assert.IsFalse(result == "Scalene", "All sides should not be equal");
        }

        [TestMethod()]
        public void CalculateAreaTest()
        {
            Triangle triangle = new Triangle() { X = 4, Y = 4, Z = 6 };
            double result = _triangleLogic.CalculateArea(triangle);
            Assert.IsFalse(result <= 0, "All sides should greater than 0");
           
        }

        [TestMethod()]
        public void CalculateAreaFailTest()
         {
            Triangle triangle = new Triangle() { X = 4, Y = 4, Z = 0 };
            double result = _triangleLogic.CalculateArea(triangle);
            Assert.IsFalse(result > 0, "All sides should greater than 0");

        }

        [TestMethod()]
        public void SortTrianglesTest()
        {
            List<Triangle> triangleList = new List<Triangle>();

            triangleList.Add(new Triangle() { X = 4, Y = 4, Z = 4 });
            triangleList.Add(new Triangle() { X = 4, Y = 8, Z = 4 });
            triangleList.Add(new Triangle() { X = 4, Y = 6, Z = 7 });
            var result = _triangleLogic.SortTriangles(triangleList);
            Assert.IsFalse(result.Count() <=0,"Triangles are incorrect");
        }
    }
}