using System;
using System.Collections.Generic;

class TemplateExample{
	public static void Main(){
		var marioGame = new Mario();
		marioGame.Run();
	}
}




abstract class GameEngine{
	public abstract List<string> getAssets();
	public abstract void loadAsset(string asset);
	public abstract void showLoadingScreen(int loadingPercent);
	public void Run(){
		var assets = getAssets();
		showLoadingScreen(0);
		int counter=0;
		foreach (var asset in assets)
		{
			loadAsset(asset);
			counter++;
			var loadingPercent = counter*100f/ assets.Count; 
			showLoadingScreen((int)Math.Floor(loadingPercent));
		}
		
	}	
}

class Mario:GameEngine{
	public override List<string> getAssets(){
		return new List<string>(){
			"Mario.png","Wall.png","Background.png"
		};
	}
	public override void loadAsset(string asset){
		Console.WriteLine("I am loading {0} asset", asset);
	}
	public override  void showLoadingScreen(int loadingPercent){
		Console.WriteLine("Loading status: {0}%", loadingPercent);
	}
	
}