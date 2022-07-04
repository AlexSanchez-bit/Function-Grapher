public class FuncionCTan: Function{

	
	public Function interna;
	
	public	FuncionCTan(Function interna){
		this.interna=interna;
		}
		public FuncionCTan(){
		interna=new FuncionBase();
		}

public Function Derivar(){
return new FuncionMultip(new FuncionDiv(new FuncionConst(1),new FuncionExponente(new FuncionSen(interna),2)),interna.Derivar());
}
public char getDom(){
return '2';
}
public char  getImg(){
return 'd';
}
public float Eval(float x_o){
return ((float)Math.Cos(interna.Eval(x_o))/(float)Math.Sin(interna.Eval(x_o)));
}
public string representacion(){
return "tan("+interna.representacion()+")";
}




}