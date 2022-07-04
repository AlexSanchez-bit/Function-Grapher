public class FuncionBase: Function{
	       Function interna;
     
    public  FuncionBase(Function comp){
      interna=comp;
      }
     public  FuncionBase(){
      interna=null;
      }

 public Function Derivar(){
	 FuncionConst ret=new FuncionConst(1);
	 return ret;
 }
 public char getDom(){

	 return '-';
 }
 public char  getImg(){
	 return 's';
}
 public float Eval(float x_o){
	if(interna==null){
	return x_o;
	}else{
	return interna.Eval(x_o);
	}
}
			 
public string representacion(){
if(interna==null){
return "x";
}else{
return interna.representacion();
}
}
}
