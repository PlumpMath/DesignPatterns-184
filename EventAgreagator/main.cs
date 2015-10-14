//remove memory leaks
//remove tightly couplin
using System;
using System.Collections.Generic;

class EventAgregatorExample{
	public static void Main(){
		var ea = new EventAgregator();
		var v = new View(ea);
		var mv = new OnlyMouseView(ea);
		
		var ev_mouse = new MouseClick();
		var ev_keyboard = new KeyboardClick();
		
		ea.Publish<KeyboardClick>(ev_keyboard);
		ea.Publish<MouseClick>(ev_mouse );	
	}
}

interface IEventAgregator
{
	void Subscribe(object subscriber);
	void Publish<TEvent>(TEvent eventToPublish);
}

interface IScubscriber<T>{
	void OnEvent(T e);
}

class MouseClick{
	
}
class KeyboardClick{
	
}

class EventAgregator : IEventAgregator{
	private List<object> subscribers;
	
	public EventAgregator(){
		subscribers = new List<object>();
	}
	
	public void Subscribe(object subscriber){
		subscribers.Add(subscriber);	
	}
	public void Publish<TEvent>(TEvent eventToPublish){
		foreach (var subscriber in subscribers)
		{
			if (subscriber is IScubscriber<TEvent>)
			{
				var subT = subscriber as IScubscriber<TEvent>;
				subT.OnEvent(eventToPublish);	
			}
			
		}
	}
}

class View : IScubscriber<MouseClick>, IScubscriber<KeyboardClick>{
	public View(IEventAgregator eventAgregator){
		eventAgregator.Subscribe(this);
	}
	public void OnEvent(MouseClick e){
		Console.WriteLine("View received MouseClick");
	}
	public void OnEvent(KeyboardClick e){
		Console.WriteLine("View received KeyboardClick");
	}
}


class OnlyMouseView : IScubscriber<MouseClick> {
	public OnlyMouseView(IEventAgregator eventAgregator){
		eventAgregator.Subscribe(this);
	}
	public void OnEvent(MouseClick e){
		Console.WriteLine("Mouse View received MouseClick");
	}
	
	public void OnEvent(KeyboardClick e){
		Console.WriteLine("Mouse View received KeyboardClick");
	}
}