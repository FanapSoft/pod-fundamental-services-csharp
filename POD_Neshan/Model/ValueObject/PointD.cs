
namespace POD_Neshan.Model.ValueObject
{
    public struct PointD
    {

        /// <param name="x">عرض جغرافیایی : Latitude</param>
        /// <param name="y">طول جغرافیایی : Longitude</param>
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary> عرض جغرافیایی : Latitude </summary>
        public double X { get; set; }

        /// <summary> طول جغرافیایی : Longitude </summary>
        public double Y { get; set; }

    }
}
