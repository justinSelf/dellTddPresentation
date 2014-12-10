namespace DellTddBanking2.Bus
{
    public interface IHandleMessages<T> where T : IMessage
    {
        void Handle(T message);
    }
}