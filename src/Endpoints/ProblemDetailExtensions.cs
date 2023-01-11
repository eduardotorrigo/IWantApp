namespace IWantApp.Endpoints;

public static class ProblemDetailExtensions
{
    public static Dictionary<string, string[]> ConvertToProblemDetail(this IReadOnlyCollection<Notification> notification)
    {
        return notification
            .GroupBy(g => g.Key)
            .ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());
    }
}
