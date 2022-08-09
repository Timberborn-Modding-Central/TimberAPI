namespace TimberbornAPI.SpecificationSystem.Fixes.CustomSpecifications.Buildings
{
    /// <summary>
    /// Stripped version of Timberborn.MechanicalSystem.MechanicalNodeSpecification
    /// Only contains relevant fields
    /// </summary>
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
