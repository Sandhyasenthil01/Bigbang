using BIGBANG_ASSESSMENT.Models;
using BIGBANG_ASSESSMENT.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BIGBANG_ASSESSMENT.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
            private readonly IRoomRepository hr;

            public RoomsController(IRoomRepository hr)
            {
                this.hr = hr;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Rooms>> GetRoom()
            {
                try
                {
                    return Ok(hr.GetRoom());
                }
                catch (Exception ex)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving hotels.");
                }
            }

            [HttpGet("{id}")]
            public ActionResult<Rooms> GetRoomByid(int id)
            {
                try
                {
                    var rooms = hr.GetRoomByid(id);
                    if (rooms == null)
                    {
                        return NotFound();
                    }
                    return Ok(rooms);
                }
                catch (Exception ex)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the hotel.");
                }
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, Rooms room)
            {
                try
                {
                    hr.PutRoom(room);
                    return NoContent();
                }
                catch (Exception ex)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the hotel.");
                }
            }

            [HttpPost]
            public ActionResult<Rooms> Post(Rooms room)
            {
                try
                {
                    return Ok(hr.PostRoom(room));
                }
                catch (Exception ex)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the hotel.");
                }
            }



            [HttpDelete("{id}")]
            public IActionResult DeleteRoom(int id)
            {
                try
                {
                    hr.DeleteRoom(id);
                    return NoContent();
                }
                catch (Exception ex)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the hotel.");
                }
            }


        }
    }


