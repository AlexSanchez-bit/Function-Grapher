
public class FuncionResta : Function
{
    private Function ladoDer;
    private Function ladoIzq;
    public FuncionResta(Function der,Function izq)
    {
        this.ladoDer = der;
        this.ladoIzq = izq;
    }
    public Function Derivar()
    {
       Function ret=new FuncionResta(this.ladoDer.Derivar(),this.ladoIzq.Derivar());
   return ret;
    }

    public float Eval(float x_o)
    {
        return ladoDer.Eval(x_o)-ladoIzq.Eval(x_o);
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
        return ladoDer.representacion()+"-"+ladoIzq.representacion();
    }
}