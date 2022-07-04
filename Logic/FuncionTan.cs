public class FuncionTan : Function
{
     private Function interna;
	
		public FuncionTan(Function inter){
		interna=inter;
		}
		public FuncionTan(){
		interna=new FuncionBase();
		}
    public Function Derivar()
    {
        return new FuncionMultip(new FuncionDiv(new FuncionConst(1),new FuncionExponente(new FuncionCos(interna),2)),interna.Derivar());
    }

    public float Eval(float x_o)
    {
        return (float)Math.Sin(interna.Eval(x_o))/(float)Math.Cos(interna.Eval(x_o));
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
        return "tan("+interna.representacion()+")";
     }
    }
