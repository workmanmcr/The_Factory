using System.Collections.Generic;
using System;

namespace Factory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.JoinEntities = new HashSet<EngineerMachine>();
    }

    public int MachineId { get; set; }

    public string MachineName { get; set; }
    public List<Engineer> Engineers { get; set; }

    public string Name { get; }
  


    public virtual ICollection<EngineerMachine> JoinEntities { get; set; }

    }
}