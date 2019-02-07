using System.Collections.Generic;
using System.Xml.Serialization;

namespace FurnitureStore.Models
{
    [XmlRoot("FurnitureItemsList")]
    public class FurnitureItemsList
    {
        [XmlElement("Furniture")]
        public List<FurnitureItem> FurnitureItems { get; set; }
    }
}
