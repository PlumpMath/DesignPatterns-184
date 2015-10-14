using System;

class ChainOfResponsibilityExample{
	public static void Main(){
		
		var accessCheck = new ResourceAccessValidator(new PublicResource())
							.registerNext(new ResourceAccessValidator(new PrivateResource()));
		
		Console.WriteLine("I have access to public: {0}", accessCheck.IsAllowedToResource("public"));
		Console.WriteLine("I have access to private: {0}", accessCheck.IsAllowedToResource("private"));	
	
		accessCheck = new ResourceAccessValidator(new PublicResource())
						.registerNext(new ResourceAccessValidator(new PrivateResource(true)));
		
		Console.WriteLine("I have access to private: {0}", accessCheck.IsAllowedToResource("private"));
	}
}

interface IMessageHandler{
	IMessageHandler registerNext(IMessageHandler nextHandler);
	bool IsAllowedToResource(string resourceName);
}

interface IResourceAccessValidator{
	bool IsAllowedToResource(string resourceName);
}

class ResourceAccessValidator : IMessageHandler{
	IResourceAccessValidator validator;
	IMessageHandler nextHandler;
	
	public ResourceAccessValidator(IResourceAccessValidator validator){
		this.validator = validator;
		nextHandler = new ResourceAccessValidatorEndChain();
	}
	public bool IsAllowedToResource(string resourceName){
		bool isAllowed = validator.IsAllowedToResource(resourceName);
		if (!isAllowed)
		{
			isAllowed = this.nextHandler.IsAllowedToResource(resourceName);
		}
		return isAllowed;
	}
	public IMessageHandler registerNext(IMessageHandler nextHandler){
		this.nextHandler = nextHandler;
		return this;
	}
}

class ResourceAccessValidatorEndChain : IMessageHandler{
	public ResourceAccessValidatorEndChain(){}
	public bool IsAllowedToResource(string rresourceName){
		return false;
	}
	public IMessageHandler registerNext(IMessageHandler nextHandler){
		throw new InvalidOperationException("End of chain handler must be the end of the chain!");
	}
}

class PublicResource : IResourceAccessValidator{
	public PublicResource(){
		
	}
	public bool IsAllowedToResource(string resourceName){
		return resourceName == "public";
	}
}

class PrivateResource : IResourceAccessValidator{
	bool isAdmin;
	public PrivateResource(bool isAdmin=false){
		this.isAdmin = isAdmin;
	}
	public bool IsAllowedToResource(string resourceName){
		return resourceName != "public" && isAdmin;
	}
}