using DelegatesApp;
using DelegatesApp.Interfaces;
using System.Collections;
using System.Runtime.CompilerServices;

ISubscriber subscriber = new Subscriber();
IIteratable fileIterator = new FileIterator(subscriber);
fileIterator.Iterate();
fileIterator.Dispose();
Console.ReadKey();