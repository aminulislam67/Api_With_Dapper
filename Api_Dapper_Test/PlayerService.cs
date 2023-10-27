using System.Dynamic;

namespace Api_Dapper_Test
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public dynamic AddPlayer(string playerName)
        {
            dynamic response = new ExpandoObject();

            if (string.IsNullOrWhiteSpace(playerName))
            {
                response.Success = false;
                response.DataTitle = "Error";
                response.Data = "Player name is required.";
            }
            else
            {
                try
                {
                    List<Player> updatedPlayers = _playerRepository.AddPlayer(playerName);

                    foreach (var player in updatedPlayers)
                    {
                        if (player.Weight > 50)
                        {
                            player.Weight = 100;
                        }
                    }

                    response.Success = true;
                    response.Data = updatedPlayers;
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Data = ex.Message;
                }
            }

            return response;
        }
    }
}
