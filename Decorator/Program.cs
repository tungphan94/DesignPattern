using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace Decorator
{
    public abstract class Display
    {
        public abstract int getRows();
        public abstract int getColums();
        public abstract string getRowText(int row);
        public void show()
        {
            for (int i = 0; i < getRows(); i++)
            {
                var txt = getRowText(i);
                if(txt != null)
                    Console.WriteLine(txt);
            }
        }

        protected string makeLine(char ch, int count)
        {
            var result = "";
            for (int i = 0; i < count; i++)
            {
                result += ch;
            }
            return result;
        }
    }

    public class StringDisplay : Display
    {
        private string text;
        public StringDisplay(string text)
        {
            this.text = text;
        }

        public override int getRows()
        {
            return 1;
        }
        public override int getColums()
        {
            return text.Length;
        }

        public override string getRowText(int row)
        {
            return row != 0 ? null : text;
        }
    }

    public class MultiStringDisplay : Display
    {
        List<string> lstString = new List<string>();
        public MultiStringDisplay() { }

        public void add(string str)
        {
            lstString.Add(str);
        }
        public override int getRows()
        {
            return lstString.Count;
        }

        public override int getColums()
        {
            var list = lstString.OrderBy(x => x.Length);
            return list.Last().Length;
        }

        public override string getRowText(int row)
        {
            if (lstString.Count == 0) {
                return null;
            }
            else {
                var txt = lstString[row];
                var cols = getColums();
                if (cols == txt.Length){
                    return txt;
                } else{
                    return txt + makeLine(' ', cols - txt.Length);
                }
            };
        }
    }

    public abstract class Border : Display
    {
        protected Display display;
        protected Border(Display display)
        {
            this.display = display;
        }
    }

    public class SideBoder : Border
    {
        char c;
        public SideBoder(Display display, char c)
            : base(display)
        {
            this.display = display;
            this.c = c;
        }

        public override int getColums()
        {
            return 1 + display.getColums() + 1;
        }

        public override int getRows()
        {
            return display.getRows();
        }

        public override string getRowText(int row)
        {
            var txt = display.getRowText(row);
            return txt is null   ? null : c + txt + c;
        }


    }


    public class FullBoder : Border
    {
        public FullBoder(Display display)
            : base(display)
        {
            this.display = display;
        }

        public override int getColums()
        {
            return 1 + display.getColums() + 1;
        }

        public override int getRows()
        {
            return 1 + display.getRows() + 1;
        }

        public override string getRowText(int row)
        {
            if (row == 0 || row == display.getRows() + 1){
                return "+" + makeLine('-', display.getColums()) + "+";
            }else{
                var txt = display.getRowText(row - 1);
                return txt is null ? null: "|" + txt + "|";
            }
        }
    }

    public class UpDownBorder : Border
    {
        char c;
        public UpDownBorder(Display display, char c)
            : base(display)
        {
            this.display = display;
            this.c = c;
        }

        public override int getColums()
        {
            return display.getColums();
        }

        public override int getRows()
        {
            return 1 + display.getRows() + 1;
        }

        public override string getRowText(int row)
        {
            if (row == 0 || row == display.getRows() + 1) {
                return makeLine(c, display.getColums());
            }  else{
                var txt = display.getRowText(row - 1);
                return txt is null ? null :  txt ;
            }
        }
    }

    class Program
    {
        static void showPizza()
        {
            var tomatoPizza = new TomatoPizza();
            var chickenPizza = new ChickenPizza();
            tomatoPizza.show();
            chickenPizza.show();
            var cheeseTomatoPizza = new CheeseDecorator(tomatoPizza);
            var peppertomatoPizza = new PepperDecorator(tomatoPizza);
            cheeseTomatoPizza.show();
            peppertomatoPizza.show();
            var cheeseTwo = new CheeseDecorator(new PepperDecorator(new CheeseDecorator(tomatoPizza)));
            cheeseTwo.show();
        }

        static void showHelloWorld()
        {
            var text = "Hello World!";
            var a = new StringDisplay(text);
            var b = new SideBoder(a, '#');
            var c = new FullBoder(b);
            a.show();
            b.show();
            c.show();
            var d = new SideBoder(
                        new FullBoder(
                            new FullBoder(
                                new SideBoder(
                                    new FullBoder(new StringDisplay(text)),
                                '*')
                                )
                            ),
                        '/');
            d.show();

            var b1 = new UpDownBorder(a, '-');
            b1.show();

            var b2 = new FullBoder(
                        new UpDownBorder(
                            new SideBoder(
                                new UpDownBorder(
                                    new SideBoder(new StringDisplay(text), '*'),
                                  '='),
                            '|')
                        , '/')
                );
            b2.show();

            var md = new MultiStringDisplay();
            md.add("Hi!");
            md.add("Good morning.!");
            md.add("Good night.!");
            md.show();

            var side_md = new SideBoder(md, '#');
            side_md.show();

            var full_md = new FullBoder(side_md);
            full_md.show();
        }
        static void Main(string[] args)
        {
            showHelloWorld();
            showPizza();
        }
    }
}
