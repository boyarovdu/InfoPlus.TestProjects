using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Services;
using System.Web.Services;

namespace _001_TestProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    [ScriptService]
    [ServiceKnownType(typeof(IEnumerable<Person>))]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    [ServiceContract]
    public class Service
    {
        [OperationContract]
        public IEnumerable<Person> GetData()
        {
            return new List<Person> {
                new Person{ Name = "Alex", Address="Kiev"},
                new Person{ Name = "Tom",  Address="London"},
                new Person{ Name = "Alex", Address="Kiev"},
                new Person{ Name = "Tom",  Address="London"}
            };
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
