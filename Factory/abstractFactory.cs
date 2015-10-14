using System;
using System.Linq;
using System.Reflection;

class AbstractFactoryExample{
	public static void Main(){
		var dbEngineFactory = LoadFactory();
		var dbengine = dbEngineFactory.getInstance("MysqlDb");
		Console.WriteLine(dbengine.runQuery("test"));
	}
	
	public static IDbFactory LoadFactory(){
		//---do stuf
		return new DbEngineFactory();
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


interface IDbFactory{
	IDb getInstance(string name);
}

class DbEngineFactory : IDbFactory{
	public IDb getInstance(string name){
		//Reflection
		return Assembly.GetExecutingAssembly().CreateInstance(name) as IDb;
		
	}	
}