using System;

class StateExample{
	public static void Main(){
		var bug = new WorkItem();
		bug.SetState(States.CLOSED);
		bug.SetState(States.IN_PROGRES);
		bug.SetState(States.OPEN);
		bug.SetState(States.CLOSED);
	}
}

enum States {OPEN=0,IN_PROGRES,CLOSED, DUPLICATE};

interface IStateObject{
	void SetState(States newState);
}

interface IBaseState
{
	bool Delete(int id);
	bool Edit(int id);
	IBaseState SetState(States newState);
	//void NextState();
}

class WorkItem : IStateObject{
	private IBaseState currentState;
	public WorkItem(){
		currentState = new Open();
	}
	public void SetState(States newState){
		currentState = currentState.SetState(newState);
	}
}

class StateFactory{
	public static IBaseState FromState(States state){
		switch (state)
		{
			case States.OPEN : return new Open();
			case States.CLOSED : return new Closed();
			default: return new InProgress();
		}
		
	}
}

class Open : IBaseState{
	public Open(){
		Console.WriteLine("Task open");
	}
	public bool Delete(int id){
		return false;
	}
	public bool Edit(int id){
		return true;
	}
	public IBaseState SetState(States newState){
		if (newState==States.CLOSED)
		{
			Console.WriteLine("Cant finish task without progress");
			return this;
		}
		return StateFactory.FromState(newState);
	}
}
class Closed : IBaseState{
	public Closed(){
		Console.WriteLine("Task closed");
	}
	public bool Delete(int id){
		return true;
	}
	public bool Edit(int id){
		return true;
	}
	
	public IBaseState SetState(States newState){
		if (newState==States.CLOSED)
		{
			Console.WriteLine("Task already closed");
			return this;
		}
		if (newState==States.IN_PROGRES)
		{
			Console.WriteLine("Closed task must be reopened");
			return this;
		}
		return StateFactory.FromState(newState);
	}
}

class InProgress : IBaseState{
	public InProgress(){
		Console.WriteLine("Task in progres");
	}
	public bool Delete(int id){
		return true;
	}
	public bool Edit(int id){
		return true;
	}
	
	public IBaseState SetState(States newState){
		if (newState==States.OPEN)
		{
			Console.WriteLine("Cant open task in progress");
			return this;
		}
		return StateFactory.FromState(newState);
	}
}