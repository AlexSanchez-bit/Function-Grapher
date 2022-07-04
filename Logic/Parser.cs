public class Parser{
public Parser(){
}

static float E = 2.18f;

public Function Parse(string cadena){
    cadena=QuitarEspacios(cadena);
    cadena=SepararExpresiones(cadena);
cadena=NombresEspeciales(cadena);
    cadena=ProcesarParentesis(cadena);
    cadena=PostfixExpRaiz(cadena);
    cadena=PostfixMultDiv(cadena);
    cadena=PostfixSumRest(cadena); 
    return Traducir(Substr(cadena,1,cadena.Length-1));
}


Function Traducir(string expression){
	LinkedList<Function> st=new LinkedList<Function>();
	string container="";
	for(int i=0;i<expression.Length;i++){
        char a = expression[i];
              if(!EsOperador(a)){
	         if(a==','){
			 if(EsNumero(container)){
			 st.AddLast(new FuncionConst(float.Parse(container)));
 				 }else if(container.Length==1){
			 st.AddLast(container=="E"?(Function)new FuncionConst(E):(Function)new FuncionBase());
			 }else{
			 TiposEspeciales(st,container);
			 }
	       container="";
		 }else{
		 container+=a;
		 }
	 }else{
	  	 var der=(st.Last.Value);
		 st.RemoveLast();
		 var izq=(st.Last.Value);
		 st.RemoveLast();


		 switch(a){
			 case '+':
		 st.AddLast(new FuncionSuma(izq,der));
		 break;
			 case '-':
		 st.AddLast(new FuncionResta(izq,der));
		 break;
			 case '*':
		 st.AddLast(new FuncionMultip(izq,der));
		 break;
			 case '/':
		 st.AddLast(new FuncionDiv(izq,der));
		 break;
			 case '^':
		 st.AddLast(new FuncionExponente(izq,der));
		 break;
		 }
	 }	
	}
	var ret =(st.First.Value);
	return ret;
}

//convertir a objetos
void TiposEspeciales(LinkedList<Function> st,string expr){

	if(expr=="sin"){
	
	  	 var der=(st.Last.Value);
		 st.RemoveLast();
                 st.AddLast(new FuncionSen(der));
		 return;
	}

	if(expr=="cos"){
	  	 var der=(st.Last.Value);
		 st.RemoveLast();
                 st.AddLast(new FuncionCos(der));
	return;
	}

	if(expr=="ctan"){
	  	 var der=(st.Last.Value);
		 st.RemoveLast();
                 st.AddLast(new FuncionTan(der));
	return;
	}
	if(expr=="ctan"){
	  	 var der=(st.Last.Value);
		 st.RemoveLast();
                 st.AddLast(new FuncionCTan(der));
	return;
	}	
	if(expr=="sqrt"){
	  	 var der=(st.Last.Value);
		 st.RemoveLast();
                 st.AddLast(new FuncionRoot(der));
	return;
	}	
	if(expr=="ln"){
	  	 var der=(st.Last.Value);
		 st.RemoveLast();
                 st.AddLast(new FuncionLog(der));
	return;
	}
string aux=Substr(expr,0,4);
if(aux=="root")
{
float _base=float.Parse(Substr(expr,4,expr.Length));
var der=(st.Last.Value);
st.RemoveLast();
st.AddLast(new FuncionRoot(der,_base));
return;
}else
{
	aux=Substr(expr,0,3);
	if(aux=="log")
	{
    float _base=float.Parse(Substr(expr,3,expr.Length));
    	var der=(st.Last.Value);
	st.RemoveLast();
	st.AddLast(new FuncionLog(der,_base));
        return;	
	}
 
	if(expr=="PI"){
	st.AddLast(new FuncionConst(3.1416f));
	}

} 



}

//detectar y procesar sen cos tan etc
string NombresEspeciales(string cadena){
string ret="";
int ultimodiv=0;
string aux="";
int i=0;
int posic=0;
while(posic<cadena.Length&&i<cadena.Length){
		var a = cadena[i];
if((a)=='#'){
ultimodiv=ret.Length;
}
if((a)=='('&&(a-1)!='#'){
aux=Substr(ret,ultimodiv+1,ret.Length);
ret=Substr(ret,0,ultimodiv+1);
}else if((a)==')'&& aux.Length>0){
ret+=')';
	ret+=',';
ret+=aux;
aux="";
posic+=1;
i++;
}
ret+=a;
posic++;
i++;
}

return ret;
}

//funcion para procesar parentesis
string ProcesarParentesis(string expression){
string cadena="";
string aux="#";
Stack<int> stack=new Stack<int>();
bool enParentesis=false;
for (int i=0;i<expression.Length;i++){
if(enParentesis){
aux+=expression[i];
}else if(expression[i]!='('&& expression[i]!=')'){
cadena+=expression[i];
}
if(expression[i]=='('){
enParentesis=true;
stack.Push(i);
}else if(expression[i]==')'){
	stack.Pop();
	if(stack.Count()==0){
enParentesis=false;
aux=Substr(aux,0,aux.Length-1)+'#';
aux=ProcesarParentesis(aux);
aux=PostfixExpRaiz(aux);
aux=PostfixMultDiv(aux);
aux=PostfixSumRest(aux);
cadena+=Substr(aux,1,aux.Length-1);
aux+='#';
	}
}
}

return cadena;
}


//detectar si es un numero
bool EsNumero(string expression){
if((int)expression[0]>=49&&(int)expression[0]<=57){
return true;
}else{
return false;
}
}

//eliminar espacios entre las funciones
string QuitarEspacios(string original){
string result="";
for(int i=0;i<original.Length;i++){
	var a = original[i]; 
if((a)!=' '){
result+=(a);
}
}
return result;
}

//separa las expresiones con '#'
string SepararExpresiones(string original){
string result="#";
for(int i=0;i<original.Length;i++){
	var a = original[i];
if(!EsOperador((a))){
result+=(a);
}else{
result+='#';
result+=(a);
result+='#';
}
}
return result+'#';
}

//se explica sola XD
bool EsOperador(char a ){
if(a=='+'|| a =='-'|| a=='*'||a=='/'||a=='^'){
return true;
}else{
return false;
}
}

//lleva a postfix las expresiones de tipo exponente
string PostfixExpRaiz(string original){
string result="";
int ultimoHastg=0;
for(int i=0;i<original.Length;i++){
	if((original[i]=='^'||original[i]=='_')&&original[i-1]=='#'){
	result=Substr(result,0,result.Length-1);
	result+=',';
           int pos=i+2;
	   for(;original[pos]!='#';pos++){
	   result+=original[pos];
	   }
	   result+=',';
	   result+=original[i];
          i=pos-1;
	}else{
	result+=original[i];
	}

}
return result;
}

//lleva a postfix las expresiones de tipo * /
string PostfixMultDiv(string original){
string result="";
int ultimoHastg=0;
for(int i=0;i<original.Length;i++){
	if((original[i]=='*'||original[i]=='/')&&original[i-1]=='#'){
	result=Substr(result,0,result.Length-1);
	result+=',';
           int pos=i+2;
	   for(;original[pos]!='#';pos++){
	   result+=original[pos];
	   }
	   result+=',';
	   result+=original[i];
          i=pos-1;
	}else{
	result+=original[i];
	}
}

return result;
}

//lleva a postfix las expresiones de tipo + -
string PostfixSumRest(string original){	
string result="";
int ultimoHastg=0;
for(int i=0;i<original.Length;i++){
	if((original[i]=='+'||original[i]=='-')&&original[i-1]=='#'){
	result=Substr(result,0,result.Length-1);
	result+=',';
           int pos=i+2;
	   for(;original[pos]!='#';pos++){
	   result+=original[pos];
	   }
	   result+=',';
	   result+=original[i];
          i=pos-1;
	}else{
	result+=original[i];
	}
}
return result; 
}

//retorna una subcadena de la cadena original
string Substr(string original,int inicio,int final){
if(inicio>=final){
return "";
}
	string ret="";
for(int i=inicio;i<final;i++){
ret+=original[i];
}
return ret;
}

Function FuncionesEspeciales(string func){
return null;
}

}
