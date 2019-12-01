using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Film_Management_System.DAL;
using Film_Management_System.Models;

namespace Film_Management_System.BLL
{
    public class ActorManaager
    {
        Actor_GateWay actor_GateWay = new Actor_GateWay();

        public List<Actor> GetAllActors()
        {
            return actor_GateWay.GetAllActors();
        }
    }
}