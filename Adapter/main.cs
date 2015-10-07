using System;
using System.Collections.Generic;
///Very often first idea is to violate O/C Principle
///Brokers in Web are example of an adapter
///Wit adapter we can use already created code

class AdapterExample {
	static int Main(){
		
		var dataRenderer = new DataRenderer();
		SaveAndRenderData(dataRenderer);
		
		var htmlRendererAdapter = new HtmlRendererAdapter(dataRenderer);
		SaveAndRenderData(htmlRendererAdapter);
		return 0;
	}
	
	public static void SaveAndRenderData(IDataRenderer dataRenderer){
		dataRenderer.SaveData();
		dataRenderer.RenderData();
		//...more...code..
	}
}

interface IDataRenderer
{
	void RenderData();
	void SaveData();
	List<string> GetData();
}

class DataRenderer:IDataRenderer {
	private List<string> data;
	public DataRenderer(){
		data = new List<String>{
			"data_row1",
			"data_row2"
		};
	}

	public void RenderData(){
		foreach (var item in data)
		{
			Console.WriteLine(item);
		}
	}
	public void SaveData(){}
	public List<string> GetData(){return data;}
	
}

class HtmlRendererAdapter :IDataRenderer{
	IDataRenderer dataRenderer;
	HtmlRender htmlRenderer;
	public HtmlRendererAdapter(IDataRenderer dataRenderer){
		this.dataRenderer = dataRenderer;
		htmlRenderer = new HtmlRender("My Page", dataRenderer.GetData()[0]);
	}
	public void RenderData(){
		Console.WriteLine(htmlRenderer.RenderHtml());
	}
	public void SaveData(){}
	public List<string> GetData(){return dataRenderer.GetData();}
}

class HtmlRender{
	private string title;
	private string body;
	public HtmlRender(string title, string body){
		this.title = title;
		this.body = body;
	}
	public string RenderHtml(){
		return String.Format("<!DOCTYPE><html><title>{0}</title><head><body>{1}</body></html>", title, body);
	}
}