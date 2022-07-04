public class FuncionConst: Function{
	       float valConst;
public FuncionConst(float valorC){
this.valConst=valorC;
}

public static bool operator ==(FuncionConst other,FuncionConst sec)
{
return sec.Eval(0)==other.Eval(0);
}

public static bool operator !=(FuncionConst other,FuncionConst sec)
{
return sec.Eval(0)!=other.Eval(0);
}
 public Function Derivar(){
	 Function ret=new FuncionConst(0);
 return ret;
 }
public char getDom(){      
	 return 'd';
 }
public char  getImg(){
	 return 'd';
}
public float Eval(float x_o){
return this.valConst;
}
			 

public string representacion(){
return valConst.ToString();
}
}