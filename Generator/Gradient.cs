namespace LibNoise.Generator
{
    /// <summary>
    /// Provides a noise module that outputs a constant value. [GENERATOR]
    /// </summary>
    public class Gradient : ModuleBase
    {
        #region Fields

        private double _min;
        private double _max;
        private double _width;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of Const.
        /// </summary>
        public Gradient()
            : base(0)
        {
        }

        /// <summary>
        /// Initializes a new instance of Const.
        /// </summary>
        /// <param name="value">The constant value.</param>
        public Gradient(double min, double max)
            : base(0)
        {
            _min = min;
            _max = max;            
        }

        #endregion

        #region Properties
        
        public double Min
        {
            get { return _min; }
            set { _min = value; UpdateCached(); }
        }

        public double Max
        {
            get { return _max; }
            set { _max = value; UpdateCached(); }
        }
        
        void UpdateCached()
        {
            _width = Max - Min;
        }

        #endregion

        #region ModuleBase Members

        /// <summary>
        /// Returns the output value for the given input coordinates.
        /// </summary>
        /// <param name="x">The input coordinate on the x-axis.</param>
        /// <param name="y">The input coordinate on the y-axis.</param>
        /// <param name="z">The input coordinate on the z-axis.</param>
        /// <returns>The resulting output value.</returns>
        public override double GetValue(double x, double y, double z)
        {
            double clamped = z;

            if (clamped < Min)
                clamped = Min;
            else if(clamped > Max)
                clamped = Max;

            double diff = clamped - Min;
                        
            return Min + diff / _width;
        }

        #endregion
    }
}