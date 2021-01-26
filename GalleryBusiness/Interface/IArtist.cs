using Gallery.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GalleryBusiness.Interface
{
    public interface IArtist
    {
        public IEnumerable<Artist> GetAllArtists();
        public bool AddArtist(Artist artist);
        public bool SetArtist(Artist eartist);
        public bool DeleteArtist(int id);
        public Artist FindArtistByID(int id);
        public List<Artist> ArtistNameView();
    }
}
