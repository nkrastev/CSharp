namespace IRunes.Services
{
    using IRunes.ViewModels.Albums;
    using IRunes.ViewModels.Tracks;
    using IRunes.ViewModels.Users;
    using System.Collections.Generic;
  

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);                        
        ICollection<string> ValidateAlbum(AlbumFormModel model);
        ICollection<string> ValidateTrack(TrackFormModel model);

    }
}
