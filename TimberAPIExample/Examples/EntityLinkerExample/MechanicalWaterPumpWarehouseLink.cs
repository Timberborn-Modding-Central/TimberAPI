using System;
using System.Collections.Generic;
using System.Text;
using TimberbornAPI.EntityLinkerSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample
{
    public class MechanicalWaterPumpWarehouseLink : 
        BaseEntityLink<MechanicalWaterPumpBehaviour, WarehouseBehaviour>
    {
        //We can have as many custom properties as we want. This exmple has one
        public int BerryTreshold { get; set; }

        public List<dynamic> Settings;

        //This creates a new Link instance. THe base constructor takes care of assigning
        //linker and linkee. Our costructor assigns initial values of custom properties
        public MechanicalWaterPumpWarehouseLink(MechanicalWaterPumpBehaviour linker,
                                                WarehouseBehaviour linkee)
            : base(linker, linkee)
        {
            BerryTreshold = 200;
        }
    }
}
