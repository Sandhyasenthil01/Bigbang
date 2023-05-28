using BIGBANG_ASSESSMENT.DB;
using BIGBANG_ASSESSMENT.Models;
using Microsoft.EntityFrameworkCore;

namespace BIGBANG_ASSESSMENT.Repo
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelContext HotelContext;

        public HotelRepository(HotelContext con)
        {
            HotelContext = con;
        }
        public Hotels GetHotelById(int id)
        {
            return HotelContext.Hotels.FirstOrDefault(x => x.HotelId == id);
        }
        public IEnumerable<Hotels> GetHotels()
        {
            return HotelContext.Hotels.Include(x => x.Rooms).ToList();
        }
        public Hotels PostHotels(Hotels Hotels)
        {
            HotelContext.Hotels.Find(Hotels.HotelId);
            HotelContext.Hotels.Add(Hotels);
            HotelContext.SaveChanges();
            return Hotels;
        }
        public void PutHotel(Hotels Hotels)
        {
            HotelContext.Entry(Hotels).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            HotelContext.SaveChanges();
        }
        public void DeleteHotels(int id)
        {
            Hotels e = HotelContext.Hotels.FirstOrDefault(x => x.HotelId == id);
            HotelContext.Hotels.Remove(e);
            HotelContext.SaveChanges();
        }

        public int GetAvailableRoomCount(string hotelname)
        {
            var hotel = HotelContext.Hotels.Include(f => f.Bookings).FirstOrDefault(f => f.HotelName == hotelname);

            if (hotel == null)
                return 0;

            int totalRooms = hotel.RoomAvailability;
            int bookedRooms = hotel.Bookings.Count();
            int availableRooms = totalRooms - bookedRooms;

            return availableRooms >= 0 ? availableRooms : 0;




        }

        public IEnumerable<Hotels> GetLocation(string location)
        {
            return HotelContext.Hotels.Where(e => e.Location == location).ToList();
        }

        public IEnumerable<Hotels> GetAmenities(string amenities)
        {
            return HotelContext.Hotels.Where(e => e.Amenities == amenities).ToList();
        }

        public IEnumerable<Hotels> GetPrice(int price)
        {
            return HotelContext.Hotels.Where(e => e.Price == price).ToList();
        }
        public IEnumerable<Hotels> FilterHotels(string location, int price, string amenities)
        {
            var filteredHotels = HotelContext.Hotels.ToList();

            if (!string.IsNullOrEmpty(location))
            {
                filteredHotels = filteredHotels.Where(h => h.Location.ToLower() == location.ToLower()).ToList();
            }

            if (price > 0)
            {
                filteredHotels = filteredHotels.Where(h => h.Price <= price).ToList();
            }

            if (!string.IsNullOrEmpty(amenities))
            {
                var amenitiesList = amenities.Split(',').Select(a => a.Trim().ToLower()).ToList();
                filteredHotels = filteredHotels.Where(h => amenitiesList.All(a => h.Amenities.ToLower().Contains(a))).ToList();
            }

            return filteredHotels;
        }

    }
}

