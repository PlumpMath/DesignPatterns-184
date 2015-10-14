using System;

class ProxyExample {
	public static void Main(){
		
	}
}

class ActualObject {
	public int RequestBigPI(){}
}

//also Lazy loading
//be carefull of more db requests

//have to be in sync
class Proxy : ActualObject {
	public overrid int RequestBigPI(){
		//return cache
		//invalidate cache
		//return tru int
	}
}