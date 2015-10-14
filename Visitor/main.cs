using System;
using System.Collections.Generic;

class VisitorExample{
	public static void Main(){
		var memoryVisitor = new MemoryVisitor();
		var memoryProfiles = new List<IMemoryProfile>(){
			new CacheMemory(), new SwapMemory()	
		};
		var gb = new GarbageCollector(memoryProfiles, memoryVisitor);
		Console.WriteLine("Total alocated: {0}", memoryVisitor.totalAlocated);
	}
}

interface IVisitor
{
	void Visit(CacheMemory memoryProfile);
	void Visit(SwapMemory memoryProfile);
}

class GarbageCollector {
	public GarbageCollector(List<IMemoryProfile> memoryProfiles, IVisitor visitor){
		foreach (var item in memoryProfiles)
		{
			item.Accept(visitor);
		}	
	}
}

class MemoryVisitor : IVisitor{
	public int totalAlocated;
	public void Visit(SwapMemory memoryProfile){
		totalAlocated += memoryProfile.alocated;
		Console.WriteLine("Swap Memory has {0} alocated MB", memoryProfile.alocated);
	}
	public void Visit(CacheMemory memoryProfile){
		totalAlocated += memoryProfile.alocated;
		Console.WriteLine("Cache Memory has {0} alocated MB", memoryProfile.alocated);
	}
}

interface IMemoryProfile{
	void Accept(IVisitor visitor);
}

class CacheMemory : IMemoryProfile{
	public int alocated;
	public CacheMemory(){
		alocated = 150;
	}
	public void Accept(IVisitor visitor){
		visitor.Visit(this);
	}
}

class SwapMemory : IMemoryProfile{
	public int alocated;
	public SwapMemory(){
		alocated = 10;
	}
	public void Accept(IVisitor visitor){
		visitor.Visit(this);
	}
}