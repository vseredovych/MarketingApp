using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Collections;

namespace DAL.Interfaces
{
    public interface IEntity 
    {
        long Id { get; set; }
    }
}
