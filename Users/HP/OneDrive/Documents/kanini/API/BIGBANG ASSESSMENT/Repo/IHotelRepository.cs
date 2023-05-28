using BIGBANG_ASSESSMENT.Models;

namespace BIGBANG_ASSESSMENT.Repo
{
    public interface IHotelRepository
    {
        public IEnumerable<Hotels> GetHotels();

        public Hotels GetHotelById(int id);

        public Hotels PostHotels(Hotels Hotels);


        public void PutHotel(Hotels Hotels);

        public void DeleteHotels(int id);
        int GetAvailableRoomCount(string hotelname);



        IEnumerable<Hotels> GetLocation(string location);


        IEnumerable<Hotels> GetAmenities(string amenities);

        IEnumerable<Hotels> GetPrice(int price);

        IEnumerable<Hotels> FilterHotels(string location, int price, string amenities);

    }
}
