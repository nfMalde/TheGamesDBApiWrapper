# Change Log
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