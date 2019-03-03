using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class User : IEntity
    {
        //[ForeignKey("ApplicationUser")]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }

        public int TitleID { get; set; }


        //public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Title Title { get; set; }
        public virtual WatchList WatchList { get; set; }
        public virtual List<Rating> Ratings { get; set; }
    }
}
