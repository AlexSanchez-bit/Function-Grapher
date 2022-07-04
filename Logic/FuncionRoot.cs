public class FuncionRoot : Function
{
    private Function interna;
    private Function _base;

    public FuncionRoot(Function _base,Function inter)
    {
        this._base = _base;
        this.interna = inter;
    }
    public FuncionRoot(float _base,Function inter)
    {
        this._base = new FuncionConst(_base);
        this.interna = inter;
    }
    public FuncionRoot()
    {
        this._base = new FuncionConst(2);
        this.interna = new FuncionBase();
    }
    public FuncionRoot(Function inter)
    {
        this._base = new FuncionConst(2);
        this.interna = inter;
    }

    public Function Derivar()
    {
        return new FuncionMultip(new FuncionMultip(new FuncionDiv(new FuncionConst(1),_base),new FuncionExponente(interna,new FuncionDiv(new FuncionConst(1),new FuncionConst(_base.Eval(0)-1)))),this.interna.Derivar());
    }

    public float Eval(float x_o)
    {
      if(x_o<0&&((int)this._base.Eval(x_o))%2==0){
throw new Exception("-2");
}
double result=0;
Function aux=this.Derivar();

for(int i=1;i<4;i++){
result += (aux.Eval(0)/factorial(i))*Math.Pow(x_o,i);
aux=aux.Derivar();
}


return (float)result;
    }

    public char getDom()
    {
        return '\0';
    }

    public char getImg()
    {
        return '\0';
    }
    float factorial(int n){
float result=1;
while(n>1){
result*=n;
n--;
}
return result;
}

    public string representacion()
    {
       return "root"+this._base.representacion()+"("+interna.representacion()+")";
    }
}