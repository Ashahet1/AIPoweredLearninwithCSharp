# C# Pub/Sub Example using Events and Delegates

Before diving into the code, here's a small write-up explaining the toy example I'll create:

This example demonstrates the Publish/Subscribe pattern in C# using the built-in event handling mechanism (`event` keyword and delegates like `Action` or `EventHandler`).

## Scenario:

We'll model a very simple scenario: a central `MessageBroadcaster` (the **Publisher**) that sends out string messages, and several `MessageListener` objects (the **Subscribers**) that receive and display these messages.

## Components:

### MessageBroadcaster (Publisher):

* This class is responsible for sending out messages.
* It will define a public `event`, let's call it `OnMessagePublished`. We'll likely use `Action<string>` as the delegate type for simplicity, meaning the event will carry the string message directly.
* It will have a method, perhaps `PublishMessage(string message)`, which, when called, triggers the `OnMessagePublished` event, sending the message to all subscribed listeners.
* Crucially, the `MessageBroadcaster` doesn't need to know *who* is listening or *how many* listeners there are. It just raises the *event*.

### MessageListener (Subscriber):

* This class represents an entity interested in receiving messages.
* Each listener will have a method, for example, `HandleMessage(string message)`, designed to match the signature of the `OnMessagePublished` event's delegate (`Action<string>`). This method will define what the listener does with the received message (e.g., print it to the console).
* To receive messages, an instance of `MessageListener` must *subscribe* its `HandleMessage` method to the `MessageBroadcaster`'s `OnMessagePublished` event. This requires the listener to have a reference to the specific broadcaster instance it wants to listen to.

## Interaction:

We will create one instance of `MessageBroadcaster` and multiple instances of `MessageListener`. Each listener instance will *subscribe* to the broadcaster's *event*. When the broadcaster calls its `PublishMessage` method, the .NET runtime automatically invokes the `HandleMessage` method on all subscribed listener instances, passing along the message content.

## Demonstrating Pub/Sub:

This setup showcases the core idea of Pub/Sub:

* **Decoupling:** The broadcaster sends messages without any specific knowledge of the listeners. Listeners react to messages without knowing the internal workings of the broadcaster, beyond the *event* it exposes.
* **One-to-Many:** One broadcast message is efficiently delivered to multiple subscribers.

