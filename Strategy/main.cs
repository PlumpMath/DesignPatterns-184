using System;

class StrategyExample{
	public static void Main(){
		var strategy = new StrategyImpl();
		strategy.WriteStateName(new Open());
	} 
}

enum State {OPEN=0,CLOSED}

class StrategyBad{
	public void WriteStateName(State state){
		switch (state)
		{
			case State.OPEN: Console.WriteLine("Open");break;
			default: Console.WriteLine("Closed");break;
		}
	}
}

class StrategyImpl{
	public void WriteStateName(IState state){
		Console.WriteLine(state.GetName());
	}
}

interface IState{
	string GetName();
}

class Open : IState{
	public string GetName(){
		return "Open";
	}
}

class Closed : IState{
	public string GetName(){
		return "Closed";
	}
}