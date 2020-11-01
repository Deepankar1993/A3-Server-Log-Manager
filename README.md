# A3-Server-Log-Manager
This is a a3 server log manager. 
Utilizes and captures the logs send from the A3 server especially from Main server and zoneserver.

Logger is inspried by 
cyber inferno's :  https://github.com/cyberinferno

Inferno-A3-Logger:  https://github.com/project-agonyl/Inferno-A3-Logger


### Features Implemented : 
* Shows online players with login Date and time
* Add and Remove Server Announcements
* Set Custom interval for Annnouncements
* PVP Shout with Town name and Location
* PVP Shout logs


All System are systems are seprated into different services.
Each service can be expanded or new services/Systems can be added or removed.

### Prerequisites
* Visual studio 2019 or higher
* .NET Core 3.1 /  NET Core 3.1


## How to Use

* Uncomment/Update MainServer/SvrInfo.ini
```
GameLogServerIP=127.0.0.1
GameLogServerPort=8000
```

* Uncomment/Update ZoneServer/SvrInfo.ini
```
GameLogServerIP=127.0.0.1
GameLogServerPort=8001
```

* Update settings.json (in the root folder of the build) with the correct ip and port
```
  "MS_IP": "127.0.0.1",
  "MS_PORT": 7789,

  "MS_LISTENER_IP": "127.0.0.1",
  "MS_LISTENER_PORT": 8000,

  "ZS_LISTENER_IP": "127.0.0.1",
  "ZS_LISTENER_PORT": 8001

```

#### How Update Map Names 
Map details are located inside ` Data/maps.json ` map names from here are taken for PVP shouts.(Don't keep long names)

#### Where are the Announcement Messages are saves
```
Data/database.sqlite
```



