using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Dapper_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService; // Replace with your service interface

        public PlayerController(IPlayerService playerService) // Inject your service here
        {
            _playerService = playerService;
        }

        [HttpPost]
        public IActionResult AddPlayer([FromBody] Playername playername)
        {
            if (playername == null || string.IsNullOrWhiteSpace(playername.Name))
            {
                return BadRequest("Player name is required.");
            }

            try
            {
                // You should call the service layer to add the player and retrieve the updated list
                dynamic response = _playerService.AddPlayer(playername.Name);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
