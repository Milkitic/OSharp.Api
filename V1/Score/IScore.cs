namespace CSharpOsu.V1.Score
{
    public interface IScore
    {
        long Score { get; }
        int Count300 { get; }
        int Count100 { get; }
        int Count50 { get; }
        int CountMiss { get; }
        int MaxCombo { get; }
        int CountKatu { get; }
        int CountGeki { get; }
        bool IsPerfect { get; }
        long UserId { get; }
        string Rank { get; }
    }
}
