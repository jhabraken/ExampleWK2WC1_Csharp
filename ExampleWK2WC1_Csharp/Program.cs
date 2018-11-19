using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWK2WC1_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                db.Blogs.Add(new Blog { Url = "http://www.bt.com" });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                Console.WriteLine("All blogs in database:");
                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(" - {0}", blog.Url);
                }

                //Examples of LINQ queries.
                Console.WriteLine();
                var blogExample = db.Blogs.Single(b => b.BlogId == 1);
                Console.WriteLine("Example URL of Blog with id = {0} from blog table in database using a LINQ query: {1}", blogExample.BlogId,blogExample.Url);

                Console.WriteLine();
                //Another example of LINQ query that returns a List with Blogs
                var blogList = db.Blogs
                .Where(b => b.Url.Contains("BT"))
                .ToList();
                foreach (Blog b in blogList)
                {
                    Console.WriteLine("Example URL of Blog with id = {0} from blog table in database using a LINQ query: {1}",b.BlogId,b.Url);
                }
                

            }
            Console.ReadLine();


        }
    }
}
