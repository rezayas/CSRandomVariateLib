namespace RandomVariateLib
{
    //// random variate generator
    public class RVG
    {
        private string _name;

        // instantiation 
        public RVG(string name)
        {
            _name = name;
        }
        public virtual double SampleContinuous(RNG rng)
        {
            return 0;
        }
        public virtual int SampleDiscrete(RNG rng)
        {
            return 0;
        }
        public virtual double[] ArrSampleContinuous(RNG rng)
        {
            return null;
        }
        public virtual int[] ArrSampleDiscrete(RNG rng)
        {
            return null;
        }
        public virtual double[] GetEquallyDistributedPoints(int nOfPoints)
        {
            return null;
        }
    }
}