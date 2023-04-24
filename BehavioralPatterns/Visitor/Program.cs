using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace visitorExp
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
            double getPerimeter(double radius) => 2 * radius * Math.PI;
            Console.WriteLine($"円の周囲は: {getPerimeter(A.radius)}");
        }
        public override void visit(RectangleShape B)
        {
            double getPerimeter(double w, double h) => 2 * (w + h);
            Console.WriteLine($"長方形の周囲は: {getPerimeter(B.w, B.h)}");
        }
    }

    /// <summary>concreteVisitor2 クラス </summary>

    public class AreaVisitor : Visitor
    {
        public override void visit(CircleShape A)
        {
            double getArea(double radius) => Math.PI * radius * radius;
            Console.WriteLine($"円の面積は: {getArea(A.radius)}");

        }
        public override void visit(RectangleShape B)
        {
            double getArea(double w, double h) => w * h;
            Console.WriteLine($"長方形の面積は: {getArea(B.w, B.h)}");
        }
    }

    /// <summary> </summary>
    class Client
    {
        static void Main(string[] args)
        {
            var perimeterVisitor = new PerimeterVisitor();
            var circle = new CircleShape(10);
            var rect = new RectangleShape(10,20);
            circle.accept(perimeterVisitor);
            rect.accept(perimeterVisitor);

            var areaVisitor = new AreaVisitor();
            circle.accept(areaVisitor);
            rect.accept(areaVisitor);
        }
    }
}
