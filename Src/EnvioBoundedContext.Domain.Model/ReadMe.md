
## The order of elements inside classes must be:
	
	class NameOfMyClass
	{
	    // 1. Internal variables
	
	    // 2. Public Properties
	
	    // 3. Constructor
	
	    // 4. Public methods
	
	    // 5. Private methods
	}

## For C# - All methods must be named using CamelCase

### YES:  

void **D**oSomeWork()

### NO:

void **d**oSomeWork()


## For C# - All internal method variables must be named using pascalCase
### YES:
```csharp
void DoSomeWork()
{
	int correctName = 2;
}
```
### NO:
```csharp
void doSomeWork()
{
	int IncorrectName = 2;
}
```	
## For C# - All properties must be named using CamelCase
### YES:
```csharp
public string SampleProperty
{
    get 
    { 
	return _status; 
    }
     set
    {
	_status = value;
    }
}
```
### NO:
```csharp
public string sampleProperty
{
    get 
    { 
	return _status; 
    }
     set
    {
	_status = value;
    }
}
```

## We use 4 spaces for indentation not tabs.
### YES:
		void SampleMethod(string paramName)
		{
		\s\s\s\sDoSomething();
		}
		
### NO:
		void SampleMethod(string paramName)
		{
		\s\sDoSomething();
		}
### NO:
		void SampleMethod(string paramName)
		{
		\tDoSomething();
		}
	
##The open and close curly brackets must be placed in an specific line for them
### YES:
		void MethodA(int b)
		{
		    int a = 1;
		    if (b == 2) 
		    **{**
		        a = 3;
		    }
		}
		
### NO:
		void MethodA(int b)
		{
		    int a = 1;
		    if (b == 2) **{**
		        a = 3;
		    }
		}
		
##Always use open and close curly brackets. It doesn't matter if it is only line what is going to go inside the if.
### YES:
		void MethodA(int b)
		{
		    int a = 1;
		    if (b == 2) 
		    **{**
		        a = 3;
		    **}**
		}
		
### NO:
		void MethodA(int b)
		{
		    int a = 1;
		    if (b == 2) 
		        a = 3;
		}
	
### There is only one exception to this rule and is for validating input parameters at the beginning of a method.
	
	void SampleMethod(TextWriter logger, CancellationToken token)
	{
	    if (logger == null) **throw new ArgumentNullException(nameof(logger));**
	    if (token == null) throw new ArgumentNullException(nameof(token));
	
	    ...
	}

## Protect class variables that are only assigned in the constructor with readonly attribute
### YES:
		class SomeClass
		{
		    private readonly string _item;
		
		    public SomeClass(string item)
		    {
		        _item = item;
		    }
		
		    ...
		}
		
### NO:
		class SomeClass
		{
		    private string _item;
		
		    public SomeClass(string item)
		    {
		        _item = item;
		    }
		
		    ...
		}
## Prefer object initialization over setting properties after initialization
### YES:
		var processResult = new ProcessMessageResult
		{
		    Success = false,
		    QueueHasMessages = false
		};
		
### NO:
		var processResult = new ProcessMessageResult();
		processResult.Success = false;
		processResult.QueueHasMessages = false;

## Use static in class declaration when all methods are expected to be static
### YES:
		static class SampleClass
		{
		
		    public static void SampleMethod1()
		    {
		    }
		
		    public static void SampleMethod2()
		    {
		    }
		}
	
### NO:
		class SampleClass
		{
		
		    public static void SampleMethod1()
		    {
		    }
		
		    public static void SampleMethod2()
		    {
		    }
		}
	

## The order for comparison with null is always having null at the end of the comparison
### YES:
		void SampleMethod(TextWriter logger, CancellationToken token)
		{
		    if (logger == null)
		    {
		        ...
		    }
		}
		
### NO:
		void SampleMethod(TextWriter logger, CancellationToken token)
		{
		    if (null == logger)
		    {
		        ...
		    }
		}
	
## Is better to use nameof than a "string"
### YES:
		void SampleMethod(string paramName)
		{
		    if (string.IsNullOrEmpty(paramName) throw new ArgumentNullException(nameof(paramName));
		    ...
		}
		
### NO:
		void SampleMethod(string paramName)
		{
		    if (string.IsNullOrEmpty(paramName) throw new ArgumentNullException("paramName");
		    ...
		}
		
## Is better to use $ than string.format.
### YES:
		string sample = $"{variable1}:{variable2}";
		
### NO:
		string sample = string.Format("{0}:{1}", variable1, variable2);


## Use of var
### "var" can only be used when the type of the variable can be determined by looking ONLY at the right part after the "=". 

### YES:
		var variable=1;
### YES:
		var variable="Hello";
### YES:
		var element = new Dictionary<string,string>();
### YES:
		var element = (string)someClass.SomeMethod();
		
### NO:
		var element = someClass.SomeMethod();
### NO:
		var element = await someClass.SomeMethod();
		
##Number of parameters
The maximum desirable number of parameters for a method is 3. Over that number there should be a reason for not using a class.
### YES:
		void CreatePlayer(Player player)
	
### NO:
		void CreatePlayer(string playerName, string playerTeam, int playerAge, int playerNumber, ...)
