# TestDataValidation
Description:

To build this app I used `System.CommandLine` package to create commands in the console. For creation different instances I used `Factory method` pattern. `Proxy` is used for determination between old and new passport validators. Unit tests added with Xunit library. Also, I left couple `todo` comments where validation can be extended if additional info would be provided.

Usage:
  TestDataValidation [command] [options]

Options:
  --version       Show version information
  -?, -h, --help  Show help and usage information

Commands:
  passport <value>    Validate passport
  rnokpp <value>      Validate rnokpp
  birthday <value>    Validate birthday
  deviceUuid <value>  Validate device uuid

How to run the app:
1. Pull repository to the local machine
2. Build solution
3. Go to .exe file location
4. Run command e.g. `.\TestDataValidation.exe passport БД123456` or it can be used `.\TestDataValidation.exe TestDataValidation passport БД123456` as well