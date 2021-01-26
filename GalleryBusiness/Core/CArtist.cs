using Gallery.Models;
using GalleryBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GalleryBusiness.Core
{
    public class CArtist:IArtist
    {
        private GalleryContext gc = new GalleryContext();

        public bool AddArtist(Artist artist)
        {
            gc.Add(artist);
            gc.SaveChanges();
            return true;
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            var ainfo = gc.Artists.Select(a => a).ToList();
            return ainfo;
        }
        public Artist FindArtistByID(int id)
        {
            var artist = gc.Artists.Where(c => c.Aid == id).Select(c => c).FirstOrDefault();
            return artist;
        }
        public bool SetArtist(Artist eartist)
        {
            var updated = gc.Artists.Where(c => c.Aid == eartist.Aid)
                .Select(c => c).FirstOrDefault();
            updated.Aid = eartist.Aid;
            updated.Aname = eartist.Aname;
            updated.Aborn = eartist.Aborn;
            updated.Adied = eartist.Adied;
            updated.Ainformation = eartist.Ainformation;
            updated.AnumberOfWork = eartist.AnumberOfWork;
            gc.Artists.Update(updated);
            gc.SaveChanges();
            return true;
        }
        public bool DeleteArtist(int id)
        {
            var deleted = gc.Artists.FirstOrDefault(c => c.Aid == id);
            gc.Artists.Remove(deleted);
            gc.SaveChanges();
            return true;
        }
        public List<Artist> ArtistNameView()
        {
            var lartist = new List<Artist>();
            lartist = gc.Artists.Select(a => a).ToList();
            return lartist;

        }
    }
}
