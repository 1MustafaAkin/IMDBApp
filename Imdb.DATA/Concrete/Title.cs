using Imdb.DATA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imdb.DATA.Concrete
{
    public class Title : IEntity
    {
        public int TitleID { get; set; }
        public string TitleName { get; set; }

        public List<User> Users { get; set; }
    }
}
