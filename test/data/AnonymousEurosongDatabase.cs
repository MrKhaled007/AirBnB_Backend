
using LiteDB;


public class AnonymousEurosongDatabase : IAnonymousEurosongDataContext
{
    LiteDatabase db = new LiteDatabase(@"1data.db");
    string dbPath = @"data.db"; // Adjust this path if necessary
    
        
    
    

    private const string _ARTISTS = "Artists";

    private const string _SONGS = "Songs";

    private const string _USERS = "Users";

    private List<User> users = new List<User>();

    private const string _CampSpots = "CampSpots";

    private const string _Bookings = "Bookings";

    public object Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    void IAnonymousEurosongDataContext.AddSong(Song song)
  {
    db.GetCollection<Song>("Songs").Insert(song);
  }
 
 
  IEnumerable<Song> IAnonymousEurosongDataContext.GetSongs()
  {
    return db.GetCollection<Song>("Songs").FindAll();
  }
  
  

    

    void IAnonymousEurosongDataContext.AddArtist(Artist artist)
    {
        db.GetCollection<Artist>("Artists").Insert(artist);
    }

    IEnumerable<Artist> IAnonymousEurosongDataContext.GetArtists()
    {
        return db.GetCollection<Artist>("Artists").FindAll();
    }

    Artist IAnonymousEurosongDataContext.GetSinger(int id) => db.GetCollection<Artist>(_ARTISTS).FindById(id);

    List<Song> IAnonymousEurosongDataContext.getSongsByArtistID(int Artistid)
    {
        return db.GetCollection<Song>("Songs").Find(x => x.Artist_ID == Artistid).ToList();
    }



   
  
    public Artist DeleteArtist(int id)
    {
        var artistCollection = db.GetCollection("Artists");
        
        var deletionResult = artistCollection.Delete(id);
        
        if (deletionResult)
        {
            return null; // Return the deleted artist
        }
        else
        {
            // Handle deletion failure
            return null;
        }
        
    }

    void IAnonymousEurosongDataContext.AddUser(User user)
  {
    db.GetCollection<User>("Users").Insert(user);
  }

    IEnumerable<User> IAnonymousEurosongDataContext.GetUsers()
    {
        return db.GetCollection<User>("Users").FindAll();
    }

    



    public void AddCampSpots(CampSpots campSpots)
    {
        db.GetCollection<CampSpots>("CampSpots").Insert(campSpots);
    }

    public IEnumerable<CampSpots> GetCampSpots()
    {
        return db.GetCollection<CampSpots>("CampSpots").FindAll();
    }

    public CampSpots DeleteSpot(int id)
    {
        var SpotCollection = db.GetCollection("CampSpots");
        
        var deletionResult = SpotCollection.Delete(id);
        
        if (deletionResult)
        {
            return null; // Return the deleted artist
        }
        else
        {
            // Handle deletion failure
            return null;
        }
    }

    public CampSpots GetCampSpot(int id)
    {
        return db.GetCollection<CampSpots>(_CampSpots).FindById(id);
    }

    

     void IAnonymousEurosongDataContext.AddBooking(Bookings bookings)
  {
    db.GetCollection<Bookings>("Bookings").Insert(bookings);
  }

    public IEnumerable<Bookings> GetBookings()
    {
        return db.GetCollection<Bookings>("Bookings").FindAll();
    }

    public User GetUserById(int id)
    {
        return db.GetCollection<User>(_USERS).FindById(id);
    }

    void IAnonymousEurosongDataContext.UpdateUser(User user)
    {
        var collection = db.GetCollection<User>("Users");
        var existingUser = collection.FindById(user.Id);
        if (existingUser != null)
        {
            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            // Update other fields as necessary

            collection.Update(existingUser);
        }
    }

   
}