public interface IAnonymousEurosongDataContext
{
    object Users { get; set; }

    void AddSong(Song song);
  IEnumerable<Song> GetSongs();
  
 


  List<Song> getSongsByArtistID(int Artistid);

  void AddArtist(Artist artist);

  IEnumerable<Artist> GetArtists();

  Artist GetSinger(int id);

  Artist DeleteArtist(int id);
  




 
  








  void AddUser(User user);
  IEnumerable<User> GetUsers();
  User GetUserById(int id);
  void UpdateUser(User user);


  

void AddCampSpots(CampSpots campSpots);
IEnumerable<CampSpots> GetCampSpots();
CampSpots DeleteSpot(int id);

CampSpots GetCampSpot(int id);

void AddBooking(Bookings bookings); 
IEnumerable<Bookings> GetBookings();














}