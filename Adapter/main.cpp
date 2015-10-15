#include <stdio.h>
#include <string>
#include <iostream>

class ClientLibrary{
	public:
		bool SendData(int length, std::string data){
			printf("Sending through client..");
			std::cout << data << "\n";
			return true;
		}
};

class OurLibrary{
	public:
		int SendData(std::string data, int length){
			printf("We are sending...");
			std::cout << data << "\n";
			return length;
		}
};

class Adapter : public OurLibrary{
		  public:
				int SendData(std::string data, int length){
					ClientLibrary *cl = new ClientLibrary();
					if(cl->SendData(length, data)){
						return length;
					}
					return 0;
				}
};



int main(){
		  OurLibrary *legacy = new OurLibrary();
		  legacy->SendData("data",4);
		  Adapter *adapter = new Adapter();
		  adapter->SendData("data",4);
		  return 0;
}
