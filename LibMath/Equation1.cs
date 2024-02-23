namespace LibMath
{
    public class Equation1
    {
        private readonly double CoefA;
        private readonly double CoefB;
        public bool IsHz { get { return double.IsNaN(CoefA); } }
        public bool IsVz { get { return double.IsNaN(CoefB); } }
        public Equation1(double x1, double y1, double x2, double y2)
        {
            if (y2 == y1) // Horizontal
            {
                CoefA = double.NaN;
                CoefB = y1;
            }
            else if (x2 == x1)  // Vertical
            {
                CoefA = x1;
                CoefB = double.NaN;
            }
            else
            {
                CoefA = (x2 - x1) / (y2 - y1);
                CoefB = y1 - CoefA * x1;
            }
        }
        public double GetX(double y)
        {
            if (IsHz) // c'est Horizontal
            {
                if (y == CoefB) // y = CoefB
                {
                    if (y < 0)
                    {
                        return double.NegativeInfinity;
                    }
                    else
                    {
                        return double.PositiveInfinity;
                    }
                }
                else // y != CoefB
                {
                    return double.NaN;
                }
            }
            else if (IsVz) // C'est vertical alors je retourne la meme valeur
            {
                return y;
            }
            else
            {
                return (y - CoefB) / CoefA;
            }
        }
        public double GetY(double x)
        {
            if (IsHz) // c'est horizontal alors je retourne la valeur de y
            {
                return CoefB;
            }
            else if (IsVz) // c'est vertical
            {
                if (x == CoefA)
                {
                    if (x > 0)
                    {
                        return double.PositiveInfinity;
                    }
                    else
                    {
                        return double.NegativeInfinity;
                    }
                }
                else  // x != CoefA
                {
                    return double.NaN;
                }
            }
            else
            {
                return CoefA * x + CoefB;
            }
        }
    }
}
