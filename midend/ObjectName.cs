using System.Linq;
namespace midend
{
	using System;
	using System.Xml.Serialization;
	
	public struct ObjectName 
	{
		public ObjectName(params string[] path)
		{
			this.Path = path.ToArray();
		}
	
		[XmlElement("string")]
		public string[] Path { get; set; }
		
		public override string ToString() => string.Join(".", this.Path);
	}
}