using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestService.BLL.DTO
{
    public class RequestWithAdvertDto : RequestDTO
    {
        public AdvertDTO? Advert { get; set; }
    }
}
