using DanskeIT.Data.Entities;
using DanskeIT.Logic.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DanskeIT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriangleController : Controller
    {
        private readonly ITriangleService _triangleService;

        public TriangleController(ITriangleService triangleService)
        {
            _triangleService = triangleService;
        }


        [HttpPost("CheckTriangle")]
        public string CheckTriangle(Triangle triangle)
        {
            try
            {
                if (!ValidateTriangle(triangle))
                {
                    throw new Exception("Invalid triangle");
                }

                return _triangleService.CheckTriangle(triangle);
            }
            catch (Exception ex)
            {
                //todo logger
                return string.Empty;
            }
        }

        [HttpPost("CalculateArea")]
        public double CalculateArea(Triangle triangle)
        {
            try
            {
                if (!ValidateTriangle(triangle))
                {
                    throw new Exception("Invalid triangle");
                }
                return _triangleService.CalculateArea(triangle);
            }
            catch (Exception ex)
            {
                //todo logger
                return double.NaN;
            }
        }

        [HttpPost("SortTriangles")]
        public IList<TriangleResponse> SortTriangles(List<Triangle> triangleList)
        {
            try
            {
                foreach (Triangle triangle in triangleList)
                {
                    if (!ValidateTriangle(triangle))
                    {
                        throw new Exception("Invalid triangle");
                    }
                }
                return _triangleService.SortTriangles(triangleList);
            }
            catch (Exception ex)
            {
                //todo logger
                return new List<TriangleResponse>();
            }
        }

        private bool ValidateTriangle(Triangle triangle)
        {
            if (triangle.X == 0 || triangle.Y == 0 || triangle.Z == 0)
            {
                return false;
            }
            return true;
        }

    }
}
