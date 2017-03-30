using System;
using System.Diagnostics;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Runtime;
using MyActor.Interfaces;

namespace MyActor
{
  internal static class Program
  {
    /// <summary>
    /// This is the entry point of the service host process.
    /// </summary>
    private static void Main()
    {
      try
      {
        // This line registers an Actor Service to host your actor class with the Service Fabric runtime.
        // The contents of your ServiceManifest.xml and ApplicationManifest.xml files
        // are automatically populated when you build this project.
        // For more information, see https://aka.ms/servicefabricactorsplatform

        ActorRuntime.RegisterActorAsync<MyActor>(
           (context, actorType) => new ActorService(context, actorType)).GetAwaiter().GetResult();

        Console.WriteLine("Actor runtime registration completed");

        // Speak with actor a few times. I.e. send messages.
        // Create a randomly distributed actor ID
        ActorId actorId = ActorId.CreateRandom();

        // This only creates a proxy object, it does not activate an actor or invoke any methods yet.
        IMyActor myActor = ActorProxy.Create<IMyActor>(actorId, new Uri("fabric:/MyApp/MyActorService"));

        // Create the token source.
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken cts = source.Token;

        // This will invoke a method on the actor. If an actor with the given ID does not exist, it will
        // be activated by this method call.
        myActor.SetCountAsync(1, cts);


        Thread.Sleep(Timeout.Infinite);
      }
      catch (Exception e)
      {
        ActorEventSource.Current.ActorHostInitializationFailed(e.ToString());
        throw;
      }
    }
  }
}
