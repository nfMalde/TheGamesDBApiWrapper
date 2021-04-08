# TheGamesDBApiWrapper
Wrapper Lib for handling requests to the [TheGamesDB API](https://thegamesdb.net/).
For API-Docs look here: https://api.thegamesdb.net/#/

**NOTE** Not a official release - so no warranty for usage.

## Requirements
* .NET Core 3.1 or higher
* The GamesDB API Access [(Request your keys here)](https://forums.thegamesdb.net/viewforum.php?f=10)

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

## Contribute
If you find any bug or want to add an feature. Simply create an Issue. And submit an pull request with your changes and link it the issue.


