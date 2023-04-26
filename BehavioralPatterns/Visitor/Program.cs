using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Visitor
{
    /// <summary>Element クラス </summary>
    public abstract class Shape
    {
        public abstract void accept(Visitor visitor);
    }
    /// <summary>concreteElementA クラス</summary>
    public class CircleShape : Shape
    {
        public double radius { get; }
        public CircleShape(double radius)
        {
            this.radius = radius;
        }
        public override void accept(Visitor visitor)
        {
            visitor.visit(this);
        }
    }

    /// <summary>concreteElementB クラス</summary>
    public class RectangleShape : Shape
    {
        public double w { get; }
        public double h { get; }
        public RectangleShape(double w, double h)
        {
            this.w = w;
            this.h = h;
        }
        public override void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

    }

    /// <summary>Visitor クラス</summary>

    public abstract class Visitor
    {
        public abstract void visit(CircleShape circle);
        public abstract void visit(RectangleShape B);
    }

    /// <summary>concreteVisitor1 クラス </summary>
    public class PerimeterVisitor : Visitor
    {
        public override void visit(CircleShape A)
        {
            var perimeter = 2 * A.radius * Math.PI;
            Console.WriteLine($"円の周囲は: {perimeter}");
        }
        public override void visit(RectangleShape B)
        {
            var perimeter = 2 * (B.w + B.h);
            Console.WriteLine($"長方形の周囲は: {perimeter}");
        }
    }

    /// <summary>concreteVisitor2 クラス </summary>

    public class AreaVisitor : Visitor
    {
        public override void visit(CircleShape A)
        {
            var area = Math.PI * A.radius * A.radius;
            Console.WriteLine($"円の面積は: {area}");

        }
        public override void visit(RectangleShape B)
        {
            var area = B.w * B.h;
            Console.WriteLine($"長方形の面積は: {area}");
        }
    }

    /// <summary> </summary>
    class Client
    {
        static void Main(string[] args)
        {
            //var perimeterVisitor = new PerimeterVisitor();
            //var circle = new CircleShape(10);
            //var rect = new RectangleShape(10,20);
            //circle.accept(perimeterVisitor);
            //rect.accept(perimeterVisitor);

            //var areaVisitor = new AreaVisitor();
            //circle.accept(areaVisitor);
            //rect.accept(areaVisitor);
            SettingFile.cmd();
        }
    }
}
