# Change Log

## 3.1.0
- **New Endpoints**:
  - Added **Regions** endpoint (`api.Regions.All()`, `api.Regions.ByRegionID()`).
  - Added **Countries** endpoint (`api.Countries.All()`).
  - Added **Utility** endpoint (`api.Utility.GetApiLimit()`) to check API key allowance without consuming quota.
- **New Game Endpoints**:
  - Added `Games/ByGameUniqueID` for searching games by unique/external identifier (e.g. ROM serial).
  - Added `Games/ByGameHash` for searching games by ROM hash with optional hash type filter (e.g. `md5`, `crc`).
- **Model Fixes**:
  - Fixed `PlatformFields` enum — individual values were incorrectly copied from `GameFields`. Now correctly contains: `Icon`, `Console`, `Controller`, `Developer`, `Manufacturer`, `Media`, `CPU`, `Memory`, `Graphics`, `Sound`, `MaxControllers`, `Display`, `Overview`, `YouTube`.
  - Added missing fields to `PlatformModel`: `Manufacturer`, `Media`, `CPU`, `Memory`, `Graphics`, `Sound`, `MaxControllers`, `Display`, `YouTube`.
  - Added `RegionId` and `CountryId` properties to `GameModel`.
  - Fixed `ImageBaseUrlMetaModel` property name typo: `Lage` → `Large`.
- **Breaking Changes**:
  - Removed incorrect `PlatformFields` enum members (`Players`, `Publishers`, `Genres`, `LastUpdated`, `Rating`, `Platform`, `Coop`, `OS`, `Processor`, `RAM`, `HDD`, `Video`, `Alternates`). These were game-specific fields that never applied to platforms.
  - Renamed `ImageBaseUrlMetaModel.Lage` to `ImageBaseUrlMetaModel.Large`.
- **Enhancements**:
  - Registered `HttpClient` in dependency injection.
  - Added `HttpTimeout` configuration property to `TheGamesDBApiConfigModel` for customizable HTTP request timeout (defaults to 180 seconds).
  - Improved HTTP client lifecycle management through DI container.

## 3.0.3
- **Fixes**:
  - Fixed serialization issues with Field.All and Include.All enums. Now they correctly serialize to all values when used in requests.
## 3.0.2
- **Fixes**:
  - Fixed GameValueUpdate converter to handle numbers and number arrays correctly.
## 3.0.1 
- **Hot Fixes**:
  - Fixed a NullReference error when calling "NextPage()" or "PreviousPage()" on all paginated results.
  - Removed obsolete "DiResolver".
  
## 3.0.0
- **Breaking Changes**:
  - Removed `RestClient` and `Newtonsoft.Json` dependencies.
  - Updated all API methods to use `HttpClient` and `System.Text.Json`.
  - Migrated to .NET 9.
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
* Fixed a bug where encoding CSV-like parameters broke the request.
* Added support for multiple values in CSV-like parameters.
* Added enhanced error handling (e.g., when the API is down).
## 2.1.0
Upgraded to the latest RestSharp and .NET 8.
## 2.0.0
Fixes:
* Fixed a bug where certain null values in GameModel resulted in breaking the code.
* Fixed TheGamesDBApiWrapperRestClientFactory creation due to breaking changes in RestSharp 110.20.
Updates:
* Migrated to the latest RestSharp (110.20).
* Migrated to .NET 6.

Starting with this release, older versions of this package are no longer supported or maintained and will be marked as deprecated in NuGet.
## 1.2.0
* Migrated to the latest RestSharp (107.1.2).
* Migrated to .NET 5.

## 1.1.0
* You can now track the allowance of TheGamesDBAPI by injecting the [IAllowanceTracker](https://github.com/nfMalde/TheGamesDBApiWrapper/blob/main/src/Domain/Track/IAllowanceTracker.cs) or using the `AllowanceTrack` property of [ITheGamesDBAPI](https://github.com/nfMalde/TheGamesDBApiWrapper/blob/main/src/Domain/ITheGamesDBAPI.cs). See README or documentation for more info.

## 1.0.5
### Changed
* Updated dependencies and added automated README.

## 1.0.4
### Changed
* Fixed Game Update call to allow all value types (objects, non-object, string, int). The Game Update Response Model now has an additional property called "Values" of type "GameUpdateValueModel" which has three properties: Value, Values, and Objects. One is set, the rest will be NULL. See: [GameUpdateValueModel](https://github.com/nfMalde/TheGamesDBApiWrapper/blob/main/src/Models/Responses/Games/GameUpdateValueModel.cs)

## 1.0.3
### Changed
* Fixed ID data types in responses.
* Fixed response classes for paginated responses.
* Fixed Game Images call image types.
* Fixed Platform Images call image types.
* Changed RestSharp config to ignore null values by default.
* Fixes for some JSON properties.

## 1.0.2
### Changed
* Fixed package info.

## 1.0.1
### Changed
* Fixed license info.

## 1.0.0
* Initial release.