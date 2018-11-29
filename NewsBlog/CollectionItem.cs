using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBlog
{
    public class CollectionItem : ObservableObject
    {
      //  public int Id { get; set; }
        //public string PostHeader { get; set; }
        private string header;
        public string PostHeader
        {
            get => header;
            set => Set(ref header, value);
        }

        private string htmlText;
        public string HTMLtext
        {
            get => htmlText;
            set => Set(ref htmlText, value);
        }

        //public DateTime PostDate { get; set; }
        private DateTime postDate;
        public DateTime PostDate
        {
            get => postDate;
            set => Set(ref postDate, value);
        }
    }
}
