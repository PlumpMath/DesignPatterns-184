#include <iostream>
#include <string>
using namespace std;

class TemplateEngine{
	public:
		void Run(){
			//...
			ShowLoadingScreen(0);
			LoadAsset();
			//...for each...
			ShowLoadingScreen(100);
		}
	protected:
		virtual void LoadAsset()=0;
		virtual void ShowLoadingScreen(int percent)=0;

};

class MarioGame : public TemplateEngine{
	public:
		void LoadAsset(){
			cout << "loading asset.." << "\n";
		}
		void ShowLoadingScreen(int percent){
			cout << "loading screen: " << percent << "%\n";
		}
};

int main(){
	MarioGame *mg = new MarioGame();
	mg->Run();
	return 0;
}
