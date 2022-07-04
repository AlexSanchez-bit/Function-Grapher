class FuncionSen:Function{

	private Function interna;
	public FuncionSen(Function inter){
		interna= inter;
		}
		FuncionSen(){
		interna=new FuncionBase();
		}

    public Function Derivar()
    {
        return new FuncionMultip(new FuncionCos(interna),interna.Derivar());
    }

    public float Eval(float x_o)
    {
       return (float)Math.Sin(interna.Eval(x_o));
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
       return "sin("+interna.representacion()+")";
    }
}