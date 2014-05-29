using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

//http://azerdark.wordpress.com/2010/04/01/simple-example-of-nhibernate-and-sql-server-2008/
//http://www.google.pl/search?client=opera&rls=pl&q=nhibernate&sourceid=opera&ie=utf-8&oe=utf-8&channel=suggest#sclient=psy-ab&hl=pl&client=opera&rls=pl&channel=suggest&q=nhibernate+tutorial+c%23&oq=nhibernate+tutor&aq=1&aqi=g2&aql=&gs_l=serp.3.1.0l2.9521.12996.0.14411.7.3.1.3.4.0.219.495.0j2j1.3.0...0.0.jrn7t-r2B-k&pbx=1&bav=on.2,or.r_gc.r_pw.,cf.osb&fp=1179042883144699&biw=808&bih=643

namespace _3._11._4
{
    
    
    class Program
    {
        static void Main(string[] args)
        {
            string username = "sa";
            string pass = "pass";

            ISession session = NHibernateHelper.GetCurrentSession();
            IQuery query = session.CreateQuery("FROM STUDENCI WHERE username = :name  AND pass = :pass ");
            query.SetString("name", username);
            query.SetString("pass", pass);
            IList<Account> acc = query.List<Account>();
            session.Close();
            if (acc.Count == 0)
                Console.WriteLine("Cannot find specified user");
            else
                Console.WriteLine("Found " + acc[0].Nazwisko);

            Console.ReadKey();
        }
    }
}
