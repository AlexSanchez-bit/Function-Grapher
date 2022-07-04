public class FuncionDiv: Function{
		Function ladoDer;
		Function ladoIzq;        
      public FuncionDiv(Function der,Function Izq){
	this.ladoDer=der;
	this.ladoIzq=Izq;
	}

   public Function Derivar(){
	   Function ret=new FuncionDiv(new FuncionResta(new FuncionMultip(ladoDer.Derivar(),ladoIzq),new FuncionMultip(ladoDer,ladoIzq.Derivar())),new FuncionExponente(ladoIzq,2));
   return ret;
   }
   public char getDom(){
   return 'd';
   }
   public char getImg(){
   return 's';
   }
  public float Eval(float x_o){
  
	  if(ladoIzq.Eval(x_o)!=0){
	  return ladoDer.Eval(x_o)/ladoIzq.Eval(x_o);
	  }
	  throw new DivideByZeroException("division por cero");
  }
  public string representacion(){
return ladoDer.representacion()+"/"+ladoIzq.representacion();
}
~FuncionDiv(){
}
}