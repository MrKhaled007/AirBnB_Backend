 public class AnonymousEurosongDataList : IAnonymousEurosongDataContext
 {
   List<Song> songs = new List<Song>();
   List<Artist> artists= new List<Artist>();

   List<Vote> votes= new List<Vote>();

   List<User> users= new List<User>();

   List<CampSpots> spots= new List<CampSpots>();

   List<Bookings> allbookings= new List<Bookings>();

   

    public object Users { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public void AddSong(Song song)
   {
     songs.Add(song);
   }

   public void AddArtist(Artist artist)
   {
    artists.Add(artist);
   }

  public void AddVote(Vote vote)
  {
    votes.Add(vote);
  } 

    

    

    public IEnumerable<Song> GetSongs()
   {
     return songs;
   }

   public IEnumerable<Artist> GetArtists()
   {
    return artists;
   }

   public IEnumerable<Vote> GetVotes()
   {
    return votes;
   }

    public Artist GetSinger(int id)
    {
        throw new NotImplementedException();
    }

    public Vote GetVote(int id)
    {
      throw new NotImplementedException();
    }

    public List<Song> getSongsByArtistID(int Artistid)
    {
        throw new NotImplementedException();
    }

    public Artist DeleteArtist(int id)
    {
        throw new NotImplementedException();
    }

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public IEnumerable<User> GetUsers()
    {
        return users;
    }

    public void UpdateUser(User user)
    {
        var existingUser = users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser != null)
        {
            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            // Update other fields as necessary
        }
    }

    public void AddCampSpots(CampSpots campSpots)
    {
        spots.Add(campSpots);
    }

    public IEnumerable<CampSpots> GetCampSpots()
    {
        return spots;
    }

    public CampSpots DeleteSpot(int id)
    {
        throw new NotImplementedException();
    }

    public CampSpots GetCampSpot(int id)
    {
        throw new NotImplementedException();
    }

    public void AddBooking(Bookings bookings)
    {
        allbookings.Add(bookings);
    }

    public IEnumerable<Bookings> GetBookings()
    {
        return allbookings;
    }

    public User GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    
}