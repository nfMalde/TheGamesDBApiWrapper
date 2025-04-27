# Change Log
## 3.0.0
- **Breaking Changes**:
  - Removed `RestClient` and `Newtonsoft.Json` dependencies.
  - Updated all API methods to use `HttpClient` and `System.Text.Json`.
  - Moved to .NET 9
- **Migration to System.Text.Json**:
  - Replaced `Newtonsoft.Json` with `System.Text.Json` across all models and converters.
  - Added `TimestampToDateTimeConverter` for converting Unix timestamps to `DateTime`.
  - Removed `Newtonsoft.Json` dependency from the project.

- **Migration to HttpClient**:
  - Replaced `RestClient` with `HttpClient` for making API calls.
  - Updated all API methods to use `HttpClient` for requests and responses.
  - Removed `RestSharp` dependency from the project.

- **Nullable Return Types**:
  - Updated all return types in the `IGames` interface to be nullable to support `null` responses.

- **Enhancements to TheGamesDBApiWrapperRestClientFactory**:
  - The `Create` method now returns an `HttpClient` instead of a `RestClient`.
  - Added a new method `GetJsonSerializerOptions` to configure `System.Text.Json` serialization options.

- **Refactoring and Consistency Improvements**:
  - Updated documentation for the `IGames` interface to reflect nullable return types.
  - Improved consistency in serialization and deserialization logic across models.

- **Enum Improvements**:
  - Updated `GameFieldIncludes` and other enums to use `System.Text.Json.Serialization.JsonStringEnumConverter`.

- **Testing and Mock Data Updates**:
  - Updated test cases to reflect changes in models and converters.
  - Adjusted JSON mock data to align with the new `System.Text.Json` serialization.

- **General Code Cleanup**:
  - Improved code readability and structure across multiple files.

- **Other Changes**:
  - Enhanced error handling and validation in API classes.
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