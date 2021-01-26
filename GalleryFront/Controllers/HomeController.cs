using Gallery.Models;
using Gallery.ViewModels;
using GalleryBusiness.Encrypt;
using GalleryBusiness.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GalleryFront.Controllers
{
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        private readonly IArtist _artist;
        private readonly IArtWork _artwork;
        private readonly IGroup _group;
        private readonly IUserLogin _userlogin;


        public HomeController(IArtist artist, IArtWork artwork, IGroup group, IUserLogin userlogin)
        {
            _artist = artist;
            _artwork = artwork;
            _group = group;
            _userlogin = userlogin;
        }
        public ViewResult Index()
        {
            TempData["Username"] = HttpContext.Session.GetString("currentUser");
            string userName = TempData["Username"] as string;
            return View();
        }
        /*   [HttpPost]
           public IActionResult Index()
           {

           }*/
        [HttpPost]
        public IActionResult SubmitForm(Artist artist)
        {
            if (ModelState.IsValid)
                return View(_artist.AddArtist(artist));
            else
            {
                return View(artist);
            }
        }
        public IActionResult GroupList()
        {
            ViewBag.artworkobj = _artwork.ArtworkNameView();

            return View(_group.ListOfGroup());
        }
        public IActionResult GetallArtist()
        {
            return View(_artist.GetAllArtists());
        }
        public IActionResult ListOfArtWorks()
        {
            return View(_artwork.ListOfArtWork());
        }
        public IActionResult Edit(int id)
        {
            ViewBag.artistobj = _artist.ArtistNameView();
            return View(_artwork.FindArtWorkByID(id));
        }
        [HttpPost]
        public IActionResult Edit(ArtWork eartwork)
        {
            _artwork.SetArtWork(eartwork);
            return RedirectToAction("ListOfArtWorks");
        }
        public IActionResult AddArtWork()
        {
            ViewBag.artistobj = _artist.ArtistNameView();
            return View();
        }
        [HttpPost]
        public void AddArtWork(ArtWork artwork)
        {
            _artwork.AddArtWork(artwork);
        }
        [HttpPost]
        public IActionResult DeleteArtWork(int id)
        {
            _artwork.DeleteArtWork(id);
            return RedirectToAction("ListOfArtWorks");
        }
        public IActionResult EditArtist(int id)
        {
            return View(_artist.FindArtistByID(id));
        }
        [HttpPost]
        public IActionResult EditArtist(Artist eartist)
        {
            _artist.SetArtist(eartist);
            return RedirectToAction("GetallArtist");
        }
        [HttpPost]
        public IActionResult DeleteArtist(int id)
        {
            _artist.DeleteArtist(id);
            return RedirectToAction("GetallArtist");
        }
        public void AddGroup(Group group)
        {
            _group.AddGroup(group);
        }
        public IActionResult DeleteGroup(int id)
        {
            _group.DeleteGroup(id);
            return RedirectToAction("GroupList");
        }
        [HttpPost]
        public IActionResult EditGroup(Group egroup)
        {
            _group.SetGroup(egroup);
            return RedirectToAction("GroupList");
        }
        public IActionResult EditGroup(int id)
        {
            return View(_group.FindGroupById(id));
        }
        public IActionResult EditProfile()
        {
            var loggedInUser = HttpContext.User;
            var loggedInUserName = loggedInUser.Identity.Name;
            return View(_userlogin.GetProfileInfo(loggedInUserName));
        }
        [HttpPost]
        public IActionResult EditProfile(ProfilViewModel profilViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(profilViewModel);
            }
            else
            {
                _userlogin.SetProfile(profilViewModel);
                return RedirectToAction("Index");
            }
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordVM passwordVM)
        {
            var loggedInUser = HttpContext.User;
            var loggedInUserName = loggedInUser.Identity.Name; // This is our username we set earlier in the claims. 
                                                               // var loggedInPassword = loggedInUser.Identity.;
            var loggedInPassword = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Hash).Value; //Another way to get the name or any other claim we set.
            if (Sha256.ComputeSha256Hash(passwordVM.oldPassword) == loggedInPassword)
            {
                _userlogin.updatePassword(loggedInUserName, passwordVM.newPassword);
                return RedirectToAction("EditProfile");
            }
            else
                return View();


        }


    }
}
