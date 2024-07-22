namespace AspireDay.WebApp.Services;

public class SessionService : ISessionService
{
    public Guid UserId { get; set; }

    public SessionService()
    {
        UserId = Guid.Parse("f07a8ade-a1d6-4dc8-9b09-17d37ff61b65");
    }
}

public interface ISessionService
{
    Guid UserId { get; set; }
}