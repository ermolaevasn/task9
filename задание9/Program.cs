using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задание9
{
    class Point
{
    public int inf;
    public Point Next;
    public Point Prev;

    public Point()
    {
        inf = 0;
        Next = null;
        Prev = null;
    }
}
class Program
{
        static void Main(string[] args)
        {
            int N;
            Console.WriteLine("Ведите количество элементов N для двунаправленного списка");
            Vvod("количество элементов N = ", out N);
            Proverka("количество элементов N", ref N);
            //часть, которую нельзя удалять
            Point list = new Point();
            Point beg = new Point();
            Make(N, 1, ref list, beg);
            Write(list);
            Console.WriteLine();
            //конец части, которую нельзя удалять
            Random rnd = new Random();
            // удаление первого элемента
            Delete(1, ref list, beg);
            Write(list);
            Console.WriteLine();
            // удаление последнего элемента
            Delete(N, ref list, beg);
            Write(list);
            Console.WriteLine();
            // удаление среднего элемента
            Delete(rnd.Next(2, N), ref list, beg);
            Write(list);
            Console.WriteLine();
            Console.ReadLine();
        }
        static void Make(int N, int num, ref Point List, Point beg)
    {
        if (num == 1)
            beg = List;
        if (num < N)
        {
            beg.Next = new Point();
            beg.Next.Prev = beg;
        }
        if (num <= N)
        {
            beg.inf = num;
            beg = beg.Next;
            num++;
            Make(N, num, ref List, beg);
        }

    }
    static void Write(Point list)
    {
        Point beg = new Point();
        beg = list;
        while (beg != null)
        {
            Console.Write(beg.inf);
            if (beg.Next != null) Console.Write(" --> ");
            beg = beg.Next;
        }
    }
    static void Delete(int num, ref Point List, Point beg)
    {
        if (beg.inf == 0) beg = List;
        if (beg.inf == num)
        {
            if (beg.Prev == null)
                List = List.Next;
            if (beg.Next == null)
                beg.Prev.Next = null;
            if ((beg.Prev == null) && (beg.Next == null))
                beg = null;
            if ((beg.Prev != null) && (beg.Next != null))
            {
                beg.Prev.Next = beg.Next;
                beg.Next.Prev = beg.Prev;
            }
        }
        else if (beg.Next != null)
        {
            beg = beg.Next;
            Delete(num, ref List, beg);
        }
    }
    static double Vvod(string s, out int n)//ввод числа
    {
        bool ok;
        string buf;
        do
        {
            Console.Write(s + " = ");
            buf = Console.ReadLine();
            ok = Int32.TryParse(buf, out n);
            if (!ok) Console.WriteLine("Введите " + s + " заново");
        } while (!ok);
        return n;
    }
    static void Proverka(string s, ref int a)//проверка ввода на отрицательность
    {
        bool ok = false;
        string buf;
        do
        {
            if (a > 0) ok = true;
            else
            {
                if (!ok) Console.WriteLine("\aВведите " + s + " заново");
                Console.Write(s + " = ");
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out a);
                ok = false;
            }
        } while (!ok);
    }
    
}
}