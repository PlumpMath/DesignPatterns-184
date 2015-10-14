using System;

class StrategyExample{
	public static void Main(){
		
	} 
}

enum State {OPEN=0,CLOSED}

class StrategyBad{
	public void WriteStateName(State state){
		switch (state)
		{
			case OPEN: return "Open";
			default: return "Closed";
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