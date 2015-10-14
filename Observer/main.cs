using System;
using System.Collections.Generic;

class ObserverExample{
	public static void Main(){
		var emailSubject = new EmailSubject();
		var emailObserver = new EmailObserver();
		emailSubject.RegisterObserver(emailObserver);
		//...if 
		emailSubject.NotifyObservers();
	}
}

interface IObserver
{
	void Notify();
}

class EmailObserver : IObserver{
	public void Notify(){
		Console.WriteLine("You have e-mail!");
	}
}

class EmailSubject{
	private List<IObserver> observers;
	public EmailSubject(){
		observers = new List<IObserver>();
	}
	public void RegisterObserver(IObserver observer){
		observers.Add(observer);
	}
	public void NotifyObservers(){
		foreach (var observer in observers)
		{
			observer.Notify();
		}
	}
}