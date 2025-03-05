# Change Log
## 2.1.1
* Fixed bug where encoding csv like parameter broke the request
* Added support for multiple values in csv like parameter
* Added enhanced error handling (e.g. when the API is down)
## 2.1.0
Upgraded to latest Restsharp and .net 8.
## 2.0.0
Fixes:
* Fixed a bug where certain null values at GameModel result in breaking the code.
* Fixed TheGamesDBApiWrapperRestClientFactory creation due to breaking code changes in RestSharp 110.20
Updates:
* Migrated to latest RestSharp (110.20)
* Migrated to .NET 6

Starting with this release older versions of th is package are no longer supported or mantained and will be marked as depricated in nuget.
## 1.2.0
* Migrated to latest RestSharp (107.1.2)
* Migrated to .NET 5

## 1.1.0
* You can now track the allowance of TheGamesDBAPI by injecting the [IAllowanceTracker](https://github.com/nfMalde/TheGamesDBApiWrapper/blob/main/src/Domain/Track/IAllowanceTracker.cs) or using the `AllowanceTrack` Property of [ITheGamesDBAPI](https://github.com/nfMalde/TheGamesDBApiWrapper/blob/main/src/Domain/ITheGamesDBAPI.cs) See Readme or Docs for more info

## 1.0.5
### Changed
* Updated Dependencies and added automated readme.

## 1.0.4
### Changed
* Fixed Game Update Call to allow all value types (objects, non object, string, int). The Game Update Response Model will have now an additional Property called "Values" of Type "GameUpdateValueModel" which has  3 Properties: Value, Values and Objects. One is set, the rest will be NULL. See: [GameUpdateValueModel](https://github.com/nfMalde/TheGamesDBApiWrapper/blob/main/src/Models/Responses/Games/GameUpdateValueModel.cs)

## 1.0.3
### Changed
* Fixed ID  Data Types in Responses
* Fixed Response Classes for Paginated responses 
* Fixed Game Images Call Image Types
* Fixed Platform Images Call Image Types
* Changed RestSharp Config to Ignore Null values by default
* Fixes for some json properties

## 1.0.2
### Changed
* Fixed Package Info

## 1.0.1
### Changed
* Fixed License Info

## 1.0.0
* Initial Release