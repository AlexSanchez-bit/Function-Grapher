
public class FuncionMultip : Function
{
    private Function ladoDer;
    private Function ladoIzq;
    public FuncionMultip(Function der,Function izq)
    {
      this.ladoDer = der;
      this.ladoIzq = izq;
    }
    public Function Derivar()
    {
        Function ret = new FuncionSuma(new FuncionMultip(ladoDer.Derivar(),ladoIzq),new FuncionMultip(ladoDer,ladoIzq.Derivar()));
   return ret;
    }

    public float Eval(float x_o)
    {
       return ladoDer.Eval(x_o)*ladoIzq.Eval(x_o);
    }

    public char getDom()
    {
        return '\0';
    }

    public char getImg()
    {
        return '\0';
    }

    public string representacion()
    {
        return "("+ladoDer.representacion()+")"+"*"+"("+ladoIzq.representacion()+")";
    }
}