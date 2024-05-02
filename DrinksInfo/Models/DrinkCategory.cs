using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksInfo.Models;

public class DrinkCategory
{
    [JsonProperty("strCategory")]
    public string Name { get; set; }
}
