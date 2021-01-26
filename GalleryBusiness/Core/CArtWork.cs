using Gallery.Models;
using GalleryBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Gallery.ViewModels;
namespace GalleryBusiness.Core
{
    public class CArtWork:IArtWork
    {
        private GalleryContext gc = new GalleryContext();

       
        public IEnumerable<ArtworkWithArtistName> ListOfArtWork()
        {
            var artname = (from art in gc.ArtWorks
                           join awitha in gc.Artists
                           on art.Aid equals awitha.Aid
                           select new ArtworkWithArtistName
                           {
                               Awid = art.Awid,
                               Awdate = art.Awdate,
                               Awinformation = art.Awinformation,
                               Awname = art.Awname,
                               Awtype = art.Awtype,
                               Awvalue = art.Awvalue,
                               Aname = awitha.Aname
                           }
                           ).ToList();
            return artname;

        }
        public bool AddArtWork(ArtWork artwork)
        {
            gc.Add(artwork);
            gc.SaveChanges();
            return true;
        }



        public ArtWork FindArtWorkByID(int id)
        {
            var artwork =( from artw in gc.ArtWorks
                          join awitha in gc.Artists
                          on artw.Aid equals awitha.Aid
                          where artw.Awid == id
                          select new ArtWork
                          {
                Awdate = artw.Awdate,
                Awname = artw.Awname,
                Awinformation = artw.Awinformation,
                Awtype = artw.Awtype,
                Awvalue = artw.Awvalue,
                Awid = artw.Awid,
                Aid = awitha.Aid
            }).FirstOrDefault();
            return artwork;
    }

        public bool SetArtWork(ArtWork eartwork)
        {
            var updated = gc.ArtWorks.Where(c => c.Awid == eartwork.Awid)
                .Select(c => c).FirstOrDefault();
            updated.Awname = eartwork.Awname;
            updated.Awinformation = eartwork.Awinformation;
            updated.Awtype = eartwork.Awtype;
            updated.Awvalue = eartwork.Awvalue;
            updated.Awid = eartwork.Awid;
            updated.Aid = eartwork.Aid;
            gc.ArtWorks.Update(updated);
            gc.SaveChanges();
            return true;
        }
        public bool DeleteArtWork(int id)
        {
            var deleted = gc.ArtWorks.Where(c => c.Awid == id)
                .Select(c => c).FirstOrDefault();
            gc.ArtWorks.Remove(deleted);
            gc.SaveChanges();
            return true;
        }
        public List<ArtWork> ArtworkNameView()
        {
           var  lartist = gc.ArtWorks.Select(a => a).ToList();
            return lartist;
        }
    }
}
