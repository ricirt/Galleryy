using System;
using System.Collections.Generic;
using System.Text;
using Gallery.Models;
using System.Linq;
using Gallery.ViewModels;

namespace GalleryBusiness.Interface

{
    public interface IGroup
    {
        public IEnumerable<GroupListViewModel> ListOfGroup();
        public bool AddGroup(Group group);
        public bool DeleteGroup(int id);
        public Group FindGroupById(int id);
        public bool SetGroup(Group egroup);
    }
}
