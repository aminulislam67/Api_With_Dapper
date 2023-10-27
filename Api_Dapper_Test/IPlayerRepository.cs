namespace Api_Dapper_Test
{
    public interface IPlayerRepository
    {
        List<Player> AddPlayer(string playerName);
    }
}
