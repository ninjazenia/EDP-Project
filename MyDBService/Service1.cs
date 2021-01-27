using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyDBService.Entity;
namespace MyDBService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public List<Attractions> SelectAttractionsAll()
        {
            Attractions emp = new Attractions();
            return emp.GetAttractionsAll();
        }
        public Attractions SelectAttractions(string ID)
        {
            Attractions emp = new Attractions();
            return emp.GetAttractions(ID);
        }
        public int CreateAttractions(string ID, string Name, string Desc,
                       decimal unitPrice, string Image)
        {
            Attractions emp = new Attractions(ID, Name, Desc, unitPrice, Image);
            return emp.Insert();
        }

    }
}
