namespace Poker
{
    public interface ICard
    {
        CardFace Face { get; }
        CardSuit Suit { get; }
        string ToString();

        int CompareTo(ICard card);
    }
}
