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
        private double radius;
        public CircleShape(double radius)
        {
            this.radius = radius;
        }
        public override void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public double getPerimeter() => 2 * radius * Math.PI;
        public double getArea() => Math.PI * radius * radius;
   
    }

    /// <summary>concreteElementB クラス</summary>
    public class RectangleShape : Shape
    {
        private double w;
        private double h;
        public RectangleShape(double w, double h)
        {
            this.w = w;
            this.h = h;
        }
        public override void accept(Visitor visitor)
        {
            visitor.visit(this);
        }

        public double getPerimeter() => 2 * (w + h);
        public double getArea() => w * h;
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
            Console.WriteLine($"円の周囲は: {A.getPerimeter()}");
        }
        public override void visit(RectangleShape B)
        {
            Console.WriteLine($"長方形の周囲は: {B.getPerimeter()}");
        }
    }

    /// <summary>concreteVisitor2 クラス </summary>

    public class AreaVisitor : Visitor
    {
        public override void visit(CircleShape A)
        {
            Console.WriteLine($"円の面積は: {A.getArea()}");

        }
        public override void visit(RectangleShape B)
        {
            Console.WriteLine($"長方形の面積は: {B.getArea()}");
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
