# Learning by doing: **Service Fabric**

## Plan / work

- [x] [Stateless Service](https://github.com/mambrus/csharp_lab1)
- [x] [Stateful Service](https://github.com/mambrus/csharp_lab2)
- [ ] [Actor Stateful service](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-reliable-actors-introduction)
- [ ] Run (any) SF solution on Azure
- [ ] Deployment & continuous integration
  - [ ] Build
  - [ ] Test
    - [ ] Escalate
  - [ ] [CD](https://en.wikipedia.org/wiki/Continuous_delivery)

## References

* [SF Actors, get started](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-reliable-actors-introduction)
* [MSDN Class library doc: SF Actors](https://msdn.microsoft.com/library/azure/dn971626.aspx)
* [Azure Samples in C#](https://github.com/Azure-Samples?utf8=%E2%9C%93&q=fabric&type=&language=c%23)

## Research

- [ ] Interfaces
 * How well does 
	  [Event
	  Sourcing](https://msdn.microsoft.com/en-us/library/jj554200.aspx)
	  go with `Actor`, `IActor` ?

## Tutorials, Labs & specific sample projects

* [SF "reliable" Actors get started](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-reliable-actors-get-started)
* [`C#` SF getting-started](https://github.com/azure-samples/service-fabric-dotnet-getting-started)
  * See in particular the Actor samples: 
   [`VoicemailBox`](https://github.com/Azure-Samples/service-fabric-dotnet-getting-started/tree/master/Actors/VoiceMailBox),
   [`VisualObjects`](https://github.com/Azure-Samples/service-fabric-dotnet-getting-started/tree/master/Actors/VisualObjects)
* [`Java` SF getting-started](https://github.com/Azure-Samples/service-fabric-java-getting-started)
  * See inparticular the Actor samples:
   [`ActorCounter`](https://github.com/Azure-Samples/service-fabric-java-getting-started/tree/master/Actors/ActorCounter),
   [`VisualObjectActor`](https://github.com/Azure-Samples/service-fabric-java-getting-started/tree/master/Actors/VisualObjectActor)



# Notes

## My First SF Actor Lab

### Create a project into umbrella-project

Create project:

* Create a directory **two levels** down your umbrella project
  * `mkdir -p ServiceFabric/ActorLabs`
* **But** use another instance of Visual Studio (keep the names suggested in walk-through)
* Follow the guide at the first bullet under *Turorials..* above.
  * This will create yet a third sub-level: `MyActorApplication`
* Build and run *as is*. This should deploy on your localhost.
  * Diagnostic Events should open and the last message should be `RunAsync has successfully completed for a stateful service replica`
  * SF explorer at [http://localhost:19080](http://localhost:19080)
    * `Cluster->Application->`: MyActorApplication**Type**
    * `Nodes->`and `System->` populated accordingly

Notice that:

- 3 projects have been created `MyActor`, `MyActor.interfaces`, `MyActoatApplication`
  - The last one contains only scripts and config, but is the one which is set as *default project*.
- Build options are set to `Debug`and `x64`

Incoorperate into umbrella-project

* Stop debug, close ploject & open your umbrella-project instead (as root)
* In `Solution Explorer` add `Add`->`New Solution Folder` twice recursively and with the same names as the directory structure created
  I.e `ServiceFabric/ActorLabs
* Right-click on `ActorLabs` and `Add`->`Existing Project`
* Set the Build-options as before: `Debug`and `x64
* Build and run as before and checkt that it deploys as before.

Add to SCM:

```bash
cd $PROJROOT
git add .
git commit -a -m"Service Fabric application created and added from template"
```

*Voilá!*

### Files

The template builds and runs (a service sitting doing nothing):

Source-code (C#, i.e. what counts) as follows:

```
./MyActor/ActorEventSource.cs
./MyActor/MyActor.cs
./MyActor/Program.cs
./MyActor/Properties/AssemblyInfo.cs
./MyActor.Interfaces/IMyActor.cs
./MyActor.Interfaces/Properties/AssemblyInfo.cs
```
 
Notice:

* Only two directories contan code (execution related)
  * The third one is a deployment project
  * Albeit the "real-code" projects are not entirely free from configs and what-not's either
* Threre exists only one *Main()*, i.e. only one formal process is deployed.
  * Any conurrency is managed within this project
  * Replicas not included (i.e. SF's load-balancing)

Analyze:

* This can't scale on demand by itself
* The interface-class is the main _intended_ way for communication
  * It mandate's *Task* methods  
