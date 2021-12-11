using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class MembershipDetailDto : IDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SubsName { get; set; }
        public decimal SubsPrice { get; set; }
        public DateTime SubsDate { get; set; }
        public DateTime SubsFinishDate { get; set; }
    }
}
