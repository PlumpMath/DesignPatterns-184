using System;

class BridgeExample{
	
	public static void Main(){
		var webClient = new WebClient(new LanConnection());
		webClient.connect();
		webClient.send("google.com");
		
		var webClientWifi = new WebClient(new WiFiConnection());
		webClientWifi.connect();
		webClientWifi.send("google.com");
	}
	
}

interface IConnectionAPI
{
	void connect();
	void send(string data);
}

class LanConnection : IConnectionAPI{
	public void connect(){
		Console.WriteLine("Connect on wire");
	}
	public void send(string data){
		Console.WriteLine("Sending on wire: {0}", data);
	}
}

class WiFiConnection : IConnectionAPI{
	public void connect(){
		Console.WriteLine("Connect with WiFi");
	}
	public void send(string data){
		Console.WriteLine("Transmiting with WiFi: {0}", data);
	}
}

abstract class ConnectionClient{
	protected IConnectionAPI connectionAPI;
	protected ConnectionClient(IConnectionAPI connectionAPI){
		this.connectionAPI = connectionAPI;
	}
	public abstract void connect();
	public abstract void send(string data);
}

class WebClient : ConnectionClient{
	public WebClient(IConnectionAPI connectionAPI) : base(connectionAPI){
		
	}
	public override void connect(){
		connectionAPI.connect();
	}
	public override void send(string data){
		connectionAPI.send(data);
	}
}