using System.Web.Http;
using WebActivatorEx;
using NextSalaryCalculator;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace NextSalaryCalculator
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "NextSalaryCalculator");
                        c.DescribeAllEnumsAsStrings(); 
                        c.PrettyPrint();
                    })
                .EnableSwaggerUi(c =>
                    {

                        c.DocumentTitle("NextSalaryCalculator");


                    });
        }
    }
}
