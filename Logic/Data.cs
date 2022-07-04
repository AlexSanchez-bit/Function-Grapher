namespace Logic
{
    public class Data
    {
        //puntos de inflexion
        //asintotas
        //maximos y minimos
        private double increment_x;
        public double Increment { get { return increment_x; } set { increment_x = value; } }

        private List<Tuple<double, double>> intervalos;
        public List<Tuple<double, double>> Intervalos { get { return intervalos; } set { } }
        private double intervale_a, intervale_b;
        public double Intervale_a { get { return intervale_a;  } }
        public double Intervale_b { get { return intervale_b; } }
     
        public Data(double a, double b, string func) {
            intervale_a = a;
            intervale_b = b;
            
            
        
        }
        
    }
}