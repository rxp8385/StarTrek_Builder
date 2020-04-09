using System;
using System.Collections.Generic;

namespace DesignPatterns.GangOfFour.Creational.Builder
{
    /// <summary>
    /// Builder Design Pattern.
    /// Definition: The Builder Pattern is used to separate 
    /// the construction of a complex object from its representation 
    /// so that the same construction process can create different representations.
    /// 
    /// </summary>
    public class Program
    {
        // <summary>
        /// Main program that uses the Builder Design Pattern
        /// To create different classes of Federation and NonFederation ships.
        /// 
        /// </summary>
        public static void Main()
        {
            // Create starTrekShipSimulator
            var starTrekShipSimulator = new StarTrekShipSimulator();

            // Construct and display ships
            starTrekShipSimulator.Construct(new FederationStarshipDefiant());
            starTrekShipSimulator.ShowShip();

            starTrekShipSimulator.Construct(new RomulanStarshipWarbird());
            starTrekShipSimulator.ShowShip();

            starTrekShipSimulator.Construct(new BorgStarshipCube());
            starTrekShipSimulator.ShowShip();

            // User input ends the program...
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Director' class
    /// </summary>
    class StarTrekShipSimulator
    {
        ShipBuilder shipBuilder;

        // Builder uses a complex series of steps to create items that are
        // shared among similar objects...
        public void Construct(ShipBuilder shipBuilder)
        {
            this.shipBuilder = shipBuilder;

            this.shipBuilder.BuildFrame();
            this.shipBuilder.BuildWarpDrive();
            this.shipBuilder.BuildShields();
            this.shipBuilder.BuildPhasers();
        }

        public void ShowShip()
        {
            shipBuilder.Ship.Show();
        }
    }

    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class ShipBuilder
    {
        public Ship Ship { get; private set; }

        // Constructor
        public ShipBuilder(ShipType shipType)
        {
            Ship = new Ship(shipType);
        }

        public abstract void BuildFrame();
        public abstract void BuildWarpDrive();
        public abstract void BuildShields();
        public abstract void BuildPhasers();
    }

    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class BorgStarshipCube : ShipBuilder
    {
        // Invoke base class constructor
        public BorgStarshipCube()
            : base(ShipType.Borg_Starship_Cube)
        {
        }

        public override void BuildFrame()
        {
            Ship[PartType.Frame] = "Borg_Starship_Cube Frame";
        }

        public override void BuildWarpDrive()
        {
            Ship[PartType.Warp_Drive] = "Warp 14";
        }

        public override void BuildShields()
        {
            Ship[PartType.Sheilds] = "100";
        }

        public override void BuildPhasers()
        {
            Ship[PartType.Phasers] = "100";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class RomulanStarshipWarbird : ShipBuilder
    {
        // Invoke base class constructor
        public RomulanStarshipWarbird()
            : base(ShipType.Romulan_Warbird)
        {
        }

        public override void BuildFrame()
        {
            Ship[PartType.Frame] = "Romulan_Warbird Frame";
        }

        public override void BuildWarpDrive()
        {
            Ship[PartType.Warp_Drive] = "Warp 9";
        }

        public override void BuildShields()
        {
            Ship[PartType.Sheilds] = "80";
        }

        public override void BuildPhasers()
        {
            Ship[PartType.Phasers] = "80";
        }
    }

    /// <summary>
    /// The 'ConcreteBuilder3' class
    /// </summary>
    class FederationStarshipDefiant : ShipBuilder
    {
        // Invoke base class constructor
        public FederationStarshipDefiant() : base(ShipType.Federation_Ship_Defiant)
        {
        }

        public override void BuildFrame()
        {
            Ship[PartType.Frame] = "Federation_Ship_Defiant Frame";
        }

        public override void BuildWarpDrive()
        {
            Ship[PartType.Warp_Drive] = "Warp 10";
        }

        public override void BuildShields()
        {
            Ship[PartType.Sheilds] = "88";
        }

        public override void BuildPhasers()
        {
            Ship[PartType.Phasers] = "82";
        }
    }

    /// <summary>
    /// The 'Product' class
    /// </summary>
    class Ship
    {
        ShipType shipType;
        Dictionary<PartType, string> parts = new Dictionary<PartType, string>();

        // Constructor
        public Ship(ShipType shipType)
        {
            this.shipType = shipType;
        }

        public string this[PartType key]
        {
            get { return parts[key]; }
            set { parts[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Ship Type:   {0}", shipType);
            Console.WriteLine(" Frame:      {0}",
                this[PartType.Frame]);
            Console.WriteLine(" Warp_Drive: {0}",
                this[PartType.Warp_Drive]);
            Console.WriteLine(" Sheilds:    {0}",
                this[PartType.Sheilds]);
            Console.WriteLine(" Phasers:    {0}",
                this[PartType.Phasers]);
        }
    }

    /// <summary>
    /// Part type enumeration
    /// </summary>
    public enum PartType
    {
        Frame,
        Warp_Drive,
        Sheilds,
        Phasers
    }

    /// <summary>
    /// Ship type enumeration
    /// </summary>
    public enum ShipType
    {
        Romulan_Warbird,
        Federation_Ship_Defiant,
        Borg_Starship_Cube
    }

}
