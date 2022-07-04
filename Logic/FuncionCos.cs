public class FuncionCos:Function{

		Function interna;

		public FuncionCos(Function interna){
		this.interna=interna;
		}
	public	FuncionCos(){
		interna=new FuncionBase();
		}

public Function Derivar(){
return new FuncionMultip(new FuncionResta(new FuncionConst(0),new FuncionSen(interna)),interna.Derivar());
}
public char getDom(){
return 'e';
}
public char  getImg(){
return 's';
}
public float Eval(float x_o){
return (float)Math.Cos(interna.Eval(x_o));
}
public string representacion(){
return "cos("+interna.representacion()+")";
}

~FuncionCos(){

}

}