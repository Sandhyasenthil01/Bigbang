using BIGBANG_ASSESSMENT.DB;
using BIGBANG_ASSESSMENT.Models;

namespace BIGBANG_ASSESSMENT.Repo
{
    public class RoomRepository:IRoomRepository
    {
      private readonly HotelContext hotelContext;

            public RoomRepository(HotelContext con)
            {
                hotelContext = con;
            }
            public Rooms GetRoomByid(int id)
            {
                return hotelContext.Rooms.FirstOrDefault(x => x.RoomId == id);
            }
            public IEnumerable<Rooms> GetRoom()
            {
                return hotelContext.Rooms.ToList();
            }
            public Rooms PostRoom(Rooms rooms)
            {
                hotelContext.Rooms.Find(rooms.RoomId);
                hotelContext.Rooms.Add(rooms);
                hotelContext.SaveChanges();
                return rooms;
            }
            public void PutRoom(Rooms rooms)
            {
                hotelContext.Entry(rooms).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                hotelContext.SaveChanges();
            }
            public void DeleteRoom(int id)
            {
                Rooms e = hotelContext.Rooms.FirstOrDefault(x => x.RoomId == id);
                hotelContext.Rooms.Remove(e);
                hotelContext.SaveChanges();
            }
        }
    }
















