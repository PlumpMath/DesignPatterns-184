using System.

class LiskovExample{
	public static void Main(){
		
	}
}


class Address{
	protected string street;
	protected string postCode;
	public void setStreet(string street){
		
	}
	public bool validateStreet(string street){
		if (street.contains(postcode)){
			return true;
		}
		return false;
	}
}

class PolishAddress : Address{
	public override setStreet(string street){
		this.street = street;
	}
}