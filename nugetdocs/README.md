[![Nuget](https://img.shields.io/nuget/v/TheGamesDBApiWrapper?style=flat-square)](https://www.nuget.org/packages/TheGamesDBApiWrapper/) 
 [![Downloads](https://img.shields.io/nuget/dt/TheGamesDBApiWrapper?style=flat-square)](https://www.nuget.org/packages/TheGamesDBApiWrapper/)
 [![Paypal Donate](https://img.shields.io/badge/DONATE%E2%99%A5-PAYPAL-blue?style=flat-square&logo=paypal)](https://www.paypal.com/donate/?hosted_button_id=SVZHLRTQ6H4VL)
 [![Github](https://img.shields.io/badge/nfMalde-TheGamesDBApiWrapper-lightgrey?style=flat-square&logo=github)](https://github.com/nfMalde/TheGamesDBApiWrapper)

# TheGamesDBApiWrapper
Wrapper Lib for handling requests to the [TheGamesDB API](https://thegamesdb.net/).
For API-Docs look here: https://api.thegamesdb.net/#/

**NOTE** Not a official release - so no warranty for usage.

**External Libraries**
This Library uses the following lib(s) fro archive its functionality:
* [RestSharp](https://github.com/restsharp/RestSharp)
* [NewtonSoft.Json/JSON.NET](https://github.com/JamesNK/Newtonsoft.Json)

## Requirements
* .NET 6 or higher
* Older Versions for NET5 and below are still available - however **starting with v2.0.0** these versions are no longer supported and marked as depricated. Please update your package to latest version when possible.
* This package requires RestSharp  1.110.x and above.
* The GamesDB API Access [(Request your keys here)](https://forums.thegamesdb.net/viewforum.php?f=10)
## Install
Nuget:
```
Install-Package TheGamesDBApiWrapper 
```

Dotnet Cli
```
dotnet add package TheGamesDBApiWrapper
```
 

## Usage
### Add
Add to Services:

```C#
//Startup.cs

public IServiceProvider ConfigureServices(IServiceCollection services) {
    
    // Variant 1: Load Settings from IConfiguration for API Wrapper (See Readme.md -> Configure for more details):
    services.AddTheGamesDBApiWrapper();
    // Variant 2: Provide a type of TheGamesDBApiConfigModel to configure the api lib.
    services.AddTheGamesDBApiWrapper(new TheGamesDBApiConfigModel() {
        BaseUrl = "....", // Change Base Url for API Requests e.g. for proxies (Defaults to: https://api.thegamesdb.net/)
        Version = 1, //Indicate the Version to use of the API (Defaults to 1)
        ApiKey = "abc",  // The API Key to use (either the one lifetime private key or the public key received by the API Team of "TheGamesDB" see "Requirements",
        ForceVersion = false // Indicates if version is forces to use - see Configure Readme Section for more
    });
    
    // Variant 3: Provide value by value
     services.AddTheGamesDBApiWrapper("apikey",1, "https://api.thegamesdb.net/");
  
}
```
### Configure
You can configure the API Lib by using the App Configuration.
For Example in your appsettings.json: 
```JSON
{
  ...
  "TheGamesDB": {
     "BaseUrl": "https://api.thegamesdb.net/",
     "Version": 1,
     "ApiKey": "abcdefg",
     "ForceVersion": false
  }
  
  ...
}
```
Property | Description | Type | Default
------------ | ------------- | ------------- | -------------
BaseUrl | The Base Url for all API Requests | String | https://api.thegamesdb.net/
Version | The API Version to use | Double | 1
ApiKey | The API Key to use for requests | String | NULL
ForceVersion | By default, The API Lib will try to get the highest possible minor version of an api endpoint (1.1,1.2, 1.3 etc) So if you select version 1 and Version 1.3 is declared for this endpoint the Lib will use 1.3 for requests. If you force the version it will ignore minor versions and use the configured version instead - even if its not available for this endpoint. So use this with caution | Boolean | FALSE




### Use

To use it in code simple inject the API Class to your service or controller:

```C#
public class MyServiceClass { 
  private ITheGamesDBAPI api;
  
  public MyServiceClass(ITheGamesDBAPI api) {
    this.api = api;
  }
```

The Api Wrapper Lib is built in fluent pattern and based on the documentation of TheGamesDB api.
So for loading all Platforms which is the api endpoint `/Platforms` you simple call:

```C#
var platforms = await this.api.Platform.All();
```

All parameters of all methods in the specific api class is documented in the ["TheGamesDB" Api Docs](https://api.thegamesdb.net/#/)


### Keeping Track of your monthly allowance
TheGamesDB API has set an monthly request limit called "monthly allowance".
To keep track of it you have (Starting with version 1.1.x) 2 ways to do so:
#### Method 1 The IAllowanceTracker Singelton
The singelton can be injected at every place of your code.
Once you call one of the API endpoints such as `/Platforms`
The values of the singelton will be set and you cann access it (Be sure that its in the same context)

Example: Monthly Allowance limit reached

```C#

public class MyService:IMyService {
  private ITheGamesDBAPI api;
  private IAllowanceTracker tracker;

  public MyService(IAllowanceTracker tracker, ITheGamesDBAPI api) {
    this.tracker = tracker;
    this.api = api;
  }

  public async Task ImportPlatforms() {

      var platforms = await this.api.Platforms.All();
      //... do something with the response

      var currentAllowance = this.tracker.Current;

      if (currentAllowance != null) {
          int remainingRequests = currentAllowance.Remaining;
          DateTime resetDate = currentAllowance.ResetAt;

          // Do something with this info
          // For example store it in db to use it as offset next time (See "Allowance Offset" in this readme)


      }

  }

}
```
#### Method 2 The AllowanceTrack Property
The `AllowanceTrack` Property of `ITheGamesDBAPI` is a shortcut handle to access the Singelton´s  `Current` Property.
Its the same as above only you dont  need to inject the singelton in your service.
```C#

public class MyService:IMyService {
  private ITheGamesDBAPI api;

  public MyService(ITheGamesDBAPI api) {
    this.api = api;
  }

  public async Task ImportPlatforms() {

      var platforms = await this.api.Platforms.All();
      //... do something with the response

      var currentAllowance = this.api.AllowanceTrack; // Shortcut to IAllowanceTracker->Current

      if (currentAllowance != null) {
          int remainingRequests = currentAllowance.Remaining;
          DateTime resetDate = currentAllowance.ResetAt;

          // Do something with this info
          // For example store it in db to use it as offset next time (See "Allowance Offset" in this readme)

      }

  }

}
```
#### Allowance Offset
When you store the allowance in DB or Cache you can load it before you call any api and set the IAllowanceTracker by yourself.
This is helpfull, for keeping track of your allowance before sending the next api call.

```C#
// Assuming our Entity have the following properties:
// int Remaining, int ResetInSeconds
var mydbentity = this.loadFromDB(); // Load the data from db

if (mydbentity != null) {
  // Tracker is our IAllowanceTracker
   tracker.SetAllowance(mydbentity.Remaining, 0, mydbentity.ResetInSeconds);
}

if (tracker.Current != null && tracker.Current.Remaining == 0) {
    throw new Exception($"We reached TheGamesDBApi Limit and can use the api again at {tracker.Current.ResetAt}");
}

 var platforms = await this.api.Platforms.All();

 // do something with the response

mydbentity.Remaining = tracker.Current.Remaining; 
mydbentity.ResetInSeconds = tracker.Current.ResetAtSeconds;

this.saveDbEntity(mydbentity);

```

In the example above we save the allowance contents to db to check on every run if we allready reached it.
This way if you know the amount of api calls for your operation you can see if you have enough monthly allowance left to finish your operation or you want to wait for reaching the reset timer.
 


### Helpers
#### Paginating
All paginated responses have two helper methods called NextPage and PreviousPage. So you can swap between pages by calling this async methods.
For Example:
```C#
var gamesresponse = await this.api.Games.ByGameName("Counter");

// Info about current, next, prev page is stored in the sub oject "Pages"

// Check if we have a next page and switch to it

if (gamesresponse.Pages?.Next != null) {
    var nextResponse = await gamesresponse.NextPage();
    // Do something...
}

// Same for prev. page:
if (gamesresponse.Pages?.Previous != null) {
    var prevResponse = await gamesresponse.PreviousPage();
    // Do something...
}
```

## Contribute / Donations
If you got any Ideas to improve my projects feel free to send an pull request. 

If you like my work and want to support me (or want to buy me a coffee/beer) paypal donation are more than appreciated.

 [![Paypal Donate](https://img.shields.io/badge/DONATE%E2%99%A5-PAYPAL-blue?style=for-the-badge&logo=paypal)](https://www.paypal.com/donate/?hosted_button_id=SVZHLRTQ6H4VL)

