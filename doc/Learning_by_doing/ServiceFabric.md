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
