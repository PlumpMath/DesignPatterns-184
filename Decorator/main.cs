using System;

class DecoratorExample{
	public static void Main(){
		var marcinPay = 
			new IncomeTax(
				new CharityDeduction(0.0f,
					new HealthTax(
						new RetirmentTax(
							new PensionTax(						
								new EmployePay()
							)
						)
					)
				)
			);
			
		Console.WriteLine("Marcin pay is {0} and total tax is {1}", marcinPay.GetPay(), marcinPay.GetTotalTax());
	} 
} 

abstract class Payment {
	public abstract float GetPay();
	public abstract float GetTotalTax();
}

class EmployePay : Payment{
	public override  float GetPay(){
		return 12*1500.0f;
	}
	public override  float GetTotalTax(){
		return 0.0f;
	}
}

class TaxDecorator : Payment{
	private Payment payment;
	private float payBeforeTax;
	public TaxDecorator(Payment payment){
		this.payment = payment;	
		payBeforeTax = payment.GetPay();
	}
	public override float GetPay(){
		return payment.GetPay();
	}
	public override float GetTotalTax(){
		return payment.GetTotalTax();
	}
}

class HealthTax : TaxDecorator{
	
	public HealthTax(Payment payment):base(payment){
		
	}
	
	public override float GetPay(){
		return base.GetPay() - 0.103f*base.GetPay();
	}
	
	public override float GetTotalTax(){
		return base.GetTotalTax() + 0.103f*base.GetPay();
	}
	
}


class PensionTax : TaxDecorator{
	
	public PensionTax(Payment payment):base(payment){		
	}
	
	public override float GetPay(){
		return base.GetPay() - 0.015f*base.GetPay();
	}
	
	public override float GetTotalTax(){
		return base.GetTotalTax() + 0.015f*base.GetPay();
	}
}


class RetirmentTax : TaxDecorator{
	
	public RetirmentTax(Payment payment):base(payment){
		
	}
	
	public override float GetPay(){
		return base.GetPay() - 0.098f*base.GetPay();
	}
	
	public override float GetTotalTax(){
		return base.GetTotalTax() + 0.098f*base.GetPay();
	}
}

class IncomeTax : TaxDecorator{
	
	public IncomeTax(Payment payment):base(payment){
		
	}
	
	public override float GetPay(){
		return base.GetPay() - ( 0.18f*base.GetPay() - 556.02f);
	}
	
	public override float GetTotalTax(){
		return base.GetTotalTax() + ( 0.18f*base.GetPay() - 556.02f);
	}
}

class CharityDeduction : TaxDecorator{
	private float charity;
	
	public CharityDeduction(float charity, Payment payment):base(payment){
		this.charity = charity;
	}
	
	public override float GetPay(){
		return base.GetPay();
	}
	
	public override float GetTotalTax(){
		if (charity > base.GetPay()/2.0f)
		{
			charity = base.GetPay()/2.0f;
		}
		return base.GetTotalTax() - charity;
	}
}