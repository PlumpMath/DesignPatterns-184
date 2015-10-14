using System;
using System.Linq;
using System.Collections.Generic;

//trees, distributions

class CompositionExample{
	public static void Main(){
		var marcin = new Employe("Marcin");
		var krzysiek = new Employe("Krzysiek");
		var marta = new Employe("Marta");
		
		marcin.Pay(100);
		krzysiek.Pay(120);
		marta.Pay(130);
		
		var dcgEmployes = new Division("DCG", new List<IEmploye>{marcin, krzysiek});
		var sgxEmployes = new Division("SGX", new List<IEmploye>{marta});
		
		var polandEmployes = new Division("Poland", new List<IEmploye>{dcgEmployes, sgxEmployes});
		var allEmployes = new Division("All", new List<IEmploye>{polandEmployes});
		
		allEmployes.Pay(10);
		Console.WriteLine("We have spend:");
		allEmployes.DisplayPayment();
	}
}

interface IEmploye
{
	void Pay(float ammount);
	void AddQPB(int percent);
	float GetTotalPay();
	void DisplayPayment();
}

class Employe : IEmploye{
	private float payment;
	private string name;
	public Employe(string name){
		this.name = name;
		payment = 0.0f;
	}
	public void Pay(float ammount){
		payment +=ammount;
	}
	public void AddQPB(int percent){
		payment +=payment*percent;
	}
	public float GetTotalPay(){
		return payment;
	}
	public void DisplayPayment(){
		Console.WriteLine("{0} got {1}$", name, payment);
	}
}

class Division : IEmploye{
	private List<IEmploye> employees;
	private string divisionName;
	public Division(string divisionName, List<IEmploye> members){
		this.divisionName = divisionName;
		employees = new List<IEmploye>();
		employees = members;
	}
	public void Pay(float ammount){
		foreach (var employee in employees)
		{
			employee.Pay(ammount);
		}
	}
	public void AddQPB(int percent){
		foreach (var employee in employees)
		{
			employee.AddQPB(percent);
		}
	}
	public string GetDivisionName(){
		return divisionName;
	}
	public float GetTotalPay(){
		 return employees.Sum(e=>e.GetTotalPay());
	}
	
	public void DisplayPayment(){
		Console.WriteLine("Total of {0} got {1}$", divisionName, GetTotalPay());
			
		foreach (var part in employees)
		{
			part.DisplayPayment();
		}
	}
}