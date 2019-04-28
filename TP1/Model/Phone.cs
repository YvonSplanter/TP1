using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP1.Model
{
    public class Phone
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public Phone() {
            this.ID="";
            this.Name = "";
            this.Price = 0;
            this.Image = null;
            this.Description = null;
        }
        public Phone(string id,string name,float price,string image,string description) {
            this.ID = id;
            this.Name = name;
            this.Price = price;
            this.Image = image;
            this.Description = description;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
