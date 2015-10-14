using System;

class BuilderExample{
	public static void Main(){
		var threeWheelRedCar = CarMaker.BuildCar(new ThreeWheelsRedCar());
		var fourWheelBlackCar = CarMaker.BuildCar(new FourWheelsBlackCar());
		threeWheelRedCar.display();
		fourWheelBlackCar.display();
	}
}

public class Car {
	private int wheels;
	private string color;
	public void addWheels(int wheels){this.wheels=wheels;}
	public void setColor(string color){this.color=color;}
	public void display(){
		Console.WriteLine("My Car has {0} wheels and it is {1}", this.wheels, this.color);
	} 
}
public abstract class CarBuilderType{
	protected Car car;
	public abstract void addWheels();
	public abstract void setColor();
	public void Initialize(){car = new Car();}
	public Car getCar(){return this.car;}
}

public  class ThreeWheelsRedCar : CarBuilderType{
	public ThreeWheelsRedCar(){car = new Car();}
	public override void addWheels(){
		car.addWheels(3);
	}
	public override void setColor(){
		car.setColor("red");
	}
}


public class FourWheelsBlackCar : CarBuilderType{
	public override void addWheels(){
		car.addWheels(4);
	}
	public override void setColor(){
		car.setColor("black");
	}
}
//director
public class CarMaker{
	public static Car BuildCar(CarBuilderType builderType){
		builderType.Initialize();
		builderType.addWheels();
		builderType.setColor();
		return builderType.getCar();
	}	
}