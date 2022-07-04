public class FuncionExponente:Function{       
	       Function interna;
	       Function exponente;
    
	public FuncionExponente(Function comp,Function exp){
	interna=comp;
	exponente=exp;
	}

      public FuncionExponente(Function comp,float exp){
      interna=comp;
      exponente=new FuncionConst(exp);
      }
      public FuncionExponente(int exp){
      interna=new FuncionBase();
      exponente=new FuncionConst(exp);
      }

 public Function Derivar(){
	 Function ret=new FuncionMultip(new FuncionMultip(new FuncionConst(exponente.Eval(0)),new FuncionExponente(interna,exponente.Eval(0)-1)),interna.Derivar());
	 return ret;
 }
 public char getDom(){

	 return 'd';
 }
public char  getImg(){
	 return 'd';
}
public float Eval(float x_o){
	return (float)Math.Pow((interna.Eval(x_o)),exponente.Eval(x_o));
}
			 
public string representacion(){
	return "("+interna.representacion()+")^"+"("+exponente.representacion()+")";
}


}