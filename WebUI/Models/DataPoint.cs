using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Entity;

namespace WebUI.Models
{
    [DataContract]
    public class DataPoint
    {
      	public DataPoint(string label, double y)
		{
			this.Label = label;
			this.Y = y;
		}
        
       	[DataMember(Name = "label")]
		public string Label = "";
 
		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public Nullable<double> Y = null;
    }
}