using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertService.DAL.Entities
{
    public class AdvertToRequests
    {
        public int advertId { get; set; }
        public int requestId { get; set; }
        public Advert advert { get; set; }
    }
}
