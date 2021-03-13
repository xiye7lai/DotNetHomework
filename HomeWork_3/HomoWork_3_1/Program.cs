using System;

namespace HomoWork_3_1
{
    public abstract class Shape
    {
        public abstract double Area();
        public abstract bool IsLegal();
    }
    public class Recangle : Shape
    {
        private double _length;
        private double _width;

        public Recangle(double length,double width)
        {
            this.Length = length;
            this.Width = width;
        }

        public override double Area()
        {
            return this.Length * this.Width;
        }

        public override bool IsLegal()
        {
            if (this.Length > 0 && this.Width > 0)
            {
                return true;
            }
            return false;
        }
        public double Length
        {
            get => _length;
            set => _length = value;
        }
        public double Width
        {
            get => _width;
            set => _width = value;
        }
    }
    public class Square : Recangle
    {
        private double _edge;
        public Square(double edge) : base(edge,edge){
            this.Edge = edge;
        }

        public double Edge
        {
            get => _edge;
            set => _edge = value;
        }
    }
    public class Delta : Shape
    {
        private double _edge1;
        private double _edge2;
        private double _edge3;

        public Delta(double edge1, double edge2, double edge3)
        {
            Edge1 = edge1;
            Edge2 = edge2;
            Edge3 = edge3;
        }

        public override double Area()
        {
            double temp = (Edge1 + Edge2 + Edge3) / 2;
            return Math.Sqrt(temp * (temp - Edge1) * (temp - Edge2) * (temp - Edge3));
        }

        public override bool IsLegal()
        {
            if (Edge1 > 0 && Edge2 > 0 && Edge3 > 0)
                return Edge1 + Edge2 > Edge3 && Edge1 + Edge3 > Edge2 && Edge2 + Edge3 > Edge1;
            return false;
        }
        public double Edge1
        {
            get => _edge1;
            set => _edge1 = value;
        }
        public double Edge2
        {
            get => _edge2;
            set => _edge2 = value;
        }
        public double Edge3
        {
            get => _edge3;
            set => _edge3 = value;
        }
    }

    public class ShapeTest {
        static void Main(string[] args)
        {
            //创立对象后先判断是否合法，在输出相关信息
            Recangle rec = new Recangle(10, 20);
            if (rec.IsLegal()) Console.WriteLine($"矩形合法\n矩形长为：{rec.Length}宽为{rec.Width},面积为{rec.Area()}");
            Square squ = new Square(15);
            if (squ.IsLegal()) Console.WriteLine($"正方形合法\n正方形边长为：{squ.Edge},面积为{squ.Area()}");
            Delta del = new Delta(30,40,50);
            if (del.IsLegal()) Console.WriteLine($"三角形合法\n三角形边长为：{del.Edge1},{del.Edge2},{del.Edge3},面积为{del.Area()}");
        }
    }

}
