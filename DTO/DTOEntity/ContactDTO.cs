using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOEntity
{
    public class ContactDTO
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string PhoneOne { get; set; }
        public string PhoneTwo { get; set; }
        public string EmailOne { get; set; }
        public string EmailTwo { get; set; }
        public string MapUrl { get; set; }
    }
}
