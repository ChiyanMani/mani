using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Addsample.Models;

namespace Addsample.Models
{
    public class bal
    {
        public string save(Class1 obj)
        {           
            dal d = new dal();
            return d.save(obj);            
        }
    }
}