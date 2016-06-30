# MultipleFtpSitePublisher
Multiple ftp site publisher

Small app that can help you automate deployment to multiple ftp servers by JSON config file.

Config file has to be named config.json and placed besides exe file.

###Example
```json
{
  "Sites": [
    {
      "HostName": "ftp.site.com",
      "Password": "paswd",
      "Protocol": 2,
      "UserName": "myFtpUser",
      "RemoteBasePath": "/wwwroot1"
    }, {
      "HostName": "ftp.site2.com",
      "Password": "paswd2",
      "Protocol": 2,
      "UserName": "myFtpUser2",
      "RemoteBasePath": "/wwwroot2"
    }
  ],
  "TransferableItems": [
    {
      "LocalPath": "x:\\Develop\\CopyFolder\\*",
      "RemotePath": "/Destination/",
      "Remove": false
    }, {
      "LocalPath": "x:\\Develop\\CopyFolder2\\*",
      "RemotePath": "/Destination/",
      "Remove": false
    }
  ]
}
```
