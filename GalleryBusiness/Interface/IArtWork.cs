using Gallery.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Gallery.ViewModels;
namespace GalleryBusiness.Interface
{
   public interface IArtWork
    {
        public IEnumerable<ArtworkWithArtistName> ListOfArtWork();
        public bool AddArtWork(ArtWork artwork);
        public ArtWork FindArtWorkByID(int id);
        public bool SetArtWork(ArtWork eartwork);
        public bool DeleteArtWork(int id);
        public List<ArtWork> ArtworkNameView();
    }
}
