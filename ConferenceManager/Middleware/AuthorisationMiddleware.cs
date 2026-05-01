
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;

namespace ConferenceManager.Middleware
{
    public class AuthorisationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine("ENTERING AUTH CHAIN");
            string path = context.Request.Path;
            string type = context.Request.Method;

            if (path.Contains("events"))
            {
                Console.WriteLine("Validating Event");
                AuthoriseAttendees(context, type);
            }
            else if (path.Contains("attendees"))
            {
                Console.WriteLine("Validating Attendee");
            }
            else if (path.Contains("speakers"))
            {
                Console.WriteLine("Validating Speaker");

            }
            await next.Invoke(context);
            Console.WriteLine("ENDING AUTH CHAIN");
        }
        
        public void AuthoriseAttendees(HttpContext context, string type)
        {
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            var attendeeName = jwtToken.Payload.FirstOrDefault(c => c.Key == "name").Value.ToString() ?? "";
            var userId = jwtToken.Payload.FirstOrDefault(c => c.Key == "sub").Value.ToString() ?? "";
            Console.WriteLine(userId);

            if (type is "POST")
            {
                Console.WriteLine("Type: Post");
            }
            if (type is "GET")
            {
                context.Response.Headers.Append("userId", userId);
            }
        }

    }
}
