using System;
using System.Collections.Generic;
using System.Text;

namespace TimberbornAPI.SpecificationSystem.Buildings
{
    public class MechanicalNode
    {
        public MechanicalNode(int powerInput, int powerOutput)
        {
            PowerInput = powerInput;
            PowerOutput = powerOutput;
        }

        public int PowerInput;

        public int PowerOutput;
    }
}
