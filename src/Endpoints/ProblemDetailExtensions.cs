namespace IWantApp.Endpoints;

public static class ProblemDetailExtensions
{
    public static Dictionary<string, string[]> ConvertToProblemDetail(this IReadOnlyCollection<Notification> notification)
    {
        return notification
            .GroupBy(g => g.Key)
            .ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());
    }
    
    public static Dictionary<string, string[]> ConvertToProblemDetail(this IEnumerable<IdentityError> error)
    {
        var dictionary = new Dictionary<string, string[]>();
        dictionary.Add("Error", error.Select(e => e.Description).ToArray());
        return dictionary;
    }
}
