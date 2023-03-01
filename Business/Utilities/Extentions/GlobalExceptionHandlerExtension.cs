using Core.Utilities.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Extentions
{
    public static class GlobalExceptionHandlerExtension
    {
        public static void CustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var Feature = context.Features.Get<IExceptionHandlerFeature>();
                    int statuscode = 500;
                    string message = "Server error:(";
                    if (Feature != null)
                    {
                        message = Feature.Error.Message;
                        if (Feature.Error is NotFoundException)
                        {
                            statuscode = 404;
                        }
                        context.Response.Redirect("/Home/Error");
                    }
                    else
                    {
                        context.Response.StatusCode = statuscode;
                        string response = JsonConvert.SerializeObject(new
                        {
                            code = statuscode,
                            message = message
                        });
                        await context.Response.WriteAsync(response);
                    }
            ;
                });
            });
        }
    }
}
