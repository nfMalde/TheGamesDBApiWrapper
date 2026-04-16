[![Nuget](https://img.shields.io/nuget/v/TheGamesDBApiWrapper?style=flat-square)](https://www.nuget.org/packages/TheGamesDBApiWrapper/) 
[![Downloads](https://img.shields.io/nuget/dt/TheGamesDBApiWrapper)](https://www.nuget.org/packages/TheGamesDBApiWrapper/)
[![Paypal Donate](https://img.shields.io/badge/donate-paypal-blue)](https://www.paypal.com/donate/?hosted_button_id=SVZHLRTQ6H4VL)
[![Pull Request Check](https://img.shields.io/github/actions/workflow/status/nfMalde/TheGamesDBApiWrapper/pr.yml)](https://github.com/nfMalde/TheGamesDBApiWrapper/actions/workflows/pr.yml)

# TheGamesDBApiWrapper
Wrapper library for handling requests to the [TheGamesDB API](https://thegamesdb.net/).
For API documentation, see: https://api.thegamesdb.net/#/

**NOTE** This is not an official release, so there is no warranty for usage.

**External Libraries**
This library uses the following dependencies to achieve its functionality:
* [.NET 10](https://github.com/microsoft/dotnet)
* [Shouldly](https://github.com/shouldly)
* [RichardSzalay.MockHttp](https://github.com/richardszalay/mockhttp)
* [Moq](https://github.com/devlooped/moq)
* [xunit](https://github.com/xunit/xunit)
* [xunit.runner.visualstudio](https://github.com/xunit/visualstudio.xunit)
## Requirements
* .NET 10 or higher
* The GamesDB API Access [(Request your keys here)](https://thegamesdb.net/)

## Install
NuGet:
```
Install-Package TheGamesDBApiWrapper 
```

Dotnet CLI
```
dotnet add package TheGamesDBApiWrapper
```
 

## Usage
### Add
Add to services:

```C#
//Startup.cs

public IServiceProvider ConfigureServices(IServiceCollection services) {
    
  // Variant 1: Load settings from IConfiguration for the API Wrapper (see README.md -> Configure for more details):
    services.AddTheGamesDBApiWrapper();
  // Variant 2: Provide a TheGamesDBApiConfigModel to configure the API library.
    services.AddTheGamesDBApiWrapper(new TheGamesDBApiConfigModel() {
  BaseUrl = "....", // Change the base URL for API requests, e.g., for proxies (Defaults to: https://api.thegamesdb.net/)
  Version = 1, // Indicate the version of the API to use (Defaults to 1)
  ApiKey = "abc",  // The API key to use (either the lifetime private key or the public key received from the API Team of "TheGamesDB"; see "Requirements")
  ForceVersion = false // Indicates if the version is forced - see Configure README section for more
    });
    
  // Variant 3: Provide values directly
  services.AddTheGamesDBApiWrapper("apikey", 1, "https://api.thegamesdb.net/");
  
}
```
### Configure
You can configure the API library using the app configuration.
For example, in your appsettings.json: 
```JSON
{
  ...
  "TheGamesDB": {
     "BaseUrl": "https://api.thegamesdb.net/",
     "Version": 1,
     "ApiKey": "abcdefg",
     "ForceVersion": false,
     "HttpTimeout": 180
  }
  
  ...
}
```
Property | Description | Type | Default
------------ | ------------- | ------------- | -------------
BaseUrl | The base URL for all API requests | String | https://api.thegamesdb.net/
Version | The API version to use | Double | 1
ApiKey | The API key to use for requests | String | NULL
ForceVersion | By default, the API library will try to get the highest possible minor version of an API endpoint (1.1, 1.2, 1.3, etc.). If you select version 1 and version 1.3 is available for this endpoint, the library will use 1.3 for requests. If you force the version, it will ignore minor versions and use the configured version instead—even if it is not available for this endpoint. Use this with caution. | Boolean | FALSE
HttpTimeout | The HTTP request timeout in seconds | Integer | 180




### Use

To use it in code, simply inject the API class into your service or controller:

```C#
public class MyServiceClass { 
  private ITheGamesDBAPI api;
  
  public MyServiceClass(ITheGamesDBAPI api) {
    this.api = api;
  }
```

The API Wrapper library is built using the fluent pattern and is based on the documentation of TheGamesDB API.
To load all platforms (which is the API endpoint `/Platforms`), simply call:

```C#
var platforms = await this.api.Platform.All();
```

All parameters of all methods in the specific API class are documented in the ["TheGamesDB" API Docs](https://api.thegamesdb.net/#/).

#### Regions & Countries
You can fetch all regions and countries, or look up regions by ID:

```C#
// Get all regions
var regions = await this.api.Regions.All();

// Get region(s) by ID
var region = await this.api.Regions.ByRegionID(1);
var multipleRegions = await this.api.Regions.ByRegionID(new int[] { 1, 2, 3 });

// Get all countries
var countries = await this.api.Countries.All();
```

#### Search Games by Unique ID or ROM Hash
You can search for games using their unique/external identifier (e.g. ROM serial) or by ROM hash:

```C#
// Search by unique ID
var games = await this.api.Games.ByGameUniqueID("GM-007037-00");

// Search by unique ID with platform filter
var filtered = await this.api.Games.ByGameUniqueID("GM-007037-00", new int[] { 18 });

// Search by ROM hash
var byHash = await this.api.Games.ByGameHash("a29da82b");

// Search by ROM hash with hash type filter
var byCrc = await this.api.Games.ByGameHash("a29da82b", null, "crc");
```

#### Check API Limit
You can check your API key allowance without consuming quota:

```C#
var limit = await this.api.Utility.GetApiLimit();
int remaining = limit.RemainingMonthlyAllowance;
int extra = limit.ExtraAllowance;
int? refreshTimer = limit.AllowanceRefreshTimer; // null for unlimited keys
```


#### GameUpdates Handling
TheGamesDB provides an API call called "games/updates" which allows you to get incremental changes and update them in your database.
The value that needs to be updated can differ by type:
- Array of string
- Array of objects
- Array of numbers
- String (Single Value update)
- Number (Single Value update)
- Date

To simplify output, TheGamesDBAPIWrapper already parses the values to each type:

```c#
ITheGamesDBAPI api = this.ServiceProvider.GetRequiredService<ITheGamesDBAPI>();

var response = await api.Games.Updates(0);// Last Edit ID - always save it for later updates (found in response)

foreach (var update in response.Data.Updates)
{
  // The type of the update, e.g., the property or fields to be updated, for example: developers array
    var type = update.Type;
  // This is where the API wrapper parses all values found in the response
    var value = update.Values;

  // Do something with the last edit id, e.g., save it to the database for later updates
    var lastEditId = update.EditID;

    // There are 4 types of values possible

    // 1. Single String Value
    if (value?.Value is string stringValue)
    {
        // Handle single string value
        continue;
    }
    // 2. Single Number Value
    else if (value?.NumberValue is long numberValue)
    {
  // To ensure our number type has the correct size, we use long here
        // Handle single number value
        continue;
    }
    else if (value?.Values is object[] valuesArray)
    {
        // 3. Array of Values
  // Handle array of values
        foreach (var item in valuesArray)
        {
            // Process each item in the array
        }
        continue;
    }
    else if (value?.Objects is Dictionary<string, object>[] keyValuePairs)
    {
        // 4. Array of Key/Value Pairs
  // Handle array of key/value pairs
        foreach (var dict in keyValuePairs)
        {
            foreach (var kvp in dict)
            {
                var key = kvp.Key;
                var val = kvp.Value;
                // Process each key/value pair
            }
        }
        continue;
    }


}
```

### Keeping Track of your monthly allowance
TheGamesDB API has a monthly request limit called "monthly allowance".
Starting with version 1.1.x, there are two ways to keep track of it:
#### Method 1: The IAllowanceTracker Singleton
The singleton can be injected anywhere in your code.
Once you call one of the API endpoints, such as `/Platforms`,
the values of the singleton will be set and you can access it (be sure that it's in the same context).

Example: Monthly allowance limit reached

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
  // ...do something with the response

  var currentAllowance = this.tracker.Current;

      if (currentAllowance != null) {
          int remainingRequests = currentAllowance.Remaining;
          DateTime resetDate = currentAllowance.ResetAt;

          // Do something with this info
          // For example, store it in the database to use as an offset next time (see "Allowance Offset" in this README)


      }

  }

}
```
#### Method 2: The AllowanceTrack Property
The `AllowanceTrack` property of `ITheGamesDBAPI` is a shortcut to access the singleton's `Current` property.
It's the same as above, except you don't need to inject the singleton into your service.
```C#

public class MyService:IMyService {
  private ITheGamesDBAPI api;

  public MyService(ITheGamesDBAPI api) {
    this.api = api;
  }

  public async Task ImportPlatforms() {

  var platforms = await this.api.Platforms.All();
  // ...do something with the response

  var currentAllowance = this.api.AllowanceTrack; // Shortcut to IAllowanceTracker->Current

      if (currentAllowance != null) {
          int remainingRequests = currentAllowance.Remaining;
          DateTime resetDate = currentAllowance.ResetAt;

          // Do something with this info
          // For example, store it in the database to use as an offset next time (see "Allowance Offset" in this README)

      }

  }

}
```
#### Allowance Offset
When you store the allowance in a database or cache, you can load it before you call any API and set the IAllowanceTracker yourself.
This is helpful for keeping track of your allowance before sending the next API call.

```C#
// Assuming our entity has the following properties:
// int Remaining, int ResetInSeconds
var mydbentity = this.loadFromDB(); // Load the data from the database

if (mydbentity != null) {
  // Tracker is our IAllowanceTracker
  tracker.SetAllowance(mydbentity.Remaining, 0, mydbentity.ResetInSeconds);
}

if (tracker.Current != null && tracker.Current.Remaining == 0) {
  throw new Exception($"We reached TheGamesDBApi limit and can use the API again at {tracker.Current.ResetAt}");
}

 var platforms = await this.api.Platforms.All();

 // Do something with the response

mydbentity.Remaining = tracker.Current.Remaining; 
mydbentity.ResetInSeconds = tracker.Current.ResetAtSeconds;

this.saveDbEntity(mydbentity);

```

In the example above, we save the allowance contents to the database to check on every run if we have already reached it.
This way, if you know the number of API calls for your operation, you can see if you have enough monthly allowance left to finish your operation or if you want to wait until the reset timer is reached.
 


### Helpers
#### Paginating
All paginated responses have two helper methods called NextPage and PreviousPage. You can switch between pages by calling these async methods.
For example:
```C#
var gamesresponse = await this.api.Games.ByGameName("Counter");

// Information about the current, next, and previous page is stored in the sub-object "Pages".

// Check if we have a next page and switch to it

if (gamesresponse.Pages?.Next != null) {
    var nextResponse = await gamesresponse.NextPage();
  // Do something...
}

// Same for previous page:
if (gamesresponse.Pages?.Previous != null) {
    var prevResponse = await gamesresponse.PreviousPage();
  // Do something...
}
```

## Contribute / Donations
If you have any ideas to improve my projects, feel free to send a pull request. 

If you like my work and want to support me (or want to buy me a coffee/beer), PayPal donations are more than appreciated.

[![Paypal Donate](https://img.shields.io/badge/donate-paypal-blue)](https://www.paypal.com/donate/?hosted_button_id=SVZHLRTQ6H4VL)
