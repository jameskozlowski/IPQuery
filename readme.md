# A Simple C# .NET Core API for using ip-api.com #
 
 ## Usage ##

 `dotnet restore`

 To run a lookup on your own ip: `dotnet run`

 To run a lookup on a IP address: `dotnet run 8.8.8.8`

 To run a lookup on a hostname: `dotnet run google.com`
 
 ## Returned Data ##
 Name|Description|Example|Type
 |---|-----------|-------|----
 status|Success/fail|success|string 
 message|Error Message|invalid query|string
 country|country|United States|string
 countryCode|country short|US|string
 region|region/state|CA or 10|string
 regionName|region/state|California|string
 city|city|Mountain View|string
 zip|zip code|94043|string
 lat|latitude|37.4192|float
 lon|longitude|-122.0574|float
 timezone|city timezone|America/Los_Angeles|string
 isp|ISP name|Google|string
 org|Organization name|Google|string
 as|AS number and name|AS15169 Google Inc.|string
 reverse|Reverse DNS|wi-in-f94.1e100.net|string
 mobile|mobile (cellular)|true|bool
 proxy|proxy (anonymous)|true|bool
 query|IP|173.194.67.94|string

 [More Information](http://ip-api.com/docs/api:xml)