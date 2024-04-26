using HackVisualVirtuosoBE.Models;
using Microsoft.EntityFrameworkCore;
namespace HackVisualVirtuosoBE.API
{
    public class UserAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/checkuser/{uid}", (HackVisualVirtuosoBEDbContext db, string uid) =>
            {
                var user = db.Users.Where(user => user.Uid == uid).ToList();
                if (uid == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(user);
                }
            });

            app.MapPost("/createUser", (HackVisualVirtuosoBEDbContext db, User newUser) =>
            {
                db.Users.Add(newUser);
                db.SaveChanges();
                return Results.Created($"/user/{newUser.Id}", newUser);
            });
        }
    }
}