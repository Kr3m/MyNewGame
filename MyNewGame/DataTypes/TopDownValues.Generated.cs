
namespace MyNewGame.DataTypes
{
    public partial class TopDownValues
    {
        public string Name;
        public bool UsesAcceleration;
        public float MaxSpeed;
        public float AccelerationTime;
        public float DecelerationTime;
        public bool UpdateDirectionFromVelocity;
        public const string Default = "Default";
        public static System.Collections.Generic.List<System.String> OrderedList = new System.Collections.Generic.List<System.String>
        {
        Default
        };
        
        
    }
}
