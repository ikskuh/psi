using System;
using System.Xml.Serialization;
namespace midend
{
	[XmlRoot("configuration")]
	public sealed class CompilerConfiguration
	{
		[XmlElement("integer-width")]
		public int IntegerWidth { get; set; } = 32;
	}
}
