#include <stdio.h>
class ICar{
	public:
		virtual void Drive()=0;
};


class BMW: public ICar{
	public:
		void Drive(){
			printf("BMW!\n");
		}
};
class Toyota: public ICar{
	public:
		void Drive(){
			printf("Toyota\n");
		}
};
class CarFactory{
	public:
		static ICar *create(int carId){
			if(carId==0){
			return new BMW();
			} 
			return new Toyota();
		}
};

int main(){
	//CarFactory *cf = new CarFactory;
	ICar *c = CarFactory::create(1);
	c->Drive();
	return 0;
}
