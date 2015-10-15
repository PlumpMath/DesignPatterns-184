using System;

class MVCExample{
	public static void Main(){
		var view = new StudentView(); //in web most time it is "index.html"
		var controller = new StudentController(view);
		controller.Update();
		
		//usually http event handler
		var newPerson = new StudentModel(){name="Jan Antoni", surname="Kowalski"};
		controller.PostData(newPerson);
		controller.Update();
	}
}

interface IView
{
	void display(IPerson person);
}

interface IControler{
	void Update();
	void PostData(IPerson person);
}

interface IPerson{
	string getName();
	string getSurname();
	void setName(string name);
	void setSurname(string surname);
}

class StudentModel : IPerson{
	public string name;
	public string surname;	
	
	public string getName(){return name;}
	public string getSurname(){return surname;}
	
	public void setName(string name){this.name=name;}
	public void setSurname(string surname){this.surname =surname;}
}

class StudentView : IView{
	public void display(IPerson person){
		Console.WriteLine("Persone is {0} {1}", person.getName(), person.getSurname());
	}
}

class StudentController{
	private IView view;
	IPerson person;
	public StudentController(IView view){
		this.person = new StudentModel(){
			name="Jan",surname="Kowalski"
		};
		this.view = view;
	}
	
	
	public void PostData(IPerson person){
		this.person.setName(person.getName());
		this.person.setSurname(person.getSurname());
	}
	
	public IPerson getStudent(){
		//usually call to db provider
		return this.person;
	}
	public void Update(){
		view.display( getStudent());
	}
}