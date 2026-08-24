using System.Collections;
using System.ComponentModel;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OPP05
{
    internal class Program
    {
        static void Main(string[] args)
        {


            #region Part 1 

            #region Q1
            //a) What happens when you assign one object variable to another object variable?

            //Only the reference(memory address) of the object is copied to the new variable.Both variables now point to the exact same object in memory.

            //b) Does assigning one object to another create a new object? Explain.

            //No, it does not create a new object.It only creates a new reference targeting the existing object.A new object is created only when using the new keyword or a cloning method.

            //c) What is the difference between copying an object and copying its reference ?

            //Copying a reference means two variables share the same memory instance, so changes made through one affect the other.Copying an object creates a separate, independent instance with its own data.

            #endregion

            #region Q2

            //a) What is a Shallow Copy 

            //A Shallow Copy creates a new object instance and copies value-type fields directly, but for reference - type fields, it only copies their references, sharing the underlying objects between original and copy.

            //b) What is a Deep Copy ?

            //    A Deep Copy creates a new object instance along with new duplicate instances of all referenced objects, ensuring the new object is completely independent of the original.

            //c) What happens to reference-type members when a Shallow Copy is created?

            //They are shared between the original object and the copied object because only their reference addresses are copied.

            //d) What happens to reference-type members when a Deep Copy is created?

            //    New instances are recursively created for them, making them completely independent from the original object's members.

            //e) Give one situation where Deep Copy would be safer than Shallow Copy.

            //    When an object contains nested reference properties(e.g., a Shipment having a DeliveryAddress) and modifying the nested data in the copied object must not alter or corrupt the original object's data.



            #endregion

            #region Q3

            //a) What is a static field, and how is it different from an instance field ?

            //A static field belongs to the class itself and is shared among all instances of that class. An instance field belongs to a specific object, meaning each object holds its own separate copy.

            //b) What is a static method? Can a static method directly access instance members ?

            //    A static method is a method that belongs to the class rather than an instance and can be called without creating an object.No, it cannot directly access instance members because it operates without a specific instance context.

            //c) What is a static constructor, and when is it executed ?

            //    A static constructor is used to initialize static data or perform actions needed only once.It executes automatically before the first instance is created or any static members are referenced.

            //d) What is a static class? Can you create an object from a static class?

            //A static class is a class that contains only static members and cannot be instantiated or inherited.No, you cannot create an object from a static class using the new keyword.


            #endregion

            #region Q4

            //a) What is an Extension Method ?

            //    An Extension Method allows developers to add new methods to existing types without modifying the original source code or inheriting from the class.

            //b) What keyword must be used in the first parameter of an extension method ?

            //    The this keyword must precede the first parameter to specify the type being extended.

            //c) Where must an extension method be declared ?

            //    It must be declared inside a non-generic, non-nested static class.

            //d) Can an extension method access private members of the class it extends?

            //No, an extension method can only access public (or internal, if in the same assembly) members of the class it extends.






            #endregion

            #region Q5

            //a) What is a Partial Class ?

            //    A Partial Class allows the definition of a single class to be split across multiple.cs files, which are compiled into one unified class.

            //b) Why would a developer split one class into multiple files?

            //To improve code organization, separate responsibilities in large classes, and enable multiple developers to work on different parts of the same class simultaneously.

            //c) What is a Partial Method ?

            //    A Partial Method has its declaration in one part of a partial class and its optional implementation in another part.It must return void and is implicitly private.

            //d) What happens if a declared partial method has no implementation?

            //If a partial method is not implemented, the compiler completely removes the declaration and all calls to that method during compilation, resulting in no runtime performance cost.





            #endregion





            #endregion


            #region Part2

            #region main

            //        using System;

            //        namespace ShipmentSystem
            //{
            //    internal class Program
            //    {
            //        static void Main(string[] args)
            //        {
            //            DeliveryUtilities.PrintSystemTitle("Smart Delivery Management System");

            //            Console.WriteLine("Creating Shipments...");
            //            DeliveryUtilities.PrintSeparator();

            //            Shipment sh1 = new Shipment("SH001", "Standard", 3, new DeliveryAddress("Cairo"));
            //            Console.WriteLine("Standard Shipment Created");

            //            Shipment sh2 = new Shipment("SH002", "Express", 2, new DeliveryAddress("Cairo"));
            //            Console.WriteLine("Express Shipment Created");

            //            Shipment sh3 = new Shipment("SH003", "International", 8, new DeliveryAddress("Cairo"));
            //            Console.WriteLine("International Shipment Created\n");

            //            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}");

            //            DeliveryUtilities.PrintSystemTitle("Object Copying");
            //            Shipment assignedShipment = sh1;
            //            Console.WriteLine($"Original Shipment : {sh1.TrackingCode}");
            //            Console.WriteLine($"Assigned Shipment : {assignedShipment.TrackingCode}");
            //            Console.WriteLine($"Same Object : {ReferenceEquals(sh1, assignedShipment)}\n");

            //            DeliveryUtilities.PrintSeparator();
            //            Console.WriteLine("Shallow Copy");
            //            DeliveryUtilities.PrintSeparator();

            //            Shipment shallowCopied = sh1.ShallowCopy();
            //            Console.WriteLine($"Original Shipment Address : {sh1.Address.City}");
            //            Console.WriteLine($"Copied Shipment Address   : {shallowCopied.Address.City}\n");

            //            Console.WriteLine("Changing copied shipment address...\n");
            //            shallowCopied.Address.City = "Giza";

            //            Console.WriteLine($"Original Shipment Address : {sh1.Address.City}");
            //            Console.WriteLine($"Copied Shipment Address   : {shallowCopied.Address.City}");
            //            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(sh1.Address, shallowCopied.Address)}\n");

            //            sh1.Address.City = "Cairo";

            //            DeliveryUtilities.PrintSeparator();
            //            Console.WriteLine("Deep Copy");
            //            DeliveryUtilities.PrintSeparator();

            //            Shipment deepCopied = sh1.DeepCopy();
            //            Console.WriteLine($"Original Shipment Address : {sh1.Address.City}");
            //            Console.WriteLine($"Copied Shipment Address   : {deepCopied.Address.City}\n");

            //            Console.WriteLine("Changing copied shipment address...\n");
            //            deepCopied.Address.City = "Giza";

            //            Console.WriteLine($"Original Shipment Address : {sh1.Address.City}");
            //            Console.WriteLine($"Copied Shipment Address   : {deepCopied.Address.City}");
            //            Console.WriteLine($"Same DeliveryAddress Object : {ReferenceEquals(sh1.Address, deepCopied.Address)}\n");

            //            DeliveryUtilities.PrintSystemTitle("Extension Methods");
            //            Console.WriteLine(sh1.GetSummary());

            //            sh2.UpdateTrackingStatus("Out For Delivery");
            //            sh3.UpdateTrackingStatus("Delivered");

            //            Console.WriteLine(sh2.GetSummary());
            //            Console.WriteLine(sh3.GetSummary());
            //            Console.WriteLine();

            //            Console.WriteLine($"SH001 Is Delivered : {sh1.IsDelivered()}");
            //            Console.WriteLine($"SH003 Is Delivered : {sh3.IsDelivered()}\n");

            //            DeliveryUtilities.PrintSystemTitle("Tracking Status");
            //            sh1.UpdateTrackingStatus("Out For Delivery");
            //            Console.WriteLine();

            //            DeliveryUtilities.PrintSystemTitle("Static Utilities");
            //            Console.WriteLine("Delivery Center\n");
            //            Console.WriteLine($"Total Shipments Created : {Shipment.GetTotalShipmentsCreated()}\n");

            //            DeliveryUtilities.PrintSystemTitle("Partial Method");
            //            sh1.UpdateTrackingStatus("Delivered");
            //            Console.WriteLine();

            //            DeliveryUtilities.PrintSystemTitle("Assignment Completed");
            //        }
            //    }
            //}



            #endregion

            #region Shipment.Tracking.cs

            //        using System;

            //        namespace ShipmentSystem
            //{
            //    public partial class Shipment
            //    {
            //        public string TrackingStatus { get; private set; }

            //        partial void OnTrackingStatusChanged(string newStatus);

            //        public void UpdateTrackingStatus(string newStatus)
            //        {
            //            TrackingStatus = newStatus;
            //            OnTrackingStatusChanged(newStatus);
            //        }

            //        partial void OnTrackingStatusChanged(string newStatus)
            //        {
            //            Console.WriteLine($"Tracking status changed to: {newStatus}");
            //        }
            //    }
            //}



            #endregion

            #region Shipment.cs

            //            using System;

            //namespace ShipmentSystem
            //    {
            //        public partial class Shipment
            //        {
            //            private static int totalShipmentsCreated = 0;

            //            public string TrackingCode { get; set; }
            //            public string ShipmentType { get; set; }
            //            public double Weight { get; set; }
            //            public DeliveryAddress Address { get; set; }

            //            static Shipment()
            //            {
            //                Console.WriteLine("Shipment System Initialized");
            //            }

            //            public Shipment(string trackingCode, string shipmentType, double weight, DeliveryAddress address)
            //            {
            //                TrackingCode = trackingCode;
            //                ShipmentType = shipmentType;
            //                Weight = weight;
            //                Address = address;
            //                TrackingStatus = "In Transit";

            //                totalShipmentsCreated++;
            //            }

            //            public static int GetTotalShipmentsCreated()
            //            {
            //                return totalShipmentsCreated;
            //            }

            //            public Shipment CopyShipment()
            //            {
            //                return this;
            //            }

            //            public Shipment ShallowCopy()
            //            {
            //                return (Shipment)this.MemberwiseClone();
            //            }

            //            public Shipment DeepCopy()
            //            {
            //                Shipment copy = (Shipment)this.MemberwiseClone();
            //                copy.Address = this.Address.DeepCopy();
            //                return copy;
            //            }
            //        }
            //    }

            #endregion

            #region DeliveryUtilities.cs

            //            using System;

            //namespace ShipmentSystem
            //    {
            //        public static class DeliveryUtilities
            //        {
            //            public static void PrintSeparator()
            //            {
            //                Console.WriteLine("==================================================");
            //            }

            //            public static void PrintSystemTitle(string title)
            //            {
            //                PrintSeparator();
            //                Console.WriteLine(title);
            //                PrintSeparator();
            //            }
            //        }
            //    }
            #endregion

            #region ShipmentExtensions.cs

            //        namespace ShipmentSystem
            //{
            //    public static class ShipmentExtensions
            //    {
            //        public static string GetSummary(this Shipment shipment)
            //        {
            //            return $"{shipment.TrackingCode} | {shipment.ShipmentType} | {shipment.Weight} KG | {shipment.TrackingStatus}";
            //        }

            //        public static bool IsDelivered(this Shipment shipment)
            //        {
            //            return shipment.TrackingStatus == "Delivered";
            //        }
            //    }
            //}
            #endregion

            #region DeliveryAddress.cs

    //        namespace ShipmentSystem
    //{
    //    public class DeliveryAddress
    //    {
    //        public string City { get; set; }

    //        public DeliveryAddress(string city)
    //        {
    //            City = city;
    //        }

    //        public DeliveryAddress DeepCopy()
    //        {
    //            return new DeliveryAddress(this.City);
    //        }
    //    }
    //}

            #endregion




            #endregion



}
    }
}




