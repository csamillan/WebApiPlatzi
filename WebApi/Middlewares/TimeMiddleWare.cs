namespace WebApi.Middlewares
{
    public class TimeMiddleWare
    {
        readonly RequestDelegate next;

        public TimeMiddleWare(RequestDelegate nextrequest)
        {
            next = nextrequest;
        }

        public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext  context)
        {
            await next(context); // en esta posicion, la respuesta de este middleware se agrega al final

            if(context.Request.Query.Any( p => p.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortDateString());
            }

            await next(context); // en esta posicion, solo se muestra la respuesta del middlaware ya que primero se ejecutara esta logica antes de los demas request
        }
    }

    public static class TimeMiddleWareExtension
    {
        public static IApplicationBuilder UseTimeMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleWare>();
        }
    }
}

