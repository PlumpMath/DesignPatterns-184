using System;
using System.Linq;
using System.Reflection;

class FactoryExample{
	public static void Main(){
		var dbEngineFactory = new DbEngineFactory();
		var dbengine = dbEngineFactory.getInstance("MysqlDb");
		Console.WriteLine(dbengine.runQuery("test"));
	}
}


interface IDb
{
	string runQuery(string query);
}
class MysqlDb : IDb{
	public string runQuery(string query){
		return String.Format("Mysql query {0}", query);
	}
}

class PostgresDb : IDb{
	
	public string runQuery(string query){
		return String.Format("Postgres query {0}", query);
	}
}

class DbEngineFactory{
	public IDb getInstance(string name){
		//Reflection
		return Assembly.GetExecutingAssembly().CreateInstance(name) as IDb;
		
	}	
}