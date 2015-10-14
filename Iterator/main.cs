using System;
using System.Collections.Generic;

class IteratorExample{
	public static void Main(){
		var cars = new List<Car>(){
				new Car{name="Toyota"},
				new Car{name="BMW"}};
		var carIterator = new CarIterator(cars);
		while (carIterator.hasNext())
		{
			var car = carIterator.next();
			Console.WriteLine(car.name);
		}
	}
}

interface IIterator<T>
{
	bool hasNext();
	T next();
}

class CarIterator : IIterator<Car>{
	private List<Car> cars;
	private int index;
	public CarIterator(List<Car> cars){
		this.cars = cars;
	}
	public bool hasNext(){
		return index < cars.Count;
	}
	public Car next(){
		if (hasNext())
		{
			var car = cars[index++];
			return car;
		}
		return null;
	}
}

class Car{
	public string name;
}