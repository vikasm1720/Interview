using DanskeIT.Logic.Logic;
using DanskeIT.Logic.Logic.ILogic;
using DanskeIT.Logic.Services;
using DanskeIT.Logic.Services.IServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanskeIT.Logic
{
    public static class DependencyInjection
    {
        public static void RegisterLogicDependencies(this IServiceCollection services)
        {
            services.AddScoped<ITriangleLogic, TriangleLogic>();
            services.AddScoped<ITriangleService, TriangleService>();
        }
    }
}
