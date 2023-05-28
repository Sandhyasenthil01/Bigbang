using BIGBANG_ASSESSMENT.Models;
using BIGBANG_ASSESSMENT.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BIGBANG_ASSESSMENT.Controller
{
    [Authorize(Roles = "Customer,Staff")]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository er;
       
        public HotelController(IHotelRepository er)
        {
            this.er = er;
        }



        [HttpGet]
        public ActionResult<IEnumerable<Hotels>> GetHotel()
        {
            try
            {
                return Ok(er.GetHotels());
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving hotels.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Hotels> Getid(int id)
        {
            try
            {
                var hotel = er.GetHotelById(id);
                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the hotel.");
            }
        }

        [HttpPost]
        public ActionResult<Hotels> Post(Hotels hotel)
        {
            try
            {
                return Ok(er.PostHotels(hotel));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpPut("{id}")]
        public IActionResult Put(Hotels hotel)
        {
            try
            {
                er.PutHotel(hotel);
                return NoContent();
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the hotel.");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                er.DeleteHotels(id);
                return NoContent();
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the hotel.");
            }
        }

        [HttpGet("/count")]
        public ActionResult<int> GetRoomAvailabilityCount(string hotelname)
        {
            try
            {
                int availablerooms = er.GetAvailableRoomCount(hotelname);
                return Ok(availablerooms);
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the room availability count.");
            }
        }



        [HttpGet("/filter/location")]
        public ActionResult<IEnumerable<Hotels>> GetLocation(string location)
        {
            try
            {
                return Ok(er.GetLocation(location));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while filtering by location.");
            }
        }


        [HttpGet("/filter/amenities")]
        public ActionResult<IEnumerable<Hotels>> GetAmenities(string amenities)
        {
            try
            {
                return Ok(er.GetAmenities(amenities));
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while filtering by amenities.");
            }
        }


        [HttpGet("/filter/price")]
        public ActionResult<IEnumerable<Hotels>> GetPrice(int price)
        {
            try
            {
                return Ok(er.GetPrice(price));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while filtering by price.");
            }
        }

        [HttpGet("/filter/all three")]
        public ActionResult<IEnumerable<Hotels>> Filter(string location, int price, string amenities)
        {
            try
            {
                var filteredHotels = er.FilterHotels(location, price, amenities);
                return Ok(filteredHotels);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while filtering hotels.");
            }
        }

    }
}

