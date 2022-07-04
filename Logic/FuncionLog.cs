public class FuncionLog:Function{

static float E =  2.181610f;
		Function interna;
		Function _base;
		bool neperiano=false;
		bool unario=false,constante=false;	
		public FuncionLog(Function _in,Function _base){
		interna=_in;
		this._base=_base;
		}
		public FuncionLog(){
		interna=new FuncionBase();
		neperiano=true;
		_base =new FuncionLog(new FuncionBase(),E);
		}

		public FuncionLog(FuncionConst a,FuncionConst b){
			if(a==b){
			unario=true;
			}
			this.interna=a;
			this._base=b;
			constante=true;
		}

 		public FuncionLog(FuncionConst _in,float b)
		{
			if(_in.Eval(0)==b){
			unario=true;
			}
			if(b==E){
		neperiano=true;	
			}
			this.interna=_in;
			this._base=new FuncionConst(b);
			constante=true;
		}

  	public	FuncionLog(Function _in, float _base){
			if(_in.Derivar().representacion()=="0"){
			constante=true;
			if(_in.Eval(0)==_base)
			{
			unario=true;
			}
			}
			neperiano=(_base==E);
		this.interna=_in;
		this._base=new FuncionConst(_base);
		}


	public	FuncionLog(float a,float b){
		if(a==b)
		{
		unario=true;
		}else if (b==E){
		neperiano=true;
		}
		this.interna=new FuncionConst(a);
		this._base=new FuncionConst(b);
		constante=true;
		}

public Function Derivar(){
	if(constante)
	{
	return new FuncionConst(0);
	}
if(neperiano)
{
return new FuncionMultip(new FuncionDiv(new FuncionConst(1),this.interna),interna.Derivar());
}

return new FuncionMultip(new FuncionDiv(new FuncionConst(1),new FuncionMultip(interna,new FuncionLog(this._base,E))),interna.Derivar());
}
public char getDom(){
return 's';
}
public char  getImg(){
return 's';
}


public float Eval(float x_o){
	if(interna.Eval(x_o)==0){
	throw new Exception("valor fuera de rango");
	}else if(interna.Eval(x_o)==1){
	return 0;
	}else if(unario||interna.Eval(x_o)==_base.Eval(x_o)){
	return 1;
	}
	if(constante){
	x_o=interna.Eval(0);
	}

float result=0;
Function der=this.Derivar();
	float uno=der.Eval(1);
	float cuatro=uno*(interna.Eval(x_o)-1);
	result+=cuatro;
return result;
}


public string representacion(){
	if(unario)
	{
	return "1";
	}
	if(neperiano)
	{
	return "ln("+this.interna.representacion()+")";
	}

return "log"+this._base.representacion()+"("+interna.representacion()+")";
}

int factorial(int n){
int result=1;
while(n>1){
result*=n;
n--;
}
return result;
}


}