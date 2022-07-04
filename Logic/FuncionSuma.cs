class FuncionSuma :  Function{
	private Function ladoDer;
    private	Function ladoIzq;
        
     public FuncionSuma(Function der,Function Izq){
	this.ladoDer=der;
	this.ladoIzq=Izq;
	}

    public Function Derivar()
    {
       Function ret=new FuncionSuma(this.ladoDer.Derivar(),this.ladoIzq.Derivar());
   return ret;
    }

    public float Eval(float x_o)
    {
         return ladoDer.Eval(x_o)+ladoIzq.Eval(x_o);
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
         return ladoDer.representacion()+"+"+ladoIzq.representacion();
    }
}