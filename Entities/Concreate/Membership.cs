using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreate
{
    public class Membership : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubsId { get; set; }
        public decimal SubsPrice { get; set; }
        public DateTime SubsDate { get; set; }
        public DateTime SubsFinishDate { get; set; }
    }
}
